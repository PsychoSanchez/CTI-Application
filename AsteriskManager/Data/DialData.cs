using System;

namespace AsteriskManager
{
    public class DialData : ICloneable
    {
        public enum Dialstat
        {
            DialBegin11 =0,
            DialBegin = 1,
            ConversationBegin = 2,
            ConversationEnd = 3
        };
        public Dialstat currentstatus { get; set; }
        public string ChannelID { get; set; }
        public string DestinationID { get; set; }
        public string CallerIDNum { get; set; }
        public string CallerIDName { get; set; }
        public string ConnectedLineNum { get; set; }
        public string ConnectedLineName { get; set; }
        public string DialStatus { get; set; }
        public string Uniqueid { get; set; }
        public string Uniqueid2 { get; set; }
        public string Dialstring { get; set; }

        public DialData()
        {

        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
