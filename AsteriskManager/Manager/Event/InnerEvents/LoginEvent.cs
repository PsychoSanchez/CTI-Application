using System.Threading;

namespace AsteriskManager.Manager.Event
{
    class LoginEvent : EventManager
    {
        public static readonly AutoResetEvent LoginComplete = new AutoResetEvent(false);

        public override string ActionID
        {
            get;
            set;
        }
        public bool IsConnected { get; }
        public string Version { get; }
        public LoginEvent ()
        {
            LoginComplete.Set();
        }
        public LoginEvent(string message)
        {
            ActionID = Helper.GetParameterValue(message, "ActionID: ");
            if (string.IsNullOrEmpty(ActionID))
            {
                IsConnected = false;
            }
            else
            {
                IsConnected = true;
                Version= Helper.GetParameterValue(message, "Asterisk Call Manager/");
                AMIManager.ActionIdMessages.Add(ActionID, this);
                LoginComplete.Set();
            }
            
        }


    }
}
