namespace AsteriskManager.Manager.Event
{
    class DialEndEvent : EventManager
    {
        DialData dial = new DialData();

        public DialEndEvent(string message)
        {
            if (Helper.GetParameterValue(message, "Event: ") == "DialEnd")
            {
                dial.DialStatus = Helper.GetParameterValue(message, "DialStatus: ");

                dial.ChannelID = Helper.GetParameterValue(message, "Channel: ");
                //if (string.IsNullOrEmpty(dial.ChannelID))
                //    return;
                dial.DestinationID = Helper.GetParameterValue(message, "DestChannel: ");

                dial.CallerIDNum = Helper.GetParameterValue(message, "CallerIDNum: ");
                dial.CallerIDName = Helper.GetParameterValue(message, "CallerIDName: ");

                dial.ConnectedLineNum = Helper.GetParameterValue(message, "ConnectedLineNum: ");
                if (string.IsNullOrEmpty(dial.ConnectedLineNum) || dial.ConnectedLineNum == "<unknown>")
                    dial.ConnectedLineNum = Helper.GetParameterValue(message, "DestCallerIDNum: ");

                dial.ConnectedLineName = Helper.GetParameterValue(message, "ConnectedLineName: ");
                if (string.IsNullOrEmpty(dial.ConnectedLineName) || dial.ConnectedLineName == "<unknown>")
                    dial.ConnectedLineName = Helper.GetParameterValue(message, "DestCallerIDName: ");

                dial.Uniqueid = Helper.GetParameterValue(message, "Uniqueid: ");
                if (string.IsNullOrEmpty(dial.Uniqueid))
                    dial.Uniqueid = Helper.GetParameterValue(message, "DestLinkedid: ");
                dial.Uniqueid2 = Helper.GetParameterValue(message, "DestUniqueid: ");

                if (dial.DialStatus == "ANSWER")
                    dial.currentstatus = DialData.Dialstat.ConversationBegin;
                else
                    dial.currentstatus = DialData.Dialstat.ConversationEnd;

                DialEventArgs e = new DialEventArgs(dial);
                RaiseDialEvent(e);
            }
            else
            {
                dial.DialStatus = Helper.GetParameterValue(message, "DialStatus: ");
                dial.ChannelID = Helper.GetParameterValue(message, "Channel: ");
                dial.Uniqueid = Helper.GetParameterValue(message, "UniqueID: ");
                dial.currentstatus = DialData.Dialstat.ConversationEnd;

                DialEventArgs e = new DialEventArgs(dial);
                RaiseDialEvent(e);
            }
        }
        public DialEndEvent(ChannelData channel)
        {
            dial = Helper.ChannelDataToDial(channel);
            dial.DialStatus = "END";
            dial.currentstatus = DialData.Dialstat.ConversationEnd;
            DialEventArgs e = new DialEventArgs(dial);
            RaiseDialEvent(e);
        }
        public DialEndEvent(DialData dialinfo)
        {
            dial = dialinfo;
            if (string.IsNullOrEmpty(dialinfo.DialStatus))
                dial.DialStatus = "END";
            dial.currentstatus = DialData.Dialstat.ConversationEnd;
            DialEventArgs e = new DialEventArgs(dial);
            RaiseDialEvent(e);
        }
    }
}

