using System;
using System.Collections.Generic;
using AsteriskManager;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Microsoft.Win32.SafeHandles;
using BCTI.CustomControls;
using BCTI.DialogBoxes;
using System.Threading;

namespace BCTI
{
    public class CallManager : IDisposable
    {
        public AMIManager AMI;
        private System.Timers.Timer callTimer;
        public DateTime callStart;
        private List<DialData> dials = new List<DialData>();
        private Splash splash;
        private int CallDuration = 0;
        public CallType Type = CallType.UNKNOWN;
        private ClientsData _caller;
        public BLFPanel blf;
        public bool Parked = false;
        private RingInfo newRing = new RingInfo();
        public event EventHandler VisibilityChanged;
        public HiddenSplash hidden;
        public bool Hanguped = false;
        public string NotBlindNumberTransferTo = string.Empty;

        public string Number { get; set; }
        #region Конструкторы
        /// <summary>
        /// Известный клиент
        /// </summary>
        /// <param name="_type"></param>
        /// <param name="dial"></param>
        /// <param name="_client"></param>
        public CallManager(BLFPanel _blf, CallType _type, DialData dial, ClientsData _client, string _Number)
        {
            blf = _blf;
            Console.WriteLine(dial.ChannelID + " " + dial.DestinationID);
            dials.Add(dial);
            Type = _type;
            callStart = DateTime.Now;
            _caller = _client;
            AMI = _blf.AMI;
            Number = _Number;
            InitSplash();
        }
        /// <summary>
        /// Новый клиент из входящего звонка
        /// </summary>
        /// <param name="_type"></param>
        /// <param name="dial"></param>
        public CallManager(BLFPanel _blf, CallType _type, DialData dial, string _Number)
        {
            blf = _blf;
            Console.WriteLine(dial.ChannelID + " " + dial.DestinationID);
            dials.Add(dial);
            Type = _type;
            callStart = DateTime.Now;
            this.Number = _Number;
            _caller = new ClientsData();
            if (Type == CallType.IncomingCall)
            {
                _caller.Number = dial.CallerIDNum;
            }
            else
            {
                _caller.Number = dial.ConnectedLineNum;
            }
            AMI = _blf.AMI;
            InitSplash();
        }
        /// <summary>
        /// Зыонок иницированный из приложения
        /// </summary>
        /// <param name="_type"></param>
        /// <param name="_client"></param>
        public CallManager(BLFPanel _blf, ClientsData _client, string _Number)
        {
            blf = _blf;
            Type = CallType.OutcomingCall;
            _caller = _client;
            callStart = DateTime.Now;
            this.Number = _Number;
            AMI = _blf.AMI;
            InitSplash();
        }
        public CallManager(BLFPanel _blf, string number)
        {
            blf = _blf;
            Type = CallType.OutcomingCall;
            _caller = new ClientsData();
            _caller.Number = number;
            this.Number = number;
            callStart = DateTime.Now;
            AMI = _blf.AMI;
            InitSplash();

        }
        #endregion
        /// <summary>
        /// Показать сплеш окно
        /// </summary>
        public void ShowSplash()
        {
            try
            {
                blf.BeginInvoke((MethodInvoker)(() =>
                {
                    if (splash != null && !splash.IsDisposed)
                    {
                        splash.Opacity = 100;
                        splash.Show();
                    }
                }));
            }
            catch (InvalidOperationException ex)
            {
                EventLogs.WriteLog(ex.Message, ex.StackTrace);
            }
        }
        /// <summary>
        /// Спрятать сплеш окно
        /// </summary>
        public void HideSplash()
        {
            try
            {
                blf.BeginInvoke((MethodInvoker)(() =>
                {
                    if (splash != null && !splash.IsDisposed)
                    {
                        splash.Hide();
                    }
                }));
            }
            catch (InvalidOperationException ex)
            {
                EventLogs.WriteLog(ex.Message, ex.StackTrace);
            }
        }
        /// <summary>
        /// Инициализация сплеш окна
        /// </summary>
        private void InitSplash()
        {
            try
            {
                blf.BeginInvoke((MethodInvoker)(() =>
                {
                    splash = new Splash(this);
                    //Console.WriteLine((Screen.PrimaryScreen.WorkingArea.Size.Width - splash.Width).ToString() + " " + (Screen.PrimaryScreen.WorkingArea.Size.Height - splash.Height).ToString());
                    splash.SetLocation(Screen.PrimaryScreen.WorkingArea.Size.Width - splash.Width, Screen.PrimaryScreen.WorkingArea.Size.Height /*- splash.Height */- (blf.calls.Count/* == 0 ? 0 : blf.calls.Count - 1*/ * splash.Height));
                    splash.client = _caller;
                    splash.VisibleChanged += Splash_VisibleChanged;
                    if (!blf.settings.CommonSettings.bDoNotDisturb)
                    {
                        splash.Opacity = 100;
                    }
                    string lastcall = blf.FindRingInfo(_caller);
                    if (!string.IsNullOrEmpty(lastcall))
                    {
                        splash.LastCall(lastcall);
                    }
                    splash.Show(blf);
                }));
            }
            catch (InvalidOperationException ex)
            {
                EventLogs.WriteLog(ex.Message, ex.StackTrace);
            }
        }
        /// <summary>
        /// Сворачивание сплеша в панель
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Splash_VisibleChanged(object sender, EventArgs e)
        {
            VisibilityChanged?.Invoke(this, null);
            if (splash.Visible == false)
            {
                if (hidden == null)
                {
                    hidden = new HiddenSplash(this, _caller, CallDuration);
                }
                blf.AddHiddenSplash(hidden);
            }
            else
            {
                if (hidden != null)
                {
                    blf.RemoveHiddenSplash(hidden);
                }
            }
        }

        public int DialsCount
        {
            get
            {
                return dials.Count;
            }
        }
        /// <summary>
        /// обновление информации звонков
        /// </summary>
        /// <param name="_dial"></param>
        public void UpdateDialInfo(DialData _dial)
        {
            Console.WriteLine(_dial.ChannelID + " " + _dial.DestinationID);
            for (int i = 0; i < dials.Count; i++)
            {
                if (AMI.AmiVersion == AMIManager.AmiVersions.v25 || AMI.AmiVersion == AMIManager.AmiVersions.v28)
                {
                    if ((dials[i].ChannelID == _dial.ChannelID && dials[i].DestinationID == _dial.DestinationID))
                    {
                        dials[i] = _dial;
                        return;
                    }

                }
                else
                {
                    if ((dials[i].ChannelID == _dial.ChannelID && dials[i].DestinationID == _dial.DestinationID))
                    {
                        dials[i] = _dial;
                        return;
                    }
                    else if ((dials[i].ChannelID == _dial.DestinationID && dials[i].DestinationID == "") || dials[i].Uniqueid == _dial.Uniqueid)
                    {
                        dials[i] = _dial;
                        return;
                    }
                }
            }
            dials.Add(_dial);
        }
        /// <summary>
        /// Сравнение информации звонков
        /// </summary>
        /// <param name="dialinfo"></param>
        /// <returns></returns>
        public bool CompareDials(DialData dialinfo)
        {
            for (int i = 0; i < dials.Count; i++)
            {
                if (dials[i].ChannelID == dialinfo.ChannelID ||
                    (dials[i].DestinationID == dialinfo.DestinationID && !string.IsNullOrEmpty(dialinfo.DestinationID) && !string.IsNullOrEmpty(dials[i].DestinationID)) ||
                    dials[i].DestinationID == dialinfo.ChannelID ||
                    dials[i].ChannelID == dialinfo.DestinationID ||
                    dials[i].Uniqueid == dialinfo.Uniqueid)
                    return true;
            }
            return false;
        }
        #region DialandAndTimerControls
        /// <summary>
        /// Начало разговора
        /// </summary>
        public void ConversationStart()
        {
            if (callTimer == null)
            {
                callTimer = new System.Timers.Timer(1000);
                callTimer.AutoReset = true;
                callTimer.Enabled = true;
                callTimer.Elapsed += CallTime_Elapsed;
                callTimer.Start();
                try
                {
                    splash.EnableButtons();
                }
                catch (Exception ex)
                {
                    EventLogs.WriteLog(ex.Message, ex.StackTrace);
                }
                SerializeRingInfo();
            }
        }
        /// <summary>
        /// Завершение звонка
        /// </summary>
        /// <param name="dialinfo"></param>
        public void ConversationEnd(DialData dialinfo)
        {
            if (!Parked)
            {
                for (int i = 0; i < dials.Count; i++)
                {
                    ///**
                    if (AMI.AmiVersion == AMIManager.AmiVersions.v11 || AMI.AmiVersion == AMIManager.AmiVersions.v13)
                    {
                        UpdateDialInfo(dialinfo);
                    }
                    //Console.WriteLine("Channels: " + dials[i].ChannelID + " " + dialinfo.ChannelID + " " + dials[i].DestinationID + " " + dialinfo.DestinationID);
                    //Console.WriteLine("UniqueID: " + dials[i].Uniqueid + " " + dialinfo.Uniqueid);
                    if (dials[i].ChannelID == dialinfo.ChannelID && dials[i].DestinationID == dialinfo.DestinationID /*|| dials[i].DestinationID == dialinfo.ChannelID || dials[i].ChannelID == dialinfo.DestinationID*/)
                    {
                        dials.RemoveAt(i);
                        i--;
                    }
                    else if (dials[i].Uniqueid == dialinfo.Uniqueid)
                    {
                        dials.RemoveAt(i);
                        i--;
                    }
                }
            }
            if (dials.Count == 0)
            {
                if (callTimer != null)
                {
                    callTimer.Stop();
                    callTimer.Dispose();
                    if (!splash.IsDisposed)
                        splash.CallEnd();
                    SerializeRingInfo();
                    blf.AddRingInfo(newRing);
                }
                else
                {
                    if (Type != CallType.OutcomingCall)
                        Type = CallType.Unanswered;
                    try
                    {
                        if (!splash.IsDisposed)
                            splash.CallEnd();
                    }
                    catch
                    {
                    }
                    SerializeRingInfo();
                    blf.AddRingInfo(newRing);
                }
            }
            else
            {
                //dials[0].currentstatus == DialData.Dialstat.
            }
        }
        /// <summary>
        /// Пауза
        /// </summary>
        public void Hold()
        {
            if (callTimer != null)
                callTimer.Stop();

        }
        /// <summary>
        /// Снятие с паузы
        /// </summary>
        public void UnHold()
        {
            if (callTimer != null)
                callTimer.Start();
        }
        /// <summary>
        /// Событие таймера
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CallTime_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (!Parked)
                CallDuration++;
            if (!splash.IsDisposed)
                try
                {
                    splash.Invoke((MethodInvoker)(() => splash.TimerTick(CallDuration)));
                }
                catch (InvalidOperationException)
                {

                }
            if (hidden != null)
            {
                hidden.Invoke((MethodInvoker)(() => hidden.TimerTick(CallDuration)));
            }
        }
        #endregion
        #region Dispose
        public bool disposed = false;
        // Instantiate a SafeHandle instance.
        SafeHandle handle = new SafeFileHandle(IntPtr.Zero, true);

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        // Protected implementation of Dispose pattern.
        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
                handle.Dispose();
                // Free any other managed objects here.
                //
                if (splash != null)
                {
                    try
                    {
                        blf.Invoke((MethodInvoker)(() => splash.Dispose()));

                    }
                    catch (Exception ex)
                    {
                        EventLogs.WriteLog(ex.Message, ex.StackTrace);
                    }
                }
                if (hidden != null)
                {
                    try
                    {
                        blf.Invoke((MethodInvoker)(() => blf.RemoveHiddenSplash(hidden)));
                    }
                    catch (Exception ex)
                    {
                        EventLogs.WriteLog(ex.Message, ex.StackTrace);
                    }
                    //hidden.Dispose();
                }
            }

            // Free any unmanaged objects here.
            //
            disposed = true;
        }
        #endregion
        #region SplashFunctions
        /// <summary>
        /// Сброс звонка
        /// </summary>
        public void Hangup()
        {
            if (Parked)
            {
                AMI.Redirect(dials[0], AMI.UserData.Number);
                AMI.HangupAllAiringCalls(AMI.UserData.Number);
            }
            if (DialsCount > 0)
            {
                foreach (DialData d in dials)
                {
                    AMI.HangupByChannel(d.ChannelID);
                }
            }
            else
            {
                AMI.HangupAllAiringCalls(AMI.UserData.Number);
            }
            if (splash != null)
            {
                blf.Invoke((MethodInvoker)(() => splash.Dispose()));
            }
            if (hidden != null)
            {
                blf.RemoveHiddenSplash(hidden);
                hidden.Dispose();
            }

            try
            {
                blf.BeginInvoke((MethodInvoker)delegate
                {
                    blf.UpdateUserStatus("Online");
                });
            }
            catch (Exception ex)
            {
                EventLogs.WriteLog(ex.Message);
            }
            SerializeRingInfo();
            blf.AddRingInfo(newRing);
            Hanguped = true;
        }
        /// <summary>
        /// Скрипт
        /// </summary>
        public void Script()
        {
            if (DialsCount > 0)
            {
                string BatFilePath = blf.settings.Script.BatFilePath;
                if (!string.IsNullOrEmpty(BatFilePath))
                {
                    string arguments = string.Empty;
                    string ArgumentsString = blf.settings.Script.ParamString;
                    if (ArgumentsString.Contains("CallerIDNum"))
                        arguments += dials[0].CallerIDNum.ToString() + " ";
                    if (ArgumentsString.Contains("CallerIDName"))
                        arguments += dials[0].CallerIDName.ToString() + " ";
                    if (ArgumentsString.Contains("ConnectedLineNum"))
                        arguments += dials[0].ConnectedLineNum.ToString() + " ";
                    if (ArgumentsString.Contains("ConnectedLineName"))
                        arguments += dials[0].ConnectedLineName.ToString() + " ";
                    if (ArgumentsString.Contains("Channel"))
                        arguments += dials[0].ChannelID.ToString() + " ";
                    if (ArgumentsString.Contains("CurrentStatus"))
                        arguments += dials[0].currentstatus.ToString() + " ";
                    if (ArgumentsString.Contains("Destination"))
                        arguments += dials[0].DestinationID.ToString() + " ";
                    if (ArgumentsString.Contains("DialStatus"))
                        arguments += dials[0].DialStatus.ToString() + " ";
                    if (ArgumentsString.Contains("Uniqueid"))
                        arguments += dials[0].Uniqueid.ToString() + " ";
                    if (ArgumentsString.Contains("Uniqueid2"))
                        arguments += dials[0].Uniqueid2.ToString() + " ";
                    System.Diagnostics.ProcessStartInfo info = new System.Diagnostics.ProcessStartInfo(BatFilePath, arguments);
                    System.Diagnostics.Process.Start(info);
                }
                else BMessageBox.Show("Не указан путь к скрипту");
            }
            else BMessageBox.Show("Нет данных о звонке");
        }
        /// <summary>
        /// Парковка
        /// </summary>
        /// <returns></returns>
        public bool Park()
        {
            if (DialsCount > 0)
            {
                Parked = true;
                AMI.Park(dials[0], 480);
                if (dials[0].CallerIDNum == AMI.UserData.Number)
                {
                    AMI.HangupByChannel(dials[0].ChannelID);
                }
                else
                {
                    AMI.HangupByChannel(dials[0].DestinationID);
                }
                return true;
            }
            else
                return false;
        }
        public bool UnPark()
        {
            if (DialsCount > 0)
            {
                AMI.Redirect(dials[0], AMI.UserData.Number);
                Thread.Sleep(700);
                Parked = false;
                return true;
            }
            else
                return false;
        }
        /// <summary>
        /// Сохранение информации о звонке в структуру
        /// </summary>
        public void SerializeRingInfo()
        {
            DateTime secondDate = DateTime.Now;
            if (callStart == DateTime.MaxValue)
                callStart = secondDate;
            newRing.momentOfRing = callStart;
            newRing.number = _caller.Number;
            newRing.type = Type;
            TimeSpan duration = new TimeSpan(0, 0, CallDuration);
            newRing.Duration = duration.ToString();
            if (DialsCount > 0)
                if (!string.IsNullOrEmpty(dials[0].Uniqueid))
                    newRing.UniqueID = dials[0].Uniqueid;
                else
                    newRing.UniqueID = "UNKNOWN";
        }
        string RedirectToNumber = string.Empty;
        DialData RedirectDial;
        bool hangupRedirect = true;
        public bool IsRedirected(DialData newdial)
        {
            if (RedirectDial != null)
            {
                if (newdial.currentstatus == DialData.Dialstat.ConversationEnd)
                {
                    hangupRedirect = !hangupRedirect;
                }
                if ((RedirectDial.ChannelID == newdial.ChannelID ||
                    (RedirectDial.DestinationID == newdial.DestinationID && !string.IsNullOrEmpty(newdial.DestinationID) && !string.IsNullOrEmpty(RedirectDial.DestinationID)) ||
                    RedirectDial.DestinationID == newdial.ChannelID ||
                    RedirectDial.ChannelID == newdial.DestinationID ||
                    RedirectDial.Uniqueid == newdial.Uniqueid) && !hangupRedirect)
                    return true;
            }
            return false;
        }
        /// <summary>
        /// Перевод звонка
        /// </summary>
        public void Redirect(string TransferTo)
        {
            RedirectDial = dials[0];
            AMI.Redirect(Number, TransferTo);
            if (splash != null)
            {
                blf.Invoke((MethodInvoker)(() => splash.Dispose()));
            }
            if (hidden != null)
            {
                blf.RemoveHiddenSplash(hidden);
                hidden.Dispose();
            }

            try
            {
                blf.BeginInvoke((MethodInvoker)delegate
                {
                    blf.UpdateUserStatus("Online");
                });
            }
            catch (Exception ex)
            {
                EventLogs.WriteLog(ex.Message);
            }
            SerializeRingInfo();
            blf.AddRingInfo(newRing);
        }
        public void StartRedirect(string RedirTo)
        {
            Park();
            RedirectToNumber = RedirTo;
            Thread.Sleep(1000);
            blf.RaiseCall(RedirectToNumber);
        }
        public void CancelRedirect()
        {
            UnPark();
        }
        public void EndRedirect()
        {
            Thread.Sleep(1000);
            AMI.Redirect(dials[0], RedirectToNumber);
        }

        bool parked = false;
        AutoResetEvent redir = new AutoResetEvent(true);

        /// <summary>
        /// Сопровождаемый перевод звонка
        /// </summary>
        /// <param name="NumberTransferTo">Номер абонента, которого будем переводить</param>
        /// <param name="TransferToNumber">Номер абонента, на которого будем переводить</param>
        public void NotBlindRedirect(string NumberTransferTo, string TransferToNumber)
        {
            redir.WaitOne();
            if (!parked)
            {
                AMI.Park(NumberTransferTo, 480);
                parked = true;
                blf.RaiseCall(TransferToNumber);
                NotBlindNumberTransferTo = TransferToNumber.Clone() as string;
            }
            if (dials.Count > 0)
            {
                if (dials[0].CallerIDNum == AMI.UserData.Number)
                    AMI.HangupByChannel(dials[0].ChannelID);
                else
                    AMI.HangupByChannel(dials[0].DestinationID);
            }
            redir.Set();
        }

        /// <summary>
        /// Объединение сплешей при сопровождаемом переводе
        /// </summary>
        public void UnionSplash()
        {
            splash.SwitchDisplayMode();
        }
        #endregion
    }
}
