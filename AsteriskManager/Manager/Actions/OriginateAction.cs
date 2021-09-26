using System.Text;
using System.Collections.Generic;
using AsteriskManager.Exceptions;
using AsteriskManager.Utils;

namespace AsteriskManager.Manager.Actions
{
    enum OriginateEventСallType
    {
        SipToExten = 1,
        AppCommand,
        OutgoingToLoacal,
        Default
    }
    /// <summary>
    /// http://www.voip-info.org/wiki/view/Asterisk+Manager+API+Action+Originate
    /// </summary>
    class OriginateAction : BaseAmiAction
    {
        #region Переменные
        public string Account = string.Empty;
        public string Application = string.Empty;
        public OriginateEventСallType CallType;
        public string CallerId = string.Empty;
        public bool IsAsync = false;
        public string Channel = string.Empty;
        public string Context = string.Empty;
        public string Data = string.Empty;
        public string Exten = string.Empty;
        public int Priority = -1;
        public long Timeout = -1;
        private Dictionary<string, string> variables;

        const string ACTION_NAME = "Originate";

        public OriginateAction(string actionId, OriginateEventСallType type) : base(actionId, ACTION_NAME)
        {
            CallType = type;
        }

        public OriginateAction(OriginateEventСallType type) : base(ACTION_NAME)
        {
            CallType = type;
        }


        #endregion
        public void SetVariables(Dictionary<string, string> vars)
        {
            variables = vars;
        }

        public override Dictionary<string, object> GetFields()
        {
            if (string.IsNullOrEmpty(Channel))
            {
                throw new AmiException("Failure: Channel is empty in originateaction"); //Допилить эксепшн
            }


            switch (CallType)
            {
                case OriginateEventСallType.Default:
                    return GetDefaultOriginateFields();
                case OriginateEventСallType.AppCommand:
                    return GetAppCommandFields();
                case OriginateEventСallType.OutgoingToLoacal:
                    return GetOutgoingToLoacalFields();
                case OriginateEventСallType.SipToExten:
                    return GetSipToExtenFields();

                default:
                    return new();
            }
        }

        private Dictionary<string, object> GetDefaultOriginateFields()
        {

            var fields = AsteriskManagerUtils.OmitNullOrEmptyStrings(new()
            {
                ["Channel"] = Channel,
                ["Context"] = Context,
                ["Exten"] = Exten,
            });

            if (Priority != -1)
            {
                fields["Priority"] = Priority;
            }

            if (variables.Count > 0)
            {
                fields["Variable"] = BuildDefaultOriginateVariableString();
            }

            if (Timeout > 0)
            {
                fields["Timeout"] = Timeout;
            }


            return fields;
        }

        private Dictionary<string, object> GetAppCommandFields()
        {
            if (string.IsNullOrEmpty(Application) || string.IsNullOrEmpty(Data))
            {
                throw new AmiException("Failure: Unable to create appcomand in originateaction");
            }

            Dictionary<string, object> fields = new()
            {
                ["Channel"] = Channel,
                ["Application"] = Application,
                ["Data"] = Data,
            };
            if (Priority != -1)
            {
                fields["Priority"] = Priority;
            }

            if (variables.Count > 0)
            {
                fields["Variable"] = BuildExtendedVariablesString();
            }

            if (Timeout > 0)
            {
                fields["Timeout"] = Timeout;
            }


            return fields;
        }

        private Dictionary<string, object> GetSipToExtenFields()
        {

            if (string.IsNullOrEmpty(Context) || string.IsNullOrEmpty(Exten) || Priority == -1)
            {
                throw new AmiException("Failure: Channel or context or exten is empty in originateaction"); //Допилить эксепшн
            }

            Dictionary<string, object> fields = new()
            {

                ["Channel"] = Channel,
                ["Context"] = Context,
                ["Exten"] = Exten,
                ["Priority"] = Priority,
            };

            if (variables?.Count > 0)
            {
                fields["Variable"] = BuildExtendedVariablesString();
            }

            if (Timeout > 0)
            {
                fields["Timeout"] = Timeout;
            }

            return fields;
        }

        private Dictionary<string, object> GetOutgoingToLoacalFields()
        {

            if (string.IsNullOrEmpty(Context) || string.IsNullOrEmpty(Exten) || Priority == -1)
            {
                throw new AmiException("Failure: Channel or context or exten is empty in originateaction"); //Допилить эксепшн
            }

            Dictionary<string, object> fields = new()
            {

                ["Channel"] = Channel,
                ["Context"] = Context,
                ["Exten"] = Exten,
                ["Priority"] = Priority,
            };

            if (!string.IsNullOrEmpty(CallerId))
            {
                fields["Callerid"] = CallerId;
            }

            if (Timeout > 0)
            {
                fields["Timeout"] = Timeout;
            }

            return fields;
        }

        private string BuildDefaultOriginateVariableString()
        {
            var sb = new StringBuilder();

            foreach (KeyValuePair<string, string> value in variables)
            {
                sb.Append(string.Concat(value.Key, "=", value.Value, "|"));
            }
            sb.Length--;
            sb.Append(Helper.LINE_SEPARATOR);

            return sb.ToString();
        }

        private string BuildExtendedVariablesString()
        {
            StringBuilder sb = new();

            int i = 0;
            foreach (KeyValuePair<string, string> value in variables)
            {
                i++;
                if (i == variables.Count)
                {
                    sb.Append(string.Concat(value.Key, value.Value));
                }
                else
                {
                    sb.Append(string.Concat(value.Key, "=\"", value.Value, "\"", "|"));
                }
            }
            sb.Length--;
            sb.Append(Helper.LINE_SEPARATOR);

            return sb.ToString();
        }
    }
}
