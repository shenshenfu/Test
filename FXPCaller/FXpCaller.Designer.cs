namespace FXPCaller
{
    partial class FXpCaller
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.txtWorkspace = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.ctrlBox = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rtxtLog = new System.Windows.Forms.RichTextBox();
            this.btnInitialize = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbMethods = new System.Windows.Forms.ComboBox();
            this.rbSimulation = new System.Windows.Forms.CheckBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "Workspace";
            // 
            // txtWorkspace
            // 
            this.txtWorkspace.Location = new System.Drawing.Point(35, 50);
            this.txtWorkspace.Name = "txtWorkspace";
            this.txtWorkspace.Size = new System.Drawing.Size(301, 21);
            this.txtWorkspace.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnClose);
            this.groupBox1.Controls.Add(this.rbSimulation);
            this.groupBox1.Controls.Add(this.cmbMethods);
            this.groupBox1.Controls.Add(this.btnInitialize);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(500, 112);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Operation";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(418, 81);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Run";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // ctrlBox
            // 
            this.ctrlBox.Location = new System.Drawing.Point(13, 357);
            this.ctrlBox.Name = "ctrlBox";
            this.ctrlBox.Size = new System.Drawing.Size(500, 47);
            this.ctrlBox.TabIndex = 3;
            this.ctrlBox.TabStop = false;
            this.ctrlBox.Text = "Ctrl";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rtxtLog);
            this.groupBox2.Location = new System.Drawing.Point(13, 131);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(500, 220);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Log";
            // 
            // rtxtLog
            // 
            this.rtxtLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtxtLog.Location = new System.Drawing.Point(3, 17);
            this.rtxtLog.Name = "rtxtLog";
            this.rtxtLog.Size = new System.Drawing.Size(494, 200);
            this.rtxtLog.TabIndex = 0;
            this.rtxtLog.Text = "";
            // 
            // btnInitialize
            // 
            this.btnInitialize.Location = new System.Drawing.Point(332, 37);
            this.btnInitialize.Name = "btnInitialize";
            this.btnInitialize.Size = new System.Drawing.Size(75, 23);
            this.btnInitialize.TabIndex = 0;
            this.btnInitialize.Text = "Initialize";
            this.btnInitialize.UseVisualStyleBackColor = true;
            this.btnInitialize.Click += new System.EventHandler(this.btnInitialize_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "Methods";
            // 
            // cmbMethods
            // 
            this.cmbMethods.FormattingEnabled = true;
            this.cmbMethods.Location = new System.Drawing.Point(22, 81);
            this.cmbMethods.Name = "cmbMethods";
            this.cmbMethods.Size = new System.Drawing.Size(301, 20);
            this.cmbMethods.TabIndex = 6;
            this.cmbMethods.SelectedIndexChanged += new System.EventHandler(this.cmbMethods_SelectedIndexChanged);
            // 
            // rbSimulation
            // 
            this.rbSimulation.AutoSize = true;
            this.rbSimulation.Location = new System.Drawing.Point(332, 84);
            this.rbSimulation.Name = "rbSimulation";
            this.rbSimulation.Size = new System.Drawing.Size(84, 16);
            this.rbSimulation.TabIndex = 7;
            this.rbSimulation.Text = "Simulation";
            this.rbSimulation.UseVisualStyleBackColor = true;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(418, 37);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 8;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(518, 416);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.ctrlBox);
            this.Controls.Add(this.txtWorkspace);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtWorkspace;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox ctrlBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RichTextBox rtxtLog;
        private System.Windows.Forms.Button btnInitialize;
        private System.Windows.Forms.ComboBox cmbMethods;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox rbSimulation;
        private System.Windows.Forms.Button btnClose;
    }
}

