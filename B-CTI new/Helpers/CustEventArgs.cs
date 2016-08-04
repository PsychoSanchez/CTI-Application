using AsteriskManager;
using System;

namespace BCTI
{
    /// <summary>
    /// Структура для событий
    /// </summary>
    public class CustEventArgs : EventArgs
    {
        public string message;
        public CustEventArgs(string _message)
        {
            message = _message;
        }
    }
    public class NewClientArgs : EventArgs
    {
        public ClientsData client;
        public NewClientArgs(ClientsData newCLient)
        {
            client = newCLient;
        }
    }
}
