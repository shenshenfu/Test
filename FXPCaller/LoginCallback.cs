using FXControlLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FXPCaller
{
    internal class LoginCallback : IPasswordCallback
    {
        public void SubmitPassword(string sPassword)
        {
            throw new NotImplementedException();
        }

        public void SubmitUserPassword(string sUser, string sPassword)
        {
            throw new NotImplementedException();
        }

        public void ShowLogonDialog(out bool pVal)
        {
            throw new NotImplementedException();
        }

        string _user = "wilson";
        public string User
        {
            get { return _user; }
            set { _user = value; }
        }
    }
}
