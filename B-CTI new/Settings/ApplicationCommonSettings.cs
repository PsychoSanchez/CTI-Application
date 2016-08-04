using System;
using System.Drawing;
using System.Windows.Forms;

namespace BCTI.SettingClasses
{
    public class ApplicationCommonSettings : ICloneable
    {
        private readonly IniSettings _ini = new IniSettings();
        public Point BlfLocation;
        public Point BlfSize;
        public int ContactsBookCardType;
        public int HistorycardType;
        public bool bDoNotDisturb;
        public string sSysFilePath = string.Empty;

        public ApplicationCommonSettings()
        {
            _ini.path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\B-Cti\\UserSettings.ini";

            string location = _ini.IniReadValue("ApplicationCommon", "BLFLocation");
            var locationXy = location.Split('x');
            try
            {
                BlfLocation.X = int.Parse(locationXy[0]);
                BlfLocation.Y = int.Parse(locationXy[1]);

            }
            catch (FormatException)
            {
                BlfLocation.X = 100;
                BlfLocation.Y = 100;
            }
            string size = _ini.IniReadValue("ApplicationCommon", "BLFSize");
            var sizeXy = size.Split('x');
            try
            {
                BlfSize.X = int.Parse(sizeXy[0]);
                BlfSize.Y = int.Parse(sizeXy[1]);

            }
            catch (FormatException)
            {
                BlfSize.X = 100;
                BlfSize.Y = 100;
            }
            try
            {
                ContactsBookCardType = int.Parse(_ini.IniReadValue("ApplicationCommon", "ContactBookType"));
                HistorycardType = int.Parse(_ini.IniReadValue("ApplicationCommon", "HistoryCardType"));
            }
            catch (FormatException)
            {
                HistorycardType = 0;
                ContactsBookCardType = 0;
            }
            var temp = _ini.IniReadValue("ApplicationCommon", "DoNotDisturb");
            if (temp.ToLower().Contains("true"))
                bDoNotDisturb = true;
            else if (temp.ToLower().Contains("false"))
                bDoNotDisturb = false;

            sSysFilePath = _ini.IniReadValue("ApplicationCommon", "SystemSettings");
            if (string.IsNullOrEmpty(sSysFilePath))
                sSysFilePath = System.IO.Path.GetDirectoryName(Application.ExecutablePath);
        }

        public void SaveSettings()
        {
            _ini.IniWriteValue("ApplicationCommon", "BLFLocation", BlfLocation.X + "x" + BlfLocation.Y);
            _ini.IniWriteValue("ApplicationCommon", "BLFSize", BlfSize.X + "x" + BlfSize.Y);
            _ini.IniWriteValue("ApplicationCommon", "ContactBookType", ContactsBookCardType.ToString());
            _ini.IniWriteValue("ApplicationCommon", "HistoryCardType", HistorycardType.ToString());
            _ini.IniWriteValue("ApplicationCommon", "DoNotDisturb", bDoNotDisturb.ToString());
            _ini.IniWriteValue("ApplicationCommon", "SystemSettings", sSysFilePath);
        }

        public object Clone()
        {
            return new ApplicationCommonSettings { BlfLocation = this.BlfLocation, BlfSize = this.BlfSize, bDoNotDisturb = this.bDoNotDisturb, ContactsBookCardType = this.ContactsBookCardType, HistorycardType = this.HistorycardType, sSysFilePath = this.sSysFilePath.Clone() as string };
        }
    }
}
