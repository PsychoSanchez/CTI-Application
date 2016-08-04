namespace AsteriskManager.Manager.Actions
{
    class PingAction : ActionManager
    {
        public override string Action
        {
            get
            {
                return "Ping";
            }
        }

        public override string Parameters
        {
            get
            {
                return null;
            }
        }
    }
}
