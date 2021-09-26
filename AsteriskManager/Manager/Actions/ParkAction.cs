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
                var messageBuilder = new AmiMesasgeBuilder();
                messageBuilder.Add("Channel", Channel1);

                if (!string.IsNullOrEmpty(Channel2))
                {
                    messageBuilder.Add("Channel2", Channel2);
                }
                if (!string.IsNullOrEmpty(Timeout))
                {
                    messageBuilder.Add("Timeout", Timeout);
                }
                if (!string.IsNullOrEmpty(AnnounceChannel))
                {
                    messageBuilder.Add("AnnounceChannel", AnnounceChannel);
                }
                if (!string.IsNullOrEmpty(ParkingLot))
                {
                    messageBuilder.Add("Parkinglot", ParkingLot);
                }

                return messageBuilder.ToString();
            }
        }
    }
}
