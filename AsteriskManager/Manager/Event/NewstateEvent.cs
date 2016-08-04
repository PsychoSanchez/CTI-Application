namespace AsteriskManager.Manager.Event
{
    class NewstateEvent : EventManager
    {
        public string Channel { get; set; }
        public string ChannelState { get; set; }
        public string ChannelStateDesc { get; set; }
        public string CallerIDNum { get; set; }
        public string CallerIDName { get; set; }
        public string Context { get; set; }
        public string ConnectedLineNum { get; set; }
        public string ConnectedLineName { get; set; }

        public NewstateEvent(string message)
        {
            Channel = Helper.GetParameterValue(message, "Channel: ");
            CallerIDNum = Helper.GetParameterValue(message, "CallerIDNum: ");
            CallerIDName = Helper.GetParameterValue(message, "CallerIDName: ");
            ChannelState = Helper.GetParameterValue(message, "ChannelState: ");
            ChannelStateDesc = Helper.GetParameterValue(message, "ChannelStateDesc: ");
            Context = Helper.GetParameterValue(message, "Context: ");
            ConnectedLineNum = Helper.GetParameterValue(message, "ConnectedLineNum: ");
            ConnectedLineName = Helper.GetParameterValue(message, "ConnectedLineName: ");
            RaiseNewstateEvent(this);
        }
    }
}
