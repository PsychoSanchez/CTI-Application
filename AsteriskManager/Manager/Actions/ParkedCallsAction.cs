namespace AsteriskManager.Manager.Actions
{
    class ParkedCallsAction : ActionManager
    {
        public ParkedCallsAction()
        {

        }
        public override string Action
        {
            get
            {
                return "ParkedCalls";
            }
        }

        public override string Parameters
        {
            get
            {
                return string.Empty;
            }
        }
    }
}
