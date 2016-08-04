using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BCTI.Settings
{
    public class HotkeySettings : ICloneable
    {
        IniSettings ini = new IniSettings();
        public string Modifiers
        {
            get
            {
                return conv.ConvertToString(modifiers);
            }
            set
            {
                try
                {
                    modifiers = (Keys)conv.ConvertFromString(value);
                }
                catch (Exception ex)
                {
                    EventLogs.WriteLog("Не удалось считать горячие клавиши из настроек", ex.Message);
                }
            }
        }
        public string Key
        {
            get
            {
                return conv.ConvertToString(key);
            }
            set
            {
                try
                {
                    key = (Keys)conv.ConvertFromString(value);
                }
                catch (Exception ex)
                {
                    EventLogs.WriteLog("Не удалось считать горячие клавиши из настроек", ex.Message);
                }
            }
        }
        public bool bHotkeyInstantCall = true;
        public int DelayBeforeCall = 300;
        public System.Windows.Forms.Keys modifiers = System.Windows.Forms.Keys.Alt;
        public System.Windows.Forms.Keys key = System.Windows.Forms.Keys.C;
        KeysConverter conv = new KeysConverter();
        public HotkeySettings()
        {
            ini.path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\B-Cti\\UserSettings.ini";

            try
            {
                DelayBeforeCall = int.Parse(ini.IniReadValue("Hotkeys", "DelayBeforeCall"));
            }
            catch (FormatException)
            {
                DelayBeforeCall = 300;
            }
            Key = ini.IniReadValue("Hotkeys", "Key");
            Modifiers = ini.IniReadValue("Hotkeys", "Modifiers");
            try
            {
                key = (Keys)conv.ConvertFromString(Key);
                modifiers = (Keys)conv.ConvertFromString(Modifiers);
            }
            catch (Exception ex)
            {
                EventLogs.WriteLog("Не удалось считать горячие клавиши из настроек", ex.Message);
            }
            var temp = ini.IniReadValue("Hotkeys", "InstantCall");
            if (temp.ToLower().Contains("true"))
                bHotkeyInstantCall = true;
            else if (temp.ToLower().Contains("false"))
                bHotkeyInstantCall = false;
        }
        public void Save()
        {
            ini.IniWriteValue("Hotkeys", "Key", Key);
            ini.IniWriteValue("Hotkeys", "Modifiers", Modifiers.Replace("+None", ""));
            ini.IniWriteValue("Hotkeys", "InstantCall", bHotkeyInstantCall.ToString());
            ini.IniWriteValue("Hotkeys", "DelayBeforeCall", DelayBeforeCall.ToString());
        }

        public object Clone()
        {
            return new HotkeySettings { bHotkeyInstantCall = this.bHotkeyInstantCall, conv = this.conv, DelayBeforeCall = this.DelayBeforeCall, key = this.key, modifiers = this.modifiers };
        }
    }
}
