using System;
using System.Collections.Generic;

namespace AsteriskManager
{
    public enum ClientStatus
    {
        Online = 0,
        Calling = 1,
        Talk = 2,
        Busy = 3,
        Unknown = 4,
        Unreacheble = 5,
        Hold = 6
    }
    public class ClientsData : ICloneable //Класс для хранения информации о клиентах
    {

        public Guid ID { get; set; }
        public string Prefix { get; set; }
        public string Number { get; set; }
        public string SecondNumber { get; set; }
        public string Name { get; set; }
        public string organisation { get; set; }
        public string position { get; set; }
        public string email { get; set; }
        public string site { get; set; }
        public string note { get; set; }
        public DateTime birthday { get; set; }
        public bool onBLF { get; set; }
        public int onBLFposition { get; set; }
        public string Protocol { get; set; }
        public string IP { get; set; }
        public string Port { get; set; }

        private string _status = string.Empty;
        public string Status
        {
            get
            {
                return _status;
            }
            set
            {
                _status = value;
                if (_status.Contains("OK"))
                {
                    BLFStatus = ClientStatus.Online;
                }
                else if (_status.Contains("Call"))
                {
                    BLFStatus = ClientStatus.Calling;
                }
                else if (_status.Contains("Talk"))
                {
                    BLFStatus = ClientStatus.Talk;
                }
                else if (_status.Contains("Busy"))
                {
                    BLFStatus = ClientStatus.Busy;
                }
                else if (_status.Contains("Unreacheble"))
                {
                    BLFStatus = ClientStatus.Unreacheble;
                }
                else if (_status.Contains("Hold"))
                {
                    BLFStatus = ClientStatus.Hold;
                }
                else
                {
                    BLFStatus = ClientStatus.Unknown;
                }
            }
        }

        public ClientStatus BLFStatus { get; set; }
        public string Context { get; set; }

        public override string ToString()
        {
            if (!string.IsNullOrEmpty(Name))
            {
                return Name + " " + Number;
            }
            else
                return Number;
        }

        public string GetChannel()
        {
            return Protocol + "/" + Number;
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }

        public ClientsData()
        {
            ID = Guid.NewGuid();
            this.onBLFposition = -1;
            this.Number = string.Empty;
            this.SecondNumber = string.Empty;
            this.Name = string.Empty;
            this.organisation = string.Empty;
            this.position = string.Empty;
            this.email = string.Empty;
            this.note = string.Empty;
            this.site = string.Empty;
            this.birthday = DateTime.Today;
            this.onBLF = false;
            this.Protocol = string.Empty;
            this.IP = string.Empty;
            this.Status = string.Empty;
            this.BLFStatus = ClientStatus.Unknown;
            this.Context = string.Empty;
        }
    }

    public class Serealizator3000
    {
        public List<ClientsData> ClientsDataVar { get; set; }
        public List<RingInfo> RingInfoVar { get; set; }
    }
}
