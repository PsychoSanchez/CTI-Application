using AsteriskManager.Parser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace AsteriskManager.Manager.Event
{
    class OriginateEvent : EventManager
    {
        public static readonly AutoResetEvent OriginateComplete = new AutoResetEvent(false);

        public override string ActionID
        {
            get;
            set;
        }
        public bool IsCallSuccess { get; }
        public OriginateEvent()
        {
            OriginateComplete.Set();
        }
        public OriginateEvent(string message)
        {
            ActionID = Helper.GetParameterValue(message, "ActionID: ");
            if (string.IsNullOrEmpty(ActionID))
            {
                IsCallSuccess = false;
            }
            else
            {
                IsCallSuccess = true;
                AMIManager.ActionIdMessages.Add(ActionID, this);
                OriginateComplete.Set();
            }

        }
    }
}
