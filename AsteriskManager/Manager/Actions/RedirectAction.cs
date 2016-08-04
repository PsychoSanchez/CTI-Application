using System.Text;

namespace AsteriskManager.Manager.Actions
{
    class RedirectAction : ActionManager
    {

        public RedirectAction(string channel, string context, string exten, int priority)
        {
            Channel = channel;
            Context = context;
            Exten = exten;
            Priority = priority;
        }

        public RedirectAction(string channel, string extrachannell, string context, string exten, int priority)
        {
            Channel = channel;
            ExtraChannel = extrachannell;
            Context = context;
            Exten = exten;
            Priority = priority;
        }

        public override string Action
        {
            get
            {
                return "Redirect";
            }
        }

        public override string Parameters
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(string.Concat("Channel: ", Channel, Helper.LINE_SEPARATOR));
                if (!string.IsNullOrEmpty(ExtraChannel))
                {
                    sb.Append(string.Concat("ExtraChannel: ", ExtraChannel, Helper.LINE_SEPARATOR));
                }
                sb.Append(string.Concat("Exten: ", Exten, Helper.LINE_SEPARATOR));
                sb.Append(string.Concat("Priority: ", Priority, Helper.LINE_SEPARATOR));
                sb.Append(string.Concat("Context: ", Context, Helper.LINE_SEPARATOR));
                sb.Append(string.Concat("ExtraExten: ", Exten, Helper.LINE_SEPARATOR));
                sb.Append(string.Concat("ExtraPriority: ", Priority, Helper.LINE_SEPARATOR));
                sb.Append(string.Concat("ExtraContext: ", Context, Helper.LINE_SEPARATOR));
                return sb.ToString();
            }
        }
        public string Channel { get; set; }
        public string ExtraChannel { get; set; }
        public string Context { get; set; }
        public string Exten { get; set; }
        public int Priority { get; set; }
        public string ExtraExten { get; set; }
        public string ExtraPriority { get; set; }
        public string ExtraContext { get; set; }
    }
}
