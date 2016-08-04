using System.Threading;

namespace AsteriskManager.Manager.Event
{
    class SIPShowPeerEvent : EventManager
    {
        public static readonly AutoResetEvent SipShowPeerComplete = new AutoResetEvent(false);

        public string Channeltype { get; }
        public string ObjectName { get; }
        public string Context { get; }
        public string VoiceMailbox { get; }
        public string Callerid { get; }
        public string AddressIP { get; }
        public string AddressPort { get; }
        public string Status { get; }

        public override string ActionID
        {
            get; set;
        }
        public SIPShowPeerEvent()
        {
            SipShowPeerComplete.Set();
        }
        public SIPShowPeerEvent(string Message)
        {
            Channeltype = Helper.GetParameterValue(Message, "Channeltype: ");
            ObjectName = Helper.GetParameterValue(Message, "ObjectName: ");
            Context = Helper.GetParameterValue(Message, "Context: ");
            VoiceMailbox = Helper.GetParameterValue(Message, "VoiceMailbox: ");
            Callerid = Helper.GetParameterValue(Message, "Callerid: ");
            AddressIP = Helper.GetParameterValue(Message, "Address-IP: ");
            AddressPort = Helper.GetParameterValue(Message, "Address-Port: ");
            Status = Helper.GetParameterValue(Message, "Status: ");
            ActionID = Helper.GetParameterValue(Message, "ActionID: ");
            if (!string.IsNullOrEmpty(ActionID))
            {
                AMIManager.ActionIdMessages.Add(ActionID, this);
                SipShowPeerComplete.Set();
                //Someone waiting 
            }
        }

    }
}

