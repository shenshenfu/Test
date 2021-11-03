using AxFXControlLib;
using FXControlLib;
using Othros;
using System;
using System.Windows.Forms;

namespace FXPCaller
{
    public partial class FXpCaller : Form
    {
        AxFXControlLib.AxFXControl _ctrl = null;
        WorkspaceFile _curSpace = null;
        MethodFile _curMethod = null;
        string _methodFile = null;

        string _defaultSpacename = @"C:\Users\Public\Documents\Biomek\BiomekFXP.bif";

        IPasswordCallback _login = null;

        public FXpCaller()
        {
            InitializeComponent();

            // create FXControl.
            _ctrl = new AxFXControlLib.AxFXControl();
            this.ctrlBox.Controls.Add(_ctrl);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _login = new LoginCallback();
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            _curMethod.Open(_methodFile);
            OverrideVariable();
            //CheckSteps();

            if (!rbSimulation.Checked)
            {
                _ctrl.Run();
                //_ctrl.WaitForMethod();
            }
            else
            {
                _ctrl.StartSimulation();
                //_ctrl.WaitForSimulation();
            }
        }

        /// <summary>
        /// 对变量赋值.
        /// </summary>
        private void OverrideVariable()
        {
            // read and override variable.
            var variables = _curMethod.GetVariables();
            var dics = variables as IVariantDictionary;
            int cnt = dics.Count;
            for (int i = 0; i < cnt; i++)
            {

                string key = dics.Keys[i];
                string value = dics.Values[i].ToString();
                AppendLog($"Variable[i]: Key={key}, Value={value}");
            }

            //_curMethod.OverrideVariable(dics.Keys[0], "P1");
            //_curMethod.OverrideVariable(dics.Keys[1], "P10");
            //_curMethod.OverrideVariable(dics.Keys[2], 10);

            variables = _curMethod.GetVariables();
            dics = variables as IVariantDictionary;
            cnt = dics.Count;
            for (int i = 0; i < cnt; i++)
            {
                string key = dics.Keys[i];
                string value = dics.Values[i].ToString();
                AppendLog($"Variable[i]: Key={key}, Value={value}");
            }
        }

        private void CheckSteps()
        {
            AppendLog($"Current Method RootStep is {_curMethod.RootStep.IStep.ToString()}, SubStepCnt = {_curMethod.RootStep.SubstepCount}");
            int cnt = _curMethod.RootStep.SubstepCount;
            for (int i = 0; i < cnt; i++)
            {
                AppendLog($"Current SubStep is {_curMethod.RootStep}");
            }
        }

        private void btnInitialize_Click(object sender, EventArgs e)
        {
            try
            {
                _defaultSpacename = string.IsNullOrEmpty(txtWorkspace.Text) ? _defaultSpacename : txtWorkspace.Text;
                //_methodFile = "demo1025.1";

                _ctrl.OnError += OnCustomErrorHappened;
                _ctrl.OnIsError += ShowDialogOnIsErrorState;
                _ctrl.OnDialog += OnDialogRequest;
                _ctrl.OnExecute += OnMethodStart;
                _ctrl.OnExecutionCompleted += OnMethodFinish;
                _ctrl.OnPause += OnMethodPaused;
                _ctrl.OnResume += OnMethodResumed;
                _ctrl.OnAbort += OnMethodAborted;
                _ctrl.OnSimulationCompleted += OnMethodSimualtionCompleted;
                _ctrl.AbortOnUnhandledError = false;
                //_ctrl.AbortOnUnhandledError = true;  //true: set to abort when error happened.
                _ctrl.AllowContinuations = true;

                _curSpace = _ctrl.CurrentWorkspace;
                _curSpace.OnOpened += OnSpaceOpened;
                _curSpace.OnClosed += OnSpaceClosed;
                _curSpace.Open(_defaultSpacename);

                _curMethod = _ctrl.CurrentMethod;
                _curMethod.OnProvidePassword += OnProvideMethodUserAndPsd;
                _curMethod.OnOpened += OnMethodOpened;
                _curMethod.OnClosed += OnMethodClosed;

                txtWorkspace.Text = _curSpace.MRUWorkspaceName;
                UpdateMethodCombox(_curSpace.MethodFiles);
            }
            catch (Exception ex)
            {
                AppendLog($"Exception Occured when Initializing, {ex.Message} : {ex.StackTrace}");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            try
            {
                //todo: check running state.
                _curSpace.Close();
                _curMethod.Close();
                _ctrl.ShutDown();

                _ctrl.OnError -= OnCustomErrorHappened;
                _ctrl.OnIsError -= ShowDialogOnIsErrorState;
                _ctrl.OnDialog -= OnDialogRequest;
                _ctrl.OnExecute -= OnMethodStart;
                _ctrl.OnExecutionCompleted -= OnMethodFinish;
                _ctrl.OnPause -= OnMethodPaused;
                _ctrl.OnResume -= OnMethodResumed;
                _ctrl.OnAbort -= OnMethodAborted;
                _ctrl.OnSimulationCompleted -= OnMethodSimualtionCompleted;

                _curSpace.OnOpened -= OnSpaceOpened;
                _curSpace.OnClosed -= OnSpaceClosed;

                _curMethod.OnProvidePassword -= OnProvideMethodUserAndPsd;
                _curMethod.OnOpened -= OnMethodOpened;
                _curMethod.OnClosed -= OnMethodClosed;
            }
            catch (Exception ex)
            {
                AppendLog($"Close FXControl Failed. Exception = {ex.Message}: {ex.StackTrace}");
            }
        }

        private void UpdateMethodCombox(MethodFiles methods)
        {
            cmbMethods.Items.Clear();
            foreach (var method in methods)
            {
                cmbMethods.Items.Add(method);
            }
            cmbMethods.SelectedIndex = methods.Count > 0 ? 0 : -1;
        }

        private void cmbMethods_SelectedIndexChanged(object sender, EventArgs e)
        {
            _methodFile = cmbMethods.SelectedItem.ToString();
        }

        #region fxp event handler
        private void OnCustomErrorHappened(object sender, IFXControlEvents_OnErrorEvent e)
        {
            //todo: show errror.
            var errordialog = e.error;
            string options = "Options: ";
            foreach (var option in errordialog.Options)
            {
                options += $"{option.ToString()},";
            }
            options.Trim(',');
            AppendLog(options);

            errordialog.Display();
            //errordialog.Respond(errordialog.Options[0]);
            AppendLog($"Custom Error Happened: {e.error.Text}");
        }

        private void ShowDialogOnIsErrorState(object sender, IFXControlEvents_OnIsErrorEvent e)
        {
            AppendLog($"Dialog on is Error: {e.message.RepresentsError}");
        }

        private void OnDialogRequest(object sender, IFXControlEvents_OnDialogEvent e)
        {
            var dialog = e.dialog;
            string options = "Options: ";
            foreach (var option in dialog.Options)
            {
                options += $"{option.ToString()},";
            }
            options.Trim(',');
            AppendLog(options);

            dialog.Respond("OK");
            dialog.Respond("Abort");
            dialog.RespondWithInput("Abort", "OK");
            //dialog.Display();
            AppendLog($"Dialog on is Error: {e.dialog.Text}");
        }

        private void OnSpaceOpened(string filename)
        {
            AppendLog($"Space Opened, Space File Name = {filename}.");
        }

        private void OnSpaceClosed()
        {
            AppendLog($"Space Closed.");
        }

        private void OnProvideMethodUserAndPsd(IPasswordCallback callback)
        {
            callback = _login;
        }

        private void OnMethodOpened(string filename)
        {
            AppendLog($"Method Opened, Space File Name = {filename}.");
        }

        private void OnMethodClosed()
        {
            AppendLog($"Method Closed.");
        }

        private void OnMethodStart(object sender, EventArgs e)
        {
            AppendLog($"Start Execute Method.");
        }

        private void OnMethodPaused(object sender, EventArgs e)
        {
            AppendLog($"Method Paused.");
        }

        private void OnMethodResumed(object sender, EventArgs e)
        {
            AppendLog($"Method Resumed.");
        }

        private void OnMethodAborted(object sender, EventArgs e)
        {
            AppendLog($"Method Aborted.");
        }

        private void OnMethodSimualtionCompleted(object sender, IFXControlEvents_OnSimulationCompletedEvent e)
        {
            AppendLog($"Simulation Completed, Succ = {e.success}, Message = {e.message}, Timespan = {_ctrl.ETC}.");
        }

        private void OnMethodFinish(object sender, IFXControlEvents_OnExecutionCompletedEvent e)
        {
            AppendLog($"Finish Execute Method, Succ = {e.success}, Message = {e.message}.");
            // simulation.
            AppendLog($"Method Execute timespan = {_ctrl.ETC}s");
        }
        #endregion

        private void AppendLog(string message)
        {
            //_logBuilder.AppendLine(message); 
            rtxtLog.AppendText($"{DateTime.Now:yyyy:MM:dd hh:mm:ss:fff}: {message}\r\n");
        }

    }
}
