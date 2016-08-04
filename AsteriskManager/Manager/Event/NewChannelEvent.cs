namespace AsteriskManager.Manager.Event
{
    class NewChannelEvent : EventManager
    {
        public ChannelData Channel = new ChannelData();
        public NewChannelEvent(ChannelData _channel)
        {
            Channel = _channel;
            RaiseNewchannelEvent(this);
        }
        public NewChannelEvent(string message)
        {
            Channel.ChannelID = Helper.GetParameterValue(message, "Channel: ");
            Channel.Uniqueid = Helper.GetParameterValue(message, "Uniqueid: ");
            Channel.CallerIDNum = Helper.GetParameterValue(message, "CallerIDNum: ");
            Channel.CallerIDName = Helper.GetParameterValue(message, "CallerIDName: ");
            Channel.Context = Helper.GetParameterValue(message, "Context: ");
            Channel.ConnectedLineName = Helper.GetParameterValue(message, "ConnectedLineName: ");
            Channel.ConnectedLineNum = Helper.GetParameterValue(message, "ConnectedLineNum: ");
            Channel.Status = Helper.GetParameterValue(message, "ChannelState: ");
            Channel.ChannelStateDesc = Helper.GetParameterValue(message, "ChannelStateDesc: ");
            RaiseNewchannelEvent(this);
        }
    }
}
