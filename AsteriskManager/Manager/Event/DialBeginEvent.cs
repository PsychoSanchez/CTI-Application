namespace AsteriskManager.Manager.Event
{
    class DialBeginEvent : EventManager
    {
        DialData dial = new DialData();

        public DialBeginEvent(string message)
        {
            dial.ChannelID = Helper.GetParameterValue(message, "Channel: ");
            if (string.IsNullOrEmpty(dial.ChannelID))
                return;

            dial.DestinationID = Helper.GetParameterValue(message, "Destination: ");
            if (string.IsNullOrEmpty(dial.DestinationID))
            {
                dial.DestinationID = Helper.GetParameterValue(message, "DestChannel: ");
            }

            dial.CallerIDNum = Helper.GetParameterValue(message, "CallerIDNum: ");
            dial.CallerIDName = Helper.GetParameterValue(message, "CallerIDName: ");
            dial.ConnectedLineNum = Helper.GetParameterValue(message, "ConnectedLineNum: ");

            if (string.IsNullOrEmpty(dial.ConnectedLineNum) || dial.ConnectedLineNum == "<unknown>")
                dial.ConnectedLineNum = Helper.GetParameterValue(message, "DestCallerIDNum: ");
            //if (dail.ConnectedLineNum == "<unknown>")
            //{
            //    dail.ConnectedLineNum = null;
            //}

            dial.ConnectedLineName = Helper.GetParameterValue(message, "ConnectedLineName: ");
            if (string.IsNullOrEmpty(dial.ConnectedLineName) || dial.ConnectedLineName == "<unknown>")
                dial.ConnectedLineName = Helper.GetParameterValue(message, "DestCallerIDName: ");
            //if (dail.ConnectedLineName == "<unknown>")
            //{
            //    dail.ConnectedLineName = null;
            //}

            dial.Uniqueid = Helper.GetParameterValue(message, "Uniqueid: ");
            if (string.IsNullOrEmpty(dial.Uniqueid))
                dial.Uniqueid = Helper.GetParameterValue(message, "DestLinkedid: ");
            if (string.IsNullOrEmpty(dial.Uniqueid))
                dial.Uniqueid = Helper.GetParameterValue(message, "UniqueID: ");

            dial.Uniqueid2 = Helper.GetParameterValue(message, "DestUniqueid: ");
            if (string.IsNullOrEmpty(dial.Uniqueid2))
                dial.Uniqueid2 = Helper.GetParameterValue(message, "DestUniqueID: ");

            dial.Dialstring = Helper.GetParameterValue(message, "Dialstring: ");
            if (string.IsNullOrEmpty(dial.Dialstring))
                dial.Dialstring = Helper.GetParameterValue(message, "8: ");
            dial.currentstatus = DialData.Dialstat.DialBegin;
            DialEventArgs e = new DialEventArgs(dial);
            RaiseDialEvent(e);
        }
        public DialBeginEvent(ChannelData channel, bool ReverseInformation)
        {
            if (ReverseInformation)
                dial = Helper.ChannelDataToDialRev11(channel);
            else
            {
                dial = Helper.ChannelDataToDial(channel);
            }
            dial.currentstatus = DialData.Dialstat.DialBegin;
            DialEventArgs e = new DialEventArgs(dial);
            RaiseDialEvent(e);
        }
        
    }
    public class ConversationBeginEvent : EventManager
    {
        DialData dial = new DialData();
        public ConversationBeginEvent(DialData dialinfo)
        {
            dial = (DialData)dialinfo.Clone();
            dial.currentstatus = DialData.Dialstat.ConversationBegin;
            DialEventArgs e = new DialEventArgs(dial);
            RaiseDialEvent(e);
        }
    }
    public class DialBegin11 : EventManager
    {
        DialData dial = new DialData();

        public DialBegin11(string message)
        {
            dial.ChannelID = Helper.GetParameterValue(message, "Channel: ");
            if (string.IsNullOrEmpty(dial.ChannelID))
                return;

            dial.DestinationID = Helper.GetParameterValue(message, "Destination: ");
            if (string.IsNullOrEmpty(dial.DestinationID))
            {
                dial.DestinationID = Helper.GetParameterValue(message, "DestChannel: ");
            }

            dial.CallerIDNum = Helper.GetParameterValue(message, "CallerIDNum: ");
            dial.CallerIDName = Helper.GetParameterValue(message, "CallerIDName: ");
            dial.ConnectedLineNum = Helper.GetParameterValue(message, "ConnectedLineNum: ");

            if (string.IsNullOrEmpty(dial.ConnectedLineNum) || dial.ConnectedLineNum == "<unknown>")
                dial.ConnectedLineNum = Helper.GetParameterValue(message, "DestCallerIDNum: ");
            //if (dail.ConnectedLineNum == "<unknown>")
            //{
            //    dail.ConnectedLineNum = null;
            //}

            dial.ConnectedLineName = Helper.GetParameterValue(message, "ConnectedLineName: ");
            if (string.IsNullOrEmpty(dial.ConnectedLineName) || dial.ConnectedLineName == "<unknown>")
                dial.ConnectedLineName = Helper.GetParameterValue(message, "DestCallerIDName: ");
            //if (dail.ConnectedLineName == "<unknown>")
            //{
            //    dail.ConnectedLineName = null;
            //}

            dial.Uniqueid = Helper.GetParameterValue(message, "Uniqueid: ");
            if (string.IsNullOrEmpty(dial.Uniqueid))
                dial.Uniqueid = Helper.GetParameterValue(message, "DestLinkedid: ");
            if (string.IsNullOrEmpty(dial.Uniqueid))
                dial.Uniqueid = Helper.GetParameterValue(message, "UniqueID: ");

            dial.Uniqueid2 = Helper.GetParameterValue(message, "DestUniqueid: ");
            if (string.IsNullOrEmpty(dial.Uniqueid2))
                dial.Uniqueid2 = Helper.GetParameterValue(message, "DestUniqueID: ");

            dial.Dialstring = Helper.GetParameterValue(message, "Dialstring: ");
            if (string.IsNullOrEmpty(dial.Dialstring))
                dial.Dialstring = Helper.GetParameterValue(message, "8: ");
            dial.currentstatus = DialData.Dialstat.DialBegin11;
            DialEventArgs e = new DialEventArgs(dial);
            RaiseDialEvent(e);
        }
    }
}
