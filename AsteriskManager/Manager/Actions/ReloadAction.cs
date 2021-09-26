using System.Collections.Generic;
using AsteriskManager.Utils;

namespace AsteriskManager.Manager.Actions
{
    class ReloadAction : BaseAmiAction
    {
        public string Module;
        public ReloadAction() : base("Reload")
        {
        }

        public override Dictionary<string, object> GetFields() => AsteriskManagerUtils.OmitNullOrEmptyStrings(new()
        {
            ["Module"] = Module
        });
    }
}
