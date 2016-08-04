using System;

namespace AsteriskManager
{
    public enum CallType
    {
        IncomingCall,
        OutcomingCall,
        Unanswered,
        UNKNOWN
    }
    public class RingInfo
    {
        public string Duration { get; set; }
        public string number { get; set; }
        private string ringType { get; set; }
        private CallType _type;
        public CallType type
        {
            get { return _type; }
            set
            {
                _type = value;
                switch (_type)
                {
                    case CallType.IncomingCall:
                        ringType = "<-  ";
                        break;
                    case CallType.OutcomingCall:
                        ringType = "  ->";
                        break;
                    case CallType.Unanswered:
                        ringType = "<->";
                        break;
                    default:
                    case CallType.UNKNOWN:
                        ringType = string.Empty;
                        break;
                }
            }
        }
        public DateTime momentOfRing { get; set; }
        public string UniqueID { get; set; }
        public string getMoment ()
        {
            return String.Format("{0:00}" + "." + "{1:00}" + "." + "{2:00}" + " " + "{3:00}" + ":" + "{4:00}", momentOfRing.Day, momentOfRing.Month, momentOfRing.Year, momentOfRing.Hour, momentOfRing.Minute);
        }
    }
}
