using System.Collections.Generic;
using System.Text;

namespace AsteriskManager.Manager.Actions
{
    class RedirectAction : BaseAmiAction
    {
        public RedirectAction() : base("Redirect")
        {
        }

        public RedirectAction(string actionId) : base(actionId, "Redirect")
        {
        }

        public string Channel;
        public string ExtraChannel;
        public string Context;
        public string Exten;
        public int Priority;
        public string ExtraExten;
        public string ExtraPriority;
        public string ExtraContext;

        public override Dictionary<string, object> GetFields() => AsteriskManager.Utils.AsteriskManagerUtils.OmitNullOrEmptyStrings(new()
        {
            ["Channel"] = Channel,
            ["ExtraChannel"] = ExtraChannel,
            ["Exten"] = Exten,
            ["Priority"] = Priority,
            ["Context"] = Context,
            ["ExtraExten"] = Exten,
            ["ExtraPriority"] = Priority,
            ["ExtraContext"] = Context,
        });
    }
}
