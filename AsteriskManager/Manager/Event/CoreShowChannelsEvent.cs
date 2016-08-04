using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace AsteriskManager.Manager.Event
{
    class CoreShowChannelsEvent:EventManager
    {
        public static readonly AutoResetEvent CoreShowChannelsComplete = new AutoResetEvent(false);

        public bool IsCallSuccess { get; }
        public CoreShowChannelsEvent(List<ChannelData> channels)
        {
            foreach (var channel in channels)
                AMIManager.ActiveChannels.Add(channel);
            CoreShowChannelsComplete.Set();
        }
    }
}
