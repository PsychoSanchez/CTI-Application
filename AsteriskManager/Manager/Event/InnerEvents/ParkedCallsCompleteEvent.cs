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
