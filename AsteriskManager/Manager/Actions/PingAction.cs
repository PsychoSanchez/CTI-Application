using System.Collections.Generic;

namespace AsteriskManager.Manager.Actions
{
    class PingAction : BaseAmiAction
    {
        public PingAction() : base("Ping")
        {
        }

        public override Dictionary<string, object> GetFields() => new();
    }
}
