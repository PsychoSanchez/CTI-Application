using System.Threading;

namespace AsteriskManager.Manager.Event
{
    class StatusEvent : EventManager
    {
        public static readonly AutoResetEvent StatusComplete = new AutoResetEvent(false);
        public string Channel { get; set; }
        public string Context { get; set; }
        public string State { get; set; }
        public string Extension { get; set; }
        public string Link { get; set; }
        public string Uniqueid { get; set; }
        public override string ActionID { get; set; }

        public StatusEvent(string message)
        {
            new NewstateEvent(message);

            ActionID = Helper.GetParameterValue(message, "ActionID: ");
            Channel = Helper.GetParameterValue(message, "Channel: ");
            Context = Helper.GetParameterValue(message, "Context: ");
            State = Helper.GetParameterValue(message, "State: ");
            Link = Helper.GetParameterValue(message, "Link: ");
            Extension = Helper.GetParameterValue(message, "Extension: ");
            Uniqueid = Helper.GetParameterValue(message, "Uniqueid: ");
            AMIManager.ActionIdMessages.Add(ActionID, this);
            StatusComplete.Set();
        }
    }
}
