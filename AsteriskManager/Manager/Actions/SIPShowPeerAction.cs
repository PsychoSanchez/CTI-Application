namespace AsteriskManager.Manager.Actions
{
    class SIPShowPeerAction : ActionManager
    {
        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public SIPShowPeerAction ()
        {
            Peer = string.Empty;
        }
        /// <summary>
        /// Запрос определенного пира с сервера
        /// </summary>
        /// <param name="peer"></param>
        public SIPShowPeerAction (string peer)
        {
            this.Peer = peer;
        }
        public string Peer { get; set; }
        public override string Action
        {
            get
            {
                return "SIPShowPeer";
            }
        }

        public override string Parameters
        {
            get
            {
                if (!string.IsNullOrEmpty(Peer))
                {
                    return string.Concat("Peer: ", Peer, Helper.LINE_SEPARATOR);
                }
                return null;
            }
        }
    }
}
