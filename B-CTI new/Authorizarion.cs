using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using AsteriskManager;
using AsteriskManager.Exceptions;
using BCTI.DialogBoxes;
using BCTI.Helpers;
using BCTI.Settings;
using System.Collections.Generic;

namespace BCTI
{
    public partial class Authorization : Form
    {
        public int loginComplete = 0;
        public bool bLoginSuccess = false;
        int reconCounter = 0;
        public event EventHandler LoginComplete;
        bool defSettings = false;
        BackgroundWorker reconnectThread;
        string path = Directory.GetCurrentDirectory();
        public AMIManager loginAmiManager { get; private set; }
        bool MD5Authorization = true;
        ConnectionSettings set = new ConnectionSettings();
        Dictionary<string, string[]> Localization = new Dictionary<string, string[]>();
        /// <summary>
        /// Конструктор панели авторизации
        /// </summary>
        public Authorization()
        {

            loginAmiManager = new AMIManager();
            InitializeComponent();

            Localization = Localizator.GetFormLocalization(this.Name, BLFPanel.Staticsettings.Interface.Language);
            Localizator.MakeLocalization(this, Localization);
            BLFPanel.ApplyLanguage += GeneralSettings_Language_Changed;
            try
            {
                AutoConnect.SetText(Localization[AutoConnect.Name][0]);
            }
            catch (Exception)
            {
                AutoConnect.SetText("Автоподключение");
            }

            exitButton.BackgroundImage = closeButtonImage.Images[0];
            string Autoconnect = string.Empty;
            if (File.Exists(System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "\\B-CtiSys.ini"))
            {
                numberTextbox.Text = set.Number;

                AutoConnect.Checked = set.Autoconnect;
                loginTextbox.Text = set.Username;
                passTextbox.Text = set.Password;
                ipserverTextbox.Text = set.IP;
                portTextbox.Text = set.Port;
                MD5Authorization = set.MD5;
                if (!RightsChecker.IsUserAdministrator())
                {
                    loginTextbox.Enabled = false;
                    passTextbox.Enabled = false;
                    ipserverTextbox.Enabled = false;
                    portTextbox.Enabled = false;
                    toolTip1.SetToolTip(mainPanel, "Запустите приложение от имени администратора, чтобы редактировать настройки подключения");
                    numberTextbox.Enabled = string.IsNullOrEmpty(numberTextbox.Text);
                }
            }
            else
            {
                if (!RightsChecker.IsUserAdministrator())
                {
                    mainPanel.Enabled = false;
                    autoconnectPanel.Enabled = false;
                    acceptButton.Text = "Restart";
                    acceptButton.Font = new Font("Arial", 11, FontStyle.Bold);
                    StatusLabel.Text = "Отсутствует файл с настройками. Перезапустите приложение от администратора.";
                    toolTip1.SetToolTip(StatusLabel, "Отсутствует файл с настройками. Перезапустите приложение от имени администратора и введите данные для подключения.");
                    toolTip1.SetToolTip(mainPanel, "Отсутствует файл с настройками. Перезапустите приложение от имени администратора и введите данные для подключения.");
                    toolTip1.SetToolTip(autoconnectPanel, "Отсутствует файл с настройками. Перезапустите приложение от имени администратора и введите данные для подключения.");
                    toolTip1.SetToolTip(acceptButton, "Перезапустить приложение от имени администратора");
                }
                else
                {
                    portTextbox.Text = "5038";
                    set.Port = "5038";
                    EventLogs.WriteLog("Пользователь имеет права адмиистратора");
                }
            }

            //AutoConnect.Text = "Автоматическое подключение";
            ///Шрифты
            UserInterfaceAPI.InitFonts(this);
            UserInterfaceAPI.SetFontStyle(headPanel, FontStyle.Bold);
        }

        /// <summary>
        /// Выход из формы и запуск панели
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ReconnectThread_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (bLoginSuccess)
            {
                LoginComplete?.Invoke(this, null);
                exitButton_Click(this, null);
            }
        }
        /// <summary>
        /// Кнопка Войти
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void acceptButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (acceptButton.Text == Localization[acceptButton.Name][1])
                {
                    acceptButton.Text = Localization[acceptButton.Name][0];
                    StatusLabel.Text = Localization[StatusLabel.Name][2];
                    Application.DoEvents();
                    reconnectThread.CancelAsync();
                    reconnectThread.Dispose();
                    reconnectThread = null;
                    return;
                }
            }
            catch (Exception)
            {
                if (acceptButton.Text == "Отмена")
                {
                    acceptButton.Text = "Войти";
                    StatusLabel.Text = "Подключение отменено пользователем";
                    Application.DoEvents();
                    reconnectThread.CancelAsync();
                    reconnectThread.Dispose();
                    reconnectThread = null;
                    return;
                }
            }
            if (acceptButton.Text == "Restart")
            {
                ///Перезапускаем приложение от имени администратора
                ProcessStartInfo processInfo = new ProcessStartInfo(); //создаем новый процесс
                processInfo.Verb = "runas"; //в данном случае указываем, что процесс должен быть запущен с правами администратора
                processInfo.FileName = Application.ExecutablePath;
                Process.Start(processInfo);
                Application.Exit();
                return;
            }
            int result;
            int inputDataError = 0;

            ///Проверка правильности введенных данных
            if (loginTextbox.Text == "")
            {
                loginTextbox.BackColor = Color.FromArgb(255, 128, 128);
                inputDataError = 1;
            }
            else
            {
                loginTextbox.BackColor = SystemColors.Window;
            }
            if (passTextbox.Text == "")
            {
                passTextbox.BackColor = Color.FromArgb(255, 128, 128);
                inputDataError = 1;
            }
            else
            {
                passTextbox.BackColor = SystemColors.Window;
            }
            if (ipserverTextbox.Text == "")
            {
                ipserverTextbox.BackColor = Color.FromArgb(255, 128, 128);
                inputDataError = 1;
            }
            else
            {
                ipserverTextbox.BackColor = SystemColors.Window;
            }
            if (!Int32.TryParse(portTextbox.Text, out result) || portTextbox.Text == "")
            {
                portTextbox.BackColor = Color.FromArgb(255, 128, 128);
                inputDataError = 1;
            }
            else
            {
                portTextbox.BackColor = SystemColors.Window;
            }
            if (!Int32.TryParse(numberTextbox.Text, out result) || numberTextbox.Text == "")
            {
                numberTextbox.BackColor = Color.FromArgb(255, 128, 128);
                inputDataError = 1;
            }
            else
            {
                numberTextbox.BackColor = SystemColors.Window;
            }

            try
            {
                if (inputDataError == 1)
                {
                    StatusLabel.Text = Localization[StatusLabel.Name][7];
                    return;
                }
                else
                {
                    acceptButton.Text = Localization[acceptButton.Name][1];
                }
            }
            catch (Exception)
            {
                if (inputDataError == 1)
                {
                    StatusLabel.Text = "Неверно введены данные";
                    return;
                }
                else
                {
                    acceptButton.Text = "Отмена";
                }
            }

            set.Username = loginTextbox.Text;
            set.Password = passTextbox.Text;
            set.IP = ipserverTextbox.Text;
            set.Port = portTextbox.Text;
            set.Autoconnect = AutoConnect.Checked;
            set.Number = numberTextbox.Text;
            ///Запускаем гуся работяги
            if (reconnectThread == null)
            {
                reconnectThread = new BackgroundWorker();
            }
            if (!reconnectThread.IsBusy)
            {
                reconnectThread.WorkerSupportsCancellation = true;
                reconnectThread.DoWork += ReconnectThread_DoWork;
                reconnectThread.RunWorkerCompleted += ReconnectThread_RunWorkerCompleted;
                reconnectThread.RunWorkerAsync();
            }
        }
        /// <summary>
        /// Функция подключения
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ReconnectThread_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker bw = sender as BackgroundWorker;
            while (reconCounter < 3 && !bw.CancellationPending)
            {
                try
                {
                    StatusLabel.BeginInvoke(
                        (MethodInvoker)(() =>
                        {
                            try
                            {
                                StatusLabel.Text = Localization[StatusLabel.Name][1] + (reconCounter + 1);
                            }
                            catch (Exception ex)
                            {
                                EventLogs.WriteLog(ex.Message, ex.StackTrace);
                                StatusLabel.Text = "Подключение";
                                for (int i = 0; i < reconCounter; i++)
                                {
                                    StatusLabel.Text += ".";
                                }
                            }
                        }));
                    try
                    {
                        ///Использование мд5 шифрования
                        if (MD5Authorization)
                        {
                            ///Если подключение прошло успешно, то сохраняем настройки иначе выводим ошибку
                            if (loginAmiManager.ConnectMD5(loginTextbox.Text, passTextbox.Text, ipserverTextbox.Text, Int32.Parse(portTextbox.Text)))
                            {
                                bLoginSuccess = true;
                                reconCounter = 3;
                                if (loginAmiManager.Initialize(set.Number))
                                {
                                    StatusLabel.BeginInvoke(
                                        (MethodInvoker)(() =>
                                        {
                                            try
                                            {
                                                StatusLabel.Text = Localization[StatusLabel.Name][3];
                                            }
                                            catch (Exception ex)
                                            {
                                                EventLogs.WriteLog(ex.Message, ex.StackTrace);
                                                StatusLabel.Text = "Успешный вход";
                                            }
                                        }));
                                }
                                else
                                {

                                    StatusLabel.BeginInvoke(
                                            (MethodInvoker)(() =>
                                            {
                                                try
                                                {
                                                    StatusLabel.Text = Localization[StatusLabel.Name][4];

                                                }
                                                catch (Exception ex)
                                                {
                                                    EventLogs.WriteLog(ex.Message, ex.StackTrace);
                                                    StatusLabel.Text = "Успешный вход. !Ошибка при инициализации!";
                                                }
                                            }));
                                }
                                e.Cancel = true;
                                set.SaveSettings();
                            }
                            else
                            {
                                if (!bw.CancellationPending)
                                {
                                    StatusLabel.BeginInvoke((MethodInvoker)(() => StatusLabel.Text = "Отказано сервером"));
                                    loginAmiManager.Abort();
                                    e.Cancel = true;
                                    reconCounter = 0;
                                    if (!this.IsDisposed)
                                        acceptButton.BeginInvoke((MethodInvoker)(() => acceptButton.Text = "Войти"));
                                    return;
                                }
                                else
                                {
                                    //StatusLabel.BeginInvoke((MethodInvoker)(() => StatusLabel.Text = "Отменено пользователем"));
                                    loginAmiManager.Abort();
                                    reconCounter = 0;
                                    e.Cancel = true;
                                    return;
                                }
                            }
                        }
                        else
                        {
                            ///Если подключение прошло успешно, то сохраняем настройки иначе выводим ошибку
                            if (loginAmiManager.Connect(loginTextbox.Text, passTextbox.Text, ipserverTextbox.Text, Int32.Parse(portTextbox.Text)))
                            {
                                bLoginSuccess = true;
                                reconCounter = 3;
                                if (loginAmiManager.Initialize(set.Number))
                                {
                                    StatusLabel.BeginInvoke((MethodInvoker)(() => StatusLabel.Text = "Успешный вход"));
                                }
                                else
                                {
                                    StatusLabel.BeginInvoke((MethodInvoker)(() => StatusLabel.Text = "Успешный вход. !Ошибка при инициализации!"));
                                }
                                e.Cancel = true;
                                set.SaveSettings();
                            }
                            else
                            {
                                if (!bw.CancellationPending)
                                {
                                    StatusLabel.BeginInvoke(
                                        (MethodInvoker)(() =>
                                        {
                                            try
                                            {
                                                StatusLabel.Text = Localization[StatusLabel.Name][5];
                                            }
                                            catch (Exception ex)
                                            {
                                                EventLogs.WriteLog(ex.Message, ex.StackTrace);
                                                StatusLabel.Text = "Отказано сервером";
                                            }
                                        }));
                                    loginAmiManager.Abort();
                                    e.Cancel = true;
                                    reconCounter = 0;
                                    if (!this.IsDisposed)
                                        acceptButton.BeginInvoke(
                                            (MethodInvoker)(() =>
                                            {
                                                try
                                                {
                                                    acceptButton.Text = Localization[acceptButton.Name][1];
                                                }
                                                catch (Exception ex)
                                                {
                                                    EventLogs.WriteLog(ex.Message, ex.StackTrace);
                                                    acceptButton.Text = "Войти";
                                                }
                                            }));
                                    return;
                                }
                                else
                                {
                                    StatusLabel.BeginInvoke((MethodInvoker)(() => StatusLabel.Text = "Отменено пользователем"));
                                    loginAmiManager.Abort();
                                    reconCounter = 0;
                                    e.Cancel = true;
                                    return;
                                }
                            }
                        }
                    }
                    catch (AmiTimeOutException)
                    {
                        reconCounter++;
                    }
                    catch (AmiException ex)
                    {
                        e.Cancel = true;
                        reconCounter = 0;
                        StatusLabel.BeginInvoke((MethodInvoker)(() => StatusLabel.Text = ex.Message.ToString()));
                        loginAmiManager.Abort();
                        if (!this.IsDisposed)
                            acceptButton.BeginInvoke(
                                (MethodInvoker)(() =>
                                {
                                    try
                                    {
                                        acceptButton.Text = Localization[acceptButton.Name][1];
                                    }
                                    catch (Exception exc)
                                    {
                                        EventLogs.WriteLog(exc.Message, exc.StackTrace);
                                        acceptButton.Text = "Войти";
                                    }
                                }));

                        return;
                    }
                }
                catch (InvalidOperationException)
                {
                    return;
                }
                try
                {
                    if (reconCounter == 3 && bLoginSuccess == false)
                    {
                        StatusLabel.BeginInvoke((MethodInvoker)(() =>
                        {
                            try
                            {
                                StatusLabel.Text = Localization[StatusLabel.Name][6];
                            }
                            catch (Exception exc)
                            {
                                EventLogs.WriteLog(exc.Message, exc.StackTrace);
                                StatusLabel.Text = "Не удалось подключиться к серверу";
                            }
                        }));
                        if (!this.IsDisposed)
                            acceptButton.BeginInvoke(
                                (MethodInvoker)(() =>
                                {
                                    try
                                    {
                                        acceptButton.Text = Localization[acceptButton.Name][1];
                                    }
                                    catch (Exception exc)
                                    {
                                        EventLogs.WriteLog(exc.Message, exc.StackTrace);
                                        acceptButton.Text = "Войти";
                                    }
                                }));
                        reconCounter = 0;
                        e.Cancel = true;
                        return;
                    }
                }
                catch (InvalidOperationException)
                {
                    return;
                }
            }
        }
        /// <summary>
        /// Автоматическое подключение
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Authorization_Shown(object sender, EventArgs e)
        {
            if (AutoConnect.Checked)
            {
                acceptButton_Click(this, null);
            }
        }

        private void GeneralSettings_Language_Changed(object sender, EventArgs e)
        {
            Localization = Localizator.GetFormLocalization("Authorization", BLFPanel.Staticsettings.Interface.Language);
            Localizator.MakeLocalization(this, Localization);
            try
            {
                AutoConnect.SetText(Localization[AutoConnect.Name][0]);
            }
            catch (Exception)
            {
                AutoConnect.SetText("Автоподключение");
            }
        }

        /// <summary>
        /// Кнопка закрытия формы авторизации
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exitButton_Click(object sender, EventArgs e)
        {
            if (!bLoginSuccess)
                loginAmiManager.Abort();

            Close();
        }
        #region DefaultHandlers

        private void exitButton_MouseEnter(object sender, EventArgs e)
        {
            exitButton.BackgroundImage = closeButtonImage.Images[1];
        }

        private void exitButton_MouseLeave(object sender, EventArgs e)
        {
            if (!Disposing && !IsDisposed)
                exitButton.BackgroundImage = closeButtonImage.Images[0];
        }

        private Point lastCursor;
        private Point lastForm;
        private bool isDragging = false;

        private void headPanel_MouseDown(object sender, MouseEventArgs e)
        {
            isDragging = true;
            lastCursor = Cursor.Position;
            lastForm = this.Location;
        }

        private void headPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                this.Location =
                    Point.Add(lastForm, new Size(Point.Subtract(Cursor.Position, new Size(lastCursor))));
            }
        }

        private void headPanel_MouseUp(object sender, MouseEventArgs e)
        {
            isDragging = false;
        }

        private void headPanel_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        private void acceptButton_MouseEnter(object sender, EventArgs e)
        {
            acceptButton.BackColor = Color.FromArgb(102, 153, 255);
        }

        private void acceptButton_MouseLeave(object sender, EventArgs e)
        {
            acceptButton.BackColor = Colors.WhiteTheme.ButtonMainColor;
        }

        private void loginTextbox_Enter(object sender, EventArgs e)
        {
            //TextBox t = sender as TextBox;
            //t.BorderStyle = BorderStyle.FixedSingle;
        }

        private void loginTextbox_Leave(object sender, EventArgs e)
        {
            //TextBox t = sender as TextBox;
            //t.BorderStyle = BorderStyle.None;
        }



        private void acceptButton_Enter(object sender, EventArgs e)
        {
            acceptButton.BackColor = Color.FromArgb(102, 153, 255);
        }

        private void acceptButton_Leave(object sender, EventArgs e)
        {
            acceptButton.BackColor = Colors.WhiteTheme.ButtonMainColor;
        }

        #endregion
        #region Проверка вводимых данных

        bool alreadychanged = false;
        private void ipserver_TextChanged(object sender, EventArgs e)
        {
            if (alreadychanged)
            {
                alreadychanged = false;
                return;
            }
            TextBox temp = (TextBox)sender;
            if (!string.IsNullOrEmpty(temp.Text))
            {
                if (temp.Text.Contains(','))
                {
                    temp.Text = temp.Text.Replace(",", ".");
                    temp.SelectionStart = temp.Text.Length;
                    alreadychanged = true;
                    return;
                }
                if (temp.Text.Count(p => p == '.') == 3)
                {
                    int k = temp.Text.Length - 1;
                    while (temp.Text[k] != '.')
                        k--;
                    string IPpart = temp.Text.Substring(k + 1);
                    if (IPpart.Length > 3)
                    {
                        temp.Text = temp.Text.Remove(temp.Text.Length - 1);
                        alreadychanged = true;
                        return;
                    }
                }
                string digits = "1234567890.";
                int j = 0;
                bool find = false;
                for (j = 0; j < temp.Text.Length; j++)
                {
                    if (!digits.Contains(temp.Text[j]))
                    {
                        find = true;
                        break;
                    }
                }
                if (find)
                {
                    temp.Text = temp.Text.Remove(j, 1);
                    temp.SelectionStart = j;
                    alreadychanged = true;
                    return;
                }
                int i = temp.Text.Length - 1;
                if (temp.Text.Contains('.'))
                {
                    while (temp.Text[i] != '.')
                        i--;
                    string IPpart = temp.Text.Substring(i + 1);
                    if (IPpart.Length == 3)
                    {
                        if (int.Parse(IPpart) > 255)
                        {
                            temp.Text = temp.Text.Remove(i + 1, 3) + "255" + (temp.Text.Count(p => p == '.') == 3 ? "" : ".");
                            alreadychanged = true;
                        }
                        else
                        {
                            temp.Text += (temp.Text.Count(p => p == '.') == 3 ? "" : ".");
                            alreadychanged = true;
                        }
                        if (temp.Text.Length > temp.MaxLength)
                        {
                            temp.Text = temp.Text.Remove(temp.Text.Length - 1, 1);
                            alreadychanged = true;
                        }
                        temp.SelectionStart = temp.Text.Length;
                    }
                }
                if (temp.Text.Length == 3)
                {
                    int res;
                    if (int.TryParse(temp.Text, out res))
                    {
                        if (int.Parse(temp.Text) > 255)
                        {
                            temp.Text = temp.Text.Remove(i - 2, 3) + "255" + '.';
                            alreadychanged = true;
                        }
                        else
                        {
                            temp.Text += '.';
                            alreadychanged = true;
                        }
                        temp.SelectionStart = temp.Text.Length;
                    }
                }
            }
        }

        private void ipserver_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            TextBox temp = (TextBox)sender;
            if (!string.IsNullOrEmpty(temp.Text))
            {
                string digits = "1234567890";
                int j = 0;
                bool find = false;
                for (j = 0; j < temp.Text.Length; j++)
                {
                    if (!digits.Contains(temp.Text[j]))
                    {
                        find = true;
                        break;
                    }
                }
                if (find)
                {
                    temp.Text = temp.Text.Remove(j, 1);
                    temp.SelectionStart = j;
                    return;
                }
                int res;
                if (int.TryParse(temp.Text, out res))
                {
                    if (res > 65535)
                    {
                        temp.Text = "65535";
                        temp.SelectionStart = temp.Text.Length;
                    }
                }
            }
        }
        #endregion

        private void Authorization_FormClosing(object sender, FormClosingEventArgs e)
        {
            BLFPanel.ApplyLanguage -= GeneralSettings_Language_Changed;
        }

        private void loginTextbox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                acceptButton_Click(null, null);
            }
        }
    }
}
