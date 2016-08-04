using AsteriskManager.Parser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace AsteriskManager.Manager.Event
{
    class StatusEvent : EventManager
    {
        public static readonly AutoResetEvent StatusComplete = new AutoResetEvent(false);
        private string Channel { get; set; }
        public StatusEvent (string message)
        {
            Channel = Helper.GetParameterValue(message, "Channel: ");
            for (int i = 0; i < AMIManager.ActiveChannels.Count; i++)
            {
                if (AMIManager.ActiveChannels[i].Channel.Equals(Channel))
                {
                    AMIManager.ActiveChannels[i].CallerIDNum = Helper.GetParameterValue(message, "CallerIDNum: ");
                    AMIManager.ActiveChannels[i].CallerIDName = Helper.GetParameterValue(message, "CallerIDName: ");
                    AMIManager.ActiveChannels[i].ConnectedLineNum = Helper.GetParameterValue(message, "ConnectedLineNum: ");
                    AMIManager.ActiveChannels[i].ConnectedLineName = Helper.GetParameterValue(message, "ConnectedLineName: ");
                    AMIManager.ActiveChannels[i].Uniqueid = Helper.GetParameterValue(message, "Uniqueid: ");
                    AMIManager.ActiveChannels[i].Context = Helper.GetParameterValue(message, "Context: ");
                    break;
                }
            }
            StatusComplete.Set();
        }
    }
}
