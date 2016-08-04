namespace AsteriskManager.Manager.Event
{
    class OriginateResponseEvent : EventManager
    {
        public bool Response { get; private set; }
        public string Channel { get; private set; }
        public string Context { get; private set; }
        public string Exten { get; private set; }
        public string Reason { get; private set; }
        public string Uniqueid { get; private set; }
        public string CallerIDNum { get; private set; }
        public string CallerIDName { get; private set; }

        public OriginateResponseEvent(string message)
        {
            if (Helper.GetParameterValue(message, "Response: ").Equals("Failure"))
                Response = false;
            else
                Response = true;
            Channel = Helper.GetParameterValue(message, "Channel: ");
            Context = Helper.GetParameterValue(message, "Context: ");
            Exten = Helper.GetParameterValue(message, "Exten: ");
            Reason = Helper.GetParameterValue(message, "Reason: ");
            Uniqueid = Helper.GetParameterValue(message, "Uniqueid: ");
            CallerIDNum = Helper.GetParameterValue(message, "CallerIDNum: ");
            CallerIDName = Helper.GetParameterValue(message, "CallerIDName: ");
            RaiseOriginateResponseEvent(this);
        }
    }
}
