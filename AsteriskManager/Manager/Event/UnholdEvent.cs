using System;

namespace AsteriskManager.Manager.Event
{
    class UnholdEvent : EventManager
    {
        public UnholdEvent(string message)
        {
            DialData dial = new DialData();
            dial.DialStatus = "UNHOLD";
            
            dial.ChannelID = Helper.GetParameterValue(message, "Channel: ");
            dial.CallerIDNum = Helper.GetParameterValue(message, "CallerIDNum: ");
            dial.CallerIDName = Helper.GetParameterValue(message, "CallerIDName: ");

            dial.ConnectedLineNum = Helper.GetParameterValue(message, "ConnectedLineNum: ");

            dial.ConnectedLineName = Helper.GetParameterValue(message, "ConnectedLineName: ");
         
            dial.Uniqueid = Helper.GetParameterValue(message, "Uniqueid: ");
            dial.Uniqueid2 = Helper.GetParameterValue(message, "Linkedid: ");
            DialEventArgs e = new DialEventArgs(dial);
            RaiseUnholdEvent(e);
            Console.WriteLine(dial.DialStatus + dial.CallerIDNum + dial.ConnectedLineNum);
        }
        
    }
}
