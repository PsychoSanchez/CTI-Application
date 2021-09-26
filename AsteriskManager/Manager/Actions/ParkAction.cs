using System.Collections.Generic;
using AsteriskManager.Utils;

namespace AsteriskManager.Manager.Actions
{
    /// <summary>
    /// http://www.asteriskdocs.org/en/2nd_Edition/asterisk-book-html-chunk/asterisk-APP-F-24.html
    /// https://wiki.asterisk.org/wiki/display/AST/ManagerAction_Park
    /// </summary>
    class ParkAction : BaseAmiAction
    {
        const string ACTION_NAME = "Park";

        public ParkAction() : base(ACTION_NAME)
        {
        }

        public ParkAction(string actionId) : base(actionId, ACTION_NAME)
        {
        }

        public string Channel1;
        public string Channel2;
        public string AnnounceChannel;
        public string Timeout;
        public string ParkingLot;

        public override Dictionary<string, object> GetFields() => AsteriskManagerUtils.OmitNullOrEmptyStrings(new()
        {
            ["Channel"] = Channel1,
            ["Channel2"] = Channel2,
            ["Timeout"] = Timeout,
            ["AnnounceChannel"] = AnnounceChannel,
            ["Parkinglot"] = ParkingLot,
        });
    }
}
