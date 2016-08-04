using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace AsteriskManager
{
    public class ClientsData //Класс для хранения информации о клиентах
    {
        public int id { get; set; }

        public string number { get; set; }
        public string secondNumber { get; set; }
        public string name { get; set; }
        public string organisation { get; set; }
        public string position { get; set; }
        public string email { get; set; }
        public string adress { get; set; }
        public string note { get; set; }
        public DateTime birthday { get; set; }

        public string type { get; set; }

        public bool onBLF { get; set; }
        public string protocol { get; set; }
        public string ip { get; set; }
        public string status { get; set; }
        public string BLFStatus { get; set; }
        public string context { get; set; }

        public int pictoStatus;
        public string avatar { get; set; }

        public override string ToString()
        {
            if (name != "")
            {
                return name + " " + number;
            }

            else
                return number;
        }

        public string getchannel()
        {
            return protocol + "/" + number;
        }

        public ClientsData()
        {
            this.id = -1;
            this.number = "";
            this.secondNumber = "";
            this.name = "";
            this.organisation = "";
            this.position = "";
            this.email = "";
            this.note = "";
            this.adress = "";
            this.birthday = DateTime.Now;
            this.avatar = "";

            this.type = "";
            this.onBLF = false;
            this.pictoStatus = 0;
            this.protocol = "";
            this.ip = "";
            this.status = "";
            this.BLFStatus = "";
            this.context = "";
        }
    }

    public class Serealizator3000
    {
        public List<ClientsData> ClientsDataVar { get; set; }
        public List<RingInfo> RingInfoVar { get; set; }
    }
}
