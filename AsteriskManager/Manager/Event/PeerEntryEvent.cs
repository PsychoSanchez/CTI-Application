namespace AsteriskManager.Manager.Event
{
    class PeerEntryEvent : EventManager
    {
        public ClientsData client = new ClientsData();
        public PeerEntryEvent(string message)
        {
            ParseClientsData(message);
            RaisePeerEntryEvent(this);
        }
        private void ParseClientsData(string message)
        {
            client.Number = Helper.GetParameterValue(message, "ObjectName: ");
            client.Protocol = Helper.GetParameterValue(message, "Channeltype: ");
            client.Context = Helper.GetParameterValue(message, "Context: ");
            client.IP = Helper.GetParameterValue(message, "IPaddress: ");
            if (string.IsNullOrEmpty(client.IP))
                client.IP = Helper.GetParameterValue(message, "Address-IP: ");
            client.Port = Helper.GetParameterValue(message, "IPport: ");
            if (string.IsNullOrEmpty(client.Port))
                client.Port = Helper.GetParameterValue(message, "Address-Port: ");
            client.Status = Helper.GetParameterValue(message, "Status: ");
        }
    }
}
