//#define LOG
using AsteriskManager.Utils;
using System;
using System.Collections.Generic;

namespace AsteriskManager
{
    public class Helper
    {
        #region API CONSTANTS

        public static string MachineID = AsteriskManagerUtils.ConvertToTranslit(Environment.MachineName.Replace(" ", "")) + AsteriskManagerUtils.ConvertToTranslit(Environment.UserName.Replace(" ", ""));

        public const string DEFAULT_HOSTNAME = "localhost";

        public const int DEFAULT_PORT = 5038;

        public const char END_LINE = '\n';
        public const string LINE_SEPARATOR = "\r\n";

        public static char[] RESPONSE_KEY_VALUE_SEPARATOR = { ':' };
        public static char[] MINUS_SEPARATOR = { '-' };
        public static char[] VAR_DELIMETER = { '|' };

        public static char INTERNAL_CATION_ID_DELIMETER = '#';

        public static string[] END_MESSAGE = new string[] { "\r\n\r\n" };
        private static string[] ChannelSplit = new string[] { " " };
        public static Dictionary<string, string> vars = new Dictionary<string, string>();
        #endregion

        /// <summary>
        /// Поиск параметра в ответе из запроса.(ИСПРАВЛЕНО)
        /// </summary>
        /// <param name="SourceString">Информация в строковой переменной</param>
        /// <param name="parameterName">Указатель на искомые данные</param>
        public static string GetParameterValue(string SourceString, string parameterName)
        {
            var indexOfValue = SourceString.IndexOf(parameterName);
            if (indexOfValue < 0)
            {
                return string.Empty;
            }

            var message = SourceString.Substring(indexOfValue);
            message += Helper.LINE_SEPARATOR;

            int startPos = parameterName.Length;
            int length = message.IndexOf(Helper.LINE_SEPARATOR) - startPos;
            message = message.Substring(startPos, length);

            if (!string.IsNullOrEmpty(message))
            {
                return message;
            }

            return string.Empty;
        }
        /// <summary>
        /// Функция парсер для команды CoreShowChannels
        /// 
        /// </summary>
        /// <param name="SourceString"></param>
        /// <returns>Возвращает список открытых каналов с их статусом</returns>
        public static List<ChannelData> GetChannelsInfo(string SourceString)
        {
            List<ChannelData> Channels = new List<ChannelData>();
            var NoEndLineMessage = SourceString.Replace(Helper.LINE_SEPARATOR, "");
            var NoResponseMessage = NoEndLineMessage.Substring(NoEndLineMessage.IndexOf(Helper.END_LINE) + 1);
            var AllChannels = NoResponseMessage.Split(Helper.END_LINE);
            for (int i = 0; i < AllChannels.Length - 4; i++)
            {
                var channelinfo = AllChannels[i].Split(ChannelSplit, StringSplitOptions.RemoveEmptyEntries);
                if (channelinfo[3].Contains("(("))
                {
                    channelinfo[3] += " " + channelinfo[4];
                }
                ChannelData channel = new ChannelData(channelinfo[0], channelinfo[1], channelinfo[2], channelinfo[3]);
                Channels.Add(channel);
            }
            return Channels;
        }
        /// <summary>
        /// Превращает информацию о канале в информацию о звонке (Версия ами 1.1)
        /// </summary>
        /// <param name="channel">Канал</param>
        /// <returns></returns>
        public static DialData ChannelDataToDialRev11(ChannelData channel)
        {
            DialData dial = new DialData();


            if (!IsNullOrNotBCTI(channel.CallerIDName) || !IsNullOrNotBCTI(channel.ConnectedLineName))
            {
                CopyCallersInfo(channel, dial);
            }
            else
            {
                CopyAndInvertCallersInfo(channel, dial);
            }


            dial.ChannelID = channel.ChannelID;
            dial.DestinationID = string.IsNullOrEmpty(channel.Link) ? string.Empty : channel.Link;
            dial.Uniqueid = channel.Uniqueid;
            return dial;
        }

        private static bool IsNullOrNotBCTI(string val)
        {
            return val == null || !val.Contains("B-CTI");
        }

        private static void CopyAndInvertCallersInfo(ChannelData channel, DialData dial)
        {
            dial.CallerIDNum = channel.ConnectedLineNum;
            dial.CallerIDName = channel.ConnectedLineName;
            dial.ConnectedLineNum = channel.CallerIDNum;
            dial.ConnectedLineName = channel.CallerIDName;
        }

        private static void CopyCallersInfo(ChannelData channel, DialData dial)
        {
            dial.CallerIDNum = channel.CallerIDNum;
            dial.CallerIDName = channel.CallerIDName;
            dial.ConnectedLineNum = channel.ConnectedLineNum;
            dial.ConnectedLineName = channel.ConnectedLineName;
        }

        /// <summary>
        /// Превращает данные открытого канала в информацию о звонке
        /// </summary>
        /// <param name="channel">Информация о канале</param>
        /// <returns></returns>
        public static DialData ChannelDataToDial(ChannelData channel)
        {
            DialData dial = new DialData();
            CopyCallersInfo(channel, dial);

            dial.ChannelID = channel.ChannelID;
            dial.DestinationID = string.IsNullOrEmpty(channel.Link) ? string.Empty : channel.Link;
            dial.Uniqueid = channel.Uniqueid;
            return dial;
        }
        /// <summary>
        /// Получает номер приписанный к сип каналу
        /// </summary>
        /// <param name="ChannelID">ID канала</param>
        /// <returns></returns>
        public static string GetNumberFromChannel(string ChannelID)
        {
            if (ChannelID.ToLower().Contains("sip"))
            {
                ChannelID = ChannelID.Replace("SIP/", "");
                int length = ChannelID.IndexOf("-");
                ChannelID = ChannelID.Substring(0, length);
                return ChannelID;
            }
            else
                return string.Empty;
        }


        internal static string ToString(object obj) => AsteriskManagerUtils.ToString(obj);
    }
}

