using System.Collections.Generic;

namespace AsteriskManager.Manager.Actions
{
    class ParkedCallsAction : BaseAmiAction
    {
        public ParkedCallsAction() : base("ParkedCalls")
        {
        }

        public override Dictionary<string, object> GetFields() => new();
    }
}
