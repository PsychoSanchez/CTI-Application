namespace AsteriskManager.Manager.Event
{
    class HangupEvent : EventManager
    {
        public string Channel { get; private set; }
        public string Cause { get; private set; }
        public string Uniqueid { get; private set; }
        public string CallerIDNum { get; private set; }
        public string CallerIDName { get; private set; }
        public string ConnectedLineNum { get; private set; }
        public string ConnectedLineName { get; private set; }

        public HangupEvent(string message)
        {
            Channel = Helper.GetParameterValue(message, "Channel: ");
            ConnectedLineNum = Helper.GetParameterValue(message, "ConnectedLineNum: ");
            ConnectedLineName = Helper.GetParameterValue(message, "ConnectedLineName: ");
            Cause = Helper.GetParameterValue(message, "Cause: ");
            Uniqueid = Helper.GetParameterValue(message, "Uniqueid: ");
            CallerIDNum = Helper.GetParameterValue(message, "CallerIDNum: ");
            CallerIDName = Helper.GetParameterValue(message, "CallerIDName: ");
            RaiseHangupEvent(this);
        }
    }
}
