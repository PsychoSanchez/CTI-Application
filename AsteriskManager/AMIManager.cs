//#define CONSOLEDEBUG
//#define EVENTCONSOLEDEBUG
#define LOG
using AsteriskManager.Connect;
using AsteriskManager.Manager.Actions;
using AsteriskManager.Exceptions;
using AsteriskManager.Manager.Event;
using AsteriskManager.Parser;
using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.ComponentModel;
using System.IO;
using AsteriskManager.Utils;

namespace AsteriskManager
{
    public class AMIManager
    {
        private ActiveChannelManager activeChannels = new ActiveChannelManager();

        #region Функции для работы с массивами данных
        private DialData TryGetDialChannelInfoAndUpdateDial(DialData dial)
        {
            ChannelData channel = activeChannels.FindChInfoByChID(dial.ChannelID);
            channel ??= activeChannels.FindChInfoByChID(dial.DestinationID);

            if (channel == null)
            {
                return null;
            }

            ///Если номера совпадают подтягиваем второй канла
            activeChannels.UpdateDialInfoWithChannelInfo(dial, channel);

            UpdateActiveCalls(dial);

            return dial;
        }
        public ChannelData FindChannel(string connectedLineNum)
        {
            try
            {
                ChannelData channel = activeChannels.GetChannelByCallerNumbers(connectedLineNum, UserData.Number);

                return channel ?? FindConnectedChannel(connectedLineNum);
            }
            catch (IndexOutOfRangeException)
            {
                return FindChannel(connectedLineNum);
            }
        }
        public ChannelData FindConnectedChannel(string CallerIDNum)
        {
            try
            {
                return activeChannels.GetChannelByCallerNumbers(UserData.Number, CallerIDNum);
            }
            catch (IndexOutOfRangeException)
            {
                return FindConnectedChannel(CallerIDNum);
            }
        }

        private AutoResetEvent Calls = new AutoResetEvent(true);

        private DialData RemoveActiveCall(DialData dial)
        {
            try
            {
                Calls.WaitOne();
                for (int i = 0; i < ActiveCalls.Count; i++)
                {
                    var isSameChannelId = ActiveCalls[i].ChannelID.Equals(dial.ChannelID);
                    var isSameUniqueId = dial.Uniqueid != null && ActiveCalls[i].Uniqueid != null && ActiveCalls[i].Uniqueid.Equals(dial.Uniqueid);
                    var isSameUniqueId2 = ActiveCalls[i].Uniqueid2 != null && dial.Uniqueid2 != null && ActiveCalls[i].Uniqueid.Equals(dial.Uniqueid2);

                    if (isSameChannelId || isSameUniqueId || isSameUniqueId2)
                    {
                        activeChannels.UpdateChannelCallerInfo(dial, ActiveCalls[i]);
                        activeChannels.UpdateChannelConnectedLineInfo(dial, ActiveCalls[i]);
                        ActiveCalls.RemoveAt(i);

                        break;
                    }
                }
                return dial;
            }
            catch (IndexOutOfRangeException)
            {
                return RemoveActiveCall(dial);
            }
            finally
            {
                Calls.Set();
            }
        }

        /// <summary>
        /// Функция поиска информации о активном звонке по ID канала
        /// </summary>
        /// <param name="channel">Канал</param>
        /// <returns>Информацию о зовнке</returns>
        private DialData FindDialByChannel(ChannelData channel)
        {
            try
            {
                Calls.WaitOne();
                for (int i = 0; i < ActiveCalls.Count; i++)
                {
                    var channelId = channel.ChannelID;
                    var isDestinationOrOriginateChannel = channelId == ActiveCalls[i].ChannelID || channelId == ActiveCalls[i].DestinationID;
                    if (isDestinationOrOriginateChannel)
                    {
                        return ActiveCalls[i];
                    }
                }
                return null;
            }
            catch (IndexOutOfRangeException)
            {
                return FindDialByChannel(channel);
            }
            finally
            {
                Calls.Set();
            }
        }
        /// <summary>
        /// Функция поиска информации о активном звонке по ID канала
        /// </summary>
        /// <param name="channelId">Канал</param>
        /// <returns>Информацию о зовнке</returns>
        private DialData FindDialByChannel(string channelId)
        {
            try
            {
                Calls.WaitOne();
                for (int i = 0; i < ActiveCalls.Count; i++)
                {
                    var isDestinationOrOriginateChannel = channelId == ActiveCalls[i].ChannelID || channelId == ActiveCalls[i].DestinationID;
                    if (isDestinationOrOriginateChannel && ActiveCalls[i].currentstatus == DialData.Dialstat.DialBegin && !string.IsNullOrEmpty(channelId))
                    {
                        return ActiveCalls[i];
                    }
                }
                return null;
            }
            catch (IndexOutOfRangeException)
            {
                return FindDialByChannel(channelId);
            }
            finally
            {
                Calls.Set();
            }
        }
        private void UpdateActiveCalls(DialData dial)
        {
            try
            {
                Calls.WaitOne();
                for (int i = 0; i < ActiveCalls.Count; i++)
                {
                    if (dial.ChannelID == ActiveCalls[i].ChannelID && dial.DestinationID == ActiveCalls[i].DestinationID)
                    {
                        ActiveCalls[i] = dial;
                        Calls.Set();
                        return;
                    }
                }
                Calls.Set();
                return;
            }
            catch (IndexOutOfRangeException)
            {
                Calls.Set();
                UpdateActiveCalls(dial);
            }
        }
        private void AddActiveCall(DialData dial)
        {
            try
            {
                Calls.WaitOne();
                for (int i = 0; i < ActiveCalls.Count; i++)
                {
                    DialData call = ActiveCalls[i];
                    var isDialedChannelId = dial.DestinationID == call.ChannelID || call.ChannelID == dial.ChannelID;

                    if (isDialedChannelId)
                    {
                        call.ChannelID = dial.ChannelID;
                        call.DestinationID = dial.DestinationID;
                        return;
                    }
                }
                ActiveCalls.Add(dial);
                return;
            }
            catch (IndexOutOfRangeException)
            {
                UpdateActiveCalls(dial);
            }
            finally
            {
                Calls.Set();
            }
        }
        #endregion

        #region Обработчики событий
        /// <summary>
        /// Обработка события завершения звонка 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HangupEvent(object sender, AsteriskEventArgs e)
        {
            var Hangup = (HangupEvent)e.Event;
            var RemovedChannel = activeChannels.RemoveActiveChannel(Hangup.Channel);
            if (RemovedChannel == null)
            {
                return;
            }

            var dial = FindDialByChannel(RemovedChannel);
            if (dial == null)
            {
                return;
            }

            switch (RemovedChannel.State)
            {
                case ChannelState.Ringing:
                    dial.DialStatus = "CANCEL";
                    break;
                case ChannelState.RemoteRinging:
                    dial.DialStatus = "BUSY";
                    break;
                case ChannelState.Up:
                    dial.DialStatus = "ANSWER";
                    break;
                case ChannelState.Busy:
                    dial.DialStatus = "BUSY";
                    break;
                default:
                    break;
            }
            new DialEndEvent(dial);
        }
        /// <summary>
        /// Обработчик события по запросу информации о пользователях
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PeerEntryEvent(object sender, AsteriskEventArgs e)
        {
            var Event = (PeerEntryEvent)e.Event;
            ServerUsers.Add(Event.client);
        }
        private void ParkedCallEvent(object sender, AsteriskEventArgs e)
        {
            var Event = (ParkedCallEvent)e.Event;
            ParkedCalls.Add(Event.parkedcall);
        }
        /// <summary>
        /// Обработчик события обновления статуса канала
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NewChannelState(object sender, AsteriskEventArgs e)
        {
            var CurrChanState = (NewstateEvent)e.Event;
            var PrevChanState = activeChannels.DefaultChannelInfoValues(CurrChanState);
            if ((AmiVersion == AmiVersions.v11 || AmiVersion == AmiVersions.v13) && PrevChanState != null)
            {
                //Новый диал бегин, который создается как только мы начали дозвон.
                if ((PrevChanState.State == ChannelState.ChannelUnavailble) && CurrChanState.ChannelState == "5")
                {
                    //Ищем информацию по каналу, если он существует проверяем не равны ли подключенные номера
                    var chan = activeChannels.FindChInfoByChID(CurrChanState.Channel);
                    if (chan != null && chan.CallerIDNum != chan.ConnectedLineNum)
                    {
                        ///Генерируем событие начала звонка, так как мы ищем канал с другого конца, то переворачиваем данные Caller = Connected
                        new DialBeginEvent(chan, true);
                    }
                }

                ///////////////////////////////////////////////
                ///Нужно подумать как прикрутить информацию из DialBegin к моим ивентам, без генерации нового события
                //////////////////////////////////////////////

                ///Исходя из логов версии 1.1 это единственный способ вызвать ивенты для звонка инициированного с мобильника
                if (PrevChanState.State == ChannelState.ChannelUnavailble && CurrChanState.ChannelState == "6")
                {
                    var chan = activeChannels.FindChInfoByChID(CurrChanState.Channel);
                    if (chan != null)
                        new DialBeginEvent(chan, true);
                    Thread.Sleep(500);
                    var dial = FindDialByChannel(PrevChanState);
                    if (dial != null)
                    {
                        //var dial = UpdateDialCallerID(dail);
                        new ConversationBeginEvent(dial);
                    }
                }

                ///Так как в ами версии 1.3 события приходят с другой периодичностью, то проверка состояния канала единственный выход для того, чтобы сгенеоировать событие начала разговора.
                if ((PrevChanState.State == ChannelState.RemoteRinging /*|| PrevChanState.State == ChannelState.Ringing*/) && CurrChanState.ChannelState == "6")
                {
                    var dial = FindDialByChannel(PrevChanState);
                    if (dial != null)
                    {
                        //var dial = UpdateDialCallerID(dail);
                        new ConversationBeginEvent(dial);
                    }
                }
            }
        }
        /// <summary>
        /// Событие добавленя канала
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NewchannelEvent(object sender, AsteriskEventArgs e)
        {
            activeChannels.AddActiveChannel(((NewChannelEvent)e.Event).Channel);
        }
        /// <summary>
        /// Одно из событий для звонков
        /// Генерирует 3 события для панели:
        /// Создание канала
        /// Начало разговора
        /// Конец разговора
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EventManager_DialEvent(object sender, DialEventArgs e)
        {
            switch (e.dialinfo.currentstatus)
            {
                case DialData.Dialstat.DialBegin11:
                    {

                        AddActiveCall(e.dialinfo);
                        break;
                    }
                //Начало звонка
                case DialData.Dialstat.DialBegin:
                    {

                        if (AmiVersion == AmiVersions.v25 || AmiVersion == AmiVersions.v28)
                        {
                            TryGetDialChannelInfoAndUpdateDial(e.dialinfo);
                            EventManager.RaiseDialBeginEvent(e);
                            return;
                        }

                        ActiveCalls.Add(e.dialinfo);
                        EventManager.RaiseDialBeginEvent(e);

                        break;
                    }

                //Начало разговора
                case DialData.Dialstat.ConversationBegin:
                    {

                        if (AmiVersion == AmiVersions.v25 || AmiVersion == AmiVersions.v28)
                        {
                            TryGetDialChannelInfoAndUpdateDial(e.dialinfo);
                            //e.dialinfo = d;
                            activeChannels.DefaultChannelInfoValues(e.dialinfo);

                            if (e.dialinfo.DestinationID != null)
                            {
                                EventManager.RaiseConversationBeginEvent(e);
                            }
                        }
                        if (AmiVersion == AmiVersions.v11 || AmiVersion == AmiVersions.v13)
                        {
                            if (e.dialinfo.DestinationID != null)
                            {
                                var dial = FindDialByChannel(e.dialinfo.DestinationID);
                                if (dial != null)
                                {
                                    e.dialinfo = dial;
                                    e.dialinfo.currentstatus = DialData.Dialstat.ConversationBegin;
                                }
                                EventManager.RaiseConversationBeginEvent(e);
                            }
                        }
                        break;
                    }

                //Конец звонка
                case DialData.Dialstat.ConversationEnd:
                    {
                        if (AmiVersion == AmiVersions.v11 || AmiVersion == AmiVersions.v13)
                        {
                            if (!string.IsNullOrEmpty(e.dialinfo.DestinationID))
                            {
                                var dial = FindDialByChannel(e.dialinfo.DestinationID);
                                if (dial != null)
                                {
                                    e.dialinfo = dial;
                                    e.dialinfo.currentstatus = DialData.Dialstat.ConversationEnd;
                                }
                            }
                            EventManager.RaiseConversationEndEvent(e);
                            break;
                        }

                        var DialInfo = RemoveActiveCall(e.dialinfo);
                        if ((AmiVersion == AmiVersions.v25 || AmiVersion == AmiVersions.v28) && DialInfo != null)
                        {
                            e.dialinfo = DialInfo;
                            if (!string.IsNullOrEmpty(e.dialinfo.CallerIDNum))
                            {
                                EventManager.RaiseConversationEndEvent(e);
                            }
                        }
                        break;
                    }

            }
        }

        #endregion

        #region Переменные
        public enum AmiVersions { v11, v13, v25, v28, UNKNOWN }
        public event EventHandler Disconnecting;
        public string RecvLogPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\B-Cti\\log\\";
        public bool IsLogEnabled = true;
        public string SIPADDHEADER { get; set; }
        public AmiVersions AmiVersion { get; private set; }
        public string CallerID { get; set; }
        /// <summary>
        /// Информация о текущих активных звонках
        /// </summary>
        public List<DialData> ActiveCalls = new List<DialData>();
        /// <summary>
        /// Список запаркованных звонков
        /// </summary>
        public List<ParkedCallsData> ParkedCalls = new List<ParkedCallsData>();
        /// <summary>
        /// Общая память для сообщений с ActionID
        /// Данные хранятся в виде: Ключ - ActionID, Данные - Типизированный класс данного ответа
        /// </summary>
        public static Dictionary<string, EventManager> ActionIdMessages = new Dictionary<string, EventManager>();
        /// <summary>
        /// Данные пользователя за которым происходит слежение
        /// </summary>
        public ClientsData UserData { get; set; }
        /// <summary>
        /// Данные о пользователях на сервере, заполняется при инциализации
        /// Нужна для того, чтобы проверять статусы и данные о пользователях при входе
        /// После первой проверки можно освобождать память и хранить в xml
        /// </summary>
        public List<ClientsData> ServerUsers = new List<ClientsData>();
        /// <summary>
        /// Количество пользователей на сервере
        /// (Бесполезная переменная)
        /// </summary>
        public string UsersAmount { get; set; }
        private AmiLogger logger = new AmiLogger();
        /// <summary>
        /// Класс для подключения к серверу
        /// </summary>
        private SocketConnection connectionManager;
        /// <summary>
        /// Итератор для ActionID
        /// </summary>
        private int actionIdcounter = 0;
        /// <summary>
        /// Указатель на поток с пингом
        /// </summary>
        private Thread parserThread;
        private Thread pingThread;
        private Thread recieverThread;
        private BackgroundWorker pingerWorker;
        private BackgroundWorker parserWorker;
        private BackgroundWorker recieverWorker;
        private AutoResetEvent sendPingEvent = new AutoResetEvent(false);
        /// <summary>
        /// Переменная необходимая для грамотного выхода из библиотеки
        /// В случае если некоторые потоки, еще работают, а мы завершили рабту в библиотекой помешает вылету имключений
        /// </summary>
        public bool IsAlive = false;
        public bool IsConnected = false;
        /// <summary>
        /// Семафор для пинга
        /// </summary>
        #endregion

        #region Конструкторы
        /// <summary>
        /// Конструктор по умолчанию
        /// Инициализирует сокет
        /// </summary>
        public AMIManager()
        {
            connectionManager = new SocketConnection();
            CreateLogFoldersIfNeeded();
        }

        private void CreateLogFoldersIfNeeded()
        {
            if (!IsLogEnabled)
            {
                return;
            }

            var appFolderPath = GetAppFolderPath();
            if (!Directory.Exists(appFolderPath))
            {
                Directory.CreateDirectory(GetAppFolderPath());
            }

            var logsFolderPath = GetLogsFolder();
            if (!Directory.Exists(logsFolderPath))
            {
                Directory.CreateDirectory(logsFolderPath);
            }
        }

        private string GetLogsFolder()
        {
            return GetAppFolderPath() + "LOG\\";
        }

        private string GetAppFolderPath()
        {
            return Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\B-Cti\\";
        }

        /// <summary>
        /// Конструктор инициализирующий сокет и клиентские данные
        /// </summary>
        /// <param name="client"></param>
        public AMIManager(ClientsData client)
        {
            UserData = client;
            connectionManager = new SocketConnection();
            CreateLogFoldersIfNeeded();
        }
        /// <summary>
        /// Инициализация клиентских данных и синхронное подлючение к серверу (Старый конструктор)
        /// </summary>
        /// <param name="client"></param>
        /// <param name="login"></param>
        /// <param name="pwd"></param>
        /// <param name="ip"></param>
        /// <param name="port"></param>
        public AMIManager(ClientsData client, string login, string pwd, string ip, int port)
        {
            UserData = client;
            connectionManager = new SocketConnection();
            Connect(login, pwd, ip, port);
            CreateLogFoldersIfNeeded();
        }
        /// <summary>
        /// Конструктор для новых сокетов (Не используется)
        /// </summary>
        /// <param name="socket"></param>
        public AMIManager(TcpClient socket)
        {
            connectionManager = new SocketConnection(socket);
            CreateLogFoldersIfNeeded();
        }
        #endregion

        #region Сервисные функции для работы библиотеки с сервером
        /// <summary>
        ///Увеличивает счетчик для номера запроса
        /// </summary>
        /// <returns>Возвращает новый номер счетчика</returns>
        private string CreateActionID()
        {
            actionIdcounter++;
            return Helper.MachineID + actionIdcounter.ToString();
        }

        /// <summary>
        /// Функция отправки запроса действия на сервер астериск
        /// </summary>
        /// <param name="action">Класс действия</param>
        /// <returns>Успена ли отправка</returns>
        private void SendToAsterisk(ISerializableAmiAction action)
        {
            var messageBuilder = new AmiActionMesasgeBuilder(action);
            var fields = action.GetFields();
            var message = messageBuilder.AddFields(fields).Build();

#if LOG
            try
            {
                DateTime date = DateTime.Now;
                System.IO.StreamWriter file = new System.IO.StreamWriter("AMILOG" + date.ToShortDateString() + ".log", true);
                try
                {
                    file.WriteLine(date.ToString(), file.NewLine);
                    file.WriteLine(message);
                    file.Close();
                }
                finally
                {
                    if (file != null)
                        file.Dispose();
                }
            }
            catch (StackOverflowException)
            {
            }
#endif

            if (IsLogEnabled)
            {
                logger.WriteLog(message);
            }


            byte[] sendBuffer = Encoding.ASCII.GetBytes(message);

            if (connectionManager == null || !connectionManager.IsSockConnected())
            {
                if (!IsAlive)
                {
                    return;
                }

                if (Disconnecting != null)
                {
                    Disconnecting(this, null);
                }

                logger.WriteLog("##Disconnectiong null or socknotconnected 1059");
                Abort();

                return;
            }

            try
            {
                connectionManager.Socket.Send(sendBuffer);
            }
            catch (SocketException e)
            {
                //Console.WriteLine(e.Message);
                if (e.SocketErrorCode == SocketError.TimedOut && IsConnected)
                {
                    Disconnecting?.Invoke(this, null);

                    logger.WriteLog("##Disconnectiong socketexceps timeout 1033");
                    Abort();
                    return;
                }
            }
            catch (ObjectDisposedException e)
            {
                //Console.WriteLine(e.Message);
                if (!IsConnected)
                {
                    return;
                }

                Disconnecting?.Invoke(this, null);

                logger.WriteLog("##Disconnectiong disposed 1047");
                Abort();
                return;
            }
        }
        private void PingWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            while (worker.CancellationPending != true && connectionManager != null && connectionManager.IsSockConnected())
            {
                try
                {
                    ///Каждые 6 секунд, если нет ответа от сервера отправлять пингe

                    if (sendPingEvent.WaitOne(2000))
                    {
                        continue;
                    }

                    if (worker.CancellationPending == true || e.Cancel == true)
                    {
                        e.Cancel = true;
                        return;
                    }
                    Ping();
                    Thread.Sleep(100);
                    sendPingEvent.Reset();

                }
                catch (AmiTimeOutException)
                {
                    pingerWorker.CancelAsync();
                    pingerWorker.Dispose();
                }
                catch (AmiException)
                {
                    if (!connectionManager.IsSockConnected())
                    {
                        pingerWorker.CancelAsync();
                        pingerWorker.Dispose();
                    }
                }
                catch (NullReferenceException)
                {
                    if (connectionManager == null && IsAlive)
                        throw new AmiException("ManagerConnect не создан");
                }
            }
        }
        private void ParserWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            while (connectionManager != null && connectionManager.IsSockConnected())
            {
                if (worker.CancellationPending == true)
                {
                    if (e.Cancel == true)
                        return;
                }
                AsterParser.ParseServerMessage();
            }
        }
        /// <summary>
        /// Функция для инициализации потоков пинга и парсера
        /// </summary>
        private void StartBWThreads()
        {
            InstantiateWorkersOnce();

            StartAsyncCancellationWorker(recieverWorker, Reciever_DoWork, "Поток приема сообщений уже запущен. Переинициализируйте библиотеку");
            StartAsyncCancellationWorker(pingerWorker, PingWork, "Поток приема сообщений уже запущен. Переинициализируйте библиотеку");
            StartAsyncCancellationWorker(parserWorker, ParserWork, "Поток приема сообщений уже запущен. Переинициализируйте библиотеку");
        }
        private void InstantiateWorkersOnce()
        {
            recieverWorker ??= new BackgroundWorker();
            pingerWorker ??= new BackgroundWorker();
            parserWorker ??= new BackgroundWorker();
        }

        private void StartAsyncCancellationWorker(BackgroundWorker worker, DoWorkEventHandler workEventHandler, string busyExceptionMessage)
        {
            if (worker.IsBusy == true)
            {
                throw new AmiException(busyExceptionMessage);
            }

            worker.DoWork += workEventHandler;
            worker.WorkerSupportsCancellation = true;
            worker.RunWorkerAsync();
        }


        private void StartThreads()
        {
            //Создаем новый поток для пинга
            pingThread = new Thread(() =>
            {
                //Thread.CurrentThread.IsBackground = true;
                while (connectionManager.IsSockConnected())
                {
                    try
                    {
                        ///Каждые 6 секунд, если нет ответа от сервера отправлять пинг
                        if (!sendPingEvent.WaitOne(6000))
                        {
                            Ping();
                            Thread.Sleep(100);
                            sendPingEvent.Reset();
                        }

                    }
                    catch (AmiTimeOutException)
                    {
                        pingThread.Join();
                    }
                    catch (AmiException)
                    {
                        if (connectionManager.IsSockConnected())
                        {
                            continue;
                        }

                        pingThread.Join();
                    }
                }
            });
            pingThread.Start();
            //Как вариант записать здесь проверку на пинг, чтобы не создавать для нее новый поток
            parserThread = new Thread(() =>
            {
                Thread.CurrentThread.IsBackground = true;
                while (connectionManager.IsSockConnected())
                {
                    AsterParser.ParseServerMessage();
                }

            });
            parserThread.Start();
        }
        private void Reciever_DoWork(object sender, DoWorkEventArgs e)
        {
            byte[] recvBuffer = new byte[100000];
            string Response = string.Empty;
            int buffersize;
            BackgroundWorker worker = sender as BackgroundWorker;
            try
            {
                do
                {
                    //5 милисекунд слипа, работает и без него. Но мне так спокойнее.
                    //Нужен для того, чтобы буфер заполнился
                    Thread.Sleep(10);
                    if (worker.CancellationPending)
                    {
                        e.Cancel = true;
                        return;
                    }

                    buffersize = connectionManager.Socket.Receive(recvBuffer);
                    //Перекодируем его к строковому типу
                    Response += Encoding.ASCII.GetString(recvBuffer, 0, buffersize);
                    if (!Response.EndsWith(Helper.LINE_SEPARATOR + Helper.LINE_SEPARATOR))
                    {
                        continue;
                    }

                    if (worker.CancellationPending)
                    {
                        e.Cancel = true;
                        return;
                    }
#if LOG
                    if (IsLogEnabled)
                    {
                        logger.WriteLog(Response);

                    }
#endif
                    ///Кладем сообщение в общую память парсера
                    AsterParser.Response = Response;
                    //Разрешаем ему доступ к данным
                    AsterParser.startParse.Set();
                    sendPingEvent.Set();
                    //Обнуляем строку
                    Response = string.Empty;
                }
                while (connectionManager != null || connectionManager.IsSockConnected());
            }
            catch (SocketException ex)
            {
                if (ex.SocketErrorCode == SocketError.TimedOut && connectionManager != null && connectionManager.IsSockConnected() && !connectionManager.IsSockConnected())
                {
                    throw new AmiTimeOutException("Слишком долгое время ожидания ответа от сервера");
                }

                if (IsAlive)
                {
                    //Console.WriteLine(ex.Message);
                    return;
                }
            }
            catch (ObjectDisposedException ex)
            {
                if (IsAlive)
                    //Console.WriteLine(ex.Message);
                    return;
            }
            catch (NullReferenceException)
            {
                return;
            }
        }
        /// <summary>
        /// Функция отправлет запрос Ping на сервер, в ответ получает Pong
        /// Время между запросами - задержка соединения
        /// </summary>
        /// /// <returns>Возвращает задержку между отправкой запроса и получением ответа в милисекундах (Больше ничего не возвращает, задержка содержится в статусах)</returns>
        private void Ping()
        {
            PingAction action = new PingAction();
            SendToAsterisk(action);
        }
        /// <summary>
        /// Асинхронная функция получения сообщений от сервера
        /// </summary>
        /// <param name="pingtimeout">Время таймаута в секундах, между повторным запросом Ping</param>
        private void RecieveFromAsterisk()
        {
            byte[] recvBuffer = new byte[100000];
            string Response = string.Empty;
            int buffersize;

            try
            {
                do
                {
                    //5 милисекунд слипа, работает и без него. Но мне так спокойнее.
                    //Нужен для того, чтобы буфер заполнился
                    Thread.Sleep(10);
                    buffersize = connectionManager.Socket.Receive(recvBuffer);
                    //Перекодируем его к строковому типу
                    Response += Encoding.ASCII.GetString(recvBuffer, 0, buffersize);
                    if (!Response.EndsWith(Helper.LINE_SEPARATOR + Helper.LINE_SEPARATOR))
                    {
                        continue;
                    }
#if LOG
                    DateTime date = DateTime.Now;
                    System.IO.StreamWriter file = new System.IO.StreamWriter("RECVLOG" + date.ToShortDateString() + ".log", true);
                    try
                    {
                        file.WriteLine(date.ToString(), file.NewLine);
                        file.WriteLine(Response);
                        file.Close();
                    }
                    finally
                    {
                        if (file != null)
                        {
                            file.Dispose();
                        }
                    }
#endif
                    ///Кладем сообщение в общую память парсера
                    AsterParser.Response = Response;
                    //Разрешаем ему доступ к данным
                    AsterParser.startParse.Set();
                    sendPingEvent.Set();
                    //Обнуляем строку
                    Response = string.Empty;
                }
                while (connectionManager != null || connectionManager.IsSockConnected());
            }
            catch (SocketException e)
            {
                if (e.SocketErrorCode != SocketError.TimedOut || connectionManager == null || !connectionManager.IsSockConnected())
                {
                    return;
                }

                sendPingEvent.Set();
                Thread.Sleep(3000);

                if (connectionManager.IsSockConnected() || !IsConnected)
                {
                    return;
                }

                if (Disconnecting != null)
                {
                    Disconnecting(this, null);
                }

                logger.WriteLog("##Disconnectiong socketexceps 1377");
                Abort();
            }
            catch (ObjectDisposedException e)
            {
                if (!IsConnected)
                {
                    //Console.WriteLine(e.Message);
                    return;
                }

                if (Disconnecting != null)
                {
                    Disconnecting(this, null);
                }

                logger.WriteLog("##Disconnectiong Objectdisposed 1395");
                Abort();
            }
            catch (NullReferenceException)
            {
                if (!IsConnected)
                {
                    return;
                }

                if (Disconnecting != null)
                {
                    Disconnecting(this, null);
                }
                logger.WriteLog("##Disconnectiong nullreference 1410");
                Abort();
            }

        }
        /// <summary>
        /// Запуск потока с приемом сообщений
        /// </summary>
        /// <returns></returns>
        private void StartRecieve()
        {
            recieverThread = new Thread(() => RecieveFromAsterisk());
            recieverThread.Start();
            ///Инициализация Пинга и Парсера
            StartThreads();
        }
        /// <summary>
        /// Функция отписки от событий
        /// </summary>
        private void ReleaseAsteriskEvents()
        {
            EventManager.PeerEntry -= PeerEntryEvent;
            EventManager.Hangup -= HangupEvent;
            EventManager.ParkedCall -= ParkedCallEvent;
            EventManager.Newchannel -= NewchannelEvent;
            EventManager.Newstate -= NewChannelState;
            EventManager.DialEvent -= EventManager_DialEvent;
        }
        /// <summary>
        /// Функция освобождения памяти
        /// </summary>
        private void FreeMemeory()
        {
            activeChannels.GetChannels().Clear();
            ActiveCalls.Clear();
            AmiVersion = AmiVersions.UNKNOWN;
            ServerUsers.Clear();
            UserData = null;
            UsersAmount = null;
            ActionIdMessages.Clear();
            ParkedCalls.Clear();
            connectionManager = null;
            actionIdcounter = 0;
        }
        #endregion

        #region Функции для работы клиента с библиотекой
        public void ListCommands()
        {
            ListCommandsAction list = new ListCommandsAction();
            SendToAsterisk(list);
        }
        /// <summary>
        /// Функция подключения к серверу и старт асинхронной отправки, получения сообщений
        /// </summary>
        /// <param name="login">Имя менеджера на сервере</param>
        /// <param name="pwd">Пароль менеджера на сервере</param>
        /// <param name="ip">Адрес сервера астериск</param>
        /// <param name="port">Порт подключения к менеджеру</param>
        /// <returns>В слуучае успеха вернет true, в случае ошибки на стадии создания сокетов или подключения вернет false или выкенет Exception</returns>
        public bool Connect(string login, string pwd, string ip, int port)
        {

            ////Вариант со старыми сокетами
            if (connectionManager == null)
            {
                connectionManager = new SocketConnection();
            }

            try
            {
                connectionManager.Socket.Connect(connectionManager.getEndPoint(ip, port));
            }
            catch (SocketException e)
            {
                if (e.SocketErrorCode == SocketError.TimedOut)
                    throw new AmiTimeOutException("Сервер недоступен");
                return false;
            }
            //Создаем дейстиве логин
            LoginAction action = new LoginAction(CreateActionID())
            {
                UserName = login,
                PassWord = pwd
            };

            //Отправляем запрос
            SendToAsterisk(action);
            //Начинаем асинхронный прием сообщений
            StartBWThreads();

            if (LoginEvent.LoginComplete.WaitOne(5000))
            {
                if (ActionIdMessages.ContainsKey(action.GetActionId()))
                {
                    IsAlive = true;
                    var result = (LoginEvent)ActionIdMessages[action.GetActionId()];
                    ParseAndSetAmiVersion(result.Version);

                    ActionIdMessages.Remove(action.GetActionId());
                    IsConnected = result.IsConnected;
                    return IsConnected;
                }
            }
            Abort();
            return false;
        }

        private void ParseAndSetAmiVersion(string version)
        {
            if (version.Contains("1.1"))
            {
                AmiVersion = AmiVersions.v11;
            }
            else if (version.Contains("1.3"))
            {
                AmiVersion = AmiVersions.v13;
            }
            else if (version.Contains("2.5"))
            {
                AmiVersion = AmiVersions.v25;
            }
            else if (version.Contains("2.8"))
            {
                AmiVersion = AmiVersions.v28;
            }
            else
            {
                AmiVersion = AmiVersions.UNKNOWN;
            }
        }

        public bool ConnectMD5(string login, string pwd, string ip, int port)
        {

            connectionManager ??= new SocketConnection();

            try
            {
                connectionManager.Socket.Connect(connectionManager.getEndPoint(ip, port));
            }
            catch (SocketException e)
            {
                switch (e.SocketErrorCode)
                {
                    case SocketError.TimedOut:
                        throw new AmiTimeOutException("Время ожидания ответа от сервера истекло");
                    //break;
                    case SocketError.HostUnreachable:
                        throw new AmiException("Сервер недоступен");
                    //break;
                    case SocketError.NetworkUnreachable:
                        throw new AmiException("Сеть недоступна, проверьте настройки подключения");
                    //break;
                    default:
                        throw new AmiException(e.SocketErrorCode.ToString());
                        //break;
                }
                //return false;
            }
            //Создаем дейстиве логин
            ChallengeAction challenge = new ChallengeAction(CreateActionID());

            SendToAsterisk(challenge);
            string key = string.Empty;
            //Начинаем асинхронный прием сообщений
            StartBWThreads();

            if (!ChallengeEvent.ChallengeComplete.WaitOne(5000))
            {
                return false;
            }
            else if (ActionIdMessages.ContainsKey(challenge.GetActionId()))
            {
                var result = (ChallengeEvent)ActionIdMessages[challenge.GetActionId()];
                key = AsteriskManagerUtils.CalculateMD5Hash(result.Challenge + pwd);

                ParseAndSetAmiVersion(result.Version);

                //AmiVersion = result.Version;
                ActionIdMessages.Remove(challenge.GetActionId());
            }

            LoginAction action = new LoginAction(CreateActionID())
            {
                UserName = login,
                AuthType = "MD5",
                Key = key
            };

            SendToAsterisk(action);

            //if (reciever == null || reciever.IsAlive == false)
            //    StartRecieve();
            //else throw new AmiException("Поток приема сообщений уже запущен!!!!");
            if (LoginEvent.LoginComplete.WaitOne(5000))
            {
                if (ActionIdMessages.ContainsKey(action.GetActionId()))
                {
                    IsAlive = true;
                    var result = (LoginEvent)ActionIdMessages[action.GetActionId()];
                    ActionIdMessages.Remove(action.GetActionId());
                    IsConnected = result.IsConnected;
                    return IsConnected;
                }
            }
            Abort();
            return false;
        }
        /// <summary>
        /// Функция для инициализации клиентских данных и подписок на события (Вызывать 1 раз)
        /// Получает подробную информацию о используемом пользователе с сервера
        /// Общую информацию о пользователях
        /// Список активных каналов
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public bool Initialize(string number)
        {
            SubscribeToAsteriskEvents();
            UsersAmount = CheckClientsStatus();
            if (UserData == null)
            {
                UserData = GetUserData(number);
            }

            if (UserData == null || string.IsNullOrEmpty(UsersAmount) || !GetActiveChannelsInfo())
            {
                CloseSocket();
                ReleaseAsteriskEvents();
                FreeMemeory();
                return false;
            }
            return true;
        }

        private void SubscribeToAsteriskEvents()
        {
            EventManager.PeerEntry += PeerEntryEvent;
            EventManager.Hangup += HangupEvent;
            EventManager.ParkedCall += ParkedCallEvent;
            EventManager.Newchannel += NewchannelEvent;
            EventManager.Newstate += NewChannelState;
            EventManager.DialEvent += EventManager_DialEvent;
        }

        /// <summary>
        /// Отправка запроса отключения от сервера и осовобождение ресурсов на локальной машине
        /// </summary>
        public void Disconnect()
        {
            LogoffAction action = new LogoffAction();
            SendToAsterisk(action);

            Abort();
        }
        /// <summary>
        /// Вызывать в случае если произошел разрыв связи. Освобождение ресурсов и закрытие потоков
        /// </summary>
        public void Abort()
        {
            IsAlive = false;
            IsConnected = false;

            CloseSocket();
            StopWorkers();
            ReleaseAsteriskEvents();
            FreeMemeory();
            DisposeWorkers();
        }

        private void CloseSocket()
        {
            if (connectionManager != null && connectionManager.Socket != null)
            {
                connectionManager.CloseSocket();
            }
        }

        private void DisposeWorkers()
        {
            if (recieverWorker == null || parserWorker == null || pingerWorker == null)
            {
                return;
            }

            pingerWorker.Dispose();
            parserWorker.Dispose();
            recieverWorker.Dispose();

            pingerWorker = null;
            parserWorker = null;
            recieverWorker = null;
        }

        private void StopWorkers()
        {
            if (recieverWorker != null && recieverWorker.IsBusy)
            {
                recieverWorker.CancelAsync();
            }

            if (parserWorker != null && parserWorker.IsBusy)
            {
                parserWorker.CancelAsync();
                AsterParser.startParse.Set();
            }

            if (pingerWorker != null && pingerWorker.IsBusy)
            {
                pingerWorker.CancelAsync();
                sendPingEvent.Set();
            }
        }

        /// <summary>
        /// Запрос информации о пользователях у сервера.
        /// Для каждого пользователя сработает ивент PeerEntry
        /// После всех ивентов приходит Response. В завимости от ответа возвращает количество клиентов, которые записаны в память.
        /// </summary>
        /// <returns>Возвращает либо строку с ошибкой, дибо количество клиентов</returns>
        public string CheckClientsStatus()
        {
            if (ServerUsers.Count > 0)
            {
                ServerUsers.Clear();
            }

            SippeersAction action = new SippeersAction(CreateActionID());
            SendToAsterisk(action);

            if (PeerlistCompleteEvent.PeerlistComplete.WaitOne(25000))
            {
                if (ActionIdMessages.ContainsKey(action.GetActionId()))
                {
                    var message = (PeerlistCompleteEvent)ActionIdMessages[action.GetActionId()];
                    ActionIdMessages.Remove(action.GetActionId());

                    return message.ListItems;
                }
            }
            return "";
        }
        /// <summary>
        /// Получение информации о клиенте с сервера
        /// </summary>
        /// <returns>Возвращает клиентские данные в случае успеха, иначе Null</returns>
        public ClientsData GetUserData(string number)
        {
            ///Отправка запроса на сервер
            SIPShowPeerAction action = new SIPShowPeerAction(CreateActionID())
            {
                Peer = number
            };
            SendToAsterisk(action);

            ///Ожидание ответа в течении 5 секунд
            if (!SIPShowPeerEvent.SipShowPeerComplete.WaitOne(TimeSpan.FromMilliseconds(5000)))
            {
                return null;
            }

            ///Если в общей памяти содержится сообщение с нашим ключом, то получаем данные
            if (!ActionIdMessages.ContainsKey(action.GetActionId()))
            {
                return null;
            }

            var message = (SIPShowPeerEvent)ActionIdMessages[action.GetActionId()];
            ClientsData client = new ClientsData()
            {
                Number = number,
                Context = message.Context,
                IP = message.AddressIP,
                Status = message.Status,
                email = message.VoiceMailbox,
                Name = message.ObjectName,
                Protocol = message.Status
            };

            ActionIdMessages.Remove(action.GetActionId());

            for (int i = 0; i < ServerUsers.Count; i++)
            {
                try
                {
                    if (ServerUsers[i].Number == number)
                    {
                        ServerUsers[i] = client;
                    }
                }
                catch { }
            }

            return client;
        }
        /// <summary>
        /// Получает информацию о активных каналах
        /// Используется в инициализации
        /// </summary>
        /// <returns></returns>
        private bool GetActiveChannelsInfo()
        {
            CommandAction action = new CommandAction(CreateActionID())
            {
                Command = "Core Show Channels"
            };

            SendToAsterisk(action);

            if (!CoreShowChannelsEvent.CoreShowChannelsComplete.WaitOne(5000))
            {
                return false;
            }

            foreach (var obj in activeChannels.GetChannels())
            {
                StatusAction status = new StatusAction(CreateActionID())
                {
                    Channel = obj.ChannelID
                };
                SendToAsterisk(status);

                if (StatusEvent.StatusComplete.WaitOne(2000))
                {
                    if (ActionIdMessages.ContainsKey(status.GetActionId()))
                    {
                        ActionIdMessages.Remove(status.GetActionId());
                    }
                }
            }

            return true;
        }
        /// <summary>
        /// Функция асинхронного звонка. Ставит звонок в очередь на сервере.
        /// </summary>
        /// <param name="Number"></param>
        /// <returns>Вовзращает удалось ли добавить звонок в очередь</returns>
        public bool AsyncCall(string Number)
        {
            OriginateEvent.OriginateComplete.Reset();
            OriginateAction action = GetOriginateAction(Number, Number);

            if (OriginateEvent.OriginateComplete.WaitOne(5000))
            {
                if (ActionIdMessages.ContainsKey(action.GetActionId()))
                {
                    var result = (OriginateEvent)ActionIdMessages[action.GetActionId()];
                    ActionIdMessages.Remove(action.GetActionId());
                    return result.IsCallSuccess;
                }
            }

            return false;
        }
        public bool Call(ClientsData client, bool SecondNumber)
        {
            return Call(SecondNumber ? client.SecondNumber : client.Number, client.Name);
        }

        public bool Call(string NumberToCall, string name = null)
        {
            if (activeChannels.IsUserStartedCall(UserData.Number))
            {
                return false;
            }

            OriginateEvent.OriginateComplete.Reset();
            OriginateAction action = GetOriginateAction(NumberToCall, name);

            SendToAsterisk(action);
            if (OriginateEvent.OriginateComplete.WaitOne(5000))
            {
                if (ActionIdMessages.ContainsKey(action.GetActionId()))
                {
                    var result = (OriginateEvent)ActionIdMessages[action.GetActionId()];
                    ActionIdMessages.Remove(action.GetActionId());
                    return result.IsCallSuccess;
                }
            }

            return false;
        }


        private OriginateAction GetOriginateAction(string number, string name)
        {

            var callerIdBuilder = new StringBuilder();
            callerIdBuilder.Append(string.IsNullOrEmpty(name) ? CallerID : AsteriskManagerUtils.ConvertToTranslit(name));
            callerIdBuilder.Append(" ");
            callerIdBuilder.Append(number);
            callerIdBuilder.Append(CallerID);
            callerIdBuilder.Append(" (B-CTI) <");
            callerIdBuilder.Append(UserData.Number);
            callerIdBuilder.Append(">");

            OriginateAction action = new OriginateAction(CreateActionID(), OriginateEventСallType.SipToExten)
            {
                Exten = number,
                Priority = 1,
                Channel = UserData.GetChannel(),
                Context = UserData.Context,
                IsAsync = true,
                CallerId = callerIdBuilder.ToString()
            };


            return action;
        }

        /// <summary>
        /// Функция завершения вызова в любом состоянии
        /// Отлавливает канал с номером абонента, который совершил звонок и завершает его
        /// </summary>
        /// <param name="AiringCallNumber">Номер с которым установлено соединение</param>
        /// <returns>Если канал с таким номером существовал, то отправит запрос и вернет true, иначе false</returns>
        public bool Hangup(string AiringCallNumber)
        {
            var channel = FindChannel(AiringCallNumber);
            if (channel != null)
            {
                InvokeHangup(channel.ChannelID);
                return true;
            }
            return false;
        }
        /// <summary>
        /// Завершение звонка по channelID
        /// </summary>
        /// <param name="channel"></param>
        /// <returns></returns>
        public bool HangupByChannel(string ChannelID)
        {
            var channel = activeChannels.FindChInfoByChID(ChannelID);
            if (channel != null)
            {
                InvokeHangup(ChannelID);
                return true;
            }
            return false;
        }
        /// <summary>
        /// Завершение звонков находящего в состоянии дозвона от определенного номера
        /// </summary>
        /// <param name="AiringCallNumber"></param>
        /// <returns></returns>
        public bool HangupAllAiringCalls(string AiringCallNumber)
        {
            var channel = activeChannels.FindChannelsWithCallerID(AiringCallNumber);
            var channel2 = activeChannels.FindChannelsWithCallerID(UserData.Number);
            if (channel.Count <= 0)
            {
                return false;
            }

            for (int i = 0; i < channel.Count; i++)
            {
                if (AiringCallNumber != UserData.Number)
                {

                    if ((channel2[i].State == ChannelState.RemoteRinging && channel2[i].ConnectedLineNum == AiringCallNumber) || (channel[i].State == ChannelState.Ringing && channel[i].ConnectedLineNum == UserData.Number))
                    {
                        InvokeHangup(channel[i].ChannelID);
                    }
                }
                else
                {
                    if ((channel[i].State == ChannelState.RemoteRinging))
                    {
                        InvokeHangup(channel[i].ChannelID);
                    }
                }
            }


            return true;
        }

        private void InvokeHangup(string channelId)
        {
            HangupAction hangup = new HangupAction(CreateActionID())
            {
                Channel = channelId
            };

            SendToAsterisk(hangup);
        }
        /// <summary>
        /// Функция перевода звонка на активном канале
        /// </summary>
        /// <param name="NumberTransferTo">Номер абонента, которого будем переводить</param>
        /// <param name="transferToNumber">Номер, которому будем переводить звонок</param>
        /// <returns>Если активный канал с номером абонента существует, то отправит запрос и вернет истину</returns>
        public bool Redirect(DialData dial, string transferToNumber)
        {
            ChannelData channel = activeChannels.FindChInfoByChID(dial.CallerIDNum == UserData.Number ? dial.DestinationID : dial.ChannelID);

            if (channel != null)
            {
                InvokeRedirect(channel.ChannelID, channel.Context, transferToNumber);
                return true;
            }

            return false;
        }
        /// <summary>
        /// Функция перевода звонка на активном канале
        /// </summary>
        /// <param name="NumberTransferTo">Номер абонента, которого будем переводить</param>
        /// <param name="TransferToNumber">Номер, которому будем переводить звонок</param>
        /// <returns>Если активный канал с номером абонента существует, то отправит запрос и вернет истину</returns>
        public bool Redirect(string NumberTransferTo, string TransferToNumber)
        {
            var channel = FindChannel(NumberTransferTo);
            if (channel == null)
            {
                return false;
            }

            //Работает на версии 1.3 и 2.8
            if (!string.IsNullOrEmpty(channel.Context))
            {
                InvokeRedirect(channel.ChannelID, channel.Context, TransferToNumber);
                return true;
            }


            var channel2 = FindChannel(channel.ConnectedLineNum);
            if (channel2 == null)
            {
                return false;
            }

            InvokeRedirect(channel.ChannelID, channel2.Context, TransferToNumber);
            return true;
        }


        private void InvokeRedirect(string channeld, string context, string transferToNumber)
        {
            RedirectAction redirect = new RedirectAction()
            {
                Channel = channeld,
                Context = context,
                Exten = transferToNumber,
                Priority = 1
            };
            SendToAsterisk(redirect);

        }
        /// <summary>
        /// Функция парковки абонента на активном канале
        /// </summary>
        /// <param name="ParkNumber">Номер, который необходимо запарковать</param>
        /// <param name="Timeout">Таймаут в секундах, после которого паркуемый абонент вернется к запарковавшему его клиенту</param>
        /// <returns>Если канал с таким номером существует вернет истину</returns>
        public bool Park(DialData dial, int Timeout)
        {
            if (AmiVersion == AmiVersions.v11 || AmiVersion == AmiVersions.v13)
            {
                var isFollowedUserCaller = dial.CallerIDNum == UserData.Number;
                var (channel1, channel2) = isFollowedUserCaller
                    ? (dial.DestinationID, dial.ChannelID)
                    : (dial.ChannelID, dial.DestinationID);
                string _timeout = (Timeout * 1000).ToString();

                ParkAction park = new ParkAction(CreateActionID())
                {
                    Channel1 = channel1,
                    Channel2 = channel2,
                    Timeout = _timeout
                };
                SendToAsterisk(park);

                return true;
            }
            else if (AmiVersion == AmiVersions.v25 || AmiVersion == AmiVersions.v28)
            {
                ParkAction park = new ParkAction(CreateActionID())
                {
                    Channel1 = dial.DestinationID,
                    AnnounceChannel = dial.ChannelID
                };

                SendToAsterisk(park);
                return true;
            }

            return false;
        }
        /// <summary>
        /// Функция парковки абонента на активном канале
        /// </summary>
        /// <param name="ParkNumber">Номер, который необходимо запарковать</param>
        /// <param name="Timeout">Таймаут в секундах, после которого паркуемый абонент вернется к запарковавшему его клиенту</param>
        /// <returns>Если канал с таким номером существует вернет истину</returns>
        public bool Park(string ParkNumber, int Timeout)
        {
            var channel1 = FindChannel(ParkNumber);
            if (channel1 == null)
            {
                return false;
            }

            if (AmiVersion == AmiVersions.v11 || AmiVersion == AmiVersions.v13)
            {
                var channel2 = FindConnectedChannel(ParkNumber);
                if (channel2 != null)
                {
                    string _timeout = (Timeout * 1000).ToString();
                    ParkAction park = new ParkAction()
                    {
                        Channel1 = channel1.ChannelID,
                        Channel2 = channel2.ChannelID,
                        Timeout = _timeout
                    };
                    SendToAsterisk(park);
                    return true;
                }
            }
            else if (AmiVersion == AmiVersions.v25 || AmiVersion == AmiVersions.v28)
            {
                var channel2 = FindConnectedChannel(ParkNumber);
                ParkAction park = new ParkAction("PARKOVKAWORKAU")
                {
                    Channel1 = channel1.ChannelID,
                    AnnounceChannel = channel2.ChannelID
                };

                SendToAsterisk(park);
                return true;
            }

            return false;
        }
        /// <summary>
        /// Возвращает парковыочный слот по номеру абонента
        /// </summary>
        /// <param name="ParkedNumber">Номер запаркованного абонента</param>
        /// <returns>Парковвочный слот</returns>
        public string GetParkSlot(string ParkedNumber)
        {
            ParkedCallsAction action = new ParkedCallsAction();
            SendToAsterisk(action);

            if (ParkedCallsCompleteEvent.ParkedCallsComplete.WaitOne(5000))
            {
                for (int i = 0; i < ParkedCalls.Count; i++)
                {
                    if (ParkedCalls[i].CallerIDNum == ParkedNumber)
                    {
                        return ParkedCalls[i].Exten;
                    }
                }
            }

            return null;
        }
        /// <summary>
        /// Возвращает информацию о пользователе по номеру
        /// </summary>
        /// <param name="UserNumber">Номер пользователя</param>
        /// <returns>Пользовательские данные</returns>
        public ClientsData GetUser(string UserNumber)
        {
            for (int i = 0; i < ServerUsers.Count; i++)
            {
                if (ServerUsers[i].Number == UserNumber)
                {
                    return ServerUsers[i];
                }
            }

            return null;
        }
        /// <summary>
        /// Функция суфлера. Тихое присоединение к каналу. Только абонент к которому мы присоединились слышит нас.
        /// Мы слышим весь разговор. Собеседник не подозревает о нашем присутствии.
        /// </summary>
        /// <param name="NumberToHelpTo"></param>
        /// <returns></returns>
        public bool PrompterMode(string NumberToHelpTo)
        {
            var user = GetUser(NumberToHelpTo);
            if (user != null)
            {
                return PrompterMode(user);
            }
            return false;
        }
        /// <summary>
        /// Функция "тихого" присоединения к звонку. Все люди в конференции слышат нас.
        /// </summary>
        /// <param name="NumberToHelpTo"></param>
        /// <returns></returns>
        public bool JoinCall(string NumberToConnectTo)
        {
            var user = GetUser(NumberToConnectTo);
            if (user != null)
            {
                return JoinCall(user);
            }

            return false;
        }

        public bool PrompterMode(ClientsData user)
        {
            return OriginateChannelSpy(user, ",wx");
        }

        private bool OriginateChannelSpy(ClientsData User, string flag)
        {
            var userChannel = UserData.GetChannel();
            return OriginateEventWithSipAddHeader(userChannel, "ChanSpy", userChannel + flag);
        }

        private bool OriginateEventWithSipAddHeader(string channel, string app, string data)
        {
            OriginateAction originate = new OriginateAction(OriginateEventСallType.AppCommand)
            {
                Channel = channel,
                Application = app,
                Data = data,
            };
            originate.Priority = 1;

            Dictionary<string, string> vars = new Dictionary<string, string>();
            if (SIPADDHEADER == null)
            {
                throw new AmiException("SIPADDHEADER NULL");
            }

            vars.Add("SIPADDHEADER", SIPADDHEADER);
            originate.SetVariables(vars);
            SendToAsterisk(originate);

            //Подождать ответа от сервера
            return true;
        }

        public bool JoinCall(ClientsData user)
        {
            return OriginateChannelSpy(user, ",qBx");
        }

        /// <summary>
        /// Функция для тихой прослушки канала. Никто из абонентов не слышит нас.
        /// </summary>
        /// <param name="NumberToHelpTo">Номер клиента за которым мы будем подслушивать</param>
        /// <returns></returns>
        public bool SpyCall(string NumberToListenTo)
        {
            var user = GetUser(NumberToListenTo);
            if (user != null)
            {
                return SpyCall(user);
            }
            return false;
        }
        public bool SpyCall(ClientsData user)
        {
            return OriginateChannelSpy(user, ",qx");
        }
        /// <summary>
        /// Функция запроса прослушивания записи разговора.
        /// </summary>
        /// <param name="PathToPlayBackFile">Путь к файлу на сервере /storage/usbdisk1/test_file</param>
        /// <returns>Если все прошло успешно, то на телефон пользователя поступит вызов с записью</returns>
        public bool AskForPlayback(string PathToPlayBackFile)
        {
            return OriginateEventWithSipAddHeader(UserData.GetChannel(), "Playback", PathToPlayBackFile);
        }
        /// <summary>
        /// Функция ответа на звонок без поднятия трубки. (Работает не со всеми телефонами)
        /// Если существует канал, который пытается дозвониться до нашего абонента, то мы можем сделать ответный звонок на его линию с условием автоответа
        /// </summary>
        /// <param name="CallerNumber">Номер звонящего нам абонента</param>
        public void Answer(string CallerNumber)
        {
            var channel = FindChannel(CallerNumber);
            if (channel == null)
            {
                return;
            }

            if (channel.State == ChannelState.RemoteRinging || (channel.State == ChannelState.Ringing && channel.ConnectedLineNum == UserData.Number))
            {
                OriginateEventWithSipAddHeader(UserData.GetChannel(), "PickupChan", channel.ChannelID);
            }
        }
        /// <summary>
        /// Функция перезагрузки модуля на сервере астериск
        /// </summary>
        /// <param name="ReloadModule"></param>
        public void Reload(string ReloadModule)
        {
            ReloadAction reload = new ReloadAction()
            {
                Module = ReloadModule
            };
            SendToAsterisk(reload);
        }
        #endregion
    }
}
