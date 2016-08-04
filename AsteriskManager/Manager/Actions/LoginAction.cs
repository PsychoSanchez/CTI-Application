using System.Text;

namespace AsteriskManager.Manager.Actions
{
    public class LoginAction : ActionManager
    {
        public string _UserName { get; set; }
        public string _PassWord { get; set; }
        public string _AuthType { get; set; }
        public string _Key { get; set; }
        public string _Events { get; set; }

        public LoginAction()
        {
        }
        public LoginAction(string username, string pwd)
        {
            _UserName = username;
            _PassWord = pwd;
            _AuthType = string.Empty;
            _Key = string.Empty;
            _Events = string.Empty;
        }
        public LoginAction(string username, string AuthType, string events)
        {
            _UserName = username;
            _AuthType = AuthType;
            _Key = string.Empty;
            _PassWord = string.Empty;
            _Events = events;

        }
        public LoginAction(string username, string AuthType, string key, string events)
        {
            _UserName = username;
            _AuthType = AuthType;
            _Key = key;
            _Events = events;
            _PassWord = string.Empty;

        }

        public override string Action
        {
            get
            {
                return "Login";
            }
        }
        public override string Parameters
        {
            get
            {
                StringBuilder sb = new StringBuilder();

                if (!string.IsNullOrEmpty(_UserName))
                    sb.Append(string.Concat("UserName: ", _UserName, Helper.LINE_SEPARATOR));
                if (!string.IsNullOrEmpty(_PassWord))
                    sb.Append(string.Concat("Secret: ", _PassWord, Helper.LINE_SEPARATOR));
                if (!string.IsNullOrEmpty(_AuthType))
                    sb.Append(string.Concat("AuthType: ", _AuthType, Helper.LINE_SEPARATOR));
                if (!string.IsNullOrEmpty(_Key))
                    sb.Append(string.Concat("Key: ", _Key, Helper.LINE_SEPARATOR));          
                if (!string.IsNullOrEmpty(_Events))
                    sb.Append(string.Concat("Events: ", _Events, Helper.LINE_SEPARATOR));
                return sb.ToString();
            }
        }
    }
}
