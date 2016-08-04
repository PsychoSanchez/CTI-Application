using System;

namespace AsteriskManager
{
    public class AsteriskEventArgs : EventArgs
    {
        public AsteriskEventArgs(EventManager e)
        {
            Event = e;
        }
        public EventManager Event { get; private set; }
    }
    public class DialEventArgs : EventArgs
    {
        public DialData dialinfo;
        public DialEventArgs(DialData dial)
        {
            dialinfo = dial;
        }
        public DialEventArgs(DialData dial, ChannelData _channel1, ChannelData _channel2)
        {
            dialinfo = dial;
        }
    }

    public class EventManager
    {
        public virtual string ActionID { get; set; }
        // Declare the delegate (if using non-generic pattern).
        public delegate void AsteriskEventHandler(object sender, AsteriskEventArgs e);

        // Declare the event.
        public static event AsteriskEventHandler AsteriskEvent;
        public static event AsteriskEventHandler Hangup;
        public static event AsteriskEventHandler Bridge;
        public static event AsteriskEventHandler PeerStatus;
        public static event AsteriskEventHandler Newstate;
        public static event AsteriskEventHandler Newchannel;
        public static event AsteriskEventHandler ParkedCall;
        public static event AsteriskEventHandler PeerEntry;
        public static event AsteriskEventHandler ExtensionStatus;

        /// <summary>
        /// События версия 2.8
        /// </summary>
        public static event AsteriskEventHandler OriginateResponseEvent;


        public delegate void DialEventHandler(object sender, DialEventArgs e);
        public static event DialEventHandler DialEvent;
        public static event DialEventHandler DialBegin;
        public static event DialEventHandler ConversationBegin;
        public static event DialEventHandler ConversationEnd;
        public static event DialEventHandler HoldEvent;
        public static event DialEventHandler UnholdEvent;

        protected virtual void RaiseOriginateResponseEvent(EventManager e)
        {
            // Raise the event by using the () operator.
            if (OriginateResponseEvent != null)
                OriginateResponseEvent(this, new AsteriskEventArgs(e));
        }
        // Wrap the event in a protected virtual method
        // to enable derived classes to raise the event.
        protected virtual void RaiseHangupEvent(EventManager e)
        {
            // Raise the event by using the () operator.
            if (Hangup != null)
                Hangup(this, new AsteriskEventArgs(e));
        }
        // Wrap the event in a protected virtual method
        // to enable derived classes to raise the event.
        protected virtual void RaisePeerEntryEvent(EventManager e)
        {
            // Raise the event by using the () operator.
            if (PeerEntry != null)
                PeerEntry(this, new AsteriskEventArgs(e));
        }
        protected virtual void RaiseExtensionStatusEvent(EventManager e)
        {
            // Raise the event by using the () operator.
            if (ExtensionStatus != null)
                ExtensionStatus(this, new AsteriskEventArgs(e));
        }
        protected virtual void RaiseNewstateEvent(EventManager e)
        {
            // Raise the event by using the () operator.
            if (Newstate != null)
                Newstate(this, new AsteriskEventArgs(e));
        }
        protected virtual void RaiseParkedCallEvent(EventManager e)
        {
            // Raise the event by using the () operator.
            if (ParkedCall != null)
                ParkedCall(this, new AsteriskEventArgs(e));
        }
        protected virtual void RaiseNewchannelEvent(EventManager e)
        {
            // Raise the event by using the () operator.
            if (Newchannel != null)
                Newchannel(this, new AsteriskEventArgs(e));
        }
        protected virtual void RaiseDialEvent(DialEventArgs e)
        {
            // Raise the event by using the () operator.
            if (DialEvent != null)
                DialEvent(this, e);
        }
        public static void RaiseDialBeginEvent(DialEventArgs e)
        {
            // Raise the event by using the () operator.
            if (DialBegin != null)
                DialBegin(null, e);
        }
        public static void RaiseConversationBeginEvent(DialEventArgs e)
        {
            // Raise the event by using the () operator.
            if (ConversationBegin != null)
                ConversationBegin(null, e);
        }
        public static void RaiseConversationEndEvent(DialEventArgs e)
        {
            // Raise the event by using the () operator.
            if (ConversationEnd != null)
                ConversationEnd(null, e);
        }
        public static void RaiseHoldEvent(DialEventArgs e)
        {
            // Raise the event by using the () operator.
            if (HoldEvent != null)
                HoldEvent(null, e);
        }
        public static void RaiseUnholdEvent(DialEventArgs e)
        {
            // Raise the event by using the () operator.
            if (UnholdEvent != null)
                UnholdEvent(null, e);
        }

    }
}
