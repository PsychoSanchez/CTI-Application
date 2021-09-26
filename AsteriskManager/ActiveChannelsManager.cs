using System;
using System.Collections.Generic;
using System.Threading;
using AsteriskManager.Manager.Event;

namespace AsteriskManager
{
    public class ActiveChannelManager
    {
        const string UNKNOWN_NUMBER = "<unknown>";
        const string ROSTELEKOM_LINE_NUMBER = "rostelecom";

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

        private AutoResetEvent ActiveChanSemaphore = new AutoResetEvent(true);
        private List<ChannelData> ActiveChannels = new List<ChannelData>();
        public void DefaultChannelInfoValues(DialData dial)
        {
            try
            {
                ActiveChanSemaphore.WaitOne();
                for (int i = 0; i < ActiveChannels.Count; i++)
                {
                    ChannelData channel = ActiveChannels[i];
                    if (channel.ChannelID != dial.ChannelID)
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

        public ChannelData DefaultChannelInfoValues(NewstateEvent ChannelInfo)
        {
            try
            {
                ActiveChanSemaphore.WaitOne();
                for (int i = 0; i < ActiveChannels.Count; i++)
                {
                    ChannelData activeChannel = ActiveChannels[i];
                    if (activeChannel.ChannelID != ChannelInfo.Channel)
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

        public void UpdateChannelCallerInfo(IDialChannelInfo target, IDialChannelInfo source)
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

        public void DefaultChannelConnectedLineInfo(IDialChannelInfo target, IDialChannelInfo source)
        {
            // FastPath
            if (!IsNullEmptyOrUnknownNumber(target.CallerIDNum))
            {
                return;
            }

            UpdateChannelConnectedLineInfo(target, source);
        }

        public void UpdateChannelConnectedLineInfo(IDialChannelInfo target, IDialChannelInfo source)
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

        public ChannelData RemoveActiveChannel(string channelID)
        {
            try
            {
                ActiveChanSemaphore.WaitOne();
                for (int j = 0; j < ActiveChannels.Count; j++)
                {
                    if (ActiveChannels[j].ChannelID != channelID)
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
                return RemoveActiveChannel(channelID);
            }
        }

        private void UpdateChannelCallerID(ChannelData channel, ChannelData destination)
        {
            try
            {
                ActiveChanSemaphore.WaitOne();
                for (int i = 0; i < ActiveChannels.Count; i++)
                {
                    if (!channel.Equals(ActiveChannels[i]))
                    {
                        continue;
                    }

                    ActiveChannels[i].ConnectedLineNum = destination.CallerIDNum;
                    ActiveChanSemaphore.Set();
                    return;
                }
                ActiveChanSemaphore.Set();
                return;
            }
            catch (IndexOutOfRangeException)
            {
                ActiveChanSemaphore.Set();
                UpdateChannelCallerID(channel, destination);
            }
        }

        public void AddActiveChannel(ChannelData channel)
        {
            ActiveChanSemaphore.WaitOne();

            for (int i = 0; i < ActiveChannels.Count; i++)
            {
                if (ActiveChannels[i].ChannelID == channel.ChannelID)
                {
                    ActiveChanSemaphore.Set();
                    return;
                }
            }

            ActiveChannels.Add(channel);
            ActiveChanSemaphore.Set();
        }


        public ChannelData GetChannelByCallerNumbers(string callerIdNum, string connectedLineNum)
        {
            ActiveChanSemaphore.WaitOne();
            for (int i = 0; i < ActiveChannels.Count; i++)
            {
                ChannelData channel = ActiveChannels[i];
                if (channel.CallerIDNum != callerIdNum || channel.ConnectedLineNum != connectedLineNum)
                {
                    continue;
                }

                ActiveChanSemaphore.Set();
                return channel;
            }

            ActiveChanSemaphore.Set();
            return null;
        }

        public ChannelData FindChannel(string callerNum, string connectedNum)
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
        /// Находит полную информацию о канале по его ID
        /// </summary>
        /// <param name="ChannelID">ID канала</param>
        /// <returns>полная информаци о канале, если он существует</returns>
        public ChannelData FindChInfoByChID(string ChannelID)
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
        public List<ChannelData> FindChannelsWithCallerID(string callerId)
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


        public void UpdateDialInfoWithChannelInfo(DialData dial, ChannelData channel)
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
        private void TryUpdateChannelInfoWithDestinationChannelInfo(ChannelData channel, string channelDestinationId)
        {
            var dest = FindChInfoByChID(channelDestinationId);
            if (dest != null)
            {
                UpdateChannelCallerID(channel, dest);
            }
        }


        public bool IsUserStartedCall(string num)
        {
            return ActiveChannels.Find(channel => channel.CallerIDNum == num && channel.ConnectedLineNum == num) != null;
        }

        public List<ChannelData> GetChannels()
        {
            return ActiveChannels;
        }
    }
}