using System;

namespace AsteriskManager.Manager.Event
{
    class HoldEvent : EventManager
    {
        public HoldEvent(string message)
        {            
            DialData dial = new DialData();
            dial.DialStatus = "HOLD";

            dial.ChannelID = Helper.GetParameterValue(message, "Channel: ");
            dial.CallerIDNum = Helper.GetParameterValue(message, "CallerIDNum: ");
            dial.CallerIDName = Helper.GetParameterValue(message, "CallerIDName: ");

            dial.ConnectedLineNum = Helper.GetParameterValue(message, "ConnectedLineNum: ");

            dial.ConnectedLineName = Helper.GetParameterValue(message, "ConnectedLineName: ");

            dial.Uniqueid = Helper.GetParameterValue(message, "Uniqueid: ");
            dial.Uniqueid2 = Helper.GetParameterValue(message, "Linkedid: ");
            DialEventArgs e = new DialEventArgs(dial);
            RaiseHoldEvent(e);
            Console.WriteLine(dial.DialStatus + dial.CallerIDNum + dial.ConnectedLineNum);
        }
    }
}
