#define LOG
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using AsteriskManager;
using System.Threading;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Linq;
using BCTI.DialogBoxes;
using BCTI.CustomControls;
using BCTI.Settings;
using System.Text;
using BCTI.Helpers;
using BCTI.SettingClasses;
using System.ComponentModel;

namespace BCTI
{
    public partial class BLFPanel : Form
    {
        //public static Fonts bfonts = new Fonts();
        public static string PlaybackServerFolder;
        public AMIManager AMI;
        //public static Dictionary<string, ClientsData> Contactbook = new Dictionary<string, ClientsData>();
        public static List<ClientsData> BookOfContacts = new List<ClientsData>();
        public static IWin32Window mainBLF;
        List<RingInfo> ringList = new List<RingInfo>();
        List<Card> contactCards = new List<Card>();
        List<ClientsData> onBLFclients = new List<ClientsData>();
        contactChosen control = new contactChosen();
        multicontactChosen multicontrol = new multicontactChosen();
        nocontactChosen nocontrol = new nocontactChosen();
        List<Card> cardsChosen = new List<Card>();
        List<Splash> splashForms = new List<Splash>();
        public List<CallManager> calls = new List<CallManager>();
        UnunsweredForm ununs;
        string filter = "";
        private string StartArgs;
        SettingsForm settingsForm;
        static public UserSettings Staticsettings;
        public UserSettings settings;
        History historyForm;
        Contacts contactsForm;
        //List<BeforeSplash> listForm = new List<BeforeSplash>();
        //static public ClientsData callingClient = new ClientsData();
        bool LoginSuccess = false;
        bool Autoreconnect = true;
        KeyboardHook hook;
        public Dictionary<string, string[]> Localization = new Dictionary<string, string[]>();
        private string prevFilter = string.Empty;
        static public event EventHandler<EventArgs> ApplyLanguage;
        ToolTip settingsToolTip = new ToolTip();
        ToolTip contactsToolTip = new ToolTip();
        ToolTip historyToolTip = new ToolTip();

        [DllImport("user32.dll")]
        static extern IntPtr GetForegroundWindow();
        [DllImport("user32.dll")]
        public static extern IntPtr GetWindowThreadProcessId(IntPtr hWnd, out uint ProcessId);
        /// <summary>
        /// Получаем активный процесс для отправки запроса копирования в буфер
        /// </summary>
        /// <returns></returns>
        Process GetActiveProcess()
        {
            IntPtr hwnd = GetForegroundWindow();
            uint pid;
            GetWindowThreadProcessId(hwnd, out pid);
            Process p = Process.GetProcessById((int)pid);
            return p;
        }
        [DllImport("User32.dll")]
        public static extern bool SetForegroundWindow(IntPtr hWnd);

        /// <summary>
        /// Функция для инициализации звонка
        /// </summary>
        /// <param name="CallNumber"></param>
        public void RaiseCall(string CallNumber)
        {
            if (AMI != null && LoginSuccess)
            {
                if (AMI.UserData != null)
                {
                    if (AMI.UserData.Number == CallNumber)
                    {
                        try
                        {
                            BMessageBox.Show(Localization[BlfNumberLabel.Name][3]);
                        }
                        catch
                        {
                            BMessageBox.Show("Невозможно совершить звонок на номер под которым вы авторизованы");
                        }
                        return;
                    }
                }
                else
                {
                    try
                    {
                        BMessageBox.Show(Localization[BlfNumberLabel.Name][2]);
                    }
                    catch
                    {
                        BMessageBox.Show("Вы не авторизованы");
                    }
                    return;
                }
                CallManager call;
                callsSemaphore.WaitOne(1000);
                for (int i = 0; i < calls.Count; i++)
                {
                    if (calls[i].Number == CallNumber)
                    {
                        if (!calls[i].Hanguped)
                        {
                            calls[i].ShowSplash();
                            callsSemaphore.Set();
                            return;
                        }
                        else
                        {
                            calls[i].ShowSplash();
                            calls[i].Dispose();
                            try { calls.RemoveAt(i); } catch (Exception ex) { EventLogs.WriteLog(ex.Message, ex.StackTrace); }
                            i--;
                        }
                    }
                }
                callsSemaphore.Set();
                ClientsData temp = null;
                //try
                //{
                //    temp = Contactbook[CallNumber];
                //}
                //catch
                //{

                //}
                //try
                //{
                //    CallNumber = Editor.EditNumber(CallNumber);
                //    if (!AMI.Call(CallNumber))
                //    {
                //        //call.ShowSplash();
                //        //call.Dispose();
                //        try
                //        {
                //            BMessageBox.Show(Localization[BlfNumberLabel.Name][4]);
                //        }
                //        catch
                //        {
                //            BMessageBox.Show("Не удалось добавить звонок в очередь");
                //        }
                //        return;
                //    }
                //    else
                //    {
                //        if (temp != null)
                //            call = new CallManager(this, temp, CallNumber);
                //        else
                //            call = new CallManager(this,  CallNumber);
                //        if (settings.CommonSettings.bDoNotDisturb)
                //            call.HideSplash();
                //        else
                //            call.ShowSplash();
                //        calls.Add(call);
                //        return;
                //    }
                //}
                //catch
                //{
                //    //call.Dispose();
                //    return;
                //}
                for (int i = 0; i < BookOfContacts.Count; i++)
                {
                    if (BookOfContacts[i].Number == CallNumber || BookOfContacts[i].SecondNumber == CallNumber || BookOfContacts[i].Prefix + BookOfContacts[i].Number == CallNumber)
                    {
                        try
                        {
                            CallNumber = Editor.EditNumber(CallNumber);
                            if (!AMI.Call(CallNumber))
                            {
                                //call.ShowSplash();
                                //call.Dispose();
                                try
                                {
                                    BMessageBox.Show(Localization[BlfNumberLabel.Name][4]);
                                }
                                catch
                                {
                                    BMessageBox.Show("Не удалось добавить звонок в очередь");
                                }
                                return;
                            }
                            else
                            {
                                call = new CallManager(this, BookOfContacts[i], CallNumber);
                                if (settings.CommonSettings.bDoNotDisturb)
                                    call.HideSplash();
                                else
                                    call.ShowSplash();
                                calls.Add(call);
                                return;
                            }
                        }
                        catch
                        {
                            //call.Dispose();
                            return;
                        }
                    }
                }

                try
                {
                    CallNumber = Editor.EditNumber(CallNumber);
                    if (!AMI.Call(CallNumber))
                    {
                        //call.HideSplash();
                        //call.Dispose();
                        BMessageBox.Show("Не удалось совершить звонок");
                    }
                    else
                    {
                        call = new CallManager(this, CallNumber);
                        if (settings.CommonSettings.bDoNotDisturb)
                            call.HideSplash();
                        else
                            call.ShowSplash();
                        calls.Add(call);
                        return;
                    }
                }
                catch (Exception ex)
                {
                    EventLogs.WriteLog(ex.Message, ex.StackTrace);
                    //call.Dispose();
                    return;
                }
            }
            else
            {
                BMessageBox.Show("Не удалось совершить звонок");
                return;
            }
        }
        /// <summary>
        /// Функция для инициализации звонка
        /// </summary>
        /// <param name="CallNumber"></param>
        public void RaiseCall(ClientsData caller, bool firstnumber)
        {
            string number = firstnumber ? caller.Number : caller.SecondNumber;
            if (AMI != null && LoginSuccess)
            {
                if (AMI.UserData != null)
                {
                    if (AMI.UserData.Number == number)
                    {
                        try
                        {
                            BMessageBox.Show(Localization[BlfNumberLabel.Name][3]);
                        }
                        catch
                        {
                            BMessageBox.Show("Невозможно совершить звонок на номер под которым вы авторизованы");
                        }
                        return;
                    }
                }
                else
                {
                    try
                    {
                        BMessageBox.Show(Localization[BlfNumberLabel.Name][2]);
                    }
                    catch
                    {
                        BMessageBox.Show("Вы не авторизованы");
                    }
                    return;
                }
                CallManager call;
                callsSemaphore.WaitOne();
                for (int i = 0; i < calls.Count; i++)
                {
                    if (calls[i].Number == number)
                    {
                        if (!calls[i].Hanguped)
                        {
                            calls[i].ShowSplash();
                            callsSemaphore.Set();
                            return;
                        }
                        else
                        {
                            calls[i].Dispose();
                            try { calls.RemoveAt(i); } catch (Exception ex) { EventLogs.WriteLog(ex.Message, ex.StackTrace); }
                            i--;
                        }
                    }
                }
                callsSemaphore.Set();
                try
                {
                    number = Editor.EditNumber(number);
                    if (!AMI.Call(number))
                    {
                        //call.Dispose();
                        BMessageBox.Show("Не удалось совершить звонок");
                    }
                    else
                    {
                        call = new CallManager(this, caller, number);
                        if (settings.CommonSettings.bDoNotDisturb)
                            call.HideSplash();
                        else
                            call.ShowSplash();
                        calls.Add(call);
                        return;
                    }
                }
                catch
                {
                    //call.Dispose();
                    return;
                }
            }
            else
            {
                BMessageBox.Show("Не удалось совершить звонок");
                return;
            }
        }
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="arg"></param>
        public BLFPanel(string[] args)
        {
            mainBLF = this;
            this.Visible = false;
            string arg = string.Empty;
            foreach (string s in args)
            {
                arg += s;
            }
            StartArgs = arg;
            ///Загружаем и сохраняем себе настройки
            ///
            settings = new UserSettings();
            Editor.filePath = (string)settings.Pattern.PatternFilePath.Clone();

            Staticsettings = settings;
            PlaybackServerFolder = settings.Playback.PlaybackServerFolder;
            SettingsForm.ApplySettings += ApplySettings;
            SettingsForm.Reconnect += SettingsForm_Reconnect;
#if LOG
            if (settings.Logs.bEventLogEnabled) EventLogs.WriteLog("Application Started\r\n. Application Version: " + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString() + "\r\nMainWindow loading...");
#endif
            ///Десериализуем информацию о контактах и истории звонков
            ///
            BookOfContacts = XMLReadWriter.ReadContactsL();
            //Contactbook = XMLReadWriter.ReadContactsD();
            ringList = XMLReadWriter.ReadHistory();

            ApplicationCommonSettings apl = new ApplicationCommonSettings();
            ApplicationCommonSettings apl1 = (ApplicationCommonSettings)apl.Clone();
            apl.BlfLocation.X = 1;

            ///Применяем настройкти
            if (settings.CommonSettings.BlfLocation.X < 0 || settings.CommonSettings.BlfLocation.Y < 0 || settings.CommonSettings.BlfLocation.X > SystemInformation.VirtualScreen.Width || settings.CommonSettings.BlfLocation.Y > SystemInformation.VirtualScreen.Height)
            {
                this.DesktopLocation = new Point(100, 100);
            }
            else
            {
                this.DesktopLocation = settings.CommonSettings.BlfLocation;
            }

            InitializeComponent();
            if (settings.CommonSettings.bDoNotDisturb)
            {
                неБеспокоитьToolStripMenuItem.Checked = true;
            }
            else
            {
                неБеспокоитьToolStripMenuItem.Checked = false;
            }
            this.Visible = false;
            if (!settings.Tray.bTrayEnabled)
            {
                TrayIcon.Visible = false;
                this.ShowInTaskbar = true;
            }
            this.Size = new Size(settings.CommonSettings.BlfSize.X, settings.CommonSettings.BlfSize.Y);

            this.MaximumSize = new Size(this.Width, Screen.PrimaryScreen.WorkingArea.Height);
            SearchBox.LostFocus += SearchBox_LostFocus;
            ///Подписываемся на события для хука и закрытия приложения
            ///
            FormClosing += BLFPanel_FormClosing;
            hook = new KeyboardHook("Hotkeys");
            hook.HotkeyPressed += Hook_HotkeyPressed;
            hook.CalltoEvent += Hook_CalltoEvent;
            try
            {
                ModifKeys modif = new ModifKeys();
                if (settings.Hotkey.modifiers == Keys.Control)
                    modif = ModifKeys.Control;
                if (settings.Hotkey.modifiers == Keys.Alt)
                    modif = modif | ModifKeys.Alt;
                if (settings.Hotkey.modifiers == Keys.Shift)
                    modif = modif | ModifKeys.Shift;
                if (settings.Hotkey.modifiers == Keys.LWin || settings.Hotkey.modifiers == Keys.RWin)
                    modif = modif | ModifKeys.Win;
                hook.RegisterHotKey(modif, settings.Hotkey.key);
            }
            catch (InvalidOperationException)
            {
                BMessageBox.Show("Не удалось зарегестрировать горячие клавиши. Возможно они уже используются другим приложением", "Ошибка");
            }

            ///Добавляем элементы управления при нажатии на карточку и подгружаем картинки
            BottomControls.Visible = false;
            historyButton.BackgroundImage = topButtonsImageList.Images[0];
            contactsButton.BackgroundImage = topButtonsImageList.Images[2];
            settingsButton.BackgroundImage = topButtonsImageList.Images[4];
            closeButton.BackgroundImage = closeButtonImage.Images[0];
            control.buttonClicked += new EventHandler<CustEventArgs>(control_buttonClicked);
            multicontrol.buttonClicked += new EventHandler<CustEventArgs>(control_buttonClicked);
            nocontrol.buttonClicked += new EventHandler<CustEventArgs>(control_buttonClicked);
            BottomControls.Controls.Add(control);
            bOnBlfPanel.Controls.Clear();

            /// Подгружаем шрифты
            UserInterfaceAPI.InitFonts(this);
            UserInterfaceAPI.InitFonts(TrayMenu);
            UserInterfaceAPI.SetFontStyle(BlfNumberLabel, FontStyle.Bold);

            /// Скругляем лейбл количества пропущенных звонков
            var reg = new System.Drawing.Drawing2D.GraphicsPath();
            reg.AddEllipse(0, 0, MissedCallsLabel.Width, MissedCallsLabel.Height);

            Localization = Localizator.GetFormLocalization("BLFPanel", Staticsettings.Interface.Language);
            Localizator.MakeLocalization(this, Localization);
            Localizator.MakeLocalizationAllContextMenu(TrayMenu, Localization);
            try
            {
                prevFilter = Localization[SearchBox.Name][0];
            }
            catch (KeyNotFoundException)
            {
                prevFilter = "Введите номер или имя";
            }

            try
            {
                settingsToolTip.SetToolTip(settingsButton, Localization[settingsButton.Name][0]);
            }
            catch (Exception ex)
            {
                EventLogs.WriteLog("Ошибка локализации", ex.StackTrace);
                settingsToolTip.SetToolTip(settingsButton, "Настройки");
            }
            try
            {
                contactsToolTip.SetToolTip(contactsButton, Localization[contactsButton.Name][0]);
            }
            catch (Exception ex)
            {
                EventLogs.WriteLog("Ошибка локализации", ex.StackTrace);
                settingsToolTip.SetToolTip(contactsButton, "Книга контактов");
            }
            try
            {
                historyToolTip.SetToolTip(historyButton, Localization[historyButton.Name][0]);
            }
            catch (Exception ex)
            {
                EventLogs.WriteLog("Ошибка локализации", ex.StackTrace);
                settingsToolTip.SetToolTip(historyButton, "Настройки");
            }

            this.MissedCallsLabel.Region = new Region(reg);
        }

        /// <summary>
        /// Сообщение с CallTo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Hook_CalltoEvent(object sender, CustEventArgs e)
        {
            RaiseCall(e.message.Replace("bcti", "").Replace("callto", "").Replace("tel", "").Replace(":", ""));
        }
        public static void SendCopy()
        {
            User32.keybd_event(0x11, 0, 0, 0);
            User32.keybd_event(0x43, 0, 0, 0);
            Thread.Sleep(180);
            User32.keybd_event(0x43, 0, 2, 0);
            User32.keybd_event(0x11, 0, 2, 0);
        }
        string PrevHook = string.Empty;
        BackgroundWorker freehook;
        /// <summary>
        /// Событие нажатия горячих клавиш
        /// </summary>
        private void Hook_HotkeyPressed()
        {
            HotkeyLog.WriteLog("hotkey pressed");
            hook.PreReleaseHotkeyKeys();
            Process proc = GetActiveProcess();
            HotkeyLog.WriteLog("hotkey released", "Process name: " + proc.ProcessName + " Process ID: " + proc.Id + " Window Title: " + proc.MainWindowTitle);
            IntPtr foregroundWindow = User32.GetForegroundWindow();
            HotkeyLog.WriteLog("got foregrownd window");
            try
            {
                string PrevText = Clipboard.GetText(TextDataFormat.UnicodeText);
                HotkeyLog.WriteLog("Getting previous text", "Previous text = " + PrevText);
                InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(System.Globalization.CultureInfo.GetCultureInfo("en"));
                HotkeyLog.WriteLog("Setting main language to english");
                CloseClipboard();
                try
                {
                    Clipboard.Clear();
                }
                catch (Exception ex)
                {
                    HotkeyLog.WriteLog(ex.Message);
                    return;
                }
                SendKeys.Flush();
                Application.DoEvents();
                bool ContainsText = false;
                HotkeyLog.WriteLog("Clipboard cleared, sending Ctrl+C");
                switch (proc.ProcessName.ToLower())
                {
                    case "excel":
                        HotkeyLog.WriteLog("Getting text from excel");
                        User32.SetForegroundWindow(foregroundWindow);
                        SendCopy();
                        User32.SetForegroundWindow(foregroundWindow);
                        Application.DoEvents();
                        int i = 0;
                        HotkeyLog.WriteLog("Getting text from CB");
                        while (!ContainsText && i < 5)
                        {
                            try
                            {
                                i++;
                                Thread.Sleep(50);
                                ContainsText = Clipboard.ContainsData("DataObject");

                            }
                            catch
                            {
                                Thread.Sleep(5);
                                HotkeyLog.WriteLog("Retrying to check clipboard's text " + i);
                            }
                        }
                        if (ContainsText)
                        {
                            string text = string.Empty;
                            IDataObject dataObject = Clipboard.GetDataObject();
                            if (dataObject.GetDataPresent(DataFormats.Text) || dataObject.GetDataPresent(DataFormats.Text))
                            {
                                try
                                {
                                    text = (String)dataObject.GetData(DataFormats.Text);
                                }
                                catch (Exception ex)
                                {
                                    HotkeyLog.WriteLog("Failed to get CB text", ex.Message);
                                }
                            }
                            if (text != null)
                            {
                                HotkeyLog.WriteLog("Got text from CB", "Text: " + text);
#if LOG
                                if (settings.Logs.bEventLogEnabled) EventLogs.WriteLog("GlobalHook", text);
#endif
                                if (!settings.Hotkey.bHotkeyInstantCall)
                                {
                                    SearchBox.Text = text;
                                    this.TopMost = true;
                                }
                                else
                                {
                                    if (text != PrevHook)
                                    {
                                        HotkeyLog.WriteLog("Instant call to " + text);
                                        RaiseCall(text);
                                        PrevHook = text;
                                        if (freehook == null)
                                        {
                                            HotkeyLog.WriteLog("Text===PrevText");
                                            freehook = new BackgroundWorker();
                                            freehook.WorkerSupportsCancellation = true;
                                            freehook.DoWork += Freehook_DoWork;
                                            freehook.RunWorkerAsync();
                                        }
                                        else
                                        {
                                            if (freehook.IsBusy)
                                            {
                                                freehook.CancelAsync();
                                            }
                                            else
                                            {
                                                freehook = new BackgroundWorker();
                                                freehook.DoWork += Freehook_DoWork;
                                                freehook.RunWorkerAsync();
                                            }
                                        }
                                    }
                                    //else
                                    //{
                                    //    PrevHook = string.Empty;
                                    //}
                                }
                                int j = 0;
                                HotkeyLog.WriteLog("Setting CB text back");
                                while (j < 3)
                                {
                                    try
                                    {
                                        j++;
                                        if (!string.IsNullOrEmpty(PrevText))
                                        {
                                            Clipboard.SetDataObject(dataObject);
                                            HotkeyLog.WriteLog("Text returned to clipboard");
                                            break;
                                        }
                                    }
                                    catch
                                    {
                                        HotkeyLog.WriteLog("Failed to return text");
                                    }
                                }
                            }
                        }
                        else
                        {
                            HotkeyLog.WriteLog("No availible text, one more time");
                            i = 0;
                            HotkeyLog.WriteLog("Getting text from CB");
                            while (!ContainsText && i < 5)
                            {
                                try
                                {
                                    i++;
                                    ContainsText = Clipboard.ContainsText();
                                }
                                catch
                                {
                                    Thread.Sleep(10);
                                    HotkeyLog.WriteLog("Retrying to check clipboard's text " + i);
                                }
                            }
                            string text = string.Empty;
                            IDataObject dataObject = Clipboard.GetDataObject();
                            try
                            {
                                text = (String)dataObject.GetData(DataFormats.Text);
                            }
                            catch (Exception ex)
                            {
                                HotkeyLog.WriteLog("Failed to get CB text", ex.Message);
                            }
                            if (text != null)
                            {
#if LOG
                                if (settings.Logs.bEventLogEnabled)
                                {
                                    EventLogs.WriteLog("GlobalHook", text);
                                    HotkeyLog.WriteLog("Got text from CB", "Text: " + text);
                                }
#endif
                                if (!settings.Hotkey.bHotkeyInstantCall)
                                {
                                    SearchBox.Text = text;
                                    this.TopMost = true;
                                }
                                else
                                {
                                    if (text != PrevHook)
                                    {
                                        HotkeyLog.WriteLog("Instant call to " + text);
                                        RaiseCall(text);
                                        PrevHook = text;
                                        if (freehook == null)
                                        {
                                            freehook = new BackgroundWorker();
                                            freehook.WorkerSupportsCancellation = true;
                                            freehook.DoWork += Freehook_DoWork;
                                            freehook.RunWorkerAsync();
                                        }
                                        else
                                        {
                                            HotkeyLog.WriteLog("Text===PrevText");
                                            if (freehook.IsBusy)
                                            {
                                                freehook.CancelAsync();
                                            }
                                            else
                                            {
                                                freehook = new BackgroundWorker();
                                                freehook.DoWork += Freehook_DoWork;
                                                freehook.RunWorkerAsync();
                                            }
                                        }
                                    }
                                    //else
                                    //{
                                    //    PrevHook = string.Empty;
                                    //}
                                }
                                //if (text != PrevText && text != SearchBox.Text)
                                //{
                                //    if (!settings.Hotkey.bHotkeyInstantCall)
                                //    {
                                //        SearchBox.Text = text;
                                //        this.TopMost = true;
                                //    }
                                //    else
                                //    {
                                //        if (text != PrevHook)
                                //        {
                                //            RaiseCall(text);
                                //            PrevHook = text;
                                //        }
                                //        else
                                //        {
                                //            PrevHook = string.Empty;
                                //        }
                                //    }
                                //}
                                int j = 0;
                                HotkeyLog.WriteLog("Returning text to CB");

                                while (j < 7)
                                {
                                    try
                                    {
                                        j++;
                                        if (!string.IsNullOrEmpty(PrevText))
                                        {
                                            Clipboard.SetText(PrevText);
                                            HotkeyLog.WriteLog("Text returned to clipboard");
                                            break;
                                        }
                                    }
                                    catch
                                    {
                                        HotkeyLog.WriteLog("Failed to return text");
                                    }
                                }
                            }
                        }

                        CloseClipboard();
                        break;
                    default:
                        SendKeys.Flush();
                        User32.SetForegroundWindow(foregroundWindow);
                        SendCopy();
                        User32.SetForegroundWindow(foregroundWindow);
                        //SendKeys.SendWait("^({c})");
                        Application.DoEvents();
                        HotkeyLog.WriteLog("Getting text from CB");
                        ContainsText = false;
                        try
                        {
                            ContainsText = Clipboard.ContainsText();
                        }
                        catch
                        {
                            try
                            {
                                ContainsText = Clipboard.ContainsText();
                            }
                            catch (Exception ex)
                            {
                                EventLogs.WriteLog(ex.Message);
                                HotkeyLog.WriteLog(ex.Message);
                            }
                            try
                            {
                                CloseClipboard();
                            }
                            catch (Exception ex)
                            {
                                HotkeyLog.WriteLog("Failed to close CB ", ex.Message);
                            }
                        }
                        if (ContainsText)
                        {
                            try
                            {
                                CloseClipboard();
                            }
                            catch (Exception ex)
                            {
                                HotkeyLog.WriteLog("Failed to close CB ", ex.Message);
                            }
                            string text = string.Empty;
                            try
                            {
                                text = Clipboard.GetText(TextDataFormat.UnicodeText);
                            }
                            catch (Exception ex)
                            {
                                HotkeyLog.WriteLog("Failed to get CB text", ex.Message);
                                return;
                            }
                            HotkeyLog.WriteLog("Got text = " + text);
                            if (text != null)
                            {
#if LOG
                                if (settings.Logs.bEventLogEnabled) EventLogs.WriteLog("GlobalHook", text);
#endif
                                if (!settings.Hotkey.bHotkeyInstantCall)
                                {
                                    SearchBox.Text = text;
                                    this.TopMost = true;
                                }
                                else
                                {
                                    if (text != PrevHook)
                                    {
                                        HotkeyLog.WriteLog("Instant call to " + text);
                                        RaiseCall(text);
                                        PrevHook = text;
                                        if (freehook == null)
                                        {
                                            freehook = new BackgroundWorker();
                                            freehook.WorkerSupportsCancellation = true;
                                            freehook.DoWork += Freehook_DoWork;
                                            freehook.RunWorkerAsync();
                                        }
                                        else
                                        {
                                            if (freehook.IsBusy)
                                            {
                                                freehook.CancelAsync();
                                            }
                                            else
                                            {
                                                freehook = new BackgroundWorker();
                                                freehook.WorkerSupportsCancellation = true;
                                                freehook.DoWork += Freehook_DoWork;
                                                freehook.RunWorkerAsync();
                                            }
                                        }
                                    }
                                }
                            }
                            int j = 0;
                            while (j < 7)
                            {
                                try
                                {
                                    j++;
                                    if (!string.IsNullOrEmpty(PrevText))
                                    {
                                        Clipboard.SetText(PrevText);
                                        HotkeyLog.WriteLog("Text returned to clipboard");
                                        break;
                                    }
                                }
                                catch
                                {
                                    Thread.Sleep(100);
                                    HotkeyLog.WriteLog("Failed to return text");
                                }
                            }
                            CloseClipboard();
                        }
                        break;
                }

            }
            catch (ExternalException)
            {
                var hwnd = GetOpenClipboardWindow();
#if LOG
                if (settings.Logs.bEventLogEnabled) EventLogs.WriteLog("GlobalHook ExternalException", proc.MainWindowTitle);
#endif
                //BMessageBox.Show("Данное приложение блокирует буфер обмена HWNDPtr: " + hwnd.ToString());
            }
            //SetForegroundWindow(this.Handle);
            this.TopMost = false;
        }

        private void Freehook_DoWork(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                Thread.Sleep(2000);
                if (!e.Cancel)
                {
                    PrevHook = string.Empty;
                    return;
                }
                else
                {
                    freehook.CancelAsync();
                }
            }
        }

        /// <summary>
        /// Потеря фокуса панелью ввода
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SearchBox_LostFocus(object sender, EventArgs e)
        {
            if (SearchBox.Text.Length == 0)
            {
                try
                {
                    SearchBox.Text = Localization[SearchBox.Name][0];
                }
                catch (KeyNotFoundException)
                {
                    SearchBox.Text = "Введите номер или имя";
                }
                SearchBox.ForeColor = SystemColors.GrayText;
            }
        }
        /// <summary>
        /// Reconnect при изменении настроек подключения
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SettingsForm_Reconnect(object sender, EventArgs e)
        {
            MainAMImanager_Disconnected(this, null);
            newBLFPanel_Shown(this, null);
        }
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        static extern IntPtr CloseClipboard();
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        static extern IntPtr GetOpenClipboardWindow();

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        static extern int GetWindowText(int hwnd, StringBuilder text, int count);

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern int GetWindowTextLength(int hwnd);

        [DllImport("user32.dll", SetLastError = true)]
        static extern bool OpenClipboard(IntPtr hWndNewOwner);
        /// <summary>
        /// Событие нажатия горячих клавиш
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Hook_KeyPressed(object sender, KeyPressedEventArgs e)
        {
            Process proc = GetActiveProcess();

            if (!SetForegroundWindow(proc.MainWindowHandle))
            {
                BMessageBox.Show("Невозможно получить информацию из этого приложения");
            }
            try
            {

                //OpenClipboard(IntPtr.Zero);

                //Console.WriteLine(hwnd.ToString());
                string PrevText = Clipboard.GetText(TextDataFormat.UnicodeText);
                //System.Windows.Forms.Clipboard.Get(null,)
                InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(System.Globalization.CultureInfo.GetCultureInfo("en"));
                CloseClipboard();
                Clipboard.Clear();
                //hwnd = GetOpenClipboardWindow();
                //Console.WriteLine(hwnd.ToString());
                //SendKeys.SendWait("%");
                SendKeys.Flush();
                SendKeys.SendWait("^({c})");
                //this.Focus();
                //SetForegroundWindow(IntPtr.Zero);
                //hwnd = GetOpenClipboardWindow();
                //Console.WriteLine(hwnd.ToString());
                Thread.Sleep(150);
                //object data;
                //data = System.Windows.Forms.Clipboard.GetDataObject();
                //var hwnd = GetOpenClipboardWindow();
                //Console.WriteLine(hwnd.ToString());
                //if (hwnd != (IntPtr)0)
                //{
                //    if (!SetForegroundWindow(hwnd))
                //    {
                //        BMessageBox.Show("Невозможно получить информацию из этого приложения");
                //    }
                //    else
                //    {
                //        CloseClipboard();
                //        Console.WriteLine(hwnd.ToString());
                //        //Thread.Sleep(500);
                //    }
                //}
                //CloseClipboard();
                //Thread.Sleep(100);
                //Console.WriteLine(Clipboard.GetText(TextDataFormat.UnicodeText));
                //                
                //                {
                //                    string text = Clipboard.GetText(TextDataFormat.UnicodeText);
                //                    Console.WriteLine(PrevText + " " + text);
                //                    if (text != null)
                //                    {
                //#if LOG
                //                        if (settings.Logs.bEventLogEnabled) EventLogs.WriteLog("GlobalHook", text);
                //#endif
                //                        if (text != PrevText)
                //                        {
                //                            SearchBox.Text = text;
                //                            this.TopMost = true;
                //                            this.Show();
                //                        }
                //                        if (settings.bHotkeyInstantCall)
                //                            RaiseCall(text);
                //                    }
                //                    return;
                //                }
                bool ContainsText = false;
                try
                {
                    ContainsText = Clipboard.ContainsText();
                }
                catch
                {
                    try
                    {
                        ContainsText = Clipboard.ContainsText();
                    }
                    catch
                    {

                    }
                    CloseClipboard();
                    //try
                    //{
                    //    ContainsText = Clipboard.ContainsText();
                    //}
                    //catch
                    //{

                    //}
                }
                if (ContainsText)
                {

                    string text = Clipboard.GetText(TextDataFormat.UnicodeText);
                    Console.WriteLine(PrevText + " " + text);
                    if (text != null)
                    {
#if LOG
                        if (settings.Logs.bEventLogEnabled) EventLogs.WriteLog("GlobalHook", text);
#endif
                        if (text != PrevText)
                        {
                            SearchBox.Text = text;
                            this.TopMost = true;
                            this.Show();
                        }
                        if (settings.Hotkey.bHotkeyInstantCall)
                            RaiseCall(text);
                    }
                }
                else
                {
                    //proc = GetActiveProcess();
                    //SetForegroundWindow(proc.MainWindowHandle);
                    //SendKeys.SendWait("");
                    SendKeys.SendWait("%");
                    SendKeys.Flush();
                    Console.WriteLine("Esc1");
                    //Thread.Sleep(100);
                    SendKeys.SendWait("^({c})");
                    Thread.Sleep(100);
                    ContainsText = false;
                    try
                    {
                        ContainsText = Clipboard.ContainsText();
                    }
                    catch (Exception ex)
                    {
                        try
                        {
                            ContainsText = Clipboard.ContainsText();
                        }
                        catch (Exception exl)
                        {
                            EventLogs.WriteLog(exl.Message);
                            HotkeyLog.WriteLog(exl.Message);
                        }
                        try
                        {
                            CloseClipboard();
                        }
                        catch (Exception exc)
                        {
                            HotkeyLog.WriteLog(exc.Message);
                        }
                    }
                    Console.WriteLine(ContainsText.ToString());
                    HotkeyLog.WriteLog("Наличие текста в буфере: " + ContainsText.ToString());
                    if (ContainsText)
                    {
                        CloseClipboard();
                        string text = Clipboard.GetText(TextDataFormat.UnicodeText);
                        Console.WriteLine(PrevText + " " + text);
                        HotkeyLog.WriteLog(PrevText + " " + text);
                        if (text != null)
                        {
#if LOG
                            if (settings.Logs.bEventLogEnabled)
                            {
                                EventLogs.WriteLog("GlobalHook", text);
                                HotkeyLog.WriteLog("GlobalHook", text);
                            }
#endif
                            if (text != PrevText)
                            {
                                SearchBox.Text = text;
                                this.TopMost = true;
                                this.Show();
                            }
                            if (settings.Hotkey.bHotkeyInstantCall)
                            {
                                RaiseCall(text);
                                HotkeyLog.WriteLog("Raised call on number: " + text);
                            }
                        }
                    }
                    else
                    {
                        //proc = GetActiveProcess();
                        //SetForegroundWindow(proc.MainWindowHandle);
                        //SendKeys.SendWait("");
                        SendKeys.Flush();
                        if (!proc.MainWindowTitle.ToLower().Contains("chrome"))
                            SendKeys.SendWait("{ESC}");
                        //Thread.Sleep(100);
                        Console.WriteLine("Esc2");
                        SendKeys.SendWait("^({c})");
                        Thread.Sleep(100);
                        ContainsText = false;
                        try
                        {
                            ContainsText = Clipboard.ContainsText();
                        }
                        catch (Exception ex)
                        {
                            HotkeyLog.WriteLog(ex.Message);
                            CloseClipboard();
                        }
                        Console.WriteLine(ContainsText.ToString());
                        HotkeyLog.WriteLog("Наличие текста в буфере: " + ContainsText.ToString());
                        if (ContainsText)
                        {
                            CloseClipboard();
                            string text = Clipboard.GetText(TextDataFormat.UnicodeText);
                            Console.WriteLine(PrevText + " " + text);
                            HotkeyLog.WriteLog(PrevText + " " + text);
                            if (text != null)
                            {
#if LOG
                                if (settings.Logs.bEventLogEnabled)
                                {
                                    EventLogs.WriteLog("GlobalHook", text);
                                    HotkeyLog.WriteLog("GlobalHook", text);
                                }
#endif
                                if (text != PrevText)
                                {
                                    SearchBox.Text = text;
                                    this.TopMost = true;
                                    this.Show();
                                }
                                if (settings.Hotkey.bHotkeyInstantCall)
                                    RaiseCall(text);
                            }
                        }
                    }
                }

                if (!string.IsNullOrEmpty(PrevText))
                {
                    try
                    {
                        Clipboard.SetText(PrevText);
                    }
                    catch (Exception ex)
                    {
                        EventLogs.WriteLog(ex.Message);
                        HotkeyLog.WriteLog(ex.Message);
                        try
                        {
                            Clipboard.SetText(PrevText);
                        }
                        catch (Exception exc)
                        {
                            EventLogs.WriteLog(exc.Message);
                            HotkeyLog.WriteLog(exc.Message);
                        }
                    }

                }
                else
                {
                    try
                    {
                        Clipboard.SetText(" ");
                    }
                    catch (Exception ex)
                    {
                        EventLogs.WriteLog(ex.Message);
                        HotkeyLog.WriteLog(ex.Message);
                        try
                        {
                            Clipboard.SetText(" ");
                        }
                        catch
                        {
                            EventLogs.WriteLog(ex.Message);
                            HotkeyLog.WriteLog(ex.Message);
                        }
                    }
                }
            }
            catch (ExternalException)
            {
                var hwnd = GetOpenClipboardWindow();
                Console.WriteLine(hwnd.ToString());
#if LOG
                if (settings.Logs.bEventLogEnabled)
                {
                    EventLogs.WriteLog("GlobalHook ExternalException", proc.MainWindowTitle);
                    HotkeyLog.WriteLog("GlobalHook ExternalException", proc.MainWindowTitle);
                }
#endif
                BMessageBox.Show("Данное приложение блокирует буфер обмена HWNDPtr: " + hwnd.ToString());
            }
            this.TopMost = false;
        }

        /// <summary>
        /// Форма закрывается, сохраняем все настройки
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BLFPanel_FormClosing(object sender, FormClosingEventArgs e)
        {
            TrayIcon.Dispose();
            hook.Dispose();
            //settings.BlfLocation = this.DesktopLocation;
            //settings.BlfSize = new Point(this.Size.Width, this.Size.Height);
            //settings.SaveSettings();
            Staticsettings.CommonSettings.BlfLocation = this.DesktopLocation;
            Staticsettings.CommonSettings.BlfSize = new Point(this.Size.Width, this.Size.Height);
            Staticsettings.SaveSettings();
#if LOG
            if (settings.Logs.bEventLogEnabled) EventLogs.WriteLog(("Settings Saved"));
#endif
            XMLReadWriter.WriteHistory(ringList);

#if LOG
            if (settings.Logs.bEventLogEnabled) EventLogs.WriteLog(("History Saved"));
#endif
            XMLReadWriter.WriteContacts(BookOfContacts);
#if LOG
            if (settings.Logs.bEventLogEnabled) EventLogs.WriteLog(("Contacts Saved"));
#endif
        }

        /// <summary>
        /// Клик по всплывающему элементу управления 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void control_buttonClicked(object sender, CustEventArgs e)
        {

            if (contactCards.Count < 0) return;
            Card temp = new Card();
            foreach (Card curr in contactCards)
            {
                if (curr.bSelected)
                {
                    temp = curr;
                    break;
                }
            }
            string command = e.message;
            switch (command)
            {
                case "Call":
                    {
                        if (LoginSuccess)
                        {
                            if (string.IsNullOrEmpty(temp.client.Number))
                            {
                                temp.client.Number = filter;
                                RaiseCall(filter);
                            }
                            else
                                RaiseCall(temp.client.Number);
                        }
                        break;
                    }
                case "[+] Add":
                    {
                        int found = 0;
                        for (int i = 0; i < BookOfContacts.Count; i++)
                        {
                            if (BookOfContacts[i].Number == filter || BookOfContacts[i].SecondNumber == filter)
                            {
                                BMessageBox.Show("Номер уже есть в книге контактов");
                                found = 1;
                                break;
                            }
                        }
                        if (found == 0)
                        {
                            ClientsData curr = new ClientsData();
                            curr.Number = filter;
                            AddToBook atb = new AddToBook(curr);
                            atb.ShowDialog();
                            if (atb.added)
                            {
                                BookOfContacts.Add(atb.newClient);

                                FullReload();
                            }
                        }
                        break;
                    }
                case "Edit":
                    {
                        AddToBook atb = new AddToBook(temp.client);
                        atb.ShowDialog();
                        for (int i = 0; i < BookOfContacts.Count; i++)
                        {
                            if (BookOfContacts[i].ID == temp.client.ID)
                            {
                                BookOfContacts[i] = atb.newClient;
                                break;
                            }
                        }
                        FullReload();
                        break;
                    }
                case "History":
                    {
                        historyButton_Click(this, null);
                        if (string.IsNullOrEmpty(temp.client.Name))
                            historyForm.changeFilter(filter);
                        else historyForm.changeFilter(temp.getMainNumber());
                        break;
                    }
                case "Delete":
                    {
                        for (int i = 0; i < cardsChosen.Count; i++)
                        {
                            for (int j = 0; j < BookOfContacts.Count; j++)
                            {
                                if (BookOfContacts[j].ID == temp.client.ID)
                                {
                                    BookOfContacts[j].onBLF = false;
                                }
                            }
                            bOnBlfPanel.Controls.Remove(cardsChosen[i]);
                        }
                        cardsChosen.Clear();
                        FullReload();
                        break;
                    }
                default:
                    {
                        break;
                    }
            }

        }

        /// <summary>
        /// Клик по карточке
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void card_clicked(object sender, EventArgs e)
        {
            contactsButton.Focus();
            int cardsCount = cardsChosen.Count;
            cardsChosen.Clear();
            if (!(Control.ModifierKeys == Keys.Control))
            {
                Card temp = (Card)sender;
                if (cardsCount > 1)
                {
                    temp.bSelected = true;
                    temp.ChangeFocus();
                }
                foreach (Card card in bOnBlfPanel.Controls)
                {
                    if (card != temp)
                    {
                        card.bSelected = false;
                        card.ChangeFocus();
                    }
                }
                cardsChosen.Add(temp);
            }
            else
            {
                for (int i = 0; i < bOnBlfPanel.Controls.Count; i++)
                {
                    Card temp = (Card)bOnBlfPanel.Controls[i];
                    if (temp.bSelected)
                    {
                        cardsChosen.Add(temp);
                    }
                    else
                    {
                        if (cardsChosen.Contains(temp))
                            cardsChosen.Remove(temp);
                    }
                }
            }
            int count = 0;
            if (cardsChosen.Count > 1/* && ((BottomControls.Controls.Count <= 0) || (BottomControls.Controls[0] == nocontrol) || (BottomControls.Controls[0] == control))*/)
            {
                if (BottomControls.Controls.Count >= 1)
                {
                    if (BottomControls.Controls[0] != multicontrol)
                    {
                        BottomControls.Controls.Clear();
                        BottomControls.Controls.Add(multicontrol);
                    }
                }
            }
            else
            {
                if (BottomControls.Controls.Count >= 1)
                {
                    if (BottomControls.Controls[0] != control)
                    {
                        BottomControls.Controls.Clear();
                        //if (LoginSuccess)
                        BottomControls.Controls.Add(control);
                    }
                }
                else
                {
                    BottomControls.Controls.Add(control);
                }
                foreach (Card card in contactCards)
                {
                    if (card.bSelected) count++;
                }
                control.changeColor(!(count == 0));
                if (count == 0)
                {
                    BottomControls.Visible = false;
                }
                else
                {
                    BottomControls.Visible = true;
                }
            }
        }
        /// <summary>
        /// Событие клика по номеру
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void number_clicked(object sender, CustEventArgs e)
        {
            RaiseCall(e.message);
        }
        /// <summary>
        /// После загрузки формы, загружаем карточки
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void BLFPanel_Load(object sender, EventArgs e)
        {
            FullReload();
        }
        /// <summary>
        /// Полная перезагрузка карточек
        /// </summary>
        private void FullReload()
        {
            onBLFclients.Clear();
            for (int i = 0; i < BookOfContacts.Count; i++)
            {
                if (AMI != null)
                {
                    for (int jj = 0; jj < AMI.ServerUsers.Count; jj++)
                    {
                        if (BookOfContacts[i].Number == AMI.ServerUsers[jj].Number)
                        {
                            BookOfContacts[i].Status = AMI.ServerUsers[jj].Status;
                            break;
                        }
                    }
                }
                else
                {
                    BookOfContacts[i].Status = "UNKNOWN";
                }
                if (BookOfContacts[i].onBLF)
                {
                    if (BookOfContacts[i].onBLFposition != -1)
                    {
                        onBLFclients.Add(BookOfContacts[i]);
                    }
                }
            }
            for (int i = 0; i < BookOfContacts.Count; i++)
            {
                if (BookOfContacts[i].onBLF)
                {
                    if (BookOfContacts[i].onBLFposition == -1)
                    {
                        BookOfContacts[i].onBLFposition = onBLFclients.Count;
                        onBLFclients.Add(BookOfContacts[i]);
                    }
                }
            }
            Extensions.HeapSort(onBLFclients);
            //Extensions.ShellSort(onBLFclients);
            UpdateCards();
        }
        /// <summary>
        /// Обновление относительно фильтра
        /// </summary>
        private void UpdateCards()
        {
            int h = 0;
            string curr = String.Empty;
            try
            {
                curr = Localization[SearchBox.Name][0];
            }
            catch (Exception)
            {
                curr = "Введите номер или имя";
            }
            if (SearchBox.Text == "" || SearchBox.Text == curr)
            {
                ClearFilter.Hide();
                NotFound.Hide();
                contactCards.Clear();
                int k = bOnBlfPanel.Controls.Count;
                int l = onBLFclients.Count;
                if (k > l)
                {
                    for (int i = k - 1; i >= l; i--)
                    {
                        bOnBlfPanel.Controls.RemoveAt(i);
                    }
                }
                else
                {
                    for (int i = k; i < l; i++)
                    {
                        Card temp = new Card();
                        bOnBlfPanel.Controls.Add(temp);
                        temp.cardClicked += new EventHandler<EventArgs>(card_clicked);
                        temp.numberClicked += new EventHandler<CustEventArgs>(number_clicked);
                        temp.orderChangeUp += card_orderup;
                        temp.orderChangeDown += card_orderdown;
                        temp.DeleteCard += card_delete;
                        temp.ShowHistory += card_history;
                        temp.EditClicked += card_edit;
                    }
                }
                for (int i = 0; i < bOnBlfPanel.Controls.Count; i++)
                {
                    Card temp = (Card)bOnBlfPanel.Controls[i];
                    temp.SetClient(onBLFclients[i]);
                    temp.DefaultForm();
                    temp.client.onBLFposition = i;
                    contactCards.Add(temp);
                }
                if (cardsChosen.Count <= 0)
                {
                    BottomControls.Visible = false;
                    BottomControls.Controls.Clear();
                }
                if (BottomControls.Controls.Count >= 1)
                {
                    if (BottomControls.Controls[0] == nocontrol)
                    {
                        BottomControls.Controls.Clear();
                    }
                }
                if (onBLFclients.Count == 0)
                {
                    NoContacts.Show();
                    bOnBlfPanel.RowStyles.Clear();
                }
                else
                {
                    NoContacts.Hide();
                }
                return;
            }
            else
            {
                ClearFilter.Show();
                NoContacts.Hide();
                contactCards.Clear();
                int k = bOnBlfPanel.Controls.Count;
                List<ClientsData> SearchedClients = new List<ClientsData>();
                for (int i = 0; i < BookOfContacts.Count; i++)
                {
                    if ((BookOfContacts[i].Number.ToLower().Contains(SearchBox.Text.ToLower()) || BookOfContacts[i].SecondNumber.ToLower().Contains(SearchBox.Text.ToLower()) || BookOfContacts[i].Name.ToLower().Contains(SearchBox.Text.ToLower())))
                    {
                        SearchedClients.Add(BookOfContacts[i]);
                        h++;
                        if (h >= 10) break;
                    }
                }
                int l = SearchedClients.Count;
                if (k > l)
                {
                    for (int i = k - 1; i >= l; i--)
                    {
                        bOnBlfPanel.Controls.RemoveAt(i);
                    }
                }
                else
                {
                    for (int i = k; i < l; i++)
                    {
                        Card temp = new Card();
                        bOnBlfPanel.Controls.Add(temp);
                        temp.cardClicked += new EventHandler<EventArgs>(card_clicked);
                        temp.numberClicked += new EventHandler<CustEventArgs>(number_clicked);
                        temp.orderChangeUp += card_orderup;
                        temp.orderChangeDown += card_orderdown;
                        temp.DeleteCard += card_delete;
                        temp.ShowHistory += card_history;
                        temp.EditClicked += card_edit;
                    }
                }
                for (int i = 0; i < bOnBlfPanel.Controls.Count; i++)
                {
                    Card temp = (Card)bOnBlfPanel.Controls[i];
                    temp.SetClient(SearchedClients[i]);
                    if (temp.bSelected)
                    {
                        temp.bSelected = false;
                        temp.ChangeFocus();
                    }
                    temp.SearchForm();
                    contactCards.Add(temp);
                }
                BottomControls.Visible = true;
                if (l == 0)
                {
                    bOnBlfPanel.RowStyles.Clear();
                    NotFound.Show();
                    if (BottomControls.Controls.Count >= 1)
                    {
                        if (BottomControls.Controls[0] != nocontrol)
                        {
                            BottomControls.Controls.Clear();
                            BottomControls.Controls.Add(nocontrol);
                        }
                    }
                    else
                    {
                        BottomControls.Controls.Add(nocontrol);
                    }
                }
                else
                {
                    BottomControls.Visible = false;
                    BottomControls.Controls.Clear();
                    NotFound.Hide();
                }
            }

        }
        /// <summary>
        /// Добавление свернутного сплеша
        /// </summary>
        /// <param name="splash"></param>
        public void AddHiddenSplash(HiddenSplash splash)
        {
            try
            {
                HiddenSplashPanel.Controls.Add(splash);
                HiddenSplashPanel.Visible = true;
                NoContacts.Hide();
            }
            catch (InvalidOperationException)
            {
                EventLogs.WriteLog("Add hidden splash", "Invalid operation exception");
            }
        }
        /// <summary>
        /// Удаление свернутого сплеша
        /// </summary>
        /// <param name="splash"></param>
        public void RemoveHiddenSplash(HiddenSplash splash)
        {
            try
            {
                HiddenSplashPanel.Controls.Remove(splash);
                if (HiddenSplashPanel.Controls.Count == 0)
                {
                    HiddenSplashPanel.Visible = false;
                    if (onBLFclients.Count == 0)
                    {
                        NoContacts.Show();
                    }
                }
            }
            catch (InvalidOperationException)
            {
                EventLogs.WriteLog("Remove hidden splash", "Invalid operation exception");
            }
        }
        /// <summary>
        /// Изменение контакта
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void card_edit(object sender, EventArgs e)
        {
            Card temp = sender as Card;
            AddToBook atb = new AddToBook(temp.client);
            atb.ShowDialog();
            for (int i = 0; i < BookOfContacts.Count; i++)
            {
                if (BookOfContacts[i].ID == temp.client.ID)
                {
                    BookOfContacts[i] = atb.newClient;
                    break;
                }
            }
            FullReload();
        }
        /// <summary>
        /// История по клику на карточку
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void card_history(object sender, EventArgs e)
        {
            Card temp = sender as Card;
            historyButton_Click(this, null);
            if (string.IsNullOrEmpty(temp.client.Name))
                historyForm.changeFilter(filter);
            else historyForm.changeFilter(temp.getMainNumber());
        }
        /// <summary>
        /// Удаление краточки
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void card_delete(object sender, EventArgs e)
        {
            Card temp = sender as Card;
            for (int i = 0; i < cardsChosen.Count; i++)
            {
                for (int j = 0; j < BookOfContacts.Count; j++)
                {
                    if (BookOfContacts[j].ID == temp.client.ID)
                    {
                        BookOfContacts[j].onBLF = false;
                        bOnBlfPanel.Controls.Remove(cardsChosen[i]);
                    }
                }
            }
            cardsChosen.Clear();
            FullReload();
        }
        /// <summary>
        /// Изменение позиции карточки
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void card_orderup(object sender, EventArgs e)
        {
            Card tempCard = (Card)sender;
            int i = bOnBlfPanel.Controls.IndexOf(tempCard);

            if (i != 0)
            {
                Card tempCard2 = (Card)bOnBlfPanel.Controls[i - 1];
                tempCard.client.onBLFposition = i - 1;
                tempCard2.client.onBLFposition = i;
                if (tempCard.bSelected)
                {
                    tempCard.bSelected = false;
                    tempCard.ChangeFocus();
                    tempCard2.bSelected = true;
                    tempCard2.ChangeFocus();
                }
                for (int j = 0; j < BookOfContacts.Count; j++)
                {

                    if (tempCard.client.ID == BookOfContacts[j].ID)
                    {
                        BookOfContacts[j] = tempCard.client;
                    }
                    if (tempCard2.client.ID == BookOfContacts[j].ID)
                    {
                        BookOfContacts[j] = tempCard2.client;
                    }
                }
                FullReload();
            }
        }
        /// <summary>
        /// Изменение позиции карточки
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void card_orderdown(object sender, EventArgs e)
        {
            Card tempCard = (Card)sender;
            int i = bOnBlfPanel.Controls.IndexOf(tempCard);
            if (i < bOnBlfPanel.Controls.Count - 1)
            {
                Card tempCard2 = (Card)bOnBlfPanel.Controls[i + 1];
                tempCard.client.onBLFposition = i + 1;
                tempCard2.client.onBLFposition = i;
                if (tempCard.bSelected)
                {
                    tempCard.bSelected = false;
                    tempCard.ChangeFocus();
                    tempCard2.bSelected = true;
                    tempCard2.ChangeFocus();
                }
                for (int j = 0; j < BookOfContacts.Count; j++)
                {
                    if (tempCard.client.ID == BookOfContacts[j].ID)
                    {
                        BookOfContacts[j] = tempCard.client;
                    }
                    if (tempCard2.client.ID == BookOfContacts[j].ID)
                    {
                        BookOfContacts[j] = tempCard2.client;
                    }
                }
                FullReload();
            }
        }
        /// <summary>
        /// Клик по кнопке сворачивания
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void closeButton_Click(object sender, EventArgs e)
        {
#if LOG
            if (settings.Logs.bEventLogEnabled) EventLogs.WriteLog(("Close clicked..."));
#endif
            if (settings.Tray.bTrayEnabled)
            {
                if (settings.Tray.bMinimizedToTray)
                {
                    this.Visible = false;
                    //this.WindowState = FormWindowState.Minimized;
                    this.ShowInTaskbar = false;
                }
                else
                {
                    this.WindowState = FormWindowState.Minimized;
                }
            }
            else
            {
#if LOG
                if (settings.Logs.bEventLogEnabled) EventLogs.WriteLog(("ContactBookSaving..."));
#endif
                XMLReadWriter.WriteContacts(BookOfContacts);
                Application.Exit();
            }
        }

        Authorization auth;
        private void newBLFPanel_Shown(object sender, EventArgs e)
        {
            BlfNumberLabel.Text = "";
            BlfStatusLabel.Text = "...";
            reconnectToolStripMenuItem.Text = "Connect";

            try
            {
                StatusToolTip.SetToolTip(BlfStatusLabel, Localization[BlfNumberLabel.Name][2]);
            }
            catch
            {
                StatusToolTip.SetToolTip(BlfStatusLabel, "Не авторизован");
            }

            BlfNumberLabel.BackColor = Color.FromArgb(255, 128, 128);
            BlfStatusLabel.BackColor = Color.FromArgb(255, 128, 128);
            this.Visible = true;
            this.WindowState = FormWindowState.Normal;
#if LOG
            if (settings.Logs.bEventLogEnabled) EventLogs.WriteLog(("Authorization..."));
#endif
            if (auth == null || auth.IsDisposed)
            {
                auth = new Authorization();
                auth.LoginComplete += Autho_LoginComplete;
                auth.Show(this);
            }
            else
            {
                if (!auth.Visible)
                    auth.Show(this);
            }

        }


        /// <summary>
        /// Событие успешной авторизации
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Autho_LoginComplete(object sender, EventArgs e)
        {
            if (auth.bLoginSuccess)
            {
                AMI = auth.loginAmiManager;
                if (AMI.UserData != null)
                {
                    AMI.SIPADDHEADER = settings.Integration.SIPADDHEADER;
                    AMI.CallerID = settings.Integration.CallerID;
                    AMI.RecvLogPath = settings.Logs.AmiLogFolder;
                    AMI.IsLogEnabled = settings.Logs.bAmiLogEnabled;
#if LOG
                    if (AMI.UserData.Status != null)
                    {
                        if (settings.Logs.bEventLogEnabled) EventLogs.WriteLog("Auth complete...", AMI.UserData.Status);
                    }
#endif
                    if (AMI.UserData.Status.Contains("OK") && AMI.UserData != null)
                    {
#if LOG
                        if (settings.Logs.bEventLogEnabled) EventLogs.WriteLog("Connected", "Status OK");
#endif
                        AMI.Disconnecting += MainAMImanager_Disconnected;
                        AMI.CallerID = settings.Integration.CallerID;
                        this.Invoke((MethodInvoker)delegate
                        {
                            BlfNumberLabel.Text = AMI.UserData.Number;
                            BlfStatusLabel.Text = "Online";
                            BlfNumberLabel.BackColor = Color.FromArgb(0, 171, 57);
                            BlfStatusLabel.BackColor = Color.FromArgb(0, 171, 57);
                            reconnectToolStripMenuItem.Text = "Disconnect";
                            ununs = new UnunsweredForm();
                            ununs.Show(this);
                            ununs.openHistory += Ununs_openHistory;
                            ununs.SetLocation(Screen.PrimaryScreen.WorkingArea.Size.Width - ununs.Width, Screen.PrimaryScreen.WorkingArea.Size.Height - ununs.Height);
                            ununs.Visible = false;

                            try
                            {
                                StatusToolTip.SetToolTip(BlfStatusLabel,
                                    Localization[BlfNumberLabel.Name][1] + AMI.UserData.Number);
                            }
                            catch (NullReferenceException)
                            {
                                StatusToolTip.SetToolTip(BlfStatusLabel,
                                    Localization[BlfNumberLabel.Name][1]);
                            }
                            catch (KeyNotFoundException)
                            {
                                StatusToolTip.SetToolTip(BlfStatusLabel,
                                    "Вы авторизованы как: ");
                            }
                        });
                        LoginSuccess = true;
                        EventManager.ConversationBegin += EventManager_ConversationBegin;
                        EventManager.ConversationEnd += EventManager_ConversationEnd;
                        EventManager.DialBegin += EventManager_DialBegin;
                        EventManager.HoldEvent += EventManager_HoldEvent;
                        EventManager.UnholdEvent += EventManager_UnholdEvent;
                        this.Invoke((MethodInvoker)delegate
                        {
                            for (int i = 0; i < contactCards.Count; i++)
                            {
                                for (int j = 0; j < AMI.ServerUsers.Count; j++)
                                {
                                    try
                                    {
                                        if (contactCards[i].client.Number == AMI.ServerUsers[j].Number)
                                        {
                                            contactCards[i].client.Status = AMI.ServerUsers[j].Status;
                                            contactCards[i].UpdateStatus();
                                        }
                                    }
                                    catch
                                    { }
                                }
                            }
                        });
                    }
                    else if (AMI.UserData.Status == "UNKNOWN")
                    {
#if LOG
                        if (settings.Logs.bEventLogEnabled) EventLogs.WriteLog("Connected", "Status UNKNOWN");
#endif
                        this.Invoke((MethodInvoker)delegate
                        {
                            BlfNumberLabel.Text = AMI.UserData.Number;
                            BlfStatusLabel.Text = "Error";
                            reconnectToolStripMenuItem.Text = "Disconnect";

                            try
                            {
                                StatusToolTip.SetToolTip(BlfStatusLabel,
                                    Localization[reconnectToolStripMenuItem.Name][1]);
                            }
                            catch (Exception)
                            {
                                StatusToolTip.SetToolTip(BlfStatusLabel, "Успешная авторизация, однако телефон с данным номером недоступен");
                            }

                            BlfNumberLabel.BackColor = Color.FromArgb(255, 128, 128);
                            BlfStatusLabel.BackColor = Color.FromArgb(255, 128, 128);
                        });
                    }
                    else if (AMI.UserData.Status == "UNREACHABLE")
                    {
#if LOG
                        if (settings.Logs.bEventLogEnabled) EventLogs.WriteLog("Connected", "Status UNREACHEBLE");
#endif
                        this.Invoke((MethodInvoker)delegate
                        {

                            BlfNumberLabel.Text = AMI.UserData.Number;
                            BlfStatusLabel.Text = "Error";
                            reconnectToolStripMenuItem.Text = "Disconnect";

                            try
                            {
                                StatusToolTip.SetToolTip(BlfStatusLabel,
                                    Localization[reconnectToolStripMenuItem.Name][1]);
                            }
                            catch
                            {
                                StatusToolTip.SetToolTip(BlfStatusLabel, "Успешная авторизация, однако телефон с данным номером недоступен");

                            }

                            BlfNumberLabel.BackColor = Color.FromArgb(255, 128, 128);
                            BlfStatusLabel.BackColor = Color.FromArgb(255, 128, 128);
                        });
                    }
                    else if (AMI.UserData.Status == "Unmonitored")
                    {
#if LOG
                        if (settings.Logs.bEventLogEnabled) EventLogs.WriteLog("Connected", "Status OK");
#endif
                        AMI.Disconnecting += MainAMImanager_Disconnected;
                        AMI.CallerID = settings.Integration.CallerID;
                        this.Invoke((MethodInvoker)delegate
                        {

                            BlfNumberLabel.Text = AMI.UserData.Number;
                            BlfStatusLabel.Text = "Online";
                            BlfNumberLabel.BackColor = Color.FromArgb(0, 171, 57);
                            BlfStatusLabel.BackColor = Color.FromArgb(0, 171, 57);
                            reconnectToolStripMenuItem.Text = "Disconnect";
                            ununs = new UnunsweredForm();
                            ununs.Show(this);
                            ununs.openHistory += Ununs_openHistory;
                            ununs.SetLocation(Screen.PrimaryScreen.WorkingArea.Size.Width - ununs.Width, Screen.PrimaryScreen.WorkingArea.Size.Height - ununs.Height);
                            ununs.Visible = false;
                            try
                            {
                                StatusToolTip.SetToolTip(BlfStatusLabel,
                                    Localization[BlfNumberLabel.Name][1] + AMI.UserData.Number);
                            }
                            catch
                            {
                                StatusToolTip.SetToolTip(BlfStatusLabel,
                                    "Вы авторизованы как");
                            }
                        });
                        LoginSuccess = true;
                        EventManager.ConversationBegin += EventManager_ConversationBegin;
                        EventManager.ConversationEnd += EventManager_ConversationEnd;
                        EventManager.DialBegin += EventManager_DialBegin;
                        EventManager.HoldEvent += EventManager_HoldEvent;
                        EventManager.UnholdEvent += EventManager_UnholdEvent;
                        this.Invoke((MethodInvoker)delegate
                        {
                            for (int i = 0; i < contactCards.Count; i++)
                            {
                                for (int j = 0; j < AMI.ServerUsers.Count; j++)
                                {
                                    if (contactCards[i].client.Number == AMI.ServerUsers[j].Number)
                                    {
                                        contactCards[i].client.Status = AMI.ServerUsers[j].Status;
                                        contactCards[i].UpdateStatus();
                                    }
                                }

                            }
                        });
                    }
                    else
                    {
#if LOG
                        if (settings.Logs.bEventLogEnabled) EventLogs.WriteLog("Aithentification Failure", "NOT IMPLEMNTED");
#endif
                        this.Invoke((MethodInvoker)delegate
                        {
                            BlfNumberLabel.Text = "Auth";
                            BlfStatusLabel.Text = "Failure";
                            reconnectToolStripMenuItem.Text = "Disconnect";
                            try
                            {
                                StatusToolTip.SetToolTip(BlfStatusLabel,
                                    Localization[reconnectToolStripMenuItem.Name][2]);
                            }
                            catch
                            {
                                StatusToolTip.SetToolTip(BlfStatusLabel, "Не авторизован");
                            }
                            BlfNumberLabel.BackColor = Color.FromArgb(255, 128, 128);
                            BlfStatusLabel.BackColor = Color.FromArgb(255, 128, 128);
                        });

                    }
                }
                else
                {
#if LOG
                    if (settings.Logs.bEventLogEnabled) EventLogs.WriteLog(("Aithentification Failure"));
#endif
                    this.Invoke((MethodInvoker)delegate
                    {
                        BlfNumberLabel.Text = "Auth";
                        BlfStatusLabel.Text = "Failure";
                        reconnectToolStripMenuItem.Text = "Connect";
                        try
                        {
                            StatusToolTip.SetToolTip(BlfStatusLabel, Localization[reconnectToolStripMenuItem.Name][2]);
                        }
                        catch
                        {
                            StatusToolTip.SetToolTip(BlfStatusLabel, "Не авторизован");
                        }
                        BlfNumberLabel.BackColor = Color.FromArgb(255, 128, 128);
                        BlfStatusLabel.BackColor = Color.FromArgb(255, 128, 128);
                    });
                }
            }
            else
            {

#if LOG
                if (settings.Logs.bEventLogEnabled) EventLogs.WriteLog(("Aithentification Failure"));
#endif
                this.Invoke((MethodInvoker)delegate
                {
                    BlfNumberLabel.Text = "Auth";
                    BlfStatusLabel.Text = "Failure";
                    reconnectToolStripMenuItem.Text = "Connect";
                    try
                    {
                        StatusToolTip.SetToolTip(BlfStatusLabel, Localization[reconnectToolStripMenuItem.Name][2]);
                    }
                    catch
                    {
                        StatusToolTip.SetToolTip(BlfStatusLabel, "Не авторизован");
                    }
                    BlfNumberLabel.BackColor = Color.FromArgb(255, 128, 128);
                    BlfStatusLabel.BackColor = Color.FromArgb(255, 128, 128);
                });
            }
            if (AMI != null && AMI.UserData != null)
            {
                if (!AMI.UserData.Status.Contains("OK"))
                {
                    this.Invoke((MethodInvoker)delegate
                    {
                        for (int i = 0; i < contactCards.Count; i++)
                        {
                            contactCards[i].client.Status = "UNKNOWN";
                            contactCards[i].UpdateStatus();
                        }
                    });
                }
            }
            else
            {
                this.Invoke((MethodInvoker)delegate
                {
                    for (int i = 0; i < contactCards.Count; i++)
                    {
                        contactCards[i].client.Status = "UNKNOWN";
                        contactCards[i].UpdateStatus();
                    }
                });
            }

            if (!this.Disposing && !this.IsDisposed)
            {
                this.WindowState = FormWindowState.Normal;
            }
            if (LoginSuccess)
            {
                if (!string.IsNullOrEmpty(StartArgs))
                {
                    RaiseCall(StartArgs.ToLower().Replace("callto", "").Replace("bcti", "").Replace("uri", "").Replace("(", "").Replace(")", "").Replace("-", "").Replace(" ", "").Replace("tel", "").Replace(":", ""));
                }
            }
        }
        /// <summary>
        /// Событие снятия с паузы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EventManager_UnholdEvent(object sender, DialEventArgs e)
        {
            if (!((e.dialinfo.CallerIDNum == AMI.UserData.Number || e.dialinfo.ConnectedLineNum == AMI.UserData.Number) && (e.dialinfo.CallerIDNum != e.dialinfo.ConnectedLineNum)))
            {
                UpdateStatuses(e.dialinfo, "Talk");
            }
            else
            {
#if LOG
                if (settings.Logs.bEventLogEnabled) EventLogs.WriteLog("Conversation Begin", "\r\nCallerID " + e.dialinfo.CallerIDNum + "\r\nChannelID " + e.dialinfo.ChannelID + "\r\nDestChannelID " + e.dialinfo.DestinationID + "\r\nConnetedLineNum " + e.dialinfo.ConnectedLineNum + "\r\nUniqueID " + e.dialinfo.Uniqueid);
#endif
                UpdateStatuses(e.dialinfo, "Talk");
                statusesSemaphore.WaitOne();
                try
                {
                    BlfStatusLabel.BeginInvoke((MethodInvoker)(() =>
                    {
                        BlfStatusLabel.Text = Localization[BlfStatusLabel.Name][1];
                        BlfStatusLabel.BackColor = Color.LawnGreen;
                    }));
                }
                catch (Exception)
                {
                    BlfStatusLabel.BeginInvoke((MethodInvoker)(() =>
                    {
                        BlfStatusLabel.Text = "Разговор";
                        BlfStatusLabel.BackColor = Color.LawnGreen;
                    }));
                }
                BlfNumberLabel.BeginInvoke((MethodInvoker)(() => BlfNumberLabel.BackColor = Color.LawnGreen));
                statusesSemaphore.Set();
                callsSemaphore.WaitOne();
                for (int i = 0; i < calls.Count; i++)
                {
                    if (calls[i].DialsCount > 0)
                    {
                        if (calls[i].CompareDials(e.dialinfo))
                        {
                            calls[i].UnHold();
                            callsSemaphore.Set();
                            return;
                        }
                    }
                }
                callsSemaphore.Set();
            }
        }
        /// <summary>
        /// Событие паузы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EventManager_HoldEvent(object sender, DialEventArgs e)
        {
            if (!((e.dialinfo.CallerIDNum == AMI.UserData.Number || e.dialinfo.ConnectedLineNum == AMI.UserData.Number) && (e.dialinfo.CallerIDNum != e.dialinfo.ConnectedLineNum)))
            {
                UpdateStatuses(e.dialinfo, "Hold");
            }
            else
            {
#if LOG
                if (settings.Logs.bEventLogEnabled) EventLogs.WriteLog("Conversation Begin", "\r\nCallerID " + e.dialinfo.CallerIDNum + "\r\nChannelID " + e.dialinfo.ChannelID + "\r\nDestChannelID " + e.dialinfo.DestinationID + "\r\nConnetedLineNum " + e.dialinfo.ConnectedLineNum + "\r\nUniqueID " + e.dialinfo.Uniqueid);
#endif
                UpdateStatuses(e.dialinfo, "Hold");
                statusesSemaphore.WaitOne();
                BlfStatusLabel.BeginInvoke((MethodInvoker)(() =>
                {
                    BlfStatusLabel.Text = "Hold";
                    BlfStatusLabel.BackColor = Color.LawnGreen;
                }));
                BlfNumberLabel.BeginInvoke((MethodInvoker)(() => BlfNumberLabel.BackColor = Color.LawnGreen));
                statusesSemaphore.Set();
                callsSemaphore.WaitOne();
                for (int i = 0; i < calls.Count; i++)
                {
                    if (calls[i].DialsCount > 0)
                    {
                        if (calls[i].CompareDials(e.dialinfo))
                        {
                            calls[i].Hold();
                            callsSemaphore.Set();
                            return;
                        }
                    }
                }
                callsSemaphore.Set();
            }
        }
        /// <summary>
        /// Событие отключения библиотеки
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainAMImanager_Disconnected(object sender, EventArgs e)
        {
            EventManager.ConversationBegin -= EventManager_ConversationBegin;
            EventManager.ConversationEnd -= EventManager_ConversationEnd;
            EventManager.DialBegin -= EventManager_DialBegin;
            EventManager.HoldEvent -= EventManager_HoldEvent;
            EventManager.UnholdEvent -= EventManager_UnholdEvent;
#if LOG
            if (settings.Logs.bEventLogEnabled) EventLogs.WriteLog(("Disconnected by server"));
#endif
            if (AMI != null)
            {
                if (AMI.IsAlive)
                    AMI.Disconnect();
                else
                {
                    AMI.Abort();
                }
            }
            try
            {
                this.Invoke((MethodInvoker)delegate
                {
                    ClearCallls();
                    BlfNumberLabel.Text = "Auth";
                    BlfStatusLabel.Text = "Failure";
                    try
                    {
                        StatusToolTip.SetToolTip(BlfStatusLabel, Localization[reconnectToolStripMenuItem.Name][2]);
                    }
                    catch
                    {
                        StatusToolTip.SetToolTip(BlfStatusLabel, "Не авторизован");
                    }
                    BlfNumberLabel.BackColor = Color.FromArgb(255, 128, 128);
                    BlfStatusLabel.BackColor = Color.FromArgb(255, 128, 128);
                    reconnectToolStripMenuItem.Text = "Connect";
                    for (int i = 0; i < contactCards.Count; i++)
                    {
                        contactCards[i].client.Status = "UNKNOWN";
                        contactCards[i].UpdateStatus();
                    }
                });
            }
            catch (Exception ex)
            {
                EventLogs.WriteLog(ex.Message, ex.StackTrace);
            }
            if (Autoreconnect)
            {
                try
                {
                    this.Invoke((MethodInvoker)(() => newBLFPanel_Shown(this, null)));
                }
                catch (Exception ex)
                {
                    EventLogs.WriteLog(ex.Message, ex.StackTrace);
                }
            }
        }
        /// <summary>
        /// Событие очистки неотвеченных звонков
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Ununs_openHistory(object sender, EventArgs e)
        {
            if (historyForm == null)
            {
                historyForm = new History(ringList, BookOfContacts);
                historyForm.OnlyUnunswered();
                Invoke((MethodInvoker)(() => historyForm.Show(this)));
            }
            else if (historyForm.IsDisposed)
            {
                historyForm = new History(ringList, BookOfContacts);
                historyForm.OnlyUnunswered();
                Invoke((MethodInvoker)(() => historyForm.Show(this)));
            }
            else
            {
                historyForm.OnlyUnunswered();
                if (!historyForm.Visible)
                    Invoke((MethodInvoker)(() => historyForm.Show(this)));
            }
            //historyForm.FormClosing += HistoryForm_FormClosing;

        }
        /// <summary>
        /// Добавление в книгу контактов
        /// </summary>
        /// <param name="client"></param>
        public void AddToBook(ClientsData client)
        {
            for (int i = 0; i < BookOfContacts.Count; i++)
            {
                if (BookOfContacts[i].Number == client.Number || BookOfContacts[i].SecondNumber == client.Number)
                {
                    client = BookOfContacts[i];
                    break;
                }
            }
            AddToBook atb = new AddToBook(client);
            atb.FormClosing += Atb_FormClosing;
            try
            {
                this.BeginInvoke((MethodInvoker)(() => atb.ShowDialog(this)));
            }
            catch (Exception ex)
            {
                EventLogs.WriteLog(ex.Message, ex.StackTrace);
            }
        }
        /// <summary>
        /// Отрытие форму истории
        /// </summary>
        /// <param name="number"></param>
        public void OpenHistory(string number)
        {
            if (historyForm == null)
            {
                historyForm = new History(ringList, BookOfContacts);
                historyForm.filter = number;
            }
            if (historyForm.IsDisposed)
            {
                historyForm = new History(ringList, BookOfContacts);
                historyForm.filter = number;
                Invoke((MethodInvoker)(() => historyForm.Show(this)));
            }
            else
            {
                Invoke((MethodInvoker)(() =>
                {
                    historyForm.Show(this);
                    historyForm.changeFilter(number);
                }));
            }
        }
        /// <summary>
        /// Поиск последней информации о звонке с данным пользователем
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        public string FindRingInfo(ClientsData client)
        {
            for (int i = 0; i < ringList.Count; i++)
                try
                {
                    if (ringList[i].number == client.Number || (ringList[i].number == client.SecondNumber && client.SecondNumber != string.Empty))
                    {
                        return ringList[i].momentOfRing.ToString();
                    }
                }
                catch (Exception ex)
                {
                    EventLogs.WriteLog(ex.Message, ex.StackTrace);
                }
            return string.Empty;
        }
        /// <summary>
        /// Добавить звонок в историю
        /// </summary>
        /// <param name="ring"></param>

        public void AddRingInfo(RingInfo ring)
        {
            ringsSemaphore.WaitOne();
            bool find = false;
            for (int i = 0; i < ringList.Count; i++)
            {
                try
                {
                    if (ringList[i].number == ring.number &&
                        ringList[i].type == ring.type &&
                        ringList[i].momentOfRing == ring.momentOfRing)
                    {
                        find = true;
                        break;
                    }
                }
                catch (Exception ex)
                {
                    EventLogs.WriteLog(ex.Message, ex.StackTrace);
                }
            }
            if (!find)
            {
                ringList.Insert(0, ring);
                XMLReadWriter.WriteHistory(ringList);
                //34534
            }

            if (ring.type == CallType.Unanswered)
                try
                {
                    Invoke((MethodInvoker)(() =>
                    {
                        ununs.IncreseUnunswered();
                        MissedCallsLabel.Text = ununs.ununsweredCounter.ToString();
                        MissedCallsLabel.Show();
                        ununs.Visible = true;
                    }));
                }
                catch (InvalidOperationException)
                {

                }
            ringsSemaphore.Set();
        }
        /// <summary>
        /// Событие закрытия формы контактов
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Atb_FormClosing(object sender, FormClosingEventArgs e)
        {
            AddToBook curr = (AddToBook)sender;
            int found = 0;
            for (int i = 0; i < BookOfContacts.Count; i++)
            {
                if ((BookOfContacts[i].Number == curr.newClient.Number && !string.IsNullOrEmpty(curr.newClient.Number)) ||
                    BookOfContacts[i].SecondNumber == curr.newClient.SecondNumber && !string.IsNullOrEmpty(curr.newClient.SecondNumber))
                {
                    found = 1;
                    break;
                }
            }
            if (curr.added && found == 0)
            {
                if (!curr.editing)
                    BookOfContacts.Add(curr.newClient);
                else
                {
                    for (int i = 0; i < BookOfContacts.Count; i++)
                    {
                        if (curr.newClient.ID == BookOfContacts[i].ID)
                        {
                            BookOfContacts[i] = curr.newClient;
                            break;
                        }
                    }
                }
                FullReload();
            }
        }

        AutoResetEvent statusesSemaphore = new AutoResetEvent(true);
        AutoResetEvent callsSemaphore = new AutoResetEvent(true);
        AutoResetEvent ringsSemaphore = new AutoResetEvent(true);

        /// <summary>
        /// Обновление статусов
        /// </summary>
        /// <param name="dialinfo"></param>
        /// <param name="_Status"></param>
        private void UpdateStatuses(DialData dialinfo, string _Status)
        {
            statusesSemaphore.WaitOne();
            if (dialinfo.ChannelID != dialinfo.DestinationID)
            {
                for (int i = 0; i < contactCards.Count; i++)
                {
                    if (contactCards[i].client.Number == dialinfo.CallerIDNum || contactCards[i].client.Number == dialinfo.ConnectedLineNum)
                    {
                        contactCards[i].client.Status = _Status;
                        contactCards[i].UpdateStatus();
                    }
                }
            }
            statusesSemaphore.Set();
        }
        /// <summary>
        /// Обновление пользовательского статуса
        /// </summary>
        /// <param name="statustext"></param>
        public void UpdateUserStatus(string statustext)
        {
            statusesSemaphore.WaitOne();
            switch (statustext)
            {
                case "Online":
                    //if (calls.Count == 1)
                    //{
                    BlfStatusLabel.BeginInvoke((MethodInvoker)(() =>
                    {
                        BlfStatusLabel.Text = "Online";
                        BlfStatusLabel.BackColor = Color.FromArgb(0, 171, 57);
                    }));
                    BlfNumberLabel.BeginInvoke((MethodInvoker)(() => BlfNumberLabel.BackColor = Color.FromArgb(0, 171, 57)));
                    //}
                    break;
                case "Звонит":
                    BlfStatusLabel.BeginInvoke((MethodInvoker)(() =>
                    {
                        BlfStatusLabel.Text = "Звонит";
                        BlfStatusLabel.BackColor = Color.Orange;
                    }));
                    BlfNumberLabel.BeginInvoke((MethodInvoker)(() => BlfNumberLabel.BackColor = Color.Orange));
                    break;
                case "Разговор":
                    BlfStatusLabel.BeginInvoke((MethodInvoker)(() =>
                    {
                        BlfStatusLabel.Text = "Разговор";
                        BlfStatusLabel.BackColor = Color.LawnGreen;
                    }));
                    BlfNumberLabel.BeginInvoke((MethodInvoker)(() => BlfNumberLabel.BackColor = Color.LawnGreen));
                    break;
                default:
                    break;
            }


            statusesSemaphore.Set();
        }
        public void DeleteHanguped()
        {
            callsSemaphore.WaitOne();
            for (int i = 0; i < calls.Count; i++)
            {
                if (calls[i].Hanguped)
                {
                    calls[i].Dispose();
                    try { calls.RemoveAt(i); } catch (Exception ex) { EventLogs.WriteLog(ex.Message, ex.StackTrace); }
                    i--;
                    continue;
                }
            }
            callsSemaphore.Set();
        }
        /// <summary>
        /// Начало звонка
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EventManager_DialBegin(object sender, DialEventArgs e)
        {
            if (!(e.dialinfo.CallerIDNum == AMI.UserData.Number || e.dialinfo.ConnectedLineNum == AMI.UserData.Number) || (e.dialinfo.ChannelID == e.dialinfo.DestinationID))
            {
                UpdateStatuses(e.dialinfo, "Call");
                return;
            }
            else
            {
                //#if LOG
                //                if (settings.bEventLogEnabled) EventLogs.WriteLog("Dial Begin", "\r\nCallerID " + e.dialinfo.CallerIDNum + "\r\nChannelID " + e.dialinfo.ChannelID + "\r\nDestChannelID " + e.dialinfo.DestinationID + "\r\nConnetedLineNum " + e.dialinfo.ConnectedLineNum + "\r\nUniqueID " + e.dialinfo.Uniqueid);
                //#endif
                callsSemaphore.WaitOne();
                for (int i = 0; i < calls.Count; i++)
                {
                    if (calls[i].DialsCount > 0)
                    {
                        if (calls[i].IsRedirected(e.dialinfo))
                        {
                            calls[i].Dispose();
                            try { calls.RemoveAt(i); } catch (Exception ex) { EventLogs.WriteLog(ex.Message, ex.StackTrace); }
                            callsSemaphore.Set();
                            return;
                        }
                        if (calls[i].CompareDials(e.dialinfo))
                        {
                            calls[i].UpdateDialInfo(e.dialinfo);
                            callsSemaphore.Set();
                            UpdateStatuses(e.dialinfo, "Call");
                            UpdateUserStatus("Звонит");
                            WriteLog(e);
                            return;
                        }
                        if (!string.IsNullOrEmpty(calls[i].NotBlindNumberTransferTo) && calls[i].NotBlindNumberTransferTo == e.dialinfo.ConnectedLineNum)
                        {
                            calls[i].UpdateDialInfo(e.dialinfo);
                            callsSemaphore.Set();
                            WriteLog(e);
                            calls[i].UnionSplash();
                            return;
                        }
                    }
                    else
                    {
                        if (calls[i].Number == e.dialinfo.CallerIDNum || calls[i].Number == e.dialinfo.ConnectedLineNum)
                        {
                            if (!string.IsNullOrEmpty(calls[i].NotBlindNumberTransferTo) && calls[i].NotBlindNumberTransferTo == e.dialinfo.ConnectedLineNum)
                            {
                                calls[i].UpdateDialInfo(e.dialinfo);
                                callsSemaphore.Set();
                                WriteLog(e);
                                calls[i].UnionSplash();
                                return;
                            }
                            else
                            {
                                calls[i].UpdateDialInfo(e.dialinfo);
                                callsSemaphore.Set();
                                UpdateStatuses(e.dialinfo, "Call");
                                UpdateUserStatus("Звонит");
                                WriteLog(e);
                                return;
                            }
                        }
                        else if ((e.dialinfo.CallerIDNum.Contains(calls[i].Number) && !string.IsNullOrEmpty(e.dialinfo.CallerIDNum)) || (e.dialinfo.ConnectedLineNum.Contains(calls[i].Number) && !string.IsNullOrEmpty(e.dialinfo.ConnectedLineNum)))
                        {
                            calls[i].UpdateDialInfo(e.dialinfo);
                            callsSemaphore.Set();
                            UpdateStatuses(e.dialinfo, "Call");
                            UpdateUserStatus("Звонит");
                            WriteLog(e);
                            return;
                        }
                    }
                }
                CallType ringType = CallType.IncomingCall;
                string number = string.Empty;
                if (e.dialinfo.CallerIDNum == AMI.UserData.Number)
                {
                    ringType = CallType.OutcomingCall;
                    number = e.dialinfo.ConnectedLineNum;
                }
                else if (e.dialinfo.ConnectedLineNum == AMI.UserData.Number)
                {
                    ringType = CallType.IncomingCall;
                    number = e.dialinfo.CallerIDNum;
                }
                ClientsData temp = new ClientsData();
                temp.Number = number;
                for (int i = 0; i < BookOfContacts.Count; i++)
                {
                    if (BookOfContacts[i].Number == number || (!string.IsNullOrEmpty(BookOfContacts[i].SecondNumber) && BookOfContacts[i].SecondNumber == number))
                    {
                        temp = BookOfContacts[i];
                        break;
                    }
                }
                calls.Add(new CallManager(this, ringType, e.dialinfo, temp, number));
                if (Staticsettings.CommonSettings.bDoNotDisturb)
                    calls.Last().HideSplash();
                callsSemaphore.Set();
                UpdateStatuses(e.dialinfo, "Call");
                UpdateUserStatus("Звонит");
                WriteLog(e);
            }
        }
        private void WriteLog(DialEventArgs e)
        {
#if LOG
            if (Staticsettings.Logs.bEventLogEnabled) EventLogs.WriteLog(e.dialinfo.currentstatus.ToString(),
                "CallerID " + e.dialinfo.CallerIDNum +
                "\r\nChannelID " + e.dialinfo.ChannelID +
                "\r\nDestChannelID " + e.dialinfo.DestinationID +
                "\r\nConnetedLineNum " + e.dialinfo.ConnectedLineNum +
                "\r\nUniqueID " + e.dialinfo.Uniqueid);
#endif
        }
        /// <summary>
        /// Начало разговора
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EventManager_ConversationBegin(object sender, DialEventArgs e)
        {
            //if (!((e.dialinfo.CallerIDNum == AMI.UserData.Number || e.dialinfo.ConnectedLineNum == AMI.UserData.Number) && (e.dialinfo.CallerIDNum != e.dialinfo.ConnectedLineNum)))
            //{

            //}
            //else
            //{


            callsSemaphore.WaitOne();
            for (int i = 0; i < calls.Count; i++)
            {
                if (calls[i].DialsCount > 0)
                {
                    if (calls[i].IsRedirected(e.dialinfo))
                    {
                        return;
                    }
                    if (calls[i].CompareDials(e.dialinfo))
                    {
                        calls[i].UpdateDialInfo(e.dialinfo);
                        calls[i].ConversationStart();
                        callsSemaphore.Set();
                        WriteLog(e);
                        UpdateStatuses(e.dialinfo, "Talk");
                        UpdateUserStatus("Разговор");
                        return;
                    }
                    if (!string.IsNullOrEmpty(calls[i].NotBlindNumberTransferTo) && calls[i].NotBlindNumberTransferTo == e.dialinfo.ConnectedLineNum)
                    {
                        calls[i].UpdateDialInfo(e.dialinfo);
                        callsSemaphore.Set();
                        WriteLog(e);
                        calls[i].UnionSplash();
                        return;
                    }
                }
                else
                {
                    if (calls[i].Number == e.dialinfo.CallerIDNum || calls[i].Number == e.dialinfo.ConnectedLineNum)
                    {
                        calls[i].UpdateDialInfo(e.dialinfo);
                        calls[i].ConversationStart();
                        callsSemaphore.Set();
                        WriteLog(e);
                        UpdateStatuses(e.dialinfo, "Talk");
                        UpdateUserStatus("Разговор");
                        return;
                    }
                }
            }
            callsSemaphore.Set();
            //}
            UpdateStatuses(e.dialinfo, "Talk");
        }
        /// <summary>
        /// Конец звонка
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EventManager_ConversationEnd(object sender, DialEventArgs e)
        {
            callsSemaphore.WaitOne();
            for (int i = 0; i < calls.Count; i++)
            {
                if (calls[i].DialsCount > 0)
                {
                    if (calls[i].CompareDials(e.dialinfo))
                    {
                        if (!calls[i].IsRedirected(e.dialinfo))
                        {
                            calls[i].ConversationEnd(e.dialinfo);
                        }
                        if (calls[i].DialsCount == 0 || calls[i].Hanguped)
                        {
                            WriteLog(e);
                            UpdateUserStatus("Online");
                            UpdateStatuses(e.dialinfo, "OK");
                            Thread.Sleep(1500);

                            calls[i].Dispose();
                            try { if (string.IsNullOrEmpty(calls[i].NotBlindNumberTransferTo)) calls.RemoveAt(i); } catch (Exception ex) { EventLogs.WriteLog(ex.Message, ex.StackTrace); }

                            i--;
                        }
                        callsSemaphore.Set();

                        return;
                    }
                }
                else
                {
                    if (calls[i].Number == e.dialinfo.CallerIDNum || calls[i].Number == e.dialinfo.ConnectedLineNum)
                    {
                        calls[i].ConversationEnd(e.dialinfo);
                        if (calls[i].DialsCount == 0)
                        {
                            WriteLog(e);
                            UpdateUserStatus("Online");
                            UpdateStatuses(e.dialinfo, "OK");
                            Thread.Sleep(1500);
                            calls[i].Dispose();
                            try { calls.RemoveAt(i); } catch (Exception ex) { EventLogs.WriteLog(ex.Message, ex.StackTrace); }
                            i--;
                        }
                        callsSemaphore.Set();

                        return;
                    }
                    else if (e.dialinfo.CallerIDNum.Contains(AMI.UserData.Number))
                    {
                        calls[i].ConversationEnd(e.dialinfo);
                        if (calls[i].DialsCount == 0)
                        {
                            WriteLog(e);
                            UpdateUserStatus("Online");
                            UpdateStatuses(e.dialinfo, "OK");
                            Thread.Sleep(1500);
                            calls[i].Dispose();
                            try { calls.RemoveAt(i); } catch (Exception ex) { EventLogs.WriteLog(ex.Message, ex.StackTrace); }
                            i--;
                        }
                        callsSemaphore.Set();
                        return;
                    }
                }
            }
            callsSemaphore.Set();
            UpdateStatuses(e.dialinfo, "OK");
            //}
        }

        private void closeButton_MouseEnter(object sender, EventArgs e)
        {
            closeButton.BackgroundImage = closeButtonImage.Images[1];
        }

        private void closeButton_MouseLeave(object sender, EventArgs e)
        {
            if (!this.IsDisposed && !this.Disposing)
                closeButton.BackgroundImage = closeButtonImage.Images[0];
        }
        /// <summary>
        /// Открытие книги контактов
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void contactsButton_Click(object sender, EventArgs e)
        {
            if (contactsForm == null)
            {
                contactsForm = new Contacts(BookOfContacts);
                contactsForm.contactsEdited += copy_newBook;
            }
            if (!contactsForm.Visible)
                if (contactsForm.IsDisposed)
                {
                    contactsForm = new Contacts(BookOfContacts);
                    contactsForm.conBookEdited += new EventHandler<EventArgs>(copy_newBook);
                    contactsForm.Show(this);
                    for (int i = 0; i < contactCards.Count; i++)
                    {
                        contactCards[i].bSelected = false;
                    }
                }
                else
                {
                    contactsForm.conBookEdited += new EventHandler<EventArgs>(copy_newBook);
                    contactsForm.Show(this);
                    for (int i = 0; i < contactCards.Count; i++)
                    {
                        contactCards[i].bSelected = false;
                    }
                }

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void copy_newBook(object sender, EventArgs e)
        {
            Contacts temp = (Contacts)sender;
            BookOfContacts.Clear();
            for (int i = 0; i < temp.BookOfContacts.Count; i++)
            {
                BookOfContacts.Add(temp.BookOfContacts[i]._Client);
            }
            FullReload();
        }

        private void contactsButton_MouseEnter(object sender, EventArgs e)
        {
            contactsButton.BackgroundImage = topButtonsImageList.Images[3];
        }

        private void contactsButton_MouseLeave(object sender, EventArgs e)
        {
            contactsButton.BackgroundImage = topButtonsImageList.Images[2];
        }

        private void historyButton_MouseLeave(object sender, EventArgs e)
        {
            historyButton.BackgroundImage = topButtonsImageList.Images[0];
            //MissedCallsLabel.BackColor = Colors.WhiteTheme.DarkGray;
        }

        private void historyButton_MouseEnter(object sender, EventArgs e)
        {
            historyButton.BackgroundImage = topButtonsImageList.Images[1];
            MissedCallsLabel.BackColor = Color.Maroon;
        }

        private void settingsButton_MouseLeave(object sender, EventArgs e)
        {
            settingsButton.BackgroundImage = topButtonsImageList.Images[4];

        }

        private void settingsButton_MouseEnter(object sender, EventArgs e)
        {
            settingsButton.BackgroundImage = topButtonsImageList.Images[5];
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

        private void historyButton_Click(object sender, EventArgs e)
        {
            MissedCallsLabel.Hide();

            if (historyForm == null)
                historyForm = new History(ringList, BookOfContacts);
            if (!historyForm.Visible)
                if (historyForm.IsDisposed)
                {
                    historyForm = new History(ringList, BookOfContacts);
                    historyForm.Show(this);
                }
                else
                    historyForm.Show(this);
            //historyForm.FormClosing += HistoryForm_FormClosing;
        }

        private void TrayIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.TopMost = true;
            this.Show();
            this.ShowInTaskbar = true;
            this.WindowState = FormWindowState.Normal;
            closeButton.BackgroundImage = closeButtonImage.Images[0];
            this.Visible = true;
            this.TopMost = false;
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            XMLReadWriter.WriteContacts(BookOfContacts);
            //XmlSerializer xs = new XmlSerializer(typeof(List<ClientsData>));
            //if (!Directory.Exists(path + "/B-cti")) Directory.CreateDirectory(path + "/B-cti");
            //StreamWriter sw = new StreamWriter(path + "/B-cti/ContactsBook.xml");
            //try
            //{
            //    xs.Serialize(sw, BookOfContacts);
            //    sw.Flush();
            //    sw.Close();
            //}
            //catch (InvalidOperationException)
            //{
            //    sw.Close();
            //}
            Close();
        }

        private void неБеспокоитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            неБеспокоитьToolStripMenuItem.Checked = !неБеспокоитьToolStripMenuItem.Checked;
            IniSettings ini = new IniSettings();
            ini.path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\B-Cti\\UserSettings.ini";
            ini.IniWriteValue("ApplicationCommon", "DoNotDisturb", неБеспокоитьToolStripMenuItem.Checked.ToString());
        }

        private void settingsButton_Click(object sender, EventArgs e)
        {

            if (settingsForm == null)
                settingsForm = new SettingsForm();
            if (!settingsForm.Visible)
                if (settingsForm.IsDisposed)
                {
                    settingsForm = new SettingsForm();
                    settingsForm.Show(this);
                }
                else
                {
                    settingsForm.Show(this);
                }

        }

        private void ApplySettings(object sender, EventArgs e)
        {
            bool language_cahnged = (settings.Interface.Language != SettingsForm.settings.Interface.Language);
            settings = SettingsForm.settings;
            Editor.filePath = (string)settings.Pattern.PatternFilePath.Clone();
            string currFilter = string.Empty;
            this.BeginInvoke((MethodInvoker)(() =>
                {

                    try
                    {
                        if (!string.IsNullOrEmpty(SearchBox.Text) && SearchBox.Text != Localization[SearchBox.Name][0])
                            currFilter = SearchBox.Text;
                        Localization = Localizator.GetFormLocalization(this.Name, Staticsettings.Interface.Language);
                        Localizator.MakeLocalization(this, Localization);
                        Localizator.MakeLocalizationAllContextMenu(TrayMenu, Localization);
                        if (!string.IsNullOrEmpty(currFilter))
                            SearchBox.Text = currFilter;
                        prevFilter = Localization[SearchBox.Name][0];
                        settingsToolTip.SetToolTip(settingsButton, Localization[settingsButton.Name][0]);
                        contactsToolTip.SetToolTip(contactsButton, Localization[contactsButton.Name][0]);
                        historyToolTip.SetToolTip(historyButton, Localization[historyButton.Name][0]);
                    }
                    catch
                    {
                        if (!string.IsNullOrEmpty(SearchBox.Text) && SearchBox.Text != "Введите номер или имя")
                            currFilter = SearchBox.Text;
                        Localization = Localizator.GetFormLocalization("BLFPanel", Staticsettings.Interface.Language);
                        Localizator.MakeLocalization(this, Localization);
                        Localizator.MakeLocalizationAllContextMenu(TrayMenu, Localization);
                        if (!string.IsNullOrEmpty(currFilter))
                            SearchBox.Text = currFilter;
                        prevFilter = "Введите номер или имя";
                        settingsToolTip.SetToolTip(settingsButton, "Настройки");
                        contactsToolTip.SetToolTip(contactsButton, "Книга контактов");
                        historyToolTip.SetToolTip(historyButton, "История звонков");
                    }
                    ApplyLanguage?.Invoke(this, null);
                }));
            Staticsettings = settings;
            if (AMI != null)
            {
                AMI.SIPADDHEADER = settings.Integration.SIPADDHEADER;
                AMI.CallerID = settings.Integration.CallerID;
                AMI.IsLogEnabled = settings.Logs.bAmiLogEnabled;
                AMI.RecvLogPath = settings.Logs.AmiLogFolder;
            }
            SettingsForm.settings.CommonSettings.BlfLocation = this.DesktopLocation;
            SettingsForm.settings.CommonSettings.BlfSize = new Point(this.Size.Width, Size.Height);
            if (settings.Tray.bTrayEnabled)
                TrayIcon.Visible = true;
            else
            {
                TrayIcon.Visible = false; ;
                this.Visible = true;
                this.ShowInTaskbar = true;
            }
            if (settings.CommonSettings.bDoNotDisturb)
            {
                неБеспокоитьToolStripMenuItem.Checked = true;
            }
            else
            {
                неБеспокоитьToolStripMenuItem.Checked = false;
            }
#if LOG
            if (settings.Logs.bEventLogEnabled) EventLogs.WriteLog(("Settings Applied and Saved"));
#endif
            hook.UnregisterHotkey();
            //hook.Unregister();
            //hook = new KeyboardHook("Hotkeys", new HotkeyDefinition(Keys.C, false, true, false));
            hook.HotkeyPressed += Hook_HotkeyPressed;
            hook.CalltoEvent += Hook_CalltoEvent;
            try
            {
                ModifKeys modif = new ModifKeys();
                if (SettingsForm.settings.Hotkey.modifiers == Keys.Control)
                    modif = ModifKeys.Control;
                if (SettingsForm.settings.Hotkey.modifiers == Keys.Alt)
                    modif = modif | ModifKeys.Alt;
                if (SettingsForm.settings.Hotkey.modifiers == Keys.Shift)
                    modif = modif | ModifKeys.Shift;
                if (SettingsForm.settings.Hotkey.modifiers == Keys.LWin || settings.Hotkey.modifiers == Keys.RWin)
                    modif = modif | ModifKeys.Win;
                hook.RegisterHotKey(modif, settings.Hotkey.key);
            }
            catch (InvalidOperationException)
            {
                BMessageBox.Show("Не удалось зарегестрировать горячие клавиши. Возможно они уже используются другим приложением", "Ошибка");
            }
            SettingsForm.settings.SaveSettings();
        }

        private void TrayIcon_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                if (settings.Tray.bOneClickOpen)
                {
                    this.TopMost = true;
                    this.Show();
                    this.WindowState = FormWindowState.Normal;
                    this.Visible = true;
                    this.ShowInTaskbar = true;
                    closeButton.BackgroundImage = closeButtonImage.Images[0];
                    this.TopMost = false;
                }
        }

        private void настройкиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (settingsForm == null)
                settingsForm = new SettingsForm();
            if (!settingsForm.Visible)
                if (settingsForm.IsDisposed)
                {
                    settingsForm = new SettingsForm();
                    settingsForm.Show(this);
                }
                else
                {
                    settingsForm.Show(this);
                }
        }

        private void rightSizer_MouseLeave(object sender, EventArgs e)
        {
            Cursor = Cursors.Default;
        }

        private void downResizer_MouseEnter(object sender, EventArgs e)
        {
            Cursor = Cursors.SizeNS;
        }

        bool resizing = false;
        Point oldPosition = new Point();

        private void rightSizer_MouseUp(object sender, MouseEventArgs e)
        {
            resizing = false;
        }

        private void rightSizer_MouseDown(object sender, MouseEventArgs e)
        {
            resizing = true;
            oldPosition = PointToScreen(Cursor.Position);
        }

        private void topSizer_MouseMove(object sender, MouseEventArgs e)
        {
            Point newPosition = Cursor.Position;
            if (resizing)
            {
                this.Height += -(newPosition.Y - this.Location.Y);
                this.Location = new Point(this.Location.X, newPosition.Y);
            }
            oldPosition = newPosition;
        }

        private void downResizer_MouseMove(object sender, MouseEventArgs e)
        {
            Point newPosition = PointToScreen(Cursor.Position);
            if (resizing)
                this.Height += (newPosition.Y - oldPosition.Y);
            oldPosition = newPosition;
        }

        private void SearchBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                if (SearchBox.Text.Length > 0)
                {
                    RaiseCall(SearchBox.Text);
                }
            }
        }

        private void SearchBox_TextChanged(object sender, EventArgs e)
        {
            if (SearchBox.Text == "")
            {
                FullReload();
                return;
            }

            try
            {
                if (SearchBox.Text == Localization[SearchBox.Name][0])
                {
                    prevFilter = (string)SearchBox.Text.Clone();

                    return;
                }
            }
            catch
            {
                if (SearchBox.Text == "Введите номер или имя")
                {
                    prevFilter = (string)SearchBox.Text.Clone();
                    return;
                }
            }

            try
            {

                if (string.IsNullOrEmpty(SearchBox.Text) && prevFilter == Localization[SearchBox.Name][0])
                {
                    prevFilter = (string)SearchBox.Text.Clone();
                    return;
                }
            }
            catch
            {
                if (string.IsNullOrEmpty(SearchBox.Text) && prevFilter == "Введите номер или имя")
                {
                    prevFilter = (string)SearchBox.Text.Clone();
                    return;
                }
            }

            filter = SearchBox.Text.ToLower();

            for (int i = 0; i < cardsChosen.Count; i++)
            {
                if (!onBLFclients.Contains(cardsChosen[i].client))
                {
                    cardsChosen[i].bSelected = false;
                    cardsChosen[i].ChangeFocus();
                    cardsChosen.Remove(cardsChosen[i]);
                }
            }

            UpdateCards();
        }
        private void SearchBox_MouseEnter(object sender, EventArgs e)
        {
            try
            {
                if (SearchBox.Text == Localization[SearchBox.Name][0])
                {
                    SearchBox.Text = "";
                    SearchBox.ForeColor = SystemColors.WindowText;
                }

            }
            catch (Exception)
            {
                if (SearchBox.Text == "Введите номер или имя")
                {
                    SearchBox.Text = "";
                    SearchBox.ForeColor = SystemColors.WindowText;
                }
            }
        }
        private void SearchBox_MouseLeave(object sender, EventArgs e)
        {
            if (!SearchBox.Focused)
            {
                contactsButton.Focus();
                if (SearchBox.Text.Length == 0)
                {
                    try
                    {

                        SearchBox.Text = Localization[SearchBox.Name][0];
                    }
                    catch
                    {
                        SearchBox.Text = "Введите номер или имя";
                    }
                    SearchBox.ForeColor = SystemColors.GrayText;
                }
            }
        }
        private void ClearCallls()
        {
            callsSemaphore.WaitOne();
            foreach (var call in calls)
            {
                call.Dispose();
            }
            calls.Clear();
            callsSemaphore.Set();
        }
        /// <summary>
        /// Connect/Disconnect
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void connectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (reconnectToolStripMenuItem.Text == "Connect")
            {
                newBLFPanel_Shown(this, null);
            }
            else
            {
                EventManager.ConversationBegin -= EventManager_ConversationBegin;
                EventManager.ConversationEnd -= EventManager_ConversationEnd;
                EventManager.DialBegin -= EventManager_DialBegin;
#if LOG
                if (settings.Logs.bEventLogEnabled) EventLogs.WriteLog(("Disconnect button clicked..."));
#endif
                if (AMI != null)
                    if (AMI.IsAlive)
                        AMI.Disconnect();
                    else
                    {
                        AMI.Abort();
                    }
                for (int i = 0; i < contactCards.Count; i++)
                {
                    contactCards[i].client.Status = "UNKNOWN";
                    contactCards[i].UpdateStatus();
                }
                ClearCallls();
                BlfNumberLabel.Text = "Auth";
                BlfStatusLabel.Text = "Failure";
                try
                {
                    StatusToolTip.SetToolTip(BlfStatusLabel, Localization[BlfNumberLabel.Name][2]);
                }
                catch
                {
                    StatusToolTip.SetToolTip(BlfStatusLabel, "Не авторизован");
                }
                BlfNumberLabel.BackColor = Color.FromArgb(255, 128, 128);
                BlfStatusLabel.BackColor = Color.FromArgb(255, 128, 128);
                reconnectToolStripMenuItem.Text = "Connect";
            }
        }
        private void BlfStatusLabel_Click(object sender, EventArgs e)
        {
            connectToolStripMenuItem_Click(this, null);
        }
        private void BlfNumberLabel_Click(object sender, EventArgs e)
        {
            connectToolStripMenuItem_Click(this, null);
        }

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool ShowScrollBar(IntPtr hWnd, int wBar, bool bShow);
        private enum ScrollBarDirection
        {
            SB_HORZ = 0,
            SB_VERT = 1,
            SB_CTL = 2,
            SB_BOTH = 3
        }
        private void onBLFPanel_Resize(object sender, EventArgs e)
        {
            if (bOnBlfPanel.HorizontalScroll.Visible)
            {
                ShowScrollBar(bOnBlfPanel.Handle, (int)ScrollBarDirection.SB_HORZ, false);
            }
            if (bOnBlfPanel.VerticalScroll.Visible && (this.Size.Height > GetOptimalSize().Height - 60))
            {
                ShowScrollBar(bOnBlfPanel.Handle, (int)ScrollBarDirection.SB_VERT, false);
            }
        }

        private void NoContacts_Click(object sender, EventArgs e)
        {
            contactsButton_Click(this, null);
        }

        private void ClearFilter_Click(object sender, EventArgs e)
        {
            SearchBox.Text = "";
            BottomControls.Visible = false;
            SearchBox_MouseLeave(null, null);
        }

        private void bOnBlfPanel_DragDrop(object sender, DragEventArgs e)
        {
        }

        private void BLFPanel_DragLeave(object sender, EventArgs e)
        {
            for (int i = 0; i < bOnBlfPanel.Controls.Count; i++)
            {
                var card = (Card)bOnBlfPanel.Controls[i];
                if (card.bSelected)
                {
                    card.SetSelected();
                }
            }
        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About about = new About();
            about.ShowDialog();
        }

        private void bOnBlfPanel_MouseUp(object sender, MouseEventArgs e)
        {
            //for (int i = 0; i < bOnBlfPanel.Controls.Count; i++)
            //{
            //    var card = (Card)bOnBlfPanel.Controls[i];
            //    card.StopDragging();
            //    if (card.bSelected)
            //    {
            //        card.SetSelected();
            //    }
            //}
        }

        private void bOnBlfPanel_DragEnter(object sender, DragEventArgs e)
        {

        }

        Size prevSize;
        bool bPrevsize = false;
        private void HeadPanel_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (bPrevsize)
            {
                this.Size = prevSize;
                bPrevsize = false;
            }
            else
            {
                prevSize = this.Size;
                Size = GetOptimalSize();
                bPrevsize = true;
            }
        }
        private Size GetOptimalSize()
        {
            Size s = this.MinimumSize;
            s.Height -= 70;
            foreach (Control c in bOnBlfPanel.Controls)
            {
                s.Height += c.Height + 3;
            }
            foreach (Control c in HiddenSplashPanel.Controls)
            {
                s.Height += c.Height + 3;
            }
            return s;
        }

        EventLogsForm logs;
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (logs == null)
                logs = new EventLogsForm();
            if (!logs.Visible)
            {
                if (logs.IsDisposed)
                {
                    logs = new EventLogsForm();
                }
                logs.Show(this);
            }
        }
    }
}