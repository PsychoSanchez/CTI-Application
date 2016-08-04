using System.Collections.Generic;
using System.Threading;

namespace AsteriskManager.Manager.Event
{
    class CoreShowChannelsEvent
    {
        public static readonly AutoResetEvent CoreShowChannelsComplete = new AutoResetEvent(false);

        public bool IsCallSuccess { get; }
        public CoreShowChannelsEvent(List<ChannelData> channels)
        {
            foreach (var channel in channels)
                new NewChannelEvent(channel);
            CoreShowChannelsComplete.Set();
        }
    }
}
