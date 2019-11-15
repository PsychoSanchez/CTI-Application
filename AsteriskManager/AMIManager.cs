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
using System.Security.Cryptography;
using System.IO;

namespace AsteriskManager
{
    public class AMIManager
    {
        const string UNKNOWN_NUMBER = "<unknown>";
        const string ROSTELEKOM_LINE_NUMBER = "rostelecom";

        #region Функции для работы с массивами данных
        private AutoResetEvent ActiveChanSemaphore = new AutoResetEvent(true);

        private void DefaultChannelInfoValues(DialData dial)
        {
            try
            {
                ActiveChanSemaphore.WaitOne();
                for (int i = 0; i < ActiveChannels.Count; i++)
                {
                    ChannelData channel = ActiveChannels[i];
                    if (!channel.ChannelID.Equals(dial.ChannelID))
                    {
                        continue;
                    }


                    DefaultChannelCallerInfo(channel, dial);
                    DefaultChannelConnectedLineInfo(channel, dial);
                    ActiveChanSemaphore.Set();
                    return;
                }
                ActiveChanSemaphore.Set();
                return;
            }
            catch (IndexOutOfRangeException)
            {
                ActiveChanSemaphore.Set();
                DefaultChannelInfoValues(dial);
            }
        }

        private ChannelData DefaultChannelInfoValues(NewstateEvent ChannelInfo)
        {
            try
            {
                ActiveChanSemaphore.WaitOne();
                for (int i = 0; i < ActiveChannels.Count; i++)
                {
                    ChannelData activeChannel = ActiveChannels[i];
                    if (!activeChannel.ChannelID.Equals(ChannelInfo.Channel))
                    {
                        continue;
                    }

                    ChannelData updatedActiveChannel = GetChannelDataWithUpdatedEventInfo(activeChannel, ChannelInfo);
                    ActiveChanSemaphore.Set();
                    return updatedActiveChannel;
                }
                ActiveChanSemaphore.Set();
                return null;
            }
            catch (IndexOutOfRangeException)
            {
                ActiveChanSemaphore.Set();
                return DefaultChannelInfoValues(ChannelInfo);
            }
        }
        private ChannelData GetChannelDataWithUpdatedEventInfo(ChannelData activeChannelData, NewstateEvent channelInfo)
        {
            if (!string.IsNullOrEmpty(channelInfo.ChannelState))
            {
                activeChannelData.Status = channelInfo.ChannelState;
            }

            if (!string.IsNullOrEmpty(channelInfo.ChannelStateDesc))
            {
                activeChannelData.ChannelStateDesc = channelInfo.ChannelStateDesc;
            }

            if (!string.IsNullOrEmpty(channelInfo.Context))
            {
                activeChannelData.Context = channelInfo.Context;
            }

            DefaultChannelCallerInfo(activeChannelData, channelInfo);
            DefaultChannelConnectedLineInfo(activeChannelData, channelInfo);

            return activeChannelData;
        }

        private void DefaultChannelCallerInfo(IDialChannelInfo target, IDialChannelInfo source)
        {
            // FastPath
            if (!IsNullEmptyOrUnknownNumber(target.CallerIDNum))
            {
                return;
            }

            UpdateChannelCallerInfo(target, source);
        }

        private void UpdateChannelCallerInfo(IDialChannelInfo target, IDialChannelInfo source)
        {
            if (!IsNullEmptyOrUnknownNumber(source.CallerIDNum))
            {
                target.CallerIDNum = source.CallerIDNum;
            }

            if (!IsNullEmptyOrUnknownNumber(source.CallerIDName))
            {
                target.CallerIDName = source.CallerIDName;
            }
        }

        private void DefaultChannelConnectedLineInfo(IDialChannelInfo target, IDialChannelInfo source)
        {
            // FastPath
            if (!IsNullEmptyOrUnknownNumber(target.CallerIDNum))
            {
                return;
            }

            UpdateChannelConnectedLineInfo(target, source);
        }

        private void UpdateChannelConnectedLineInfo(IDialChannelInfo target, IDialChannelInfo source)
        {
            if (!IsNullEmptyOrUnknownNumber(source.ConnectedLineNum))
            {
                target.ConnectedLineNum = source.ConnectedLineNum;
            }

            if (!IsNullEmptyOrUnknownNumber(source.ConnectedLineName))
            {
                target.ConnectedLineName = source.ConnectedLineName;
            }
        }

        private bool IsNullEmptyOrUnknownNumber(string value)
        {
            return string.IsNullOrEmpty(value) || value == UNKNOWN_NUMBER;
        }

        private ChannelData RemoveActiveChannel(string ChannelID)
        {
            try
            {
                ActiveChanSemaphore.WaitOne();
                for (int j = 0; j < ActiveChannels.Count; j++)
                {
                    if (!ActiveChannels[j].ChannelID.Equals(ChannelID))
                    {
                        continue;
                    }

                    var removedchannel = ActiveChannels[j];
                    ActiveChannels.RemoveAt(j);
                    ActiveChanSemaphore.Set();
                    return removedchannel;
                }

                ActiveChanSemaphore.Set();
                return null;
            }
            catch (IndexOutOfRangeException)
            {
                ActiveChanSemaphore.Set();
                return RemoveActiveChannel(ChannelID);
            }
        }
        private void UpdateChannelCallerID(ChannelData Channel, ChannelData Destination)
        {
            try
            {
                ActiveChanSemaphore.WaitOne();
                for (int i = 0; i < ActiveChannels.Count; i++)
                {
                    if (!Channel.Equals(ActiveChannels[i]))
                    {
                        continue;
                    }

                    ActiveChannels[i].ConnectedLineNum = Destination.CallerIDNum;
                    ActiveChanSemaphore.Set();
                    return;
                }
                ActiveChanSemaphore.Set();
                return;
            }
            catch (IndexOutOfRangeException)
            {
                ActiveChanSemaphore.Set();
                UpdateChannelCallerID(Channel, Destination);
            }
        }

        private DialData TryGetDialChannelInfoAndUpdateDial(DialData dial)
        {
            ChannelData channel = FindChInfoByChID(dial.ChannelID);
            if (channel == null)
            {
                channel = FindChInfoByChID(dial.DestinationID);
            }

            if (channel == null)
            {
                return null;
            }

            ///Если номера совпадают подтягиваем второй канла
            UpdateDialInfoWithChannelInfo(dial, channel);

            UpdateActiveCalls(dial);

            return dial;
        }


        private void UpdateDialInfoWithChannelInfo(DialData dial, ChannelData channel)
        {
            if (channel.CallerIDNum == channel.ConnectedLineNum)
            {
                TryUpdateChannelInfoWithDestinationChannelInfo(channel, dial.DestinationID);
            }

            ///Если номер из канала не неизвестен и не пуст, то применяем его для нашего звонка
            UpdateChannelCallerInfo(dial, channel);
            ///Если номер из канала не неизвестен и не пуст, то применяем его для нашего звонка
            UpdateChannelConnectedLineInfo(dial, channel);

            ///Теперь по крайней мере 1 из номеров точно известен, осталось разобраться со вторым
            ///Для этого подтягиваем номер из айдишника канала или из dialstring

            if (IsNullEmptyOrUnknownNumber(dial.CallerIDNum))
            {
                dial.CallerIDNum = GetCallerId(dial.ChannelID, dial.Dialstring);
            }


            ///Если номер к которому подключен абонент неизвестен или пуст, то ищем канал к подключения и получаем колерайди из него
            if (IsNullEmptyOrUnknownNumber(dial.ConnectedLineNum))
            {
                var dest = FindChInfoByChID(dial.DestinationID);
                if (dest != null && !IsNullEmptyOrUnknownNumber(dest.CallerIDNum))
                {
                    dial.ConnectedLineNum = dest.CallerIDNum;
                }
            }

            ///Если он все еще неизвестен или пуст прибегаем к последнему варианту, получаем колер айди из айди канала
            if (IsNullEmptyOrUnknownNumber(dial.ConnectedLineNum))
            {
                dial.ConnectedLineNum = GetCallerId(dial.DestinationID, dial.Dialstring);
            }
        }

        private static string GetCallerId(string channelID, string dialstring)
        {
            string callerId = Helper.GetNumberFromChannel(channelID);

            if (callerId == ROSTELEKOM_LINE_NUMBER)
            {
                // Remove rostelecom prefix
                return dialstring.Replace("rostelecom/", "");
            }

            return callerId;
        }

        private void TryUpdateChannelInfoWithDestinationChannelInfo(ChannelData channel, string channelDestinationId)
        {
            var dest = FindChInfoByChID(channelDestinationId);
            if (dest != null)
            {
                UpdateChannelCallerID(channel, dest);
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
                        UpdateChannelCallerInfo(dial, ActiveCalls[i]);
                        UpdateChannelConnectedLineInfo(dial, ActiveCalls[i]);
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
        /// Функция поиска канала по номеру
        /// </summary>
        /// <param name="connectedLineNum">Номер звонящего</param>
        /// <returns>Возвращает канал или нулл если канала с таким номером нет</returns>
        private ChannelData FindChannel(string connectedLineNum)
        {
            try
            {
                ActiveChanSemaphore.WaitOne();
                ChannelData channel = GetChannelByCallerNumbers(connectedLineNum, UserData.Number);

                return channel != null ? channel : FindConnectedChannel(connectedLineNum);
            }
            catch (IndexOutOfRangeException)
            {
                return FindChannel(connectedLineNum);
            }
            finally
            {
                ActiveChanSemaphore.Set();
            }
        }

        private ChannelData GetChannelByCallerNumbers(string callerIdNum, string connectedLineNum)
        {
            for (int i = 0; i < ActiveChannels.Count; i++)
            {
                ChannelData channel = ActiveChannels[i];
                if (channel.CallerIDNum != callerIdNum || channel.ConnectedLineNum != connectedLineNum)
                {
                    continue;
                }

                return channel;
            }

            return null;
        }

        private ChannelData FindChannel(string callerNum, string connectedNum)
        {
            try
            {
                ActiveChanSemaphore.WaitOne();
                return GetChannelByCallerNumbers(callerNum, connectedNum);
            }
            catch (IndexOutOfRangeException)
            {
                return FindChannel(callerNum, connectedNum);
            }
            finally
            {
                ActiveChanSemaphore.Set();
            }
        }
        /// <summary>
        /// Функция поиска канала к которому подключен наш номер
        /// </summary>
        /// <param name="CallerIDNum"></param>
        /// <returns></returns>
        private ChannelData FindConnectedChannel(string CallerIDNum)
        {
            try
            {
                ActiveChanSemaphore.WaitOne();
                return GetChannelByCallerNumbers(UserData.Number, CallerIDNum);
            }
            catch (IndexOutOfRangeException)
            {
                return FindConnectedChannel(CallerIDNum);
            }
            finally
            {
                ActiveChanSemaphore.Set();
            }
        }
        /// <summary>
        /// Находит полную информацию о канале по его ID
        /// </summary>
        /// <param name="ChannelID">ID канала</param>
        /// <returns>полная информаци о канале, если он существует</returns>
        private ChannelData FindChInfoByChID(string ChannelID)
        {
            try
            {
                ActiveChanSemaphore.WaitOne();
                for (int i = 0; i < ActiveChannels.Count; i++)
                {
                    if (ActiveChannels[i].ChannelID == ChannelID)
                    {
                        return ActiveChannels[i];
                    }
                }

                return null;
            }
            catch (IndexOutOfRangeException)
            {
                return FindChInfoByChID(ChannelID);
            }
            finally
            {
                ActiveChanSemaphore.Set();
            }
        }
        /// <summary>
        /// Находит все каналы, на которые звонит наш абонент
        /// </summary>
        /// <param name="callerId">номер абонента</param>
        /// <returns>список каналов</returns>
        private List<ChannelData> FindChannelsWithCallerID(string callerId)
        {
            try
            {
                ActiveChanSemaphore.WaitOne();
                List<ChannelData> channels = new List<ChannelData>();
                for (int i = 0; i < ActiveChannels.Count; i++)
                {
                    if (ActiveChannels[i].CallerIDNum == callerId)
                    {
                        channels.Add(ActiveChannels[i]);
                    }
                }

                return channels;
            }
            catch (IndexOutOfRangeException)
            {
                return FindChannelsWithCallerID(callerId);
            }
            finally
            {
                ActiveChanSemaphore.Set();
            }
        }
        /// <summary>
        /// Функция поиска информации о активном звонке по ID канала
        /// </summary>
        /// <param name="channel">Канал</param>
        /// <returns>Информацию о зовнке</returns>
        private DialData FindDialbyChannel(ChannelData channel)
        {
            try
            {
                Calls.WaitOne();
                for (int i = 0; i < ActiveCalls.Count; i++)
                {
                    var channelId = channel.ChannelID;
                    var isDestinationOrOrginateChannel = channelId == ActiveCalls[i].ChannelID || channelId == ActiveCalls[i].DestinationID;
                    if (isDestinationOrOrginateChannel)
                    {
                        return ActiveCalls[i];
                    }
                }
                return null;
            }
            catch (IndexOutOfRangeException)
            {
                return FindDialbyChannel(channel);
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
        private DialData FindDialbyChannel(string channelId)
        {
            try
            {
                Calls.WaitOne();
                for (int i = 0; i < ActiveCalls.Count; i++)
                {
                    var isDestinationOrOrginateChannel = channelId == ActiveCalls[i].ChannelID || channelId == ActiveCalls[i].DestinationID;
                    if (isDestinationOrOrginateChannel && ActiveCalls[i].currentstatus == DialData.Dialstat.DialBegin && !string.IsNullOrEmpty(channelId))
                    {
                        return ActiveCalls[i];
                    }
                }
                return null;
            }
            catch (IndexOutOfRangeException)
            {
                return FindDialbyChannel(channelId);
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
                    var channelId = call.ChannelID;
                    if (dial.ChannelID == channelId)
                    {
                        call.DestinationID = dial.DestinationID;
                        return;
                    }
                    else if (dial.DestinationID == channelId)
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
            var RemovedChannel = RemoveActiveChannel(Hangup.Channel);
            if (RemovedChannel == null)
            {
                return;
            }

            var dial = FindDialbyChannel(RemovedChannel);
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
            var PrevChanState = DefaultChannelInfoValues(CurrChanState);
            if ((AmiVersion == AmiVersions.v11 || AmiVersion == AmiVersions.v13) && PrevChanState != null)
            {
                //Новый диал бегин, который создается как только мы начали дозвон.
                if ((PrevChanState.State == ChannelState.ChannelUnavailble) && CurrChanState.ChannelState == "5")
                {
                    //Ищем информацию по каналу, если он существует проверяем не равны ли подключенные номера
                    var chan = FindChInfoByChID(CurrChanState.Channel);
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
                    var chan = FindChInfoByChID(CurrChanState.Channel);
                    if (chan != null)
                        new DialBeginEvent(chan, true);
                    Thread.Sleep(500);
                    var dial = FindDialbyChannel(PrevChanState);
                    if (dial != null)
                    {
                        //var dial = UpdateDialCallerID(dail);
                        new ConversationBeginEvent(dial);
                    }
                }

                ///Так как в ами версии 1.3 события приходят с другой периодичностью, то проверка состояния канала единственный выход для того, чтобы сгенеоировать событие начала разговора.
                if ((PrevChanState.State == ChannelState.RemoteRinging /*|| PrevChanState.State == ChannelState.Ringing*/) && CurrChanState.ChannelState == "6")
                {
                    var dial = FindDialbyChannel(PrevChanState);
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
            var NewChannel = (NewChannelEvent)e.Event;
            ActiveChanSemaphore.WaitOne();
            for (int i = 0; i < ActiveChannels.Count; i++)
            {
                if (ActiveChannels[i].ChannelID == NewChannel.Channel.ChannelID)
                {
                    ActiveChanSemaphore.Set();
                    return;
                }
            }
            ActiveChannels.Add(NewChannel.Channel);
            ActiveChanSemaphore.Set();
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
                            DefaultChannelInfoValues(e.dialinfo);

                            if (e.dialinfo.DestinationID != null)
                            {
                                EventManager.RaiseConversationBeginEvent(e);
                            }
                        }
                        if (AmiVersion == AmiVersions.v11 || AmiVersion == AmiVersions.v13)
                        {
                            if (e.dialinfo.DestinationID != null)
                            {
                                var dial = FindDialbyChannel(e.dialinfo.DestinationID);
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
                                var dial = FindDialbyChannel(e.dialinfo.DestinationID);
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
        public string SendLogPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\B-Cti\\log\\";
        public string RecvLogPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\B-Cti\\log\\";
        public bool bLogEnabled = true;
        public string SIPADDHEADER { get; set; }
        public AmiVersions AmiVersion { get; private set; }
        public string CallerID { get; set; }
        private AmiLogger log = new AmiLogger();
        /// <summary>
        /// Информация о текущих активных каналах
        /// </summary>
        private List<ChannelData> ActiveChannels = new List<ChannelData>();
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
        /// Класс для подключения к серверу
        /// </summary>
        private SocketConnection ManagerConnect;
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
        /// <summary>
        /// Итератор для ActionID
        /// </summary>
        private int actionIdcount = 0;
        /// <summary>
        /// Указатель на поток с пингом
        /// </summary>
        Thread Parser;
        Thread ping;
        Thread reciever;
        BackgroundWorker pinger;
        BackgroundWorker parser;
        BackgroundWorker Reciever;
        /// <summary>
        /// Переменная необходимая для грамотного выхода из библиотеки
        /// В случае если некоторые потоки, еще работают, а мы завершили рабту в библиотекой помешает вылету имключений
        /// </summary>
        public bool IsAlive = false;
        public bool IsConnected = false;
        /// <summary>
        /// Семафор для пинга
        /// </summary>
        private AutoResetEvent SendPing = new AutoResetEvent(false);
        #endregion

        #region Конструкторы
        /// <summary>
        /// Конструктор по умолчанию
        /// Инициализирует сокет
        /// </summary>
        public AMIManager()
        {
            ManagerConnect = new SocketConnection();
            CreateLogFoldersIfNeeded();
        }

        private void CreateLogFoldersIfNeeded()
        {
            if (!bLogEnabled)
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
            ManagerConnect = new SocketConnection();
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
            ManagerConnect = new SocketConnection();
            Connect(login, pwd, ip, port);
            CreateLogFoldersIfNeeded();
        }
        /// <summary>
        /// Конструктор для новых сокетов (Не используется)
        /// </summary>
        /// <param name="socket"></param>
        public AMIManager(TcpClient socket)
        {
            ManagerConnect = new SocketConnection(socket);
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
            actionIdcount++;
            return Helper.MachineID + actionIdcount.ToString();
        }

        /// <summary>
        /// Функция отправки запроса действия на сервер астериск
        /// </summary>
        /// <param name="action">Класс действия</param>
        /// <returns>Успена ли отправка</returns>
        private void SendToAsterisk(ActionManager action)
        {
            var message = Helper.BuildAction(action, null, false);
            if (bLogEnabled)
                log.WriteLog(message);
            byte[] sendBuffer = Encoding.ASCII.GetBytes(message);

            if (ManagerConnect == null || !ManagerConnect.IsSockConnected())
            {
                if (!IsAlive)
                {
                    return;
                }

                if (Disconnecting != null)
                {
                    Disconnecting(this, null);
                }

                log.WriteLog("##Disconnectiong null or socknotconnected 1059");
                Abort();

                return;
            }

            try
            {
                ManagerConnect.Socket.Send(sendBuffer);
            }
            catch (SocketException e)
            {
                //Console.WriteLine(e.Message);
                if (e.SocketErrorCode == SocketError.TimedOut && IsConnected)
                {
                    if (Disconnecting != null)
                    {
                        Disconnecting(this, null);
                    }
                    log.WriteLog("##Disconnectiong socketexceps timeout 1033");
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

                if (Disconnecting != null)
                {
                    Disconnecting(this, null);
                }

                log.WriteLog("##Disconnectiong disposed 1047");
                Abort();
                return;
            }
        }
        private void PingWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            while (worker.CancellationPending != true && ManagerConnect != null && ManagerConnect.IsSockConnected())
            {
                try
                {
                    ///Каждые 6 секунд, если нет ответа от сервера отправлять пингe

                    if (SendPing.WaitOne(2000))
                    {
                        continue;
                    }

                    if (worker.CancellationPending == true)
                    {
                        e.Cancel = true;

                        if (e.Cancel == true)
                        {
                            return;
                        }
                    }
                    Ping();
                    Thread.Sleep(100);
                    SendPing.Reset();

                }
                catch (AmiTimeOutException)
                {
                    pinger.CancelAsync();
                    pinger.Dispose();
                }
                catch (AmiException)
                {
                    if (!ManagerConnect.IsSockConnected())
                    {
                        pinger.CancelAsync();
                        pinger.Dispose();
                    }
                }
                catch (NullReferenceException)
                {
                    if (ManagerConnect == null && IsAlive)
                        throw new AmiException("ManagerConnect не создан");
                }
            }
        }
        private void ParserWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            while (ManagerConnect != null && ManagerConnect.IsSockConnected())
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

            StartAsyncCancellationWorker(Reciever, Reciever_DoWork, "Поток приема сообщений уже запущен. Переинициализируйте библиотеку");
            StartAsyncCancellationWorker(pinger, PingWork, "Поток приема сообщений уже запущен. Переинициализируйте библиотеку");
            StartAsyncCancellationWorker(parser, ParserWork, "Поток приема сообщений уже запущен. Переинициализируйте библиотеку");
        }
        private void InstantiateWorkersOnce()
        {
            if (Reciever == null)
            {
                Reciever = new BackgroundWorker();
            }
            if (pinger == null)
            {
                pinger = new BackgroundWorker();
            }
            if (parser == null)
            {
                parser = new BackgroundWorker();
            }
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
            ping = new Thread(() =>
            {
                //Thread.CurrentThread.IsBackground = true;
                while (ManagerConnect.IsSockConnected())
                {
                    try
                    {
                        ///Каждые 6 секунд, если нет ответа от сервера отправлять пинг
                        if (!SendPing.WaitOne(6000))
                        {
                            Ping();
                            Thread.Sleep(100);
                            SendPing.Reset();
                        }

                    }
                    catch (AmiTimeOutException)
                    {
                        ping.Join();
                    }
                    catch (AmiException)
                    {
                        if (ManagerConnect.IsSockConnected())
                        {
                            continue;
                        }

                        ping.Join();
                    }
                }
            });
            ping.Start();
            //Как вариант записать здесь проверку на пинг, чтобы не создавать для нее новый поток
            Parser = new Thread(() =>
            {
                Thread.CurrentThread.IsBackground = true;
                while (ManagerConnect.IsSockConnected())
                {
                    AsterParser.ParseServerMessage();
                }

            });
            Parser.Start();
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

                    buffersize = ManagerConnect.Socket.Receive(recvBuffer);
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
                    if (bLogEnabled)
                    {
                        log.WriteLog(Response);

                    }
#endif
                    ///Кладем сообщение в общую память парсера
                    AsterParser.Response = Response;
                    //Разрешаем ему доступ к данным
                    AsterParser.startParse.Set();
                    SendPing.Set();
                    //Обнуляем строку
                    Response = string.Empty;
                }
                while (ManagerConnect != null || ManagerConnect.IsSockConnected());
            }
            catch (SocketException ex)
            {
                if (ex.SocketErrorCode == SocketError.TimedOut && ManagerConnect != null && ManagerConnect.IsSockConnected() && !ManagerConnect.IsSockConnected())
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
                    buffersize = ManagerConnect.Socket.Receive(recvBuffer);
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
                    SendPing.Set();
                    //Обнуляем строку
                    Response = string.Empty;
                }
                while (ManagerConnect != null || ManagerConnect.IsSockConnected());
            }
            catch (SocketException e)
            {
                if (e.SocketErrorCode != SocketError.TimedOut || ManagerConnect == null || !ManagerConnect.IsSockConnected())
                {
                    return;
                }

                SendPing.Set();
                Thread.Sleep(3000);

                if (ManagerConnect.IsSockConnected() || !IsConnected)
                {
                    return;
                }

                if (Disconnecting != null)
                {
                    Disconnecting(this, null);
                }

                log.WriteLog("##Disconnectiong socketexceps 1377");
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

                log.WriteLog("##Disconnectiong Objectdisposed 1395");
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
                log.WriteLog("##Disconnectiong nullreference 1410");
                Abort();
            }

        }
        /// <summary>
        /// Запуск потока с приемом сообщений
        /// </summary>
        /// <returns></returns>
        private void StartRecieve()
        {
            reciever = new Thread(() => RecieveFromAsterisk());
            reciever.Start();
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
            ActiveChannels.Clear();
            ActiveCalls.Clear();
            AmiVersion = AmiVersions.UNKNOWN;
            ServerUsers.Clear();
            UserData = null;
            UsersAmount = null;
            ActionIdMessages.Clear();
            ParkedCalls.Clear();
            ManagerConnect = null;
            actionIdcount = 0;
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
            if (ManagerConnect == null)
            {
                ManagerConnect = new SocketConnection();
            }

            try
            {
                ManagerConnect.Socket.Connect(ManagerConnect.getEndPoint(ip, port));
            }
            catch (SocketException e)
            {
                if (e.SocketErrorCode == SocketError.TimedOut)
                    throw new AmiTimeOutException("Сервер недоступен");
                return false;
            }
            //Создаем дейстиве логин
            LoginAction action = new LoginAction(login, pwd);
            //Создаем ActionId для запроса
            action.ActionID = CreateActionID();
            //Отправляем запрос
            SendToAsterisk(action);
            //Начинаем асинхронный прием сообщений
            StartBWThreads();

            if (LoginEvent.LoginComplete.WaitOne(5000))
            {
                if (ActionIdMessages.ContainsKey(action.ActionID))
                {
                    IsAlive = true;
                    var result = (LoginEvent)ActionIdMessages[action.ActionID];
                    ParseAndSetAmiVersion(result.Version);

                    ActionIdMessages.Remove(action.ActionID);
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

        private string CalculateMD5Hash(string input)
        {
            // step 1, calculate MD5 hash from input
            MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
            byte[] hash = md5.ComputeHash(inputBytes);
            // step 2, convert byte array to hex string
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("x2"));
            }
            return sb.ToString();
        }

        public bool ConnectMD5(string login, string pwd, string ip, int port)
        {

            ////Вариант со старыми сокетами
            if (ManagerConnect == null)
            {
                ManagerConnect = new SocketConnection();
            }

            try
            {
                ManagerConnect.Socket.Connect(ManagerConnect.getEndPoint(ip, port));
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
            ChallengeAction challenge = new ChallengeAction();
            challenge.ActionID = CreateActionID();
            SendToAsterisk(challenge);
            string key = string.Empty;
            //Начинаем асинхронный прием сообщений
            StartBWThreads();

            if (!ChallengeEvent.ChallengeComplete.WaitOne(5000))
            {
                return false;
            }
            else if (ActionIdMessages.ContainsKey(challenge.ActionID))
            {
                var result = (ChallengeEvent)ActionIdMessages[challenge.ActionID];
                key = CalculateMD5Hash(result.Challenge + pwd);
                ParseAndSetAmiVersion(result.Version);

                //AmiVersion = result.Version;
                ActionIdMessages.Remove(challenge.ActionID);
            }

            LoginAction action = new LoginAction();
            action._UserName = login;
            action._AuthType = "MD5";
            action._Key = key;

            //Создаем ActionId для запроса
            action.ActionID = CreateActionID();
            //Отправляем запрос
            SendToAsterisk(action);

            //if (reciever == null || reciever.IsAlive == false)
            //    StartRecieve();
            //else throw new AmiException("Поток приема сообщений уже запущен!!!!");
            if (LoginEvent.LoginComplete.WaitOne(5000))
            {
                if (ActionIdMessages.ContainsKey(action.ActionID))
                {
                    IsAlive = true;
                    var result = (LoginEvent)ActionIdMessages[action.ActionID];
                    ActionIdMessages.Remove(action.ActionID);
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
            if (ManagerConnect != null && ManagerConnect.Socket != null)
            {
                ManagerConnect.CloseSocket();
            }
        }

        private void DisposeWorkers()
        {
            if (Reciever == null || parser == null || pinger == null)
            {
                return;
            }

            pinger.Dispose();
            parser.Dispose();
            Reciever.Dispose();

            pinger = null;
            parser = null;
            Reciever = null;
        }

        private void StopWorkers()
        {
            if (Reciever != null && Reciever.IsBusy)
            {
                Reciever.CancelAsync();
            }

            if (parser != null && parser.IsBusy)
            {
                parser.CancelAsync();
                AsterParser.startParse.Set();
            }

            if (pinger != null && pinger.IsBusy)
            {
                pinger.CancelAsync();
                SendPing.Set();
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

            SippeersAction action = new SippeersAction();
            action.ActionID = CreateActionID();
            SendToAsterisk(action);
            if (PeerlistCompleteEvent.PeerlistComplete.WaitOne(25000))
            {
                if (ActionIdMessages.ContainsKey(action.ActionID))
                {
                    var message = (PeerlistCompleteEvent)ActionIdMessages[action.ActionID];
                    ActionIdMessages.Remove(action.ActionID);

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
            SIPShowPeerAction action = new SIPShowPeerAction(number);
            action.ActionID = CreateActionID();
            SendToAsterisk(action);

            ///Ожидание ответа в течении 5 секунд
            if (!SIPShowPeerEvent.SipShowPeerComplete.WaitOne(TimeSpan.FromMilliseconds(5000)))
            {
                return null;
            }

            ///Если в общей памяти содержится сообщение с нашим ключом, то получаем данные
            if (!ActionIdMessages.ContainsKey(action.ActionID))
            {
                return null;
            }

            var message = (SIPShowPeerEvent)ActionIdMessages[action.ActionID];
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

            ActionIdMessages.Remove(action.ActionID);

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
            CommandAction action = new CommandAction("Core Show Channels");
            action.ActionID = CreateActionID();
            SendToAsterisk(action);

            if (!CoreShowChannelsEvent.CoreShowChannelsComplete.WaitOne(5000))
            {
                return false;
            }

            foreach (var obj in ActiveChannels)
            {
                StatusAction status = new StatusAction(obj.ChannelID);
                status.ActionID = CreateActionID();
                SendToAsterisk(status);

                if (StatusEvent.StatusComplete.WaitOne(2000))
                {
                    if (ActionIdMessages.ContainsKey(status.ActionID))
                    {
                        ActionIdMessages.Remove(status.ActionID);
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
        public bool ASyncCall(string Number)
        {
            OriginateEvent.OriginateComplete.Reset();
            OriginateAction action = GetOriginateAction(Number, Number);

            if (OriginateEvent.OriginateComplete.WaitOne(5000))
            {
                if (ActionIdMessages.ContainsKey(action.ActionID))
                {
                    var result = (OriginateEvent)ActionIdMessages[action.ActionID];
                    ActionIdMessages.Remove(action.ActionID);
                    return result.IsCallSuccess;
                }
            }

            return false;
        }
        public bool Call(ClientsData client, bool SecondNumber)
        {
            return Call(SecondNumber ? client.SecondNumber : client.Number, client.Name);
        }

        public bool Call(string NumberToCall, string name)
        {
            if (IsUserStartedCall(UserData.Number))
            {
                return false;
            }

            OriginateEvent.OriginateComplete.Reset();
            OriginateAction action = GetOriginateAction(NumberToCall, name);

            SendToAsterisk(action);
            if (OriginateEvent.OriginateComplete.WaitOne(5000))
            {
                if (ActionIdMessages.ContainsKey(action.ActionID))
                {
                    var result = (OriginateEvent)ActionIdMessages[action.ActionID];
                    ActionIdMessages.Remove(action.ActionID);
                    return result.IsCallSuccess;
                }
            }

            return false;
        }

        private bool IsUserStartedCall(string num)
        {
            return ActiveChannels.Find(channel => channel.CallerIDNum == num && channel.ConnectedLineNum == num) != null;
        }

        private OriginateAction GetOriginateAction(string number, string name)
        {
            OriginateAction action = new OriginateAction(UserData, number, 1);

            var callerIdBuilder = new StringBuilder();
            callerIdBuilder.Append(string.IsNullOrEmpty(name) ? CallerID : Helper.ConvertToTranslit(name));
            callerIdBuilder.Append(" ");
            callerIdBuilder.Append(number);
            callerIdBuilder.Append(CallerID);
            callerIdBuilder.Append(" (B-CTI) <");
            callerIdBuilder.Append(UserData.Number);
            callerIdBuilder.Append(">");

            action.CallerId = callerIdBuilder.ToString();
            action.Async = "true";
            action.ActionID = CreateActionID();

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
            var channel = FindChInfoByChID(ChannelID);
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
            var channel = FindChannelsWithCallerID(AiringCallNumber);
            var channel2 = FindChannelsWithCallerID(UserData.Number);
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
            HangupAction hangup = new HangupAction(channelId);
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
            ChannelData channel = FindChInfoByChID(dial.CallerIDNum == UserData.Number ? dial.DestinationID : dial.ChannelID);

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
            if (channel != null)
            {

                //Работает на версии 1.3 и 2.8
                if (string.IsNullOrEmpty(channel.Context))
                {
                    var channel2 = FindChannel(channel.ConnectedLineNum);
                    if (channel2 != null)
                    {
                        InvokeRedirect(channel.ChannelID, channel2.Context, TransferToNumber);
                        return true;
                    }
                }
                else
                {
                    InvokeRedirect(channel.ChannelID, channel.Context, TransferToNumber);
                    return true;
                }

            }

            return false;
        }


        private void InvokeRedirect(string channeld, string context, string transferToNumber)
        {
            RedirectAction redirect = new RedirectAction(channeld, context, transferToNumber, 1);
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
                if (dial.CallerIDNum == UserData.Number)
                {
                    string _timeout = (Timeout * 1000).ToString();
                    ParkAction park = new ParkAction(dial.DestinationID, dial.ChannelID, _timeout);
                    SendToAsterisk(park);
                }
                else
                {
                    string _timeout = (Timeout * 1000).ToString();
                    ParkAction park = new ParkAction(dial.ChannelID, dial.DestinationID, _timeout);
                    SendToAsterisk(park);
                }
                return true;
            }
            else if (AmiVersion == AmiVersions.v25 || AmiVersion == AmiVersions.v28)
            {
                ParkAction park = new ParkAction(dial.DestinationID);
                //var channel2 = FindConnectedChannel(ParkNumber);
                park.ActionID = CreateActionID();
                park.AnnounceChannel = dial.ChannelID;
                //park.ParkingLot = UserData.number;
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
                    ParkAction park = new ParkAction(channel1.ChannelID, channel2.ChannelID, _timeout);
                    SendToAsterisk(park);
                    return true;
                }
            }
            else if (AmiVersion == AmiVersions.v25 || AmiVersion == AmiVersions.v28)
            {
                ParkAction park = new ParkAction(channel1.ChannelID);
                var channel2 = FindConnectedChannel(ParkNumber);
                park.ActionID = "PARKOVKAWORKAU";
                park.AnnounceChannel = channel2.ChannelID;
                //park.ParkingLot = UserData.number;
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
            var userChannel = UserData.getchannel();
            return OriginateEventWithSipAddHeader(userChannel, "ChanSpy", userChannel + flag);
        }

        private bool OriginateEventWithSipAddHeader(string channel, string app, string data)
        {
            OriginateAction originate = new OriginateAction(channel, app, data);
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
            return OriginateEventWithSipAddHeader(UserData.getchannel(), "Playback", PathToPlayBackFile);
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
                OriginateEventWithSipAddHeader(UserData.getchannel(), "PickupChan", channel.ChannelID);
            }
        }
        /// <summary>
        /// Функция перезагрузки модуля на сервере астериск
        /// </summary>
        /// <param name="ReloadModule"></param>
        public void Reload(string ReloadModule)
        {
            ReloadAction reload = new ReloadAction(ReloadModule);
            SendToAsterisk(reload);
        }
        #endregion
    }
}
