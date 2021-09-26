using System.Collections.Generic;

namespace AsteriskManager.Manager.Actions
{
    class SippeersAction : BaseAmiAction
    {
        public SippeersAction(string actionId) : base(actionId, "Sippeers")
        {
        }

        public override Dictionary<string, object> GetFields() => new();
    }
}
