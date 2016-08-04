namespace AsteriskManager.Manager.Event
{
    class ParkedCallEvent : EventManager
    {
        public ParkedCallsData parkedcall = new ParkedCallsData();

        public ParkedCallEvent(string message)
        {
            parkedcall.Channel = Helper.GetParameterValue(message, "Channel: ");
            parkedcall.CallerIDNum = Helper.GetParameterValue(message, "CallerIDNum: ");
            parkedcall.CallerIDName = Helper.GetParameterValue(message, "CallerIDName: ");
            parkedcall.Exten = Helper.GetParameterValue(message, "Exten: ");
            parkedcall.Timeout = Helper.GetParameterValue(message, "Timeout: ");
            RaiseParkedCallEvent(this);
        }
    }
}
