﻿using System.Collections.Generic;

namespace AsteriskManager.Manager.Actions
{
    /// <summary>
    ///     The AbsoluteTimeoutAction sets the absolute maximum amount of time permitted for a call on a given channel.<br />
    ///     Note that the timeout is set from the current time forward, not counting the number of seconds the call has already
    ///     been up.<br />
    ///     When setting a new timeout all previous absolute timeouts are cancelled.<br />
    ///     When the timeout is reached the call is returned to the T extension so that
    ///     you can playback an explanatory note to the calling party (the called party will not hear that).<br />
    ///     This action corresponds the the AbsoluteTimeout command used in the dialplan.
    /// </summary>
    public class AbsoluteTimeoutAction : ActionManager, ISerializableAMIAction
    {
        public AbsoluteTimeoutAction()
        {
        }

        /// <summary>
        ///     Creates a new AbsoluteTimeoutAction with the given channel and timeout.
        /// </summary>
        /// <param name="channel">the name of the channel</param>
        /// <param name="timeout">the timeout in seconds or 0 to cancel the AbsoluteTimeout</param>
        public AbsoluteTimeoutAction(string channel, int timeout)
        {
            Channel = channel;
            Timeout = timeout;
        }


        public string Channel { get; set; }

        // timeout in seconds.
        public int Timeout { get; set; }


        public override string Action
        {
            get { return "AbsoluteTimeout"; }
        }

        public override string Parameters
        {
            get
            {
                ///Стек оверфлоу (Потому что поздно имплементить такие штуки)
                return Helper.ToString(this);
            }
        }

        const string ACTION = "AbsoluteTimeout";
        public string GetAction() => ACTION;
        public Dictionary<string, object> GetFields() => new Dictionary<string, object>
            {
                {"Channel", Channel},
                {"Timeout", Timeout}
            };
    }
}
