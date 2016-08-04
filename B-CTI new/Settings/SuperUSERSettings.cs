using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BCTI.Settings
{
    public class SuperUSERSettings : ICloneable
    {
        private readonly IniSettings ini = new IniSettings();
        public bool bSuperUSERPass = false;
        public string SuperUSERPASSWD = "AMIPass";

        public SuperUSERSettings()
        {
            ini.path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\B-Cti\\UserSettings.ini";

            string temp = ini.IniReadValue("SuperUser", "SUEnabled");
            if (temp.ToLower().Contains("true"))
                bSuperUSERPass = true;
            else if (temp.ToLower().Contains("false"))
                bSuperUSERPass = false;

            SuperUSERPASSWD = ini.IniReadValue("SuperUser", "SUPassword");
        }

        public void Save()
        {
            ini.IniWriteValue("SuperUser", "SUEnabled", bSuperUSERPass.ToString());
            ini.IniWriteValue("SuperUser", "SUPassword", SuperUSERPASSWD.ToString());
        }

        public object Clone()
        {
            return new SuperUSERSettings { bSuperUSERPass = this.bSuperUSERPass, SuperUSERPASSWD = this.SuperUSERPASSWD };
        }
    }
}
