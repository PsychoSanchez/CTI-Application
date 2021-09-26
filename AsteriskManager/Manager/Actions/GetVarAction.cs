using System.Collections.Generic;

namespace AsteriskManager.Manager.Actions
{
    class GetVarAction : BaseAmiAction
    {
        const string ACTION = "GetVar";

        public GetVarAction(string actionId) : base(actionId, ACTION)
        {
        }

        public string Variable { get; set; }
        public string Channel { get; set; }
        public override Dictionary<string, object> GetFields()
        {
            var fields = new Dictionary<string, object>();
            if (string.IsNullOrEmpty(Variable))
            {
                return fields;
            }

            fields["Variable"] = Variable;

            if (string.IsNullOrEmpty(Channel))
            {
                return fields;
            }

            fields["Channel"] = Channel;

            return fields;
        }
    }
}
