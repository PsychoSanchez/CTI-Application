using AsteriskManager.Parser;
using System.Threading;
using System;

namespace AsteriskManager.Manager.Event
{
    class PeerlistCompleteEvent:EventManager
    {
        public static readonly AutoResetEvent PeerlistComplete = new AutoResetEvent(false);

        public string ListItems { get; }

        public override string ActionID
        {
            get; set;
        }
        public PeerlistCompleteEvent()
        {
            PeerlistComplete.Set();
        }
        public PeerlistCompleteEvent(string Message)
        {
            ListItems = Helper.GetParameterValue(Message, "ListItems: ");
            ActionID = Helper.GetParameterValue(Message, "ActionID: ");
            if(string.IsNullOrEmpty(ActionID))
            {
            }
            else
            {
                AMIManager.ActionIdMessages.Add(ActionID, this);
                //Helper.ActionIDMessages.Add(ActionID, ListItems);
                PeerlistComplete.Set();
                //Someone waiting 
            }
        }

    }
}
