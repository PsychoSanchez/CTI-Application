using System;
using System.Drawing;
using System.Windows.Forms;
using System.Security.Principal;
using AsteriskManager;
using System.IO;
using System.Collections.Generic;
using BCTI.Helpers;

namespace BCTI.SettingUC
{
    public partial class ConnectionSettingsForm : UserControl
    {
        public bool ConnectSettingsChanged = false;
        Dictionary<string, string[]> Localization = new Dictionary<string, string[]>();
        /// <summary>
        /// Проверка на наличие прав администратора
        /// </summary>
        /// <returns></returns>
        public bool IsUserAdministrator()
        {
            //bool value to hold our return value
            bool isAdmin;
            WindowsIdentity user = null;
            try
            {
                //get the currently logged in user
                user = WindowsIdentity.GetCurrent();
                WindowsPrincipal principal = new WindowsPrincipal(user);
                isAdmin = principal.IsInRole(WindowsBuiltInRole.Administrator);
            }
            catch (UnauthorizedAccessException)
            {
                isAdmin = false;
            }
            catch (Exception)
            {
                isAdmin = false;
            }
            finally
            {
                if (user != null)
                    user.Dispose();
            }
            return isAdmin;
        }
        ConnectionSettings settings = new ConnectionSettings();
        /// <summary>
        /// Конструктор формы
        /// </summary>
        public ConnectionSettingsForm()
        {
            ConnectSettingsChanged = false;
            InitializeComponent();
            //AutoConnect.Text = "Автоматическое подключение";
            //MD5Auth.Text = "Использовать MD5 шифрование для подключения к серверу";

            Localization = Localizator.GetFormLocalization(this.Name, SettingsForm.settings.Interface.Language);
            Localizator.MakeLocalization(this, Localization);
            BLFPanel.ApplyLanguage += BLFPanel_ApplyLanguage;

            UserInterfaceAPI.InitFonts(this);
            UserInterfaceAPI.SetFontStyle(groupBox1, FontStyle.Bold | FontStyle.Italic);
            UserInterfaceAPI.SetFontStyle(groupBox2, FontStyle.Bold | FontStyle.Italic);
            ///Если есть права администратора, тогда показываем форму, иначе выводим соответствующее сообщение
            if (IsUserAdministrator())
            {
                this.Dock = DockStyle.Fill;
                loginTextbox.Text = settings.Username;
                passTextbox.Text = settings.Password;
                ipserverTextbox.Text = settings.IP;
                portTextbox.Text = settings.Port;
                numberTextbox.Text = settings.Number;
                MD5Auth.Checked = settings.MD5;
                AutoConnect.Checked = settings.Autoconnect;
            }
            else
            {
                this.Dock = DockStyle.Fill;
                panel1.Hide();
                panel2.Hide();
                panel3.Hide();
                panel4.Hide();
                panel5.Hide();
                Label noRights = new Label();
                noRights.Name = "noRights";
                noRights.Dock = DockStyle.Fill;
                noRights.TextAlign = ContentAlignment.MiddleCenter;
                noRights.ForeColor = Color.FromArgb(160, 160, 160);
                noRights.Font = new Font("Century Gothic", 12);
                noRights.BorderStyle = BorderStyle.None;
                noRights.BackColor = Colors.WhiteTheme.MainColor;
                try
                {
                    noRights.Text = Localization[noRights.Name][0];
                }
                catch
                {
                    noRights.Text = "Нет прав доступа.\r\nЗапустите приложение от имени администратора, чтобы просматривать эти настройки";
                }

                Controls.Add(noRights);
            }
        }

        private void BLFPanel_ApplyLanguage(object sender, EventArgs e)
        {
            Localization = Localizator.GetFormLocalization(this.Name, BLFPanel.Staticsettings.Interface.Language);
            Localizator.MakeLocalization(this, Localization);
        }

        /// <summary>
        /// Событие сохранения настроек
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveSettingsClicked(object sender, EventArgs e)
        {
            int result;
            int inputDataError = 0;
            ConnectionSettings userSettings = new ConnectionSettings();
            userSettings.Username = loginTextbox.Text;
            if (loginTextbox.Text == "")
            {
                loginTextbox.BackColor = Color.FromArgb(255, 128, 128);
                inputDataError = 1;
            }
            else
            {
                loginTextbox.BackColor = SystemColors.Window;
            }
            userSettings.Password = passTextbox.Text;
            if (passTextbox.Text == "")
            {
                passTextbox.BackColor = Color.FromArgb(255, 128, 128);
                inputDataError = 1;
            }
            else
            {
                passTextbox.BackColor = SystemColors.Window;
            }
            userSettings.IP = ipserverTextbox.Text;
            if (ipserverTextbox.Text == "")
            {
                ipserverTextbox.BackColor = Color.FromArgb(255, 128, 128);
                inputDataError = 1;
            }
            else
            {
                ipserverTextbox.BackColor = SystemColors.Window;
            }
            userSettings.Port = portTextbox.Text;
            if (!Int32.TryParse(portTextbox.Text, out result) || portTextbox.Text == "")
            {
                portTextbox.BackColor = Color.FromArgb(255, 128, 128);
                inputDataError = 1;
            }
            else
            {
                portTextbox.BackColor = SystemColors.Window;
            }
            userSettings.Number = numberTextbox.Text;
            if (!Int32.TryParse(numberTextbox.Text, out result) || numberTextbox.Text == "")
            {
                numberTextbox.BackColor = Color.FromArgb(255, 128, 128);
                inputDataError = 1;
            }
            else
            {
                numberTextbox.BackColor = SystemColors.Window;
            }
            userSettings.Autoconnect = AutoConnect.Checked;
            //if (AutoConnect.Checked)
            //{
            //    userSettings.Autoconnect = true;
            //}
            if (inputDataError == 1)
            {
                return;
            }
            else
            {
                userSettings.SaveSettings();
            }
        }

        #region Handlers
        private void SaveAndApply_MouseEnter(object sender, EventArgs e)
        {
            SaveAndApply.BackColor = Color.FromArgb(102, 153, 255);
        }

        private void SaveAndApply_MouseLeave(object sender, EventArgs e)
        {
            SaveAndApply.BackColor = Color.FromArgb(160, 160, 160);
        }
        #endregion
    }
}
