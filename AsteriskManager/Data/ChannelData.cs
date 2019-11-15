using System;
using AsteriskManager.Manager.Event;

namespace AsteriskManager
{
    public enum ChannelState
    {
        ChannelUnavailble = 0,
        ChannelDownButReserved,
        ChannelIsOffHook,
        Digits,
        Ringing,
        RemoteRinging,
        Up,
        Busy
    }
    /// <summary>
    /// Класс хранящий информацию о активном канале
    /// </summary>
    public class ChannelData : ICloneable, IDialChannelInfo
    {
        public ChannelState State;
        private string _state;
        public string Status
        {
            get
            {
                return _state;
            }
            set
            {
                _state = value;
                int RingState;
                if (int.TryParse(_state, out RingState))
                {
                    if (RingState < 8)
                        State = (ChannelState)Enum.ToObject(typeof(ChannelState), RingState);
                }
            }
        }

        public string ChannelID { get; set; }
        public string Link { get; set; }
        public string Location { get; set; }

        public string ChannelStateDesc { get; set; }
        public string ApplicationData { get; set; }
        public string Uniqueid { get; set; }
        public string CallerIDNum { get; set; }
        public string CallerIDName { get; set; }
        public string ConnectedLineNum { get; set; }
        public string ConnectedLineName { get; set; }
        public string Context { get; set; }
        public ChannelData() { }

        public ChannelData(string _channel, string _location, string _state, string _appdata)
        {
            ChannelID = _channel;
            Location = _location;
            Status = _state;
            ApplicationData = _appdata;
        }

        public void SetConnectedLineInfo(string connectedLineNum, string connectedLineName)
        {
            ConnectedLineNum = ConnectedLineNum;
            ConnectedLineName = connectedLineName;
        }

        public void SetCallerInfo(string callerNum, string callerName)
        {
            CallerIDNum = callerNum;
            CallerIDName = callerName;
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
    public class ParkedCallsData
    {
        public string Exten { get; set; }
        public string Channel { get; set; }
        public string Timeout { get; set; }
        public string CallerIDNum { get; set; }
        public string CallerIDName { get; set; }
        public ParkedCallsData()
        {

        }
    }
}
