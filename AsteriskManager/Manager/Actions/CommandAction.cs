using System.Collections.Generic;

namespace AsteriskManager.Manager.Actions
{
    class CommandAction : BaseAmiAction
    {
        const string ACTION = "Command";
        public CommandAction(string actionId) : base(actionId, ACTION) { }

        public string Command;

        public override Dictionary<string, object> GetFields() => new()
        {
            ["Command"] = Command
        };
    }
}