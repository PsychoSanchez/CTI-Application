namespace AsteriskManager.Manager.Actions
{
    class CommandAction : ActionManager
    {
        public CommandAction(string command)
        {
            Command = command;
        }
        public string Command { get; set; }
        public override string Action
        {
            get
            {
                return "Command";
            }
        }

        public override string Parameters
        {
            get
            {
                if (!string.IsNullOrEmpty(Command))
                {
                    return string.Concat("Command: ", Command, Helper.LINE_SEPARATOR);
                }
                return null;
            }
        }
    }
}
