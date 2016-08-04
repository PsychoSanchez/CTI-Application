namespace AsteriskManager.Manager.Actions
{
    class ChallengeAction : ActionManager
    {
        public string AuthType;
        public ChallengeAction()
        {
            AuthType = "MD5";
        }
        public override string Action
        {
            get
            {
                return "Challenge";
            }
        }

        public override string Parameters
        {
            get
            {
                if (!string.IsNullOrEmpty(AuthType))
                    return "AuthType: " + AuthType + Helper.LINE_SEPARATOR;
                else
                    return null;
            }
        }
    }
}
