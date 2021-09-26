using System.Collections.Generic;

namespace AsteriskManager.Manager.Actions
{
    class ChallengeAction : BaseAmiAction
    {
        const string ACTION = "Challenge";

        public ChallengeAction(string actionId) : base(actionId, ACTION)
        {
        }

        public string AuthType = "MD5";
        public override Dictionary<string, object> GetFields() => new()
        {
            ["AuthType"] = AuthType
        };
    }
}
