using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BCTI.Settings
{
    public class PlaybackSettings : ICloneable
    {
        private readonly IniSettings ini = new IniSettings();
        public string PlaybackSaveFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\B-Cti\\PlayBack\\";
        public string PlaybackServerFolder = string.Empty;

        public PlaybackSettings()
        {
            ini.path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\B-Cti\\UserSettings.ini";

            if (!string.IsNullOrEmpty(ini.IniReadValue("Directories", "PlaybackSaveFolder")))
                PlaybackSaveFolder = ini.IniReadValue("Directories", "PlaybackSaveFolder");
            PlaybackServerFolder = ini.IniReadValue("Directories", "PlaybackServerFolder");
        }

        public void Save()
        {
            ini.IniWriteValue("Directories", "PlaybackServerFolder", PlaybackServerFolder);
            ini.IniWriteValue("Directories", "PlaybackSaveFolder", PlaybackSaveFolder);
        }

        public object Clone()
        {
            return new PlaybackSettings { PlaybackSaveFolder = this.PlaybackSaveFolder , PlaybackServerFolder = this.PlaybackServerFolder };
        }
    }
}
