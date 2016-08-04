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
        #region Функции для работы с массивами данных
        private AutoResetEvent ActiveChanSemaphore = new AutoResetEvent(true);
        private ChannelData UpdateChannelData(NewstateEvent ChannelInfo)
        {
            try
            {
                ActiveChanSemaphore.WaitOne();
                for (int j = 0; j < ActiveChannels.Count; j++)
                {
                    if (ActiveChannels[j].ChannelID.Equals(ChannelInfo.Channel))
                    {
                        ChannelData BeforeUpdate = (ChannelData)ActiveChannels[j].Clone();
                        if (!string.IsNullOrEmpty(ChannelInfo.ChannelState))
                            ActiveChannels[j].Status = ChannelInfo.ChannelState;
                        if (!string.IsNullOrEmpty(ChannelInfo.ChannelStateDesc))
                            ActiveChannels[j].ChannelStateDesc = ChannelInfo.ChannelStateDesc;

                        if (!string.IsNullOrEmpty(ChannelInfo.Context))
                            ActiveChannels[j].Context = ChannelInfo.Context;

                        if (string.IsNullOrEmpty(ActiveChannels[j].CallerIDNum) || ActiveChannels[j].CallerIDNum == "<unknown>")
                        {
                            if (ChannelInfo.CallerIDNum != "<unknown>" && !string.IsNullOrEmpty(ChannelInfo.CallerIDNum))
                                ActiveChannels[j].CallerIDNum = ChannelInfo.CallerIDNum;
                            if (ChannelInfo.CallerIDName != "<unknown>" && !string.IsNullOrEmpty(ChannelInfo.CallerIDName))
                                ActiveChannels[j].CallerIDName = ChannelInfo.CallerIDName;
                        }
                        if (string.IsNullOrEmpty(ActiveChannels[j].ConnectedLineNum) || ActiveChannels[j].ConnectedLineNum == "<unknown>")
                        {
                            if (ChannelInfo.ConnectedLineNum != "<unknown>" && !string.IsNullOrEmpty(ChannelInfo.ConnectedLineNum))
                                ActiveChannels[j].ConnectedLineNum = ChannelInfo.ConnectedLineNum;
                            if (ChannelInfo.ConnectedLineName != "<unknown>" && !string.IsNullOrEmpty(ChannelInfo.ConnectedLineName))
                                ActiveChannels[j].ConnectedLineName = ChannelInfo.ConnectedLineName;
                        }
                        ActiveChanSemaphore.Set();
                        return BeforeUpdate;
                    }
                }
                ActiveChanSemaphore.Set();
                return null;
            }
            catch (IndexOutOfRangeException)
            {
                ActiveChanSemaphore.Set();
                return UpdateChannelData(ChannelInfo);
            }
        }
        private void UpdateChannelData(DialData dial)
        {
            try
            {
                ActiveChanSemaphore.WaitOne();
                for (int j = 0; j < ActiveChannels.Count; j++)
                {
                    if (ActiveChannels[j].ChannelID.Equals(dial.ChannelID))
                    {

                        if (string.IsNullOrEmpty(ActiveChannels[j].CallerIDNum) || ActiveChannels[j].CallerIDNum == "<unknown>")
                        {
                            if (dial.CallerIDNum != "<unknown>")
                                ActiveChannels[j].CallerIDNum = dial.CallerIDNum;
                            if (dial.CallerIDName != "<unknown>")
                                ActiveChannels[j].CallerIDName = dial.CallerIDName;
                        }
                        if (string.IsNullOrEmpty(ActiveChannels[j].ConnectedLineNum) || ActiveChannels[j].ConnectedLineNum == "<unknown>")
                        {
                            if (dial.ConnectedLineNum != "<unknown>")
                                ActiveChannels[j].ConnectedLineNum = dial.ConnectedLineNum;
                            if (dial.ConnectedLineName != "<unknown>")
                                ActiveChannels[j].ConnectedLineName = dial.ConnectedLineName;
                        }
                        ActiveChanSemaphore.Set();
                        return;
                    }
                }
                ActiveChanSemaphore.Set();
                return;
            }
            catch (IndexOutOfRangeException)
            {
                ActiveChanSemaphore.Set();
                UpdateChannelData(dial);
            }
        }
        private ChannelData RemoveActiveChannel(string ChannelID)
        {
            try
            {
                ActiveChanSemaphore.WaitOne();
                for (int j = 0; j < ActiveChannels.Count; j++)
                {
                    if (ActiveChannels[j].ChannelID.Equals(ChannelID))
                    {
                        var removedchannel = ActiveChannels[j];
                        ActiveChannels.RemoveAt(j);
                        ActiveChanSemaphore.Set();
                        return removedchannel;
                    }
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
                    if (Channel.Equals(ActiveChannels[i]))
                    {
                        ActiveChannels[i].ConnectedLineNum = Destination.CallerIDNum;
                        ////Console.WriteLine(ActiveChannels[i].Channel + " " + ActiveChannels[i].ConnectedLineNum + " " + Destination.CallerIDNum + " " + Destination.ConnectedLineNum);
                        ActiveChanSemaphore.Set();
                        return;
                    }
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

        private DialData UpdateDialCallerID(DialData dial)
        {
            ChannelData Chan = FindChInfoByChID(dial.ChannelID);
            if (Chan != null)
            {
                ///Если номера совпадают подтягиваем второй канла
                if (Chan.CallerIDNum == Chan.ConnectedLineNum)
                {
                    var dest = FindChInfoByChID(dial.DestinationID);
                    if (dest != null)
                    {
                        UpdateChannelCallerID(Chan, dest);
                    }
                }
                ///Если номер из канала не неизвестен и не пуст, то применяем его для нашего звонка
                if (Chan.CallerIDNum != "<unknown>" && !string.IsNullOrEmpty(Chan.CallerIDNum))
                {
                    dial.CallerIDNum = Chan.CallerIDNum;
                }
                ///Если номер из канала не неизвестен и не пуст, то применяем его для нашего звонка
                if (Chan.ConnectedLineNum != "<unknown>" && !string.IsNullOrEmpty(Chan.ConnectedLineNum))
                {
                    dial.ConnectedLineNum = Chan.ConnectedLineNum;
                }
                ///Теперь по крайней мере 1 из номеров точно известен, осталось разобраться со вторым
                ///Для этого подтягиваем номер из айдишника канала или из dialstring

                if (dial.CallerIDNum == "<unknown>" || string.IsNullOrEmpty(dial.CallerIDNum))
                {
                    dial.CallerIDNum = Helper.GetNumberFromChannel(dial.ChannelID);
                    if (dial.CallerIDNum == "rostelecom")
                    {
                        dial.CallerIDNum = dial.Dialstring.Replace("rostelecom/", "");
                    }
                }


                ///Если номер к которому подключен абонент неизвестен или пуст, то ищем канал к подключения и получаем колерайди из него
                if (dial.ConnectedLineNum == "<unknown>" || string.IsNullOrEmpty(dial.ConnectedLineNum))
                {
                    var dest = FindChInfoByChID(dial.DestinationID);
                    if (dest != null)
                    {
                        if (dest.CallerIDNum != "<unknown>" && !string.IsNullOrEmpty(dest.CallerIDNum))
                        {
                            dial.ConnectedLineNum = dest.CallerIDNum;
                        }
                    }
                }
                ///Если он все еще неизвестен или пуст прибегаем к последнему варианту, получаем колер айди из айди канала
                if (dial.ConnectedLineNum == "<unknown>" || string.IsNullOrEmpty(dial.ConnectedLineNum))
                {
                    dial.ConnectedLineNum = Helper.GetNumberFromChannel(dial.DestinationID);
                    if (dial.ConnectedLineNum == "rostelecom")
                    {
                        dial.ConnectedLineNum = dial.Dialstring.Replace("rostelecom/", "");
                    }
                }
                //if (dial.CallerIDNum == dial.ConnectedLineNum)
                //{
                //    if (dial.DestinationID != null)
                //    {
                //        dial.ConnectedLineNum = Helper.GetNumberFromChannel(dial.DestinationID);
                //        if (dial.ConnectedLineNum == "rostelecom")
                //        {
                //            dial.ConnectedLineNum = dial.Dialstring.Replace("rostelecom/", "");
                //        }
                //    }
                //    if (dial.CallerIDNum == dial.ConnectedLineNum)
                //    {
                //        dial.CallerIDNum = Helper.GetNumberFromChannel(dial.ChannelID);
                //        if (dial.CallerIDNum == "rostelecom")
                //        {
                //            dial.CallerIDNum = dial.Dialstring.Replace("rostelecom/", "");
                //        }
                //    }
                //}
                //if (dial.CallerIDNum.ToLower().Contains("mgb_"))
                //{
                //    dial.CallerIDNum = dial.CallerIDNum.ToLower().Replace("mgb_", "");
                //}
                UpdateActiveCalls(dial);

                //if (string.IsNullOrEmpty(dial.ConnectedLineNum) || dial.ConnectedLineNum == "<unknown>")
                //    if (dial.ConnectedLineNum != "<unknown>")
                //        dial.ConnectedLineNum = channel.ConnectedLineNum;

                return dial;
            }
            else
            {
                ChannelData Dest = FindChInfoByChID(dial.DestinationID);
                if (Dest != null)
                {
                    if (Dest.CallerIDNum == Dest.ConnectedLineNum)
                    {
                        var dest = FindChInfoByChID(dial.DestinationID);
                        if (dest != null)
                        {
                            UpdateChannelCallerID(Dest, dest);
                        }
                    }
                    ///Если номер из канала не неизвестен и не пуст, то применяем его для нашего звонка
                    if (Dest.CallerIDNum != "<unknown>" && !string.IsNullOrEmpty(Dest.CallerIDNum))
                    {
                        dial.CallerIDNum = Dest.CallerIDNum;
                    }
                    ///Если номер из канала не неизвестен и не пуст, то применяем его для нашего звонка
                    if (Dest.ConnectedLineNum != "<unknown>" && !string.IsNullOrEmpty(Dest.ConnectedLineNum))
                    {
                        dial.ConnectedLineNum = Dest.ConnectedLineNum;
                    }
                    ///Теперь по крайней мере 1 из номеров точно известен, осталось разобраться со вторым
                    ///Для этого подтягиваем номер из айдишника канала или из dialstring

                    if (dial.CallerIDNum == "<unknown>" || string.IsNullOrEmpty(dial.CallerIDNum))
                    {
                        dial.CallerIDNum = Helper.GetNumberFromChannel(dial.ChannelID);
                        if (dial.CallerIDNum == "rostelecom")
                        {
                            dial.CallerIDNum = dial.Dialstring.Replace("rostelecom/", "");
                        }
                    }


                    ///Если номер к которому подключен абонент неизвестен или пуст, то ищем канал к подключения и получаем колерайди из него
                    if (dial.ConnectedLineNum == "<unknown>" || string.IsNullOrEmpty(dial.ConnectedLineNum))
                    {
                        var dest = FindChInfoByChID(dial.DestinationID);
                        if (dest != null)
                        {
                            if (dest.CallerIDNum != "<unknown>" && !string.IsNullOrEmpty(dest.CallerIDNum))
                            {
                                dial.ConnectedLineNum = dest.CallerIDNum;
                            }
                        }
                    }
                    ///Если он все еще неизвестен или пуст прибегаем к последнему варианту, получаем колер айди из айди канала
                    if (dial.ConnectedLineNum == "<unknown>" || string.IsNullOrEmpty(dial.ConnectedLineNum))
                    {
                        dial.ConnectedLineNum = Helper.GetNumberFromChannel(dial.DestinationID);
                        if (dial.ConnectedLineNum == "rostelecom")
                        {
                            dial.ConnectedLineNum = dial.Dialstring.Replace("rostelecom/", "");
                        }
                    }
                    UpdateActiveCalls(dial);
                    return dial;
                }
                return null;
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
                    if (ActiveCalls[i].ChannelID.Equals(dial.ChannelID))
                    {
                        if (string.IsNullOrEmpty(dial.CallerIDNum))
                            dial.CallerIDNum = ActiveCalls[i].CallerIDNum;
                        if (string.IsNullOrEmpty(dial.CallerIDName))
                            dial.CallerIDName = ActiveCalls[i].CallerIDName;
                        if (string.IsNullOrEmpty(dial.ConnectedLineNum))
                            dial.ConnectedLineNum = ActiveCalls[i].ConnectedLineNum;
                        if (string.IsNullOrEmpty(dial.ConnectedLineName))
                            dial.ConnectedLineName = ActiveCalls[i].ConnectedLineName;
                        ActiveCalls.RemoveAt(i);
                        Calls.Set();
                        return dial;
                    }
                    else if (dial.Uniqueid != null)
                    {
                        if (ActiveCalls[i].Uniqueid != null)
                            if (ActiveCalls[i].Uniqueid.Equals(dial.Uniqueid))
                            {
                                if (string.IsNullOrEmpty(dial.CallerIDNum))
                                    dial.CallerIDNum = ActiveCalls[i].CallerIDNum;
                                if (string.IsNullOrEmpty(dial.CallerIDName))
                                    dial.CallerIDName = ActiveCalls[i].CallerIDName;
                                if (string.IsNullOrEmpty(dial.ConnectedLineNum))
                                    dial.ConnectedLineNum = ActiveCalls[i].ConnectedLineNum;
                                if (string.IsNullOrEmpty(dial.ConnectedLineName))
                                    dial.ConnectedLineName = ActiveCalls[i].ConnectedLineName;
                                ActiveCalls.RemoveAt(i);
                                Calls.Set();
                                return dial;
                            }
                        if (ActiveCalls[i].Uniqueid2 != null)
                            if (dial.Uniqueid2 != null)
                                if (ActiveCalls[i].Uniqueid.Equals(dial.Uniqueid2))
                                {
                                    if (string.IsNullOrEmpty(dial.CallerIDNum))
                                        dial.CallerIDNum = ActiveCalls[i].CallerIDNum;
                                    if (string.IsNullOrEmpty(dial.CallerIDName))
                                        dial.CallerIDName = ActiveCalls[i].CallerIDName;
                                    if (string.IsNullOrEmpty(dial.ConnectedLineNum))
                                        dial.ConnectedLineNum = ActiveCalls[i].ConnectedLineNum;
                                    if (string.IsNullOrEmpty(dial.ConnectedLineName))
                                        dial.ConnectedLineName = ActiveCalls[i].ConnectedLineName;
                                    ActiveCalls.RemoveAt(i);
                                    Calls.Set();
                                    return dial;
                                }

                    }
                }
                Calls.Set();
                return dial;
            }
            catch (IndexOutOfRangeException)
            {
                Calls.Set();
                return RemoveActiveCall(dial);
            }
        }
        /// <summary>
        /// Функция поиска канала по номеру
        /// </summary>
        /// <param name="ConnectedLineNum">Номер звонящего</param>
        /// <returns>Возвращает канал или нулл если канала с таким номером нет</returns>
        private ChannelData FindChannel(string ConnectedLineNum)
        {
            try
            {
                ActiveChanSemaphore.WaitOne();
                for (int i = 0; i < ActiveChannels.Count; i++)
                {
                    if (ActiveChannels[i].CallerIDNum == ConnectedLineNum)
                    {
                        if (ActiveChannels[i].ConnectedLineNum == UserData.Number)
                        {
                            ActiveChanSemaphore.Set();
                            return ActiveChannels[i];
                        }
                    }
                }
                ActiveChanSemaphore.Set();
                return FindConnectedChannel(ConnectedLineNum);
            }
            catch (IndexOutOfRangeException)
            {
                ActiveChanSemaphore.Set();
                return FindChannel(ConnectedLineNum);
            }
        }
        private ChannelData FindChannel(string CallerNum, string ConnectedNum)
        {
            try
            {
                ActiveChanSemaphore.WaitOne();
                for (int i = 0; i < ActiveChannels.Count; i++)
                {
                    if (ActiveChannels[i].CallerIDNum == CallerNum)
                    {
                        if (ActiveChannels[i].ConnectedLineNum == ConnectedNum)
                        {
                            ActiveChanSemaphore.Set();
                            return ActiveChannels[i];
                        }
                    }
                }
                ActiveChanSemaphore.Set();
                return null;
            }
            catch (IndexOutOfRangeException)
            {
                ActiveChanSemaphore.Set();
                return FindChannel(CallerNum, ConnectedNum);
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
                for (int i = 0; i < ActiveChannels.Count; i++)
                {
                    if (ActiveChannels[i].ConnectedLineNum == CallerIDNum)
                    {
                        if (ActiveChannels[i].CallerIDNum == UserData.Number)
                        {
                            ActiveChanSemaphore.Set();
                            return ActiveChannels[i];
                        }
                    }
                }
                ActiveChanSemaphore.Set();
                return null;
            }
            catch (IndexOutOfRangeException)
            {
                ActiveChanSemaphore.Set();
                return FindConnectedChannel(CallerIDNum);
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
                        ActiveChanSemaphore.Set();
                        return ActiveChannels[i];
                    }
                }
                ActiveChanSemaphore.Set();
                return null;
            }
            catch (IndexOutOfRangeException)
            {
                ActiveChanSemaphore.Set();
                return FindChInfoByChID(ChannelID);
            }
        }
        /// <summary>
        /// Находит все каналы, на которые звонит наш абонент
        /// </summary>
        /// <param name="ConnectedLineNum">номер абонента</param>
        /// <returns>список каналов</returns>
        private List<ChannelData> FindAllChannels(string ConnectedLineNum)
        {
            try
            {
                ActiveChanSemaphore.WaitOne();
                List<ChannelData> channels = new List<ChannelData>();
                for (int i = 0; i < ActiveChannels.Count; i++)
                {
                    if (ActiveChannels[i].CallerIDNum == ConnectedLineNum)
                    {
                        ActiveChanSemaphore.Set();
                        channels.Add(ActiveChannels[i]);
                    }
                }
                ActiveChanSemaphore.Set();
                return channels;
            }
            catch (IndexOutOfRangeException)
            {
                ActiveChanSemaphore.Set();
                return FindAllChannels(ConnectedLineNum);
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
                    if (channel.ChannelID == ActiveCalls[i].ChannelID || channel.ChannelID == ActiveCalls[i].DestinationID)
                    {
                        Calls.Set();
                        return ActiveCalls[i];
                    }
                }
                Calls.Set();
                return null;
            }
            catch (IndexOutOfRangeException)
            {
                Calls.Set();
                return FindDialbyChannel(channel);
            }
        }
        /// <summary>
        /// Функция поиска информации о активном звонке по ID канала
        /// </summary>
        /// <param name="channel">Канал</param>
        /// <returns>Информацию о зовнке</returns>
        private DialData FindDialbyChannel(string channel)
        {
            try
            {
                Calls.WaitOne();
                for (int i = 0; i < ActiveCalls.Count; i++)
                {
                    if (channel == ActiveCalls[i].ChannelID || channel == ActiveCalls[i].DestinationID && ActiveCalls[i].currentstatus == DialData.Dialstat.DialBegin && !string.IsNullOrEmpty(channel))
                    {
                        Calls.Set();
                        return ActiveCalls[i];
                    }
                }
                Calls.Set();
                return null;
            }
            catch (IndexOutOfRangeException)
            {
                Calls.Set();
                return FindDialbyChannel(channel);
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
                    if (dial.ChannelID == ActiveCalls[i].ChannelID)
                    {
                        ActiveCalls[i].DestinationID = dial.DestinationID;
                        Calls.Set();
                        return;
                    }
                    else if (dial.DestinationID == ActiveCalls[i].ChannelID)
                    {
                        ActiveCalls[i].ChannelID = dial.ChannelID;
                        ActiveCalls[i].DestinationID = dial.DestinationID;
                        Calls.Set();
                        return;
                    }
                }
                ActiveCalls.Add(dial);
                Calls.Set();
                return;
            }
            catch (IndexOutOfRangeException)
            {
                Calls.Set();
                UpdateActiveCalls(dial);
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
            if (RemovedChannel != null)
            {
                var dial = FindDialbyChannel(RemovedChannel);
                if (dial != null)
                {
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
            }
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
            var PrevChanState = UpdateChannelData(CurrChanState);
            if ((AmiVersion == AmiVersions.v11 || AmiVersion == AmiVersions.v13) && PrevChanState != null)
            {
                //Новый диал бегин, который создается как только мы начали дозвон.
                if ((PrevChanState.State == ChannelState.ChannelUnavailble) && CurrChanState.ChannelState == "5")
                {
                    //Ищем информацию по каналу, если он существует проверяем не равны ли подключенные номера
                    var chan = FindChInfoByChID(CurrChanState.Channel);
                    if (chan != null)
                        if (chan.CallerIDNum != chan.ConnectedLineNum)
                        {
                            //Отправляем запрос со статусом из которого мы узнаем к кому подключен канал
                            //StatusAction status = new StatusAction(chan.ChannelID);
                            //status.ActionID = CreateActionID();
                            //SendToAsterisk(status);
                            //if (StatusEvent.StatusComplete.WaitOne(1500))
                            //{
                            //    if (ActionIdMessages.ContainsKey(status.ActionID))
                            //    {
                            //        var chaninfo = (StatusEvent)ActionIdMessages[status.ActionID];
                            //        chan.Link = chaninfo.Link;
                            //        ActionIdMessages.Remove(status.ActionID);
                            //    }
                            //}
                            /*ВОЗВРАЩАЕТ УЖЕ ИЗВЕСТНУЮ ИНФОРМАЦИЮ LINKCHANNEL НЕ ПРИХОДИТ*/



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
#if EVENTCONSOLEDEBUG
            ////Console.WriteLine("Канал " + NewChannel.channel.Channel + " Добавлен");
            ////Console.WriteLine();
#endif
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

                        //ChannelData channel = FindChannel(e.dialinfo.CallerIDNum);
                        if (AmiVersion == AmiVersions.v25 || AmiVersion == AmiVersions.v28)
                            UpdateDialCallerID(e.dialinfo);
                        //if (dial.ChannelID != dial.DestinationID || dial.CallerIDNum != dial.ConnectedLineNum)

                        //e.dialinfo = dial;
                        if (AmiVersion == AmiVersions.v11 || AmiVersion == AmiVersions.v13)
                        {
                            AddActiveCall(e.dialinfo);
                            //Console.WriteLine(e.dialinfo.currentstatus.ToString() + e.dialinfo.CallerIDNum + e.dialinfo.ConnectedLineNum);
                            EventManager.RaiseDialBeginEvent(e);
                            return;
                        }
                        else
                            ActiveCalls.Add(e.dialinfo);
                        //Console.WriteLine(e.dialinfo.currentstatus.ToString() + e.dialinfo.CallerIDNum + e.dialinfo.ConnectedLineNum);
                        EventManager.RaiseDialBeginEvent(e);

                        break;
                    }

                //Начало разговора
                case DialData.Dialstat.ConversationBegin:
                    {

                        if (AmiVersion == AmiVersions.v25 || AmiVersion == AmiVersions.v28)
                        {
                            UpdateDialCallerID(e.dialinfo);
                            //e.dialinfo = d;
                            UpdateChannelData(e.dialinfo);

                            if (e.dialinfo.DestinationID != null)
                            {
                                EventManager.RaiseConversationBeginEvent(e);
                                //Console.WriteLine(e.dialinfo.currentstatus.ToString() + e.dialinfo.CallerIDNum + e.dialinfo.ConnectedLineNum);
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
                                //Console.WriteLine(e.dialinfo.currentstatus.ToString() + e.dialinfo.CallerIDNum + e.dialinfo.ConnectedLineNum);
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
                            //if (e.dialinfo.ChannelID == "Local/103@base-8a54;1")
                            //{
                            //    Console.WriteLine("RAISED Local / 103@base - 8a54; 1");
                            //}
                            EventManager.RaiseConversationEndEvent(e);
                            //Console.WriteLine(e.dialinfo.currentstatus.ToString() + e.dialinfo.CallerIDNum + e.dialinfo.ConnectedLineNum + e.dialinfo.ChannelID);
                        }
                        var DialInfo = RemoveActiveCall(e.dialinfo);
                        if (AmiVersion == AmiVersions.v25 || AmiVersion == AmiVersions.v28)
                        {

                            {
                                if (DialInfo != null)
                                {
                                    e.dialinfo = DialInfo;
                                    if (!string.IsNullOrEmpty(e.dialinfo.CallerIDNum))
                                    {
                                        //Console.WriteLine(e.dialinfo.currentstatus.ToString() + e.dialinfo.CallerIDNum + e.dialinfo.ConnectedLineNum);
                                        EventManager.RaiseConversationEndEvent(e);
                                    }
                                }
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
            if (bLogEnabled)
            {
                if (!Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\B-Cti\\"))
                    Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\B-Cti\\");
                if (!Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\B-Cti\\LOG\\"))
                    Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\B-Cti\\LOG\\");
            }
        }
        /// <summary>
        /// Конструктор инициализирующий сокет и клиентские данные
        /// </summary>
        /// <param name="client"></param>
        public AMIManager(ClientsData client)
        {
            UserData = client;
            ManagerConnect = new SocketConnection();
            if (bLogEnabled)
            {
                if (!Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\B-Cti\\"))
                    Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\B-Cti\\");
                if (!Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\B-Cti\\LOG\\"))
                    Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\B-Cti\\LOG\\");
            }
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
            if (bLogEnabled)
            {
                if (!Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\B-Cti\\"))
                    Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\B-Cti\\");
                if (!Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\B-Cti\\LOG\\"))
                    Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\B-Cti\\LOG\\");
            }
        }
        /// <summary>
        /// Конструктор для новых сокетов (Не используется)
        /// </summary>
        /// <param name="socket"></param>
        public AMIManager(TcpClient socket)
        {
            ManagerConnect = new SocketConnection(socket);
            if (bLogEnabled)
            {
                if (!Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\B-Cti\\"))
                    Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\B-Cti\\");
                if (!Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\B-Cti\\LOG\\"))
                    Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\B-Cti\\LOG\\");
            }
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
        private string CreateInternalActionID()
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
            if (ManagerConnect != null && ManagerConnect.IsSockConnected())
            {
                try
                {
                    ManagerConnect.Socket.Send(sendBuffer);
                }
                catch (SocketException e)
                {
                    //Console.WriteLine(e.Message);
                    if (e.SocketErrorCode == SocketError.TimedOut)
                    {
                        if (IsConnected)
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
                }
                catch (ObjectDisposedException e)
                {
                    //Console.WriteLine(e.Message);
                    if (IsConnected)
                    {
                        if (Disconnecting != null)
                        {
                            Disconnecting(this, null);
                        }
                        log.WriteLog("##Disconnectiong disposed 1047");
                        Abort();
                        return;
                    }
                }
            }
            else
            {
                if (IsAlive)
                {
                    if (Disconnecting != null)
                        Disconnecting(this, null);
                    log.WriteLog("##Disconnectiong null or socknotconnected 1059");
                    Abort();
                }
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

                    if (!SendPing.WaitOne(2000))
                    {
                        if (worker.CancellationPending == true)
                        {
                            e.Cancel = true;
                            if (e.Cancel == true)
                                return;
                        }
                        Ping();
                        Thread.Sleep(100);
                        SendPing.Reset();
                    }

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
            if (Reciever == null)
                Reciever = new BackgroundWorker();
            if (pinger == null)
                pinger = new BackgroundWorker();
            if (parser == null)
                parser = new BackgroundWorker();
            if (Reciever.IsBusy != true)
            {
                Reciever.DoWork += Reciever_DoWork;
                Reciever.WorkerSupportsCancellation = true;
                Reciever.RunWorkerAsync();
            }
            else
            {
                throw new AmiException("Поток приема сообщений уже запущен. Переинициализируйте библиотеку");
            }
            if (pinger.IsBusy != true)
            {
                pinger.DoWork += PingWork;
                pinger.WorkerSupportsCancellation = true;
                pinger.RunWorkerAsync();
            }
            else
            {
                throw new AmiException("Поток пинга уже запущен. Переинициализируйте библиотеку");
            }
            if (parser.IsBusy != true)
            {
                parser.DoWork += ParserWork;
                parser.WorkerSupportsCancellation = true;
                parser.RunWorkerAsync();
            }
            else
            {
                throw new AmiException("Поток парсер уже запущен. Переинициализируйте библиотеку");
            }
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
                        if (!ManagerConnect.IsSockConnected())
                        {
                            ping.Join();
                        }
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
                    if (Response.EndsWith(Helper.LINE_SEPARATOR + Helper.LINE_SEPARATOR))
                    {
                        if (worker.CancellationPending)
                        {
                            e.Cancel = true;
                            return;
                        }
#if LOG
                        if (bLogEnabled)
                        {
                            log.WriteLog(Response);
                            //DateTime date = DateTime.Now;
                            //System.IO.StreamWriter file = new System.IO.StreamWriter(RecvLogPath + "amilog" + date.ToShortDateString() + ".log", true);
                            //try
                            //{
                            //    file.WriteLine(date.ToString(), file.NewLine);
                            //    file.WriteLine(Response);
                            //    file.Close();
                            //}
                            //finally
                            //{
                            //    if (file != null)
                            //        file.Dispose();
                            //}
                        }
#endif
#if CONSOLEDEBUG
                        ////ConsoleDebug
                        //Console.WriteLine(Response);
#endif
                        ///Кладем сообщение в общую память парсера
                        AsterParser.Response = Response;
                        //Разрешаем ему доступ к данным
                        AsterParser.startParse.Set();
                        SendPing.Set();
                        //Обнуляем строку
                        Response = string.Empty;
                    }
                }
                while (ManagerConnect != null || ManagerConnect.IsSockConnected());
            }
            catch (SocketException ex)
            {
                if (ex.SocketErrorCode == SocketError.TimedOut)
                    if (ManagerConnect != null && ManagerConnect.IsSockConnected())
                    {
                        //SendPing.Set();
                        //Thread.Sleep(3000);
                        if (!ManagerConnect.IsSockConnected())
                        {
                            throw new AmiTimeOutException("Слишком долгое время ожидания ответа от сервера");
                        }
                    }

                if (IsAlive)
                    //Console.WriteLine(ex.Message);
                    return;
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
            //var watch = Stopwatch.StartNew();
            SendToAsterisk(action);
            //asterInfo = AsteriskInfo(action, "Response: Success");
            //watch.Stop();
            //var elapsedMs = watch.ElapsedMilliseconds;
            //return elapsedMs - 10;
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
                    if (Response.EndsWith(Helper.LINE_SEPARATOR + Helper.LINE_SEPARATOR))
                    {
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
                                file.Dispose();
                        }
#endif
#if CONSOLEDEBUG
                        ////ConsoleDebug
                        //Console.WriteLine(Response);
#endif
                        ///Кладем сообщение в общую память парсера
                        AsterParser.Response = Response;
                        //Разрешаем ему доступ к данным
                        AsterParser.startParse.Set();
                        SendPing.Set();
                        //Обнуляем строку
                        Response = string.Empty;
                    }
                }
                while (ManagerConnect != null || ManagerConnect.IsSockConnected());
            }
            catch (SocketException e)
            {
                if (e.SocketErrorCode == SocketError.TimedOut)
                    if (ManagerConnect != null && ManagerConnect.IsSockConnected())
                    {
                        SendPing.Set();
                        Thread.Sleep(3000);
                        if (!ManagerConnect.IsSockConnected())
                        {
                            if (IsConnected)
                            {
                                if (Disconnecting != null)
                                {
                                    Disconnecting(this, null);
                                }
                                log.WriteLog("##Disconnectiong socketexceps 1377");
                                Abort();
                                return;
                            }
                        }
                    }


                //Console.WriteLine(e.Message);
                return;
            }
            catch (ObjectDisposedException e)
            {
                if (IsConnected)
                {
                    if (Disconnecting != null)
                    {
                        Disconnecting(this, null);
                    }
                    log.WriteLog("##Disconnectiong Objectdisposed 1395");
                    Abort();
                    return;
                }
                //Console.WriteLine(e.Message);
                return;
            }
            catch (NullReferenceException)
            {
                if (IsConnected)
                {
                    if (Disconnecting != null)
                    {
                        Disconnecting(this, null);
                    }
                    log.WriteLog("##Disconnectiong nullreference 1410");
                    Abort();
                    return;
                }
                return;
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
        private void ReleaseEvents()
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
            //if (reciever.IsAlive)
            //    reciever.Abort();
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
                ManagerConnect = new SocketConnection();
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

            //if (reciever == null || reciever.IsAlive == false)
            //    StartRecieve();
            //else throw new AmiException("Поток приема сообщений уже запущен!!!!");
            if (LoginEvent.LoginComplete.WaitOne(5000))
            {
                if (ActionIdMessages.ContainsKey(action.ActionID))
                {
                    IsAlive = true;
                    var result = (LoginEvent)ActionIdMessages[action.ActionID];
                    if (result.Version.Contains("1.1"))
                    {
                        AmiVersion = AmiVersions.v11;
                    }
                    else if (result.Version.Contains("1.3"))
                    {
                        AmiVersion = AmiVersions.v13;
                    }
                    else if (result.Version.Contains("2.5"))
                    {
                        AmiVersion = AmiVersions.v25;
                    }
                    else if (result.Version.Contains("2.8"))
                    {
                        AmiVersion = AmiVersions.v28;
                    }
                    else
                    {
                        AmiVersion = AmiVersions.UNKNOWN;
                    }
                    ActionIdMessages.Remove(action.ActionID);
                    IsConnected = result.IsConnected;
                    return IsConnected;
                }
            }
            Abort();
            return false;
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
                ManagerConnect = new SocketConnection();
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

            if (ChallengeEvent.ChallengeComplete.WaitOne(5000))
            {
                if (ActionIdMessages.ContainsKey(challenge.ActionID))
                {
                    var result = (ChallengeEvent)ActionIdMessages[challenge.ActionID];
                    key = CalculateMD5Hash(result.Challenge + pwd);
                    if (result.Version.Contains("1.1"))
                    {
                        AmiVersion = AmiVersions.v11;
                    }
                    else if (result.Version.Contains("1.3"))
                    {
                        AmiVersion = AmiVersions.v13;
                    }
                    else if (result.Version.Contains("2.5"))
                    {
                        AmiVersion = AmiVersions.v25;
                    }
                    else if (result.Version.Contains("2.8"))
                    {
                        AmiVersion = AmiVersions.v28;
                    }
                    else
                    {
                        AmiVersion = AmiVersions.UNKNOWN;
                    }
                    //AmiVersion = result.Version;
                    ActionIdMessages.Remove(challenge.ActionID);
                }
            }
            else
            {
                return false;
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
            EventManager.PeerEntry += PeerEntryEvent;
            EventManager.Hangup += HangupEvent;
            EventManager.ParkedCall += ParkedCallEvent;
            EventManager.Newchannel += NewchannelEvent;
            EventManager.Newstate += NewChannelState;
            EventManager.DialEvent += EventManager_DialEvent;
            UsersAmount = CheckClientsStatus();
            if (UserData == null)
                UserData = GetUserData(number);
            if (UserData == null || string.IsNullOrEmpty(UsersAmount) || !GetActiveChannelsInfo())
            {
                if (ManagerConnect != null && ManagerConnect.Socket != null)
                    ManagerConnect.CloseSocket();
                ReleaseEvents();
                FreeMemeory();
                return false;
            }
            return true;
        }
        /// <summary>
        /// Отправка запроса отключения от сервера и осовобождение ресурсов на локальной машине
        /// </summary>
        public void Disconnect()
        {
            IsAlive = false;
            IsConnected = false;
            LogoffAction action = new LogoffAction();
            SendToAsterisk(action);
            if (ManagerConnect != null)
                if (ManagerConnect.Socket != null)
                    ManagerConnect.CloseSocket();

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
            ReleaseEvents();
            FreeMemeory();
            if (Reciever != null && parser != null && pinger != null)
            {
                //while (Reciever.IsBusy || parser.IsBusy || pinger.IsBusy)
                //    Thread.Sleep(5);
                pinger.Dispose();
                parser.Dispose();
                Reciever.Dispose();
            }
            pinger = null;
            parser = null;
            Reciever = null;
            //if (Parser.IsAlive)
            //    Parser.Abort();
            //if (ping.IsAlive)
            //    ping.Abort();
        }
        /// <summary>
        /// Вызывать в случае если произошел разрыв связи. Освобождение ресурсов и закрытие потоков
        /// </summary>
        public void Abort()
        {
            IsAlive = false;
            IsConnected = false;
            if (ManagerConnect != null)
                if (ManagerConnect.Socket != null)
                    ManagerConnect.CloseSocket();

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
            ReleaseEvents();
            FreeMemeory();
            if (Reciever != null && parser != null && pinger != null)
            {
                //while (Reciever.IsBusy || parser.IsBusy || pinger.IsBusy)
                //    Thread.Sleep(5);
                pinger.Dispose();
                parser.Dispose();
                Reciever.Dispose();
            }
            pinger = null;
            parser = null;
            Reciever = null;

            //if (Parser.IsAlive)
            //    Parser.Abort();
            //if (ping.IsAlive)
            //    ping.Abort();
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
                ServerUsers.Clear();
            SippeersAction action = new SippeersAction();
            action.ActionID = CreateActionID();
            SendToAsterisk(action);
            if (PeerlistCompleteEvent.PeerlistComplete.WaitOne(25000))
            {
                if (ActionIdMessages.ContainsKey(action.ActionID))
                {
                    var message = (PeerlistCompleteEvent)ActionIdMessages[action.ActionID];
                    ActionIdMessages.Remove(action.ActionID);
                    //Console.WriteLine(message.ListItems);
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
            if (SIPShowPeerEvent.SipShowPeerComplete.WaitOne(TimeSpan.FromMilliseconds(5000)))
            {
                ///Если в общей памяти содержится сообщение с нашим ключом, то получаем данные
                if (ActionIdMessages.ContainsKey(action.ActionID))
                {
                    var message = (SIPShowPeerEvent)ActionIdMessages[action.ActionID];
                    ClientsData client = new ClientsData();
                    client.Number = number;
                    //Console.WriteLine(client.Number);
                    client.Context = message.Context;
                    client.IP = message.AddressIP;
                    client.Status = message.Status;
                    client.Protocol = message.Channeltype;
                    client.Name = message.ObjectName;
                    client.email = message.VoiceMailbox;
                    ActionIdMessages.Remove(action.ActionID);
                    for (int i = 0; i < ServerUsers.Count; i++)
                    {
                        try
                        {
                            if (ServerUsers[i].Number == number)
                                ServerUsers[i] = client;
                        }
                        catch
                        {

                        }
                    }
                    return client;
                }
                else
                    return null;
            }
            return null;
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
            if (CoreShowChannelsEvent.CoreShowChannelsComplete.WaitOne(5000))
            {
                foreach (var obj in ActiveChannels)
                {
                    StatusAction status = new StatusAction(obj.ChannelID);
                    status.ActionID = CreateActionID();
                    SendToAsterisk(status);
                    if (StatusEvent.StatusComplete.WaitOne(2000))
                    {
                        if (ActionIdMessages.ContainsKey(status.ActionID))
                            ActionIdMessages.Remove(status.ActionID);
                    }
                }
                return true;
            }
            else return false;
        }
        /// <summary>
        /// Функция асинхронного звонка. Ставит звонок в очередь на сервере.
        /// </summary>
        /// <param name="Number"></param>
        /// <returns>Вовзращает удалось ли добавить звонок в очередь</returns>
        public bool ASyncCall(string Number)
        {
            OriginateEvent.OriginateComplete.Reset();
            OriginateAction action = new OriginateAction(UserData, Number, 1);
            action.Async = "true";
            action.CallerId = Number + " Dial " + UserData.Number + CallerID + " <" + Number + ">";
            action.ActionID = CreateActionID();
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
        public bool Call(ClientsData client, bool SecondNumber)
        {
            var channels = ActiveChannels;
            for (int i = 0; i < channels.Count; i++)
            {
                if (channels[i].CallerIDNum == UserData.Number && channels[i].ConnectedLineNum == UserData.Number)
                    return false;
            }
            OriginateEvent.OriginateComplete.Reset();
            OriginateAction action;
            if (SecondNumber)
            {
                action = new OriginateAction(UserData, client.SecondNumber, 1);
                action.CallerId = Helper.ConvertToTranslit(client.Name) + " " + client.SecondNumber + CallerID + " (B-CTI) <" + UserData.Number + ">";
            }
            else
            {
                action = new OriginateAction(UserData, client.Number, 1);
                action.CallerId = Helper.ConvertToTranslit(client.Name) + " " + client.Number + CallerID + " (B-CTI) <" + UserData.Number + ">";
            }
            action.Async = "true";
            action.ActionID = CreateActionID();
            //if (SIPADDHEADER != null)
            //{
            //    Dictionary<string, string> vars = new Dictionary<string, string>();
            //    //"=\"Call-Info:\\;answer-after=0\""
            //    vars.Add("SIPADDHEADER", SIPADDHEADER);
            //    action.SetVariables(vars);
            //}
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
        public bool Call(string NumberToCall)
        {
            var channels = ActiveChannels;
            for (int i = 0; i < channels.Count; i++)
            {
                if (channels[i].CallerIDNum == UserData.Number && channels[i].ConnectedLineNum == UserData.Number)
                    return false;
            }
            OriginateEvent.OriginateComplete.Reset();
            OriginateAction action;
            action = new OriginateAction(UserData, NumberToCall, 1);
            action.CallerId = CallerID + " " + NumberToCall + " (B-CTI) <" + UserData.Number + ">";
            action.Async = "true";
            action.ActionID = CreateActionID();
            //if (SIPADDHEADER != null)
            //{
            //    Dictionary<string, string> vars = new Dictionary<string, string>();
            //    //"=\"Call-Info:\\;answer-after=0\""
            //    vars.Add("SIPADDHEADER", SIPADDHEADER);
            //    action.SetVariables(vars);
            //}
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
                HangupAction hangup = new HangupAction(channel.ChannelID);
                SendToAsterisk(hangup);
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
            var _channel = FindChInfoByChID(ChannelID);
            if (_channel != null)
            {
                HangupAction hangup = new HangupAction(ChannelID);
                SendToAsterisk(hangup);
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
            var channel = FindAllChannels(AiringCallNumber);
            var channel2 = FindAllChannels(UserData.Number);
            if (channel.Count > 0)
            {
                for (int i = 0; i < channel.Count; i++)
                {
                    if (AiringCallNumber != UserData.Number)
                    {

                        if ((channel2[i].State == ChannelState.RemoteRinging && channel2[i].ConnectedLineNum == AiringCallNumber) || (channel[i].State == ChannelState.Ringing && channel[i].ConnectedLineNum == UserData.Number))
                        {
                            HangupAction hangup = new HangupAction(channel[i].ChannelID);
                            SendToAsterisk(hangup);
                        }
                    }
                    else
                    {
                        if ((channel[i].State == ChannelState.RemoteRinging))
                        {
                            HangupAction hangup = new HangupAction(channel[i].ChannelID);
                            SendToAsterisk(hangup);
                        }
                    }
                }
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
        public bool Redirect(DialData dial, string TransferToNumber)
        {
            ChannelData channel2 = null;
            if (dial.CallerIDNum == UserData.Number)
                channel2 = FindChInfoByChID(dial.DestinationID);
            else
                channel2 = FindChInfoByChID(dial.ChannelID);
            if (channel2 != null)
            {
                RedirectAction redirect = new RedirectAction(channel2.ChannelID, channel2.Context, TransferToNumber, 1);
                SendToAsterisk(redirect);
                return true;
            }
            //if (dial.CallerIDNum == UserData.Number)
            //{
            //    string _timeout = (Timeout * 1000).ToString();
            //    ParkAction park = new ParkAction(dial.DestinationID, dial.ChannelID, _timeout);
            //    SendToAsterisk(park);
            //}
            //else
            //{
            //    string _timeout = (Timeout * 1000).ToString();
            //    ParkAction park = new ParkAction(dial.ChannelID, dial.DestinationID, _timeout);
            //    SendToAsterisk(park);
            //}
            //var channel = FindChannel(NumberTransferTo);
            //if (channel != null)
            //{
            //    //        //Вариант1 
            //    //        ////var client = GetUserData(NumberTransferTo);
            //    //        //RedirectAction redirect = new RedirectAction(ActiveChannels[i].Channel, ActiveChannels[j].Context, TransferToNumber, 1);
            //    //        //SendToAsterisk(redirect);
            //    //        //return true;

            //    //Работает на версии 1.3 и 2.8
            //    if (string.IsNullOrEmpty(channel.Context))
            //    {

            //    }
            //    else
            //    {
            //        RedirectAction redirect = new RedirectAction(channel.ChannelID, channel.Context, TransferToNumber, 1);
            //        SendToAsterisk(redirect);
            //        return true;
            //    }
            //}
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
                //        //Вариант1 
                //        ////var client = GetUserData(NumberTransferTo);
                //        //RedirectAction redirect = new RedirectAction(ActiveChannels[i].Channel, ActiveChannels[j].Context, TransferToNumber, 1);
                //        //SendToAsterisk(redirect);
                //        //return true;

                //Работает на версии 1.3 и 2.8
                if (string.IsNullOrEmpty(channel.Context))
                {
                    var channel2 = FindChannel(channel.ConnectedLineNum);
                    if (channel2 != null)
                    {
                        RedirectAction redirect = new RedirectAction(channel.ChannelID, channel2.Context, TransferToNumber, 1);
                        SendToAsterisk(redirect);
                        return true;
                    }
                }
                else
                {
                    RedirectAction redirect = new RedirectAction(channel.ChannelID, channel.Context, TransferToNumber, 1);
                    SendToAsterisk(redirect);
                    return true;
                }
            }


            //for (int i = 0; i < ActiveChannels.Count; i++)
            //{
            //    if (ActiveChannels[i].CallerIDNum == NumberTransferTo)
            //    {
            //        //GetVarAction getvar = new GetVarAction("BRIDGEPPER", ActiveChannels[i].Channel);
            //        //SendToAsterisk(getvar);
            //        //Возвращает ничего.

            //        //                    Don't use variables
            //        //If you are tryng to use asterisk variables in redirect via manager(ex: Context: artic_feat_${ featgroupid}) the input will not be parsed, so you will be redirected tu a 'null' extensions in this case.
            //        //clientsdata = Helper.GetParameterValue(asterInfo, "Value: ");




            //        //Вариант 2
            //        if (string.IsNullOrEmpty(ActiveChannels[i].Context))
            //        {
            //            for (int j = 0; j < ActiveChannels.Count; j++)
            //            {
            //                if (ActiveChannels[j].CallerIDNum == ActiveChannels[i].ConnectedLineNum)
            //                {
            //                    RedirectAction redirect = new RedirectAction(ActiveChannels[i].Channel, ActiveChannels[j].Context, TransferToNumber, 1);
            //                    SendToAsterisk(redirect);
            //                    return true;
            //                }
            //            }
            //        }

            //    }
            //}
            return false;
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
            if (channel1 != null)
            {
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
            }
            return false;
            //asterInfo = AsteriskInfo(park, "Response: Success");

            //ParkedCallsAction parkedcalls = new ParkedCallsAction();
            //asterInfo = AsteriskInfo(parkedcalls, "Response: Success");

            //int clientsnumber = 0;
            //List<string[]> listOfClient = new List<string[]>();
            //Regex regex = new Regex("Event: ParkedCall\r\n");

            //// Старый вариант: foreach (Match match in regex.Matches(asterInfo)) { ++clientsnumber; }
            //clientsnumber = regex.Matches(asterInfo).Count;

            //string[] clientsDataMass = new string[clientsnumber];
            //asterInfo = asterInfo.Substring(regex.Match(asterInfo).Index);

            //listOfClient.Add(Helper.DataExtraction(asterInfo, "ParkeeChannel: ", clientsDataMass));
            //if (listOfClient.Count == 0)
            //{
            //    listOfClient.Add(Helper.DataExtraction(asterInfo, "CallerIDNum: ", clientsDataMass));
            //}

            //listOfClient.Add(Helper.DataExtraction(asterInfo, "ParkingSpace: ", clientsDataMass));
            //if (listOfClient.Count == 1)
            //{
            //    listOfClient.Add(Helper.DataExtraction(asterInfo, "Exten: ", clientsDataMass));
            //}
            //string parkingSlot = "";

            //for (int i = 0; i < clientsnumber; i++)
            //{
            //    if (listOfClient[0][i].Contains(numberOfparked))
            //    {
            //        parkingSlot = (string)listOfClient[1][i].Clone();
            //    }
            //}
            //return true;

            //InfoMessage im = new InfoMessage();
            //im.par1 = numberOfparked; im.par2 = parkingSlot;
            //SendInfoMessage(im, 11, HWND_BROADCAST, 400);
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
            var User = GetUser(NumberToHelpTo);
            if (User != null)
            {
                OriginateAction originate = new OriginateAction(UserData.getchannel(), "ChanSpy", User.getchannel() + ",wx");
                originate.Priority = 1;
                Dictionary<string, string> vars = new Dictionary<string, string>();
                if (SIPADDHEADER == null) throw new AmiException("SIPADDHEADER NULL");
                vars.Add("SIPADDHEADER", SIPADDHEADER);
                originate.SetVariables(vars);
                SendToAsterisk(originate);
                //Подождать ответа от сервера
                return true;
            }
            return false;
        }
        public bool PrompterMode(ClientsData User)
        {
            OriginateAction originate = new OriginateAction(UserData.getchannel(), "ChanSpy", User.getchannel() + ",wx");
            originate.Priority = 1;
            Dictionary<string, string> vars = new Dictionary<string, string>();
            if (SIPADDHEADER == null) throw new AmiException("SIPADDHEADER NULL");
            vars.Add("SIPADDHEADER", SIPADDHEADER);
            originate.SetVariables(vars);
            SendToAsterisk(originate);
            //Подождать ответа от сервера
            return true;
        }
        /// <summary>
        /// Функция "тихого" присоединения к звонку. Все люди в конференции слышат нас.
        /// </summary>
        /// <param name="NumberToHelpTo"></param>
        /// <returns></returns>
        public bool JoinCall(string NumberToConnectTo)
        {
            var User = GetUser(NumberToConnectTo);
            if (User != null)
            {
                OriginateAction originate = new OriginateAction(UserData.getchannel(), "ChanSpy", User.getchannel() + ",qBx");
                originate.Priority = 1;
                Dictionary<string, string> vars = new Dictionary<string, string>();
                if (SIPADDHEADER == null) throw new AmiException("SIPADDHEADER NULL");
                vars.Add("SIPADDHEADER", SIPADDHEADER);
                originate.SetVariables(vars);
                SendToAsterisk(originate);
                //Подождать ответа от сервера
                return true;
            }
            return false;
        }
        public bool JoinCall(ClientsData User)
        {
            OriginateAction originate = new OriginateAction(UserData.getchannel(), "ChanSpy", User.getchannel() + ",qBx");
            originate.Priority = 1;
            Dictionary<string, string> vars = new Dictionary<string, string>();
            if (SIPADDHEADER == null) throw new AmiException("SIPADDHEADER NULL");
            vars.Add("SIPADDHEADER", SIPADDHEADER);
            originate.SetVariables(vars);

            SendToAsterisk(originate);
            //Подождать ответа от сервера
            return true;
        }
        /// <summary>
        /// Функция для тихой прослушки канала. Никто из абонентов не слышит нас.
        /// </summary>
        /// <param name="NumberToHelpTo">Номер клиента за которым мы будем подслушивать</param>
        /// <returns></returns>
        public bool SpyCall(string NumberToListenTo)
        {
            var User = GetUser(NumberToListenTo);
            if (User != null)
            {
                OriginateAction originate = new OriginateAction(UserData.getchannel(), "ChanSpy", User.getchannel() + ",qx");
                originate.Priority = 1;
                Dictionary<string, string> vars = new Dictionary<string, string>();
                if (SIPADDHEADER == null) throw new AmiException("SIPADDHEADER NULL");
                vars.Add("SIPADDHEADER", SIPADDHEADER);
                originate.SetVariables(vars);

                SendToAsterisk(originate);
                //Подождать ответа от сервера
                return true;
            }
            return false;
        }
        public bool SpyCall(ClientsData User)
        {
            OriginateAction originate = new OriginateAction(UserData.getchannel(), "ChanSpy", User.getchannel() + ",qx");
            originate.Priority = 1;
            Dictionary<string, string> vars = new Dictionary<string, string>();
            if (SIPADDHEADER == null) throw new AmiException("SIPADDHEADER NULL");
            vars.Add("SIPADDHEADER", SIPADDHEADER);
            originate.SetVariables(vars);

            SendToAsterisk(originate);
            //Подождать ответа от сервера
            return true;
        }
        /// <summary>
        /// Функция запроса прослушивания записи разговора.
        /// </summary>
        /// <param name="PathToPlayBackFile">Путь к файлу на сервере /storage/usbdisk1/test_file</param>
        /// <returns>Если все прошло успешно, то на телефон пользователя поступит вызов с записью</returns>
        public bool AskForPlayback(string PathToPlayBackFile)
        {
            OriginateAction originate = new OriginateAction(UserData.getchannel(), "Playback", PathToPlayBackFile);
            originate.Priority = 1;
            Dictionary<string, string> vars = new Dictionary<string, string>();
            if (SIPADDHEADER == null) throw new AmiException("SIPADDHEADER NULL");
            vars.Add("SIPADDHEADER", SIPADDHEADER);
            originate.SetVariables(vars);

            SendToAsterisk(originate);
            //Подождать ответа от сервера
            return true;

        }
        /// <summary>
        /// Функция ответа на звонок без поднятия трубки. (Работает не со всеми телефонами)
        /// Если существует канал, который пытается дозвониться до нашего абонента, то мы можем сделать ответный звонок на его линию с условием автоответа
        /// </summary>
        /// <param name="CallerNumber">Номер звонящего нам абонента</param>
        public void Answer(string CallerNumber)
        {
            var channel = FindChannel(CallerNumber);
            if (channel != null)
            {
                if (channel.State == ChannelState.RemoteRinging || (channel.State == ChannelState.Ringing && channel.ConnectedLineNum == UserData.Number))
                {
                    OriginateAction originate = new OriginateAction(UserData.getchannel(), "PickupChan", channel.ChannelID);
                    originate.Priority = 1;
                    Dictionary<string, string> vars = new Dictionary<string, string>();
                    if (SIPADDHEADER == null) throw new AmiException("SIPADDHEADER NULL");
                    //"=\"Call-Info:\\;answer-after=0\""
                    vars.Add("SIPADDHEADER", SIPADDHEADER);
                    originate.SetVariables(vars);

                    SendToAsterisk(originate);
                }
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

        #region old
        ///// <summary>
        ///// Функция отправки запроса на сервер и получения ответа в должном виде (Временная)
        ///// </summary>
        ///// <param name="clientSocket"></param> Сокет
        ///// <param name="command"></param> Команда
        ///// <param name="response"></param> Ожидаемый ответ сервера, по которому будет произведен разбор строки
        ///// <returns></returns> Возвращает новую строку
        //public string AsteriskInfo(ActionManager action, string response = "")
        //{
        //    string ServerAnswer = string.Empty;
        //    if (!string.IsNullOrEmpty(response))
        //        ServerAnswer = SendRecvInfo(Helper.BuildAction(action, null, false));
        //    //else
        //    //    SendToAsterisk(action,)
        //    //Если ответ пуст, то вызываем соотвествующий эксепшн TimeOut
        //    //if(string.IsNullOrEmpty(ServerAnswer))
        //    //{
        //    //    throw new AmiException();
        //    //}
        //    //Парсим ответ от сервера с данным (Необходимо в пармер добавить параметр ActionID)
        //    return Helper.ParseResponse(ServerAnswer, response);
        //}


        ///// <summary>
        ///// Метод для осуществления звонка
        ///// </summary>
        ///// <param name="clientSocket"></param>
        ///// <param name="numberOfDestination"></param>
        ///// <param name="client"></param>
        ///// <returns>В сулчае успеха возвращает true</returns>
        //public bool CallOld(string Number)
        //{
        //    string ACTIOIND = CreateActionID();
        //    OriginateAction action = new OriginateAction(UserData, Number, 1);
        //    action.ActionID = ACTIOIND;
        //    string asterInfo = AsteriskInfo(action, "Response: Success");
        //    return true;
        //}




        ///// <summary>
        ///// Функция для отключения от Ами и закрытия активного сокета
        ///// А также освобождение всех ресурсов
        ///// </summary>
        //public void DisconnectAmiOld()
        //{
        //    LogoffAction action = new LogoffAction();
        //    AsteriskInfo(action);
        //    ManagerConnect.CloseSocket();
        //    if (ping.IsAlive)
        //        ping.Join();
        //}

        ///// <summary>
        ///// Функция подключения к серверу AMI с использованием обычных сокетов
        ///// </summary>
        ///// <param name="login"></param>
        ///// <param name="password"></param>
        ///// <param name="ip"></param>
        ///// <param name="port"></param>
        ///// <returns>Возвращает класс с подключением </returns>
        //public bool ConnectAmiOld(string login, string pwd, string ip, int port)
        //{
        //    //Создаем дейстиве логин
        //    LoginAction action = new LoginAction(login, pwd);
        //    //Вариант со старыми сокетами
        //    if (ManagerConnect.Socket == null)
        //        ManagerConnect = new SocketConnection();
        //    try
        //    {
        //        ManagerConnect.Socket = ManagerConnect.GetSocket();
        //        ManagerConnect.Socket.Connect(ManagerConnect.getEndPoint(ip, port));
        //    }
        //    catch (SocketException e)
        //    {
        //        if (e.SocketErrorCode == SocketError.TimedOut)
        //            throw new AmiTimeOutException("Сервер недоступен");
        //        return false;
        //    }
        //    //Создаем ActionId для запроса
        //    action.ActionID = CreateActionID();
        //    //Отправляем запрос c ожиданием ответа (Или заменить на таймер???)
        //    string asterInfo = AsteriskInfo(action, "Response: Success");
        //    //Если запрос прошел - возвращает информацию о подключении
        //    return true;
        //}




        ///// <summary>
        ///// Функция завершения вызова
        ///// </summary>
        ///// <param name="AiringCallNumber"></param>
        ///// <returns></returns>
        //public bool HangupOld(string AiringCallNumber)
        //{
        //    string asterInfo = "";
        //    string clientsdata = "";
        //    List<string> dataOfChanneles = new List<string>();

        //    CommandAction action = new CommandAction("Core Show Channels");
        //    asterInfo = AsteriskInfo(action, "Response: Follows");

        //    dataOfChanneles = Helper.GetDataByParam(asterInfo, UserData.getchannel() + "-", 8);

        //    //BRED BRED BRED BRED BRED BRED BRED
        //    //REDO REDO REDO REDO REDO
        //    foreach (string channel in dataOfChanneles)
        //    {
        //        asterInfo = ""; clientsdata = "";
        //        StatusAction status = new StatusAction(channel);
        //        asterInfo = AsteriskInfo(status, "Response: Success");

        //        clientsdata = Helper.GetParameterValue(asterInfo, "ConnectedLineNum: ");
        //        if (clientsdata == "" | clientsdata == "<unknown>")
        //            continue;

        //        if ((clientsdata.Contains(AiringCallNumber) || clientsdata.Contains(UserData.number) && AiringCallNumber != UserData.number))
        //        {
        //            HangupAction hangup = new HangupAction(channel);
        //            asterInfo = AsteriskInfo(hangup, "Response: Success");
        //            return true;
        //        }
        //    }
        //    return false;
        //}

        ///// <summary>
        ///// Получение информации о клиенте с сервера
        ///// </summary>
        ///// <returns>Возвращает клиентские данные в случае успеха, иначе Null</returns>
        //public ClientsData GetClientInfoOld()
        //{
        //    string response = string.Empty;
        //    SIPShowPeerAction action = new SIPShowPeerAction(UserData.number);
        //    response = AsteriskInfo(action, "Response: Success");

        //    UserData.context = Helper.GetParameterValue(response, "Context: ");
        //    UserData.protocol = Helper.GetParameterValue(response, "Channeltype: ");
        //    UserData.ip = Helper.GetParameterValue(response, "Address-IP: ");

        //    return UserData;
        //}

        ///// <summary>
        ///// Перевод вызова на активном канале
        ///// </summary>
        ///// <param name="clientSocket">Сокет, через который осуществляется связь</param>
        ///// <param name="numberOfcaller">Порядковый номер клиента, осуществляющего связь</param>
        ///// <param name="numberOfdestination">Порядковый номер клиента, с которым должна быть осуществлена связь</param>
        ///// <param name="clients">Коллекция объектов клиентов</param>
        ///// <param name="enableConnect">Осуществлено ли подключение</param>
        //public bool RedirectOld(string numberOfredirection, string numberOfdestination)
        //{
        //    string asterInfo = "";
        //    List<string> dataOfChanneles = new List<string>();
        //    string clientsdata = "";
        //    CommandAction command = new CommandAction("Core Show Channels");
        //    asterInfo = AsteriskInfo(command, "Response: Follows");

        //    dataOfChanneles = Helper.GetDataByParam(asterInfo, UserData.getchannel() + "-", 8);
        //    foreach (string channel in dataOfChanneles)
        //    {
        //        asterInfo = "";
        //        clientsdata = "";
        //        StatusAction status = new StatusAction(channel);
        //        asterInfo = AsteriskInfo(status, "Response: Success");

        //        clientsdata = Helper.GetParameterValue(asterInfo, "ConnectedLineNum: ");
        //        if (clientsdata == "" | clientsdata == "<unknown>")
        //            continue;
        //        if (clientsdata == numberOfredirection)
        //        {
        //            GetVarAction getvar = new GetVarAction("BRIDGEPPER", channel);
        //            asterInfo = AsteriskInfo(getvar, "Response: Success");

        //            clientsdata = Helper.GetParameterValue(asterInfo, "Value: ");
        //            RedirectAction redirect = new RedirectAction(clientsdata, UserData.context, numberOfdestination, 1);
        //            asterInfo = AsteriskInfo(redirect, "Response: Success");

        //            return true;
        //        }

        //    }
        //    return false;
        //}

        ///// <summary>
        ///// Парковка вызова (ПЕРЕПИСАТЬ ПОЛНОСТЬЮ!)
        ///// </summary>
        ///// <param name="clientSocket">Сокет, через который осуществляется связь</param>
        ///// <param name="numberOfparker">Номер клиента, осуществляющего парковку</param>
        ///// <param name="numberOfparked">Номер паркуемого клиента</param>
        ///// <param name="clients">Список клиентов</param>
        ///// <param name="enableConnect">Осуществлено ли подключение</param>
        //public bool ParkingOld(string numberOfparked)
        //{
        //    string asterInfo = string.Empty;
        //    string clientsdata = string.Empty;
        //    List<string> dataOfClients = new List<string>();
        //    CommandAction command = new CommandAction("Core Show Channels");
        //    asterInfo = AsteriskInfo(command, "Response: Follows");
        //    dataOfClients = Helper.GetDataByParam(asterInfo, UserData.getchannel(), 8);

        //    foreach (string client in dataOfClients)
        //    {
        //        if (client.Contains("-"))
        //        {
        //            GetVarAction getvar = new GetVarAction("BRIDGEPEER", client);
        //            asterInfo = AsteriskInfo(getvar, "Response: Success");
        //            clientsdata = Helper.GetParameterValue(asterInfo, "Value: ");

        //            if (numberOfparked != UserData.number)
        //            {
        //                ParkAction park = new ParkAction(clientsdata, client, "45");
        //                asterInfo = AsteriskInfo(park, "Response: Success");
        //                ParkedCallsAction parkedcalls = new ParkedCallsAction();
        //                asterInfo = AsteriskInfo(parkedcalls, "Response: Success");

        //                int clientsnumber = 0;
        //                List<string[]> listOfClient = new List<string[]>();
        //                Regex regex = new Regex("Event: ParkedCall\r\n");

        //                // Старый вариант: foreach (Match match in regex.Matches(asterInfo)) { ++clientsnumber; }
        //                clientsnumber = regex.Matches(asterInfo).Count;

        //                string[] clientsDataMass = new string[clientsnumber];
        //                asterInfo = asterInfo.Substring(regex.Match(asterInfo).Index);

        //                listOfClient.Add(Helper.DataExtraction(asterInfo, "ParkeeChannel: ", clientsDataMass));
        //                if (listOfClient.Count == 0)
        //                {
        //                    listOfClient.Add(Helper.DataExtraction(asterInfo, "CallerIDNum: ", clientsDataMass));
        //                }

        //                listOfClient.Add(Helper.DataExtraction(asterInfo, "ParkingSpace: ", clientsDataMass));
        //                if (listOfClient.Count == 1)
        //                {
        //                    listOfClient.Add(Helper.DataExtraction(asterInfo, "Exten: ", clientsDataMass));
        //                }
        //                string parkingSlot = "";

        //                for (int i = 0; i < clientsnumber; i++)
        //                {
        //                    if (listOfClient[0][i].Contains(numberOfparked))
        //                    {
        //                        parkingSlot = (string)listOfClient[1][i].Clone();
        //                    }
        //                }
        //                return true;

        //                //InfoMessage im = new InfoMessage();
        //                //im.par1 = numberOfparked; im.par2 = parkingSlot;
        //                //SendInfoMessage(im, 11, HWND_BROADCAST, 400);
        //            }
        //        }
        //    }
        //    return false;
        //}
        ///// <summary>
        ///// ПЕРЕПИСАТЬ
        ///// Проверка, остался ли в заданном парковочном слоте на удержании выбранный абонент
        ///// </summary>
        ///// <param name="numberOfparked">Номер припаркованного абонента</param>
        ///// <param name="parkSlot">Парковочное место</param>
        ///// <param name="clientSocket">Сокет, по которому осуществляется соединение</param>
        ///// <param name="enableConnect">Доступно ли подключение</param>
        //public bool CheckForParkOld(string numberOfparked, string parkSlot)
        //{
        //    string asterInfo = "";
        //    ParkedCallsAction action = new ParkedCallsAction();
        //    asterInfo = AsteriskInfo(action, "Response: Success");

        //    int clientsnumber = 0;
        //    List<string[]> listOfClient = new List<string[]>();
        //    Regex regex = new Regex("Event: ParkedCall\r\n");

        //    // старый вариант: foreach (Match match in regex.Matches(asterInfo)) { ++clientsnumber; }
        //    clientsnumber = regex.Matches(asterInfo).Count;

        //    string[] clientsDataMass = new string[clientsnumber];
        //    asterInfo = asterInfo.Substring(regex.Match(asterInfo).Index);
        //    listOfClient.Add(Helper.DataExtraction(asterInfo, "ParkeeChannel: ", clientsDataMass));
        //    if (listOfClient.Count == 0)
        //    {
        //        listOfClient.Add(Helper.DataExtraction(asterInfo, "CallerIDNum: ", clientsDataMass));
        //    }

        //    listOfClient.Add(Helper.DataExtraction(asterInfo, "ParkingSpace: ", clientsDataMass));
        //    if (listOfClient.Count == 1)
        //    {
        //        listOfClient.Add(Helper.DataExtraction(asterInfo, "Exten: ", clientsDataMass));
        //    }
        //    for (int i = 0; i < clientsnumber; i++)
        //    {
        //        if (listOfClient[0][i].Contains(numberOfparked) & String.Compare(listOfClient[1][i], parkSlot) == 0)
        //        {
        //            return true;
        //        }
        //    }
        //    return false;

        //}
        ///// <summary>
        ///// ПЕРЕПИСАТЬ ПОЛНОСТЬЮ
        ///// Проверка, работает ли проверяемый канал
        ///// </summary>
        ///// <param name="clientSocket">Сокет, через который осуществляется связь с сервером</param>
        ///// <param name="MainClient"></param>
        ///// <param name="enableConnect"></param>
        ///// <param name="channel"></param>
        ///// <param name="number"></param>
        ///// <param name="whatCall"></param>
        ///// <param name="date"></param>
        //public bool isAliveOld(string channel)
        //{
        //    List<string> dataOfChanneles;
        //    dataOfChanneles = new List<string>();
        //    string asterInfo = "";
        //    CommandAction action = new CommandAction("Core Show Channels");
        //    asterInfo = AsteriskInfo(action, "Response: Follows");
        //    Regex matchExpression1 = new Regex("--END COMMAND-");
        //    asterInfo = asterInfo.Substring(0, matchExpression1.Match(asterInfo).Index);

        //    dataOfChanneles = Helper.GetDataByParam(asterInfo, UserData.getchannel() + "-", 8);

        //    if (dataOfChanneles.Count == 0)
        //    {
        //        return false;
        //    }

        //    foreach (string seekedChannel in dataOfChanneles)
        //    {
        //        if (seekedChannel == channel)
        //        {
        //            return false;
        //        }
        //    }
        //    return true;

        //    //InfoMessage im = new InfoMessage();
        //    //im.par1 = channel; im.par2 = number;
        //    //im.boolean = whatCall; im.date1 = date;
        //    //SendInfoMessage(im, 9, HWND_BROADCAST, 400);
        //}
        ///// <summary>
        ///// Полный бред. Точно переписать.
        ///// Получить статус абонентов на сервере
        ///// </summary>
        ///// <param name="clientSocket">Сокет, по которому осуществлена связь</param>
        ///// <param name="Copyclients"></param>
        ///// <param name="clients"></param>
        ///// <param name="clientsnumber"></param>
        ///// <param name="MainClient"></param>
        ///// <param name="BLFIsChanded"></param>
        ///// <param name="BoolOfContacts"></param>
        ///// <param name="enableConnect"></param>
        //public void GetCallStatus(ref List<ClientsData> Copyclients, ref List<ClientsData> BookOfContacts)
        //{
        //    List<ClientsData> clients = new List<ClientsData>();
        //    clients.AddRange(BookOfContacts);
        //    int number = Copyclients.Count;
        //    clients.Add(UserData);

        //    foreach (ClientsData client in clients)
        //    {
        //        string asterInfo = "";
        //        string clientsData = "";
        //        bool hold = false;
        //        SIPShowPeerAction showpeer = new SIPShowPeerAction(client.number);
        //        asterInfo = AsteriskInfo(showpeer, "Response: Success");
        //        clientsData = Helper.GetParameterValue(asterInfo, "Status: ");
        //        client.status = (string)clientsData.Clone();
        //        if (!client.status.Contains("OK"))
        //        {
        //            if (client.BLFStatus != "OffLine")
        //            {
        //                //Событие смены статуса

        //            }
        //            client.BLFStatus = "OffLine";
        //            client.pictoStatus = 0;
        //            continue;
        //        }
        //        CommandAction command = new CommandAction("Core Show Channels");
        //        asterInfo = AsteriskInfo(command, "Response: Follows");
        //        clientsData = Helper.FindInResponse(asterInfo, client.getchannel() + "-");
        //        if (clientsData.Contains("Ringing") | clientsData.Contains("Ring"))
        //        {
        //            if (client.BLFStatus != "Calling")
        //            {
        //                //Событие смены статуса

        //            }
        //            client.BLFStatus = "Calling";
        //            client.pictoStatus = 3;
        //            continue;
        //        }

        //        int parkNumber = 0;
        //        List<string[]> listOfClient = new List<string[]>();
        //        Regex regex = new Regex("Event: ParkedCall\r\n");
        //        ParkedCallsAction park = new ParkedCallsAction();
        //        asterInfo = AsteriskInfo(park, "Response: Success");
        //        foreach (Match match in regex.Matches(asterInfo))
        //        {
        //            ++parkNumber;
        //        }

        //        string[] clientsDataMass = new string[parkNumber];
        //        asterInfo = asterInfo.Substring(regex.Match(asterInfo).Index);
        //        listOfClient.Add(Helper.DataExtraction(asterInfo, "ParkeeChannel: ", clientsDataMass));
        //        if (listOfClient.Count == 0)
        //        {
        //            listOfClient.Add(Helper.DataExtraction(asterInfo, "CallerIDNum: ", clientsDataMass));
        //        }
        //        if (listOfClient.Count != 0)
        //        {
        //            for (int i = 0; i < parkNumber; i++)
        //            {
        //                if (listOfClient[0][i].Contains(client.number))
        //                {
        //                    if (client.BLFStatus != "ON HOLD")
        //                    {
        //                        //Событие смены статуса
        //                    }
        //                    client.BLFStatus = "ON HOLD";
        //                    client.pictoStatus = 1;
        //                    hold = true;
        //                    break;
        //                }
        //            }
        //        }

        //        if (hold)
        //        {
        //            continue;
        //        }

        //        if (clientsData.Contains("Up"))
        //        {
        //            if (client.BLFStatus != "Talking")
        //            {
        //                //Событие смены статуса
        //            }
        //            client.BLFStatus = "Talking";
        //            client.pictoStatus = 3;
        //            continue;
        //        }
        //        if (client.BLFStatus != "OnLine")
        //        {
        //            //Событие смены статуса
        //        }
        //        client.BLFStatus = "OnLine";
        //        client.pictoStatus = 2;
        //    }

        //    Copyclients.Clear();

        //    foreach (ClientsData contact in BookOfContacts)
        //    {
        //        bool done = false;

        //        foreach (ClientsData client in clients)
        //        {
        //            if (contact.number == client.number)
        //            {
        //                contact.protocol = client.protocol;
        //                contact.ip = client.ip;
        //                contact.status = client.status;
        //                contact.BLFStatus = client.BLFStatus;
        //                contact.context = client.context;
        //                contact.pictoStatus = client.pictoStatus;
        //                done = true;
        //                if (contact.number == UserData.number)
        //                {
        //                    break;
        //                }
        //                if (contact.onBLF == false)
        //                {
        //                    break;
        //                }

        //                Copyclients.Add(contact);
        //                break;
        //            }
        //        }

        //        if (done)
        //        {
        //            continue;
        //        }
        //        if (contact.onBLF == false)
        //        {
        //            continue;
        //        }
        //        Copyclients.Add(contact);
        //    }
        //}
        ///// <summary>
        ///// Что это, зачем это?
        ///// </summary>
        //public void GetSplashEvent()
        //{
        //    List<string> dataOfChanneles = new List<string>();
        //    string asterInfo = "", connectedLineNumber = "", clientdata = "";
        //    CommandAction command = new CommandAction("Core Show Channels");
        //    asterInfo = AsteriskInfo(command, "Response: Follows");

        //    Regex matchExpression1 = new Regex("--END COMMAND-");
        //    if (matchExpression1.Matches(asterInfo).Count == 0)
        //        return;

        //    asterInfo = asterInfo.Substring(0, matchExpression1.Match(asterInfo).Index);
        //    dataOfChanneles = Helper.GetDataByParam(asterInfo, UserData.getchannel() + "-", 8);

        //    if (dataOfChanneles.Count == 0)
        //        return;

        //    foreach (string channel in dataOfChanneles)
        //    {
        //        asterInfo = ""; connectedLineNumber = ""; clientdata = "";
        //        StatusAction status = new StatusAction(channel);
        //        asterInfo = AsteriskInfo(status, "Response: Success");
        //        connectedLineNumber = Helper.GetParameterValue(asterInfo, "ConnectedLineNum: ");
        //        if (connectedLineNumber == "" | connectedLineNumber == "<unknown>")
        //            return;
        //        asterInfo = "";
        //        asterInfo = AsteriskInfo(command, "Response: Follows");
        //        matchExpression1 = new Regex("--END COMMAND-");
        //        asterInfo = asterInfo.Substring(0, matchExpression1.Match(asterInfo).Index);
        //        clientdata = Helper.GetParameterValue(asterInfo, UserData.getchannel() + "-");
        //        if (clientdata.Contains("AppDial((Outgoing Line))"))
        //            //Событие

        //            return;

        //    }
        //}

        ///// <summary>
        ///// Проверка, произведён ли ответ на звонок
        ///// </summary>
        ///// <param name="clientSocket">Сокет, через который осуществляется связь с сервером</param>
        ///// <param name="MainNumber">Номер пользователя</param>
        ///// <param name="clientsnumber">Номер клиента, с которым осуществлена связь</param>
        ///// <param name="MainClient">Объект пользователя</param>
        ///// <param name="enableConnect">Осуществлено ли подключение</param>
        ///// <param name="channel">Канал</param>
        ///// <param name="number">Номер</param>
        ///// <param name="date">Время, когда начался разговор</param>
        //public bool isAnswered(string channel, string number, DateTime date, bool outcoming)
        //{
        //    //bool answered;
        //    List<string> moreDataOfChanneles;
        //    bool isDone;
        //    List<string> dataOfChanneles;


        //    moreDataOfChanneles = new List<string>();
        //    dataOfChanneles = new List<string>();
        //    //answered = true;
        //    isDone = true;
        //    string asterInfo = "";
        //    CommandAction command = new CommandAction("Core Show Channels");
        //    asterInfo = AsteriskInfo(command, "Response: Follows");

        //    Regex matchExpression1 = new Regex("--END COMMAND-");
        //    if (matchExpression1.Matches(asterInfo).Count == 0)
        //        return false;

        //    asterInfo = asterInfo.Substring(0, matchExpression1.Match(asterInfo).Index);
        //    moreDataOfChanneles = Helper.DataExtraction(asterInfo, UserData.getchannel() + "-");
        //    dataOfChanneles = Helper.GetDataByParam(asterInfo, UserData.getchannel() + "-", 8);

        //    if (moreDataOfChanneles.Count == 0)
        //    {
        //        return false;
        //    }

        //    foreach (string seekedChannel in dataOfChanneles)
        //    {
        //        if (seekedChannel == channel)
        //        {
        //            isDone = false;
        //        }
        //    }

        //    foreach (string seekedChannel in moreDataOfChanneles)
        //    {
        //        if (seekedChannel.Contains("Up"))
        //        {
        //            isDone = true;
        //            break;
        //        }
        //    }
        //    return isDone;

        //}
        /// <summary>
        /// Отправка на сервер и получение результата, в случае если он нужен
        /// </summary>
        /// <param name="action"></param>
        /// <returns>Если пользователь указал дополнительным параметром </returns>
        //public int SendAction(ActionManager action, ResponseHandler response)
        //{
        //    if (action == null)
        //    {
        //        throw new AmiException();//Exception ("Невозможно отправить запрос: Action is null")
        //    }
        //    if (ManagerConnect == null || ManagerConnect.TcpClientSocket() == null)
        //    {
        //        throw new AmiException();//ExceptionManager
        //    }
        //    string internalActionID = string.Empty;
        //    if (response != null)
        //    {
        //        internalActionID = CreateInternalActionID();

        //        //response.Hash = internalActionID.GetHashCode();
        //        //AddResponseHandler(response);
        //    }
        //    SendToAsterisk(action, internalActionID);

        //    //return response != null ? response.Hash : 0;
        //}

        /////////////СТАРАЯ ФУНКЦИЯ
        /// <summary>
        /// Функция отправки и получения ответа от сервера
        /// </summary>
        /// <param name="clientSocket"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        //private string SendRecvInfo(string command)
        //{
        //    byte[] recvBuffer = new byte[1000000];
        //    byte[] sendBuffer = Encoding.ASCII.GetBytes(command);
        //    string asterInfo = string.Empty;
        //    Regex Response = new Regex(Helper.LINE_SEPARATOR + Helper.LINE_SEPARATOR);
        //    Match RespMatch = Response.Match(asterInfo);
        //    int buffersize = 0;
        //    if (ManagerConnect.IsSockConnected())
        //    {
        //        try
        //        {
        //            ManagerConnect.Socket.Send(sendBuffer);
        //            System.Threading.Thread.Sleep(10);
        //            do
        //            {
        //                buffersize = ManagerConnect.Socket.Receive(recvBuffer);
        //                asterInfo += Encoding.ASCII.GetString(recvBuffer, 0, buffersize);
        //                RespMatch = Response.Match(asterInfo);
        //            }
        //            while (!RespMatch.Success);
        //            //Console.WriteLine(asterInfo);
        //            return asterInfo;
        //        }
        //        catch (SocketException e)
        //        {
        //            if (e.SocketErrorCode == SocketError.TimedOut)
        //                throw new AmiTimeOutException("Время ождидания подключения к серверу истекло");
        //            //Console.WriteLine(e.Message);
        //            return null;
        //        }
        //        catch (ObjectDisposedException e)
        //        {
        //            //Console.WriteLine(e.Message);
        //            return null;
        //        }
        //    }
        //    else
        //    {
        //        throw new AmiException("Сокет не создан или нет подключения");
        //    }
        //}
        /// <summary>
        /// Новая функция отправки запароса на сервер
        /// </summary>
        /// <param name="action"></param>
        /// <param name="InternalActionId"></param>
        //internal void SendToAsterisk(ActionManager action, string InternalActionId)
        //{
        //    if (ManagerConnect.TcpClientSocket() == null)
        //        throw new NotImplementedException();//ExceptionManager
        //}
        /// <summary>
        /// Функция подключения к серверу AMI с использованием TCPсокетов
        /// </summary>
        /// <param name="login"></param>
        /// <param name="password"></param>
        /// <param name="ip"></param>
        /// <param name="port"></param>
        /// <param name="isDebugMode"></param>
        /// <returns>Возвращает класс с подключением </returns>
        //public SocketConnection ConnectAmi(string login, string pwd, string ip, int port/*, bool isDebugMode*/)
        //{
        //    //Вариант с новыми сокетами
        //    IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse(ip), port);
        //    SocketConnection Connection = new SocketConnection(endPoint);
        //    try
        //    {
        //        Connection.TcpClientSocket().Connect(ip, port);
        //    }
        //    catch (SocketException ex) { return null; }

        //    string asterInfo = await AsteriskInfo(Connection.GetSocket(), "Action: Login\r\nUsername: " + login + "\r\nSecret: " + pwd + "\r\nActionID: 1\r\n\r\n", "Response: Success");

        //    if (asterInfo == null | asterInfo == "") { return null; }

        //    //if (isDebugMode)
        //    //    log.Info("AMI Connection: " + asterInfo);
        //    return Connection;
        //}

        #endregion

    }
}
