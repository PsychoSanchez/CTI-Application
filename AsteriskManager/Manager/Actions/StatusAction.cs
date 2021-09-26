using System.Collections.Generic;
using AsteriskManager.Utils;

namespace AsteriskManager.Manager.Actions
{
    class StatusAction : BaseAmiAction
    {
        public string Channel;

        public StatusAction() : base("Status")
        {
        }

        public StatusAction(string actionId) : base(actionId, "Status")
        {
        }

        public override Dictionary<string, object> GetFields() => AsteriskManagerUtils.OmitNullOrEmptyStrings(new()
        {
            ["Channel"] = Channel
        });
    }
}
