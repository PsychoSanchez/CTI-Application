using System.Collections.Generic;

namespace AsteriskManager.Manager.Actions
{
    class ListCommandsAction : BaseAmiAction
    {
        public ListCommandsAction() : base("ListCommands")
        {
        }

        private Dictionary<string, object> emptyParams = new();
        public override Dictionary<string, object> GetFields() => emptyParams;
    }
}
