using System.Collections.Generic;

namespace AsteriskManager.Manager.Actions
{
    class HangupAction : BaseAmiAction
    {
        const string ACTION = "Hangup";
        public string Channel;
        public HangupAction(string actionId) : base(actionId, ACTION)
        {
        }

        public override Dictionary<string, object> GetFields() => new()
        {
            ["Channel"] = Channel
        };
    }
}
