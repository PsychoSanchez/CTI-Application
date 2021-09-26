using System.Collections.Generic;
using System.Text;
using AsteriskManager.Utils;

namespace AsteriskManager.Manager.Actions
{
    public class LoginAction : BaseAmiAction
    {
        public string UserName = string.Empty;
        public string PassWord = string.Empty;
        public string AuthType = string.Empty;
        public string Key = string.Empty;
        public string Events = string.Empty;

        const string ACTION_NAME = "Login";

        public LoginAction(string actionId) : base(actionId, ACTION_NAME)
        {
        }
        public LoginAction() : base(ACTION_NAME)
        {
        }

        public override Dictionary<string, object> GetFields()
        {
            Dictionary<string, object> fields = new()
            {
                ["UserName"] = UserName,
                ["Secret"] = PassWord,
                ["AuthType"] = AuthType,
                ["Key"] = Key,
                ["Events"] = Events,
            };

            return AsteriskManagerUtils.OmitNullOrEmptyStrings(fields);
        }
    }
}
