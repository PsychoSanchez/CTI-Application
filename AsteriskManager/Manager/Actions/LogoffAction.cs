using System.Collections.Generic;

namespace AsteriskManager.Manager.Actions
{
    class LogoffAction : BaseAmiAction
    {
        public LogoffAction() : base("Logoff")
        {
        }

        public override Dictionary<string, object> GetFields() => new();
    }
}
