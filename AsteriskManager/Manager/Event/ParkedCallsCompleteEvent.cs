using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace AsteriskManager.Manager.Event
{
    class ParkedCallsCompleteEvent
    {
        public static AutoResetEvent ParkedCallsComplete = new AutoResetEvent(false);
        public ParkedCallsCompleteEvent()
        {
            ParkedCallsComplete.Set();
        }
    }
}
