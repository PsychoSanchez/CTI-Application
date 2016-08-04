using System.Threading;

namespace AsteriskManager.Manager.Event
{
    class ChallengeEvent : EventManager
    {
        public static readonly AutoResetEvent ChallengeComplete = new AutoResetEvent(false);

        public string Challenge { get; }
        public string Version { get; }
        public ChallengeEvent(string Message)
        {
            Version = Helper.GetParameterValue(Message, "Asterisk Call Manager/");
            Challenge = Helper.GetParameterValue(Message, "Challenge: ");
            ActionID = Helper.GetParameterValue(Message, "ActionID: ");
            if (!string.IsNullOrEmpty(ActionID))
            {
                AMIManager.ActionIdMessages.Add(ActionID, this);
                ChallengeComplete.Set();
                //Someone waiting 
            }
        }
    }
}
