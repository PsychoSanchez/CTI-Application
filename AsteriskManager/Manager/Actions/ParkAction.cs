using System.Text;
///
namespace AsteriskManager.Manager.Actions
{
    /// <summary>
    /// http://www.asteriskdocs.org/en/2nd_Edition/asterisk-book-html-chunk/asterisk-APP-F-24.html
    /// https://wiki.asterisk.org/wiki/display/AST/ManagerAction_Park
    /// </summary>
    class ParkAction : ActionManager
    {
        public ParkAction(string channel1)
        {
            Channel1 = channel1;
            //Channel2 = channel2;
            //Timeout = timeout;
        }
        public ParkAction(string channel1, string channel2, string timeout)
        {
            Channel1 = channel1;
            Channel2 = channel2;
            Timeout = timeout;
        }
        public ParkAction(string channel1, string channel2, string timeout, string parkinglot)
        {
            Channel1 = channel1;
            Channel2 = channel2;
            Timeout = timeout;
            ParkingLot = parkinglot;
        }
        public override string Action
        {
            get
            {
                return "Park";
            }
        }
        public string Channel1 { get; set; }
        public string Channel2 { get; set; }
        public string AnnounceChannel { get; set; }
        public string Timeout { get; set; }
        public string ParkingLot { get; set; }
        public override string Parameters
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(string.Concat("Channel: ", Channel1, Helper.LINE_SEPARATOR));
                if (!string.IsNullOrEmpty(Channel2))
                    sb.Append(string.Concat("Channel2: ", Channel2, Helper.LINE_SEPARATOR));
                if (!string.IsNullOrEmpty(Timeout))
                    sb.Append(string.Concat("Timeout: ", Timeout, Helper.LINE_SEPARATOR));
                if(!string.IsNullOrEmpty(AnnounceChannel))
                    sb.Append(string.Concat("AnnounceChannel: ", AnnounceChannel, Helper.LINE_SEPARATOR));
                if (!string.IsNullOrEmpty(ParkingLot))
                    sb.Append(string.Concat("Parkinglot: ", ParkingLot, Helper.LINE_SEPARATOR));
                return sb.ToString();
            }
        }
    }
}
