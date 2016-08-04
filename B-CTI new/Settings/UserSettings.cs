using System;
using System.IO;
using System.Drawing;
using BCTI.Settings;
using BCTI.SettingClasses;

namespace BCTI
{
    public class UserSettings : ICloneable
    {
        /// <summary>
        /// НАСТРОЙКИ БЛФ ПАНЕЛИ
        /// </summary>        
        public ApplicationCommonSettings CommonSettings = new ApplicationCommonSettings();
        //public Point BlfSize = new Point(219, 290);
        //public Point BlfLocation;
        ////Режим не беспокоить
        //public bool bDoNotDisturb = false;
        //public int HistorycardType = 0;
        //public int ContactsBookCardType = 0;

        /// <summary>
        /// HotKeys
        /// </summary>
        public HotkeySettings Hotkey = new HotkeySettings();
        //public string ClickToDialHotkey = "Alt+C";
        //public bool bHotkeyInstantCall = true;
        //public int DelayBeforeCall = 300;

        //Tray Settings
        public TraySettings Tray = new TraySettings();
        //public bool bMinimizedToTray = true;
        //public bool bOneClickOpen = false;
        //public bool bTrayEnabled = true;

        /// <summary>
        /// ИНТЕРФЕЙС
        /// </summary>
        public InterfaceSettings Interface = new InterfaceSettings();
        //public string Language = "russian";
        //public string ThemeStyle = "Default";

        ///User Settings
        ///

        public IntegrationSettings Integration = new IntegrationSettings();
        //public string CallerID = "";
        //public string SIPADDHEADER = "=\"Call-Info:\\;answer-after=0\"";

        ///SystemSettings
        ///
        public SystemSettings SysSettings = new SystemSettings();
        //public bool bOnWindowsStartup = false;

        //(!!!)
        /// <summary>
        /// NiceUSER settings
        /// </summary>
        //Уже в ConnectionSettings
        //public string Number = String.Empty;
        //public string Autoconnect = "False";

        //Расположение файла шаблонов

        public PatternSettings Pattern = new PatternSettings();
        //public string PatternFilePath = string.Empty;

        /// <summary>
        /// SuperUSER settings
        /// </summary>
        public SuperUSERSettings SuperUSER = new SuperUSERSettings();
        //public bool bSuperUSERPass = false;
        //public string SuperUSERPASSWD = "AMIPass";

        //Расположение файлов логов
        public LogsSettings Logs = new LogsSettings();
        //public bool bAmiLogEnabled = true;
        //public bool bEventLogEnabled = true;
        //public string EventLogFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\B-Cti\\log\\";
        //public string AmiLogFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\B-Cti\\log\\";

        public PlaybackSettings Playback = new PlaybackSettings();
        //public string PlaybackSaveFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\B-Cti\\PlayBack\\";
        //public string PlaybackServerFolder = string.Empty;

        public int Timeout = 45;

        public ScriptSettings Script = new ScriptSettings();
        //public string BatFilePath = "\\default.bat";
        //public string ParamString = string.Empty;
        
        public string ServerUpdatePath = "localhost";
        public string SaveFilePath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\B-Cti\\UserSettings.ini";

        IniSettings ini = new IniSettings();

        public object Clone()
        {
            return new UserSettings { SysSettings = (SystemSettings)this.SysSettings.Clone(), Interface = (InterfaceSettings)this.Interface.Clone(),
            Script = (ScriptSettings)this.Script.Clone(), CommonSettings = (ApplicationCommonSettings)this.CommonSettings.Clone(), Hotkey = (HotkeySettings)this.Hotkey.Clone(),
            Integration = (IntegrationSettings)this.Integration.Clone(), Logs = (LogsSettings)this.Logs.Clone(), Pattern = (PatternSettings)this.Pattern.Clone(),
            Playback = (PlaybackSettings)this.Playback.Clone(), SaveFilePath = (string)this.SaveFilePath.Clone(), ServerUpdatePath = (string)this.ServerUpdatePath,
            SuperUSER = (SuperUSERSettings)this.SuperUSER.Clone(), Tray = (TraySettings)this.Tray };
        }
        public UserSettings()
        {
            if (File.Exists(SaveFilePath))
            {
                string temp;

                //string loc = ini.IniReadValue("ApplicationCommon", "BLFLocation");
                //loc = loc.Replace(" ", "");
                //var location = loc.Split('x');
                //try
                //{
                //    BlfLocation.X = int.Parse(location[0]);
                //    BlfLocation.Y = int.Parse(location[1]);

                //}
                //catch (FormatException)
                //{
                //    BlfLocation.X = 100;
                //    BlfLocation.Y = 100;
                //}

                //string size = ini.IniReadValue("ApplicationCommon", "BLFSize");
                //size = size.Replace(" ", "");
                //var tmpsize = size.Split('x');
                //try
                //{
                //    BlfSize.X = int.Parse(tmpsize[0]);
                //    BlfSize.Y = int.Parse(tmpsize[1]);
                //}
                //catch (FormatException)
                //{
                //    BlfLocation.X = 219;
                //    BlfLocation.Y = 188;
                //}

                //try
                //{
                //    ContactsBookCardType = int.Parse(ini.IniReadValue("ApplicationCommon", "ContactBookType"));
                //    HistorycardType = int.Parse(ini.IniReadValue("ApplicationCommon", "HistoryCardType"));
                //}
                //catch (FormatException)
                //{
                //    HistorycardType = 0;
                //    ContactsBookCardType = 0;
                //}
                //try
                //{
                //    DelayBeforeCall = int.Parse(ini.IniReadValue("Hotkeys", "DelayBeforeCall"));
                //}
                //catch (FormatException)
                //{
                //    DelayBeforeCall = 300;
                //}
                //temp = ini.IniReadValue("ApplicationCommon", "DoNotDisturb");
                //if (temp.ToLower().Contains("true"))
                //    bDoNotDisturb = true;
                //else if (temp.ToLower().Contains("false"))
                //    bDoNotDisturb = false;

                //ClickToDialHotkey = ini.IniReadValue("Hotkeys", "ClickToDialHotkey");
                //temp = ini.IniReadValue("Hotkeys", "InstantCall");
                //if (temp.ToLower().Contains("true"))
                //    bHotkeyInstantCall = true;
                //else if (temp.ToLower().Contains("false"))
                //    bHotkeyInstantCall = false;

                //temp = ini.IniReadValue("Tray", "MinimizeToTray");
                //if (temp.ToLower().Contains("true"))
                //    bMinimizedToTray = true;
                //else if (temp.ToLower().Contains("false"))
                //    bMinimizedToTray = false;
                //temp = ini.IniReadValue("Tray", "OneClickOpen");
                //if (temp.ToLower().Contains("true"))
                //    bOneClickOpen = true;
                //else if (temp.ToLower().Contains("false"))
                //    bOneClickOpen = false;
                //temp = ini.IniReadValue("Tray", "TrayEnabled");
                //if (temp.ToLower().Contains("true"))
                //    bTrayEnabled = true;
                //else if (temp.ToLower().Contains("false"))
                //    bTrayEnabled = false;

                //temp = ini.IniReadValue("SuperUser", "SUEnabled");
                //if (temp.ToLower().Contains("true"))
                //    bSuperUSERPass = true;
                //else if (temp.ToLower().Contains("false"))
                //    bSuperUSERPass = false;

                //SuperUSERPASSWD = ini.IniReadValue("SuperUser", "SUPassword");

                //Language = ini.IniReadValue("Localization", "language");

                //if (!string.IsNullOrEmpty(ini.IniReadValue("Directories", "EventLogFolder")))
                //    EventLogFolder = ini.IniReadValue("Directories", "EventLogFolder");
                //if (!string.IsNullOrEmpty(ini.IniReadValue("Directories", "AmiLogFolder")))
                //    AmiLogFolder = ini.IniReadValue("Directories", "AmiLogFolder");
                //if (!string.IsNullOrEmpty(ini.IniReadValue("Directories", "PlaybackSaveFolder")))
                //    PlaybackSaveFolder = ini.IniReadValue("Directories", "PlaybackSaveFolder"); 
                //PlaybackServerFolder = ini.IniReadValue("Directories", "PlaybackServerFolder");

                //if (!string.IsNullOrEmpty(ini.IniReadValue("ServerSettings", "SIPADDHEADER")))
                //    SIPADDHEADER = ini.IniReadValue("ServerSettings", "SIPADDHEADER");

                //if (!string.IsNullOrEmpty(ini.IniReadValue("Directories", "BatfileFolder")))
                //    BatFilePath = ini.IniReadValue("Directories", "BatfileFolder");

                //if (!string.IsNullOrEmpty(ini.IniReadValue("ScriptSettings", "ScriptPath")))
                //    BatFilePath = ini.IniReadValue("ScriptSettings", "ScriptPath");
                //else
                //    BatFilePath = "";
                //if (!string.IsNullOrEmpty(ini.IniReadValue("ScriptSettings", "ScriptParams")))
                //    ParamString = ini.IniReadValue("ScriptSettings", "ScriptParams");
                //else
                //    ParamString = "";

                //if (!string.IsNullOrEmpty(ini.IniReadValue("PatternSettings", "PatternFilePath")))
                //    PatternFilePath = ini.IniReadValue("PatternSettings", "PatternFilePath");
                //else
                //    PatternFilePath = "";

                //if (!string.IsNullOrEmpty(ini.IniReadValue("Connection", "Number")))
                //    Number = ini.IniReadValue("Connection", "Number");
                //else
                //    Number = "";
                //if (!string.IsNullOrEmpty(ini.IniReadValue("Connection", "Autoconnect")))
                //    Autoconnect = ini.IniReadValue("Connection", "Autoconnect");
                //else
                //    Autoconnect = "False";
            }
            else
            {

                ini.path = SaveFilePath;
                if (!Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\B-Cti\\"))
                    Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\B-Cti\\");
                StreamWriter file = new StreamWriter(SaveFilePath);
                file.WriteLine("#UserSettings.ini contains application main settings \r\n#You can add custom settings using this string type: SettingName = SettingParameter");
                file.Close();

                CommonSettings.SaveSettings();
                //ini.IniWriteValue("ApplicationCommon", "BLFLocation", BlfLocation.X + "x" + BlfLocation.Y);
                //ini.IniWriteValue("ApplicationCommon", "BLFSize", BlfSize.X + "x" + BlfSize.Y);
                //ini.IniWriteValue("ApplicationCommon", "ContactBookType", ContactsBookCardType.ToString());
                //ini.IniWriteValue("ApplicationCommon", "HistoryCardType", HistorycardType.ToString());
                //ini.IniWriteValue("ApplicationCommon", "DoNotDisturb", bDoNotDisturb.ToString());
                Hotkey.Save();
                //ini.IniWriteValue("Hotkeys", "ClickToDialHotkey", ClickToDialHotkey);
                //ini.IniWriteValue("Hotkeys", "InstantCall", bHotkeyInstantCall.ToString());
                //ini.IniWriteValue("Hotkeys", "DelayBeforeCall", DelayBeforeCall.ToString());
                Tray.Save();
                //ini.IniWriteValue("Tray", "MinimizeToTray", bMinimizedToTray.ToString());
                //ini.IniWriteValue("Tray", "OneClickOpen", bOneClickOpen.ToString());
                //ini.IniWriteValue("Tray", "TrayEnabled", bTrayEnabled.ToString());
                Integration.Save();
                //ini.IniWriteValue("ServerSettings", "SIPADDHEADER", SIPADDHEADER);
                SysSettings.Save();
                SuperUSER.Save();
                //ini.IniWriteValue("SuperUser", "SUEnabled", bSuperUSERPass.ToString());
                //ini.IniWriteValue("SuperUser", "SUPassword", SuperUSERPASSWD.ToString());
                Interface.Save();
                //ini.IniWriteValue("Localization", "language", Language);
                Logs.Save();
                //ini.IniWriteValue("Directories", "EventLogFolder", EventLogFolder);
                //ini.IniWriteValue("Directories", "AmiLogFolder", AmiLogFolder);
                Script.Save();
                //ini.IniWriteValue("Directories", "BatfileFolder", BatFilePath);
                Playback.Save();
                //ini.IniWriteValue("Directories", "PlaybackServerFolder", PlaybackServerFolder);
                //ini.IniWriteValue("Directories", "PlaybackSaveFolder", PlaybackSaveFolder);

                //ini.IniWriteValue("ScriptSettings", "ScriptPath", BatFilePath);
                //ini.IniWriteValue("ScriptSettings", "ScriptParams", ParamString);
                Pattern.Save();
                //ini.IniWriteValue("PatternSettings", "PatternFilePath", PatternFilePath);

                //if (!string.IsNullOrEmpty(Number))
                //    ini.IniWriteValue("UserSettings", "Number", Number);
                //if (!string.IsNullOrEmpty(Autoconnect))
                //    ini.IniWriteValue("UserSettings", "Autoconnect", Autoconnect);
            }
        }
        public void SaveSettings()
        {
            ini.path = SaveFilePath;

            CommonSettings.SaveSettings();
            //ini.IniWriteValue("ApplicationCommon", "BLFLocation", BlfLocation.X + "x" + BlfLocation.Y);
            //ini.IniWriteValue("ApplicationCommon", "BLFSize", BlfSize.X + "x" + BlfSize.Y);
            //ini.IniWriteValue("ApplicationCommon", "ContactBookType", ContactsBookCardType.ToString());
            //ini.IniWriteValue("ApplicationCommon", "HistoryCardType", HistorycardType.ToString());
            //ini.IniWriteValue("ApplicationCommon", "DoNotDisturb", bDoNotDisturb.ToString());
            Hotkey.Save();
            //ini.IniWriteValue("Hotkeys", "ClickToDialHotkey", ClickToDialHotkey);
            //ini.IniWriteValue("Hotkeys", "InstantCall", bHotkeyInstantCall.ToString());
            //ini.IniWriteValue("Hotkeys", "DelayBeforeCall", DelayBeforeCall.ToString());
            Tray.Save();
            //ini.IniWriteValue("Tray", "MinimizeToTray", bMinimizedToTray.ToString());
            //ini.IniWriteValue("Tray", "OneClickOpen", bOneClickOpen.ToString());
            //ini.IniWriteValue("Tray", "TrayEnabled", bTrayEnabled.ToString());
            Integration.Save();
            //ini.IniWriteValue("ServerSettings", "SIPADDHEADER", SIPADDHEADER);
            SysSettings.Save();
            SuperUSER.Save();
            //ini.IniWriteValue("SuperUser", "SUEnabled", bSuperUSERPass.ToString());
            //ini.IniWriteValue("SuperUser", "SUPassword", SuperUSERPASSWD.ToString());
            Interface.Save();
            //ini.IniWriteValue("Localization", "language", Language);
            Logs.Save();
            //ini.IniWriteValue("Directories", "EventLogFolder", EventLogFolder);
            //ini.IniWriteValue("Directories", "AmiLogFolder", AmiLogFolder);
            //ini.IniWriteValue("Directories", "BatfileFolder", BatFilePath);
            Playback.Save();
            //ini.IniWriteValue("Directories", "PlaybackServerFolder", PlaybackServerFolder);
            //ini.IniWriteValue("Directories", "PlaybackSaveFolder", PlaybackSaveFolder);
            Script.Save();
            //ini.IniWriteValue("ScriptSettings", "ScriptPath", BatFilePath);
            //ini.IniWriteValue("ScriptSettings", "ScriptParams", ParamString);
            Pattern.Save();
            //ini.IniWriteValue("PatternSettings", "PatternFilePath", PatternFilePath);
            //if (!string.IsNullOrEmpty(Number))
            //    ini.IniWriteValue("ConnectionSettings", "Number", Number);
            //if (!string.IsNullOrEmpty(Autoconnect))
            //    ini.IniWriteValue("ConnectionSettings", "Autoconnect", Autoconnect);
        }
    }
}
