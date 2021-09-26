using System.Collections.Generic;
using AsteriskManager.Utils;

namespace AsteriskManager.Manager.Actions
{
    class SIPShowPeerAction : BaseAmiAction
    {
        public string Peer;

        public SIPShowPeerAction(string actionId) : base(actionId, "SIPShowPeer")
        {
        }

        public override Dictionary<string, object> GetFields() => AsteriskManagerUtils.OmitNullOrEmptyStrings(new()
        {
            ["Peer"] = Peer
        });
    }
}
