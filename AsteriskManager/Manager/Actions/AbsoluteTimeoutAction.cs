using System.Collections.Generic;

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
    public class AbsoluteTimeoutAction : BaseAmiAction
    {
        const string ACTION = "AbsoluteTimeout";
        public AbsoluteTimeoutAction(string actionId) : base(actionId, ACTION)
        {
        }

        public string Channel;
        // timeout in seconds or 0 to cancel the AbsoluteTimeout
        public int Timeout;

        public override Dictionary<string, object> GetFields() => new()
        {

            ["Channel"] =
                Channel,
            ["Timeout"] =
                Timeout
        };
    }
}
