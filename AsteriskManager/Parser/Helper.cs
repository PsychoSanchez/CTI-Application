//#define LOG
using AsteriskManager.Manager.Actions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace AsteriskManager
{
    public class Helper
    {
        #region API CONSTANTS

        public static string MachineID = Helper.ConvertToTranslit(Environment.MachineName.Replace(" ", "")) + Helper.ConvertToTranslit(Environment.UserName.Replace(" ", ""));

        private static Dictionary<char, string> RusEng;
        private static void InitDictionary()
        {
            RusEng = new Dictionary<char, string>();
            var rulowercase = russianAlphabetLowercase.Split(' ');
            var ruuppercase = russianAlphabetUppercase.Split(' ');
            var enlowercase = expectedLowercase.Split(' ');
            var enuppercase = expectedUppercase.Split(' ');
            for (int i = 0; i < rulowercase.Length; i++)
            {
                RusEng.Add(rulowercase[i][0], enlowercase[i]);
                RusEng.Add(ruuppercase[i][0], enuppercase[i]);
            }
        }
        public static string ConvertToTranslit(string rustring)
        {
            if (RusEng == null)
            {
                InitDictionary();
            }
            string enstring = string.Empty;
            var charstring = rustring.ToCharArray();
            for (int i = 0; i < charstring.Length; i++)
            {
                if (RusEng.ContainsKey(charstring[i]))
                {
                    charstring[i] = RusEng[charstring[i]][0];
                    enstring = enstring + charstring[i];
                }
                else
                {
                    enstring = enstring + charstring[i];
                }
            }
            return enstring;
        }
        private const string russianAlphabetLowercase = "а б в г д е ё ж з и й к л м н о п р с т у ф х ц ч ш щ ъ ы ь э ю я";
        private const string russianAlphabetUppercase = "А Б В Г Д Е Ё Ж З И Й К Л М Н О П Р С Т У Ф Х Ц Ч Ш Щ Ъ Ы Ь Э Ю Я";

        private const string expectedLowercase = "a b v g d e yo zh z i y k l m n o p r s t u f kh ts ch sh shch \" y ' e yu ya";
        private const string expectedUppercase = "A B V G D E Yo Zh Z I Y K L M N O P R S T U F Kh Ts Ch Sh Shch \" Y ' E Yu Ya";

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
        /// Функция для срздания запроса с параметро ActionId, чтобы обрабатывать пакеты до получения Response
        /// Теперь обрабатывать пакеты можно по actionID запросу
        /// </summary>
        /// <param name="action"></param>
        /// <param name="internalActionId"></param>
        /// <returns></returns>
        public static string BuildAction(ActionManager action, string internalActionId, bool IsProxyAction)
        {
            try
            {

                StringBuilder sb = new StringBuilder();
                if (string.IsNullOrEmpty(action.ActionID))
                {
                    action.ActionID = MachineID;
                }
                //Создаем Action Запрос. Сначала выбираем какого типа запрос.
                if (IsProxyAction)
                {
                    sb.Append(string.Concat("ProxyAction: ", action.Action, LINE_SEPARATOR));
                }
                else
                {
                    sb.Append(string.Concat("Action: ", action.Action, LINE_SEPARATOR));
                }
                sb.Append(string.Concat("ActionID: ", action.ActionID, LINE_SEPARATOR));
                //Если запрос обладает параметрами, добавляем их. 
                //Добавляем только параметры, потому что все значения конца строки уже выставлены
                if (!(string.IsNullOrEmpty(action.Parameters)))
                {
                    sb.Append(action.Parameters);
                }
                //Он был написан одним из параметров в вики, однако в примерах не указывается. В случае если он не требуется, можно удалить.
                //if (string.IsNullOrEmpty(internalActionId))
                //{
                //    actionIDvlaue = action.ActionID;
                //}
                //else
                //{
                //    actionIDvlaue = string.Concat(internalActionId, INTERNAL_CATION_ID_DELIMETER, action.ActionID);
                //}
                //
                sb.Append(LINE_SEPARATOR);
#if LOG
                DateTime date = DateTime.Now;
                System.IO.StreamWriter file = new System.IO.StreamWriter("AMILOG" + date.ToShortDateString() + ".log", true);
                try
                {
                    file.WriteLine(date.ToString(), file.NewLine);
                    file.WriteLine(sb.ToString());
                    file.Close();
                }
                finally
                {
                    if (file != null)
                        file.Dispose();
                }
#endif
                return sb.ToString();
            }
            catch (StackOverflowException)
            {
                return "";
            }
        }

        /// <summary>
        /// Поиск параметра в ответе из запроса.(ИСПРАВЛЕНО)
        /// </summary>
        /// <param name="SourceString">Информация в строковой переменной</param>
        /// <param name="parameterName">Указатель на искомые данные</param>
        public static string GetParameterValue(string SourceString, string parameterName)
        {
            if (SourceString.Contains(parameterName))
            {
                var message = SourceString.Substring(SourceString.IndexOf(parameterName));
                message += Helper.LINE_SEPARATOR;
                int startPos = parameterName.Length;
                int length = message.IndexOf(Helper.LINE_SEPARATOR) - startPos;
                message = message.Substring(startPos, length);
                if (!string.IsNullOrEmpty(message))
                    return message;
                else
                    return string.Empty;
            }
            else
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
            if (channel.CallerIDName != null)
            {
                if (channel.CallerIDName.Contains("B-CTI"))
                {
                    dial.CallerIDNum = channel.CallerIDNum;
                    dial.CallerIDName = channel.CallerIDName;
                    dial.ConnectedLineNum = channel.ConnectedLineNum;
                    dial.ConnectedLineName = channel.ConnectedLineName;
                }
                else
                {
                    dial.CallerIDNum = channel.ConnectedLineNum;
                    dial.CallerIDName = channel.ConnectedLineName;
                    dial.ConnectedLineNum = channel.CallerIDNum;
                    dial.ConnectedLineName = channel.CallerIDName;
                }
            }
            else if (channel.ConnectedLineName != null)
            {
                if (channel.ConnectedLineName.Contains("B-CTI"))
                {
                    dial.CallerIDNum = channel.CallerIDNum;
                    dial.CallerIDName = channel.CallerIDName;
                    dial.ConnectedLineNum = channel.ConnectedLineNum;
                    dial.ConnectedLineName = channel.ConnectedLineName;
                }
                else
                {
                    dial.CallerIDNum = channel.ConnectedLineNum;
                    dial.CallerIDName = channel.ConnectedLineName;
                    dial.ConnectedLineNum = channel.CallerIDNum;
                    dial.ConnectedLineName = channel.CallerIDName;
                }
            }
            else
            {
                dial.CallerIDNum = channel.ConnectedLineNum;
                dial.CallerIDName = channel.ConnectedLineName;
                dial.ConnectedLineNum = channel.CallerIDNum;
                dial.ConnectedLineName = channel.CallerIDName;
            }
            dial.ChannelID = channel.ChannelID;
            if (!string.IsNullOrEmpty(channel.Link))
            {
                dial.DestinationID = channel.Link;
            }
            else
            {
                dial.DestinationID = string.Empty;
            }
            dial.Uniqueid = channel.Uniqueid;
            return dial;
        }
        /// <summary>
        /// Превращает данные открытого канала в информацию о звонке
        /// </summary>
        /// <param name="channel">Информация о канале</param>
        /// <returns></returns>
        public static DialData ChannelDataToDial(ChannelData channel)
        {
            DialData dial = new DialData();
            dial.CallerIDNum = channel.CallerIDNum;
            dial.CallerIDName = channel.CallerIDName;
            dial.ConnectedLineNum = channel.ConnectedLineNum;
            dial.ConnectedLineName = channel.ConnectedLineName;

            dial.ChannelID = channel.ChannelID;
            if (!string.IsNullOrEmpty(channel.Link))
            {
                dial.DestinationID = channel.Link;
            }
            else
            {
                dial.DestinationID = string.Empty;
            }
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
        #region ToString()
        /// <summary>
        ///     Convert object with all properties to string
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        internal static string ToString(object obj)
        {
            object value;
            var sb = new StringBuilder(obj.GetType().Name, 1024);
            sb.Append(" {");
            string strValue;
            IDictionary getters = GetGetters(obj.GetType());
            bool notFirst = false;
            var arrays = new List<MethodInfo>();
            // First step - all values properties (not a list)
            foreach (string name in getters.Keys)
            {
                var getter = (MethodInfo)getters[name];
                Type propType = getter.ReturnType;
                if (propType == typeof(object))
                    continue;
                if (
                    !(propType == typeof(string) || propType == typeof(bool) || propType == typeof(double) ||
                      propType == typeof(DateTime) || propType == typeof(int) || propType == typeof(long)))
                {
                    string propTypeName = propType.Name;
                    if (propTypeName.StartsWith("Dictionary") || propTypeName.StartsWith("List"))
                    {
                        arrays.Add(getter);
                    }
                    continue;
                }

                try
                {
                    value = getter.Invoke(obj, new object[] { });
                }
                catch
                {
                    continue;
                }

                if (value == null)
                    continue;
                if (value is string)
                {
                    strValue = (string)value;
                    if (strValue.Length == 0)
                        continue;
                }
                else if (value is bool)
                {
                    strValue = ((bool)value ? "true" : "false");
                }
                else if (value is double)
                {
                    var d = (double)value;
                    if (d == 0.0)
                        continue;
                    strValue = d.ToString();
                }
                else if (value is DateTime)
                {
                    var dt = (DateTime)value;
                    if (dt == DateTime.MinValue)
                        continue;
                    strValue = dt.ToLongTimeString();
                }
                else if (value is int)
                {
                    var i = (int)value;
                    if (i == 0)
                        continue;
                    strValue = i.ToString();
                }
                else if (value is long)
                {
                    var l = (long)value;
                    if (l == 0)
                        continue;
                    strValue = l.ToString();
                }
                else
                    strValue = value.ToString();

                if (notFirst)
                    sb.Append("; ");
                notFirst = true;
                sb.Append(string.Concat(getter.Name.Substring(4), ":", strValue));
            }

            // Second step - all lists
            foreach (var getter in arrays)
            {
                value = null;
                try
                {
                    value = getter.Invoke(obj, new object[] { });
                }
                catch
                {
                    continue;
                }
                if (value == null)
                    continue;

                #region List 

                IList list;
                if (value is IList && (list = (IList)value).Count > 0)
                {
                    if (notFirst)
                        sb.Append("; ");
                    notFirst = true;
                    sb.Append(getter.Name.Substring(4));
                    sb.Append(":[");
                    bool notFirst2 = false;
                    foreach (var o in list)
                    {
                        if (notFirst2)
                            sb.Append("; ");
                        notFirst2 = true;
                        sb.Append(o);
                    }
                    sb.Append("]");
                }
                #endregion

                #region IDictionary 
                if (value is IDictionary && ((IDictionary)value).Count > 0)
                {
                    if (notFirst)
                        sb.Append("; ");
                    notFirst = true;
                    sb.Append(getter.Name.Substring(4));
                    sb.Append(":[");
                    bool notFirst2 = false;
                    foreach (var key in ((IDictionary)value).Keys)
                    {
                        object o = ((IDictionary)value)[key];
                        if (notFirst2)
                            sb.Append("; ");
                        notFirst2 = true;
                        sb.Append(string.Concat(key, ":", o));
                    }
                    sb.Append("]");
                }

                #endregion
            }

            sb.Append("}");
            return sb.ToString();
        }

        /// <summary>
        ///     Returns a Map of getter methods of the given class.<br />
        ///     The key of the map contains the name of the attribute that can be accessed by the getter, the
        ///     value the getter itself . A method is considered a getter if its name starts with "get",
        ///     it is declared internal and takes no arguments.
        /// </summary>
        /// <param name="clazz">the class to return the getters for</param>
        /// <returns> a Map of attributes and their accessor methods (getters)</returns>
        internal static Dictionary<string, MethodInfo> GetGetters(Type clazz)
        {
            string name;
            string methodName;
            MethodInfo method;

            var accessors = new Dictionary<string, MethodInfo>();
            MethodInfo[] methods = clazz.GetMethods();

            for (int i = 0; i < methods.Length; i++)
            {
                method = methods[i];
                methodName = method.Name;

                // skip not "get..." methods and  skip methods with != 0 parameters
                if (!methodName.StartsWith("get_") || method.GetParameters().Length != 0)
                    continue;

                name = methodName.Substring(4);
                if (name.Length == 0)
                    continue;
                accessors[name] = method;
            }
            return accessors;
        }

        #endregion

        #region YaroslavRegion
        ///// <summary>
        ///// Временный парсер для ответов
        ///// </summary>
        ///// <param name="ParseString"></param>
        ///// <param name="response"></param>
        ///// <returns></returns>
        //public static string ParseResponse(string ParseString, string response)
        //{
        //    Regex matchExpression1 = new Regex(response);
        //    ParseString = ParseString.Substring(matchExpression1.Match(ParseString).Index);
        //    return ParseString;
        //}
        ///// <summary>
        ///// Возвращает все данные по определенному параметру
        ///// </summary>
        ///// <param name="asterInfo">Информация в строковой переменной</param>
        ///// <param name="matchfinder">Указатель на искомые данные</param>
        ///// <param name="clientsdata">Извлечённые данные</param>
        ///// <param name="number">Число, определяющее количество извлекаемых символов</param>
        //public static List<string> GetDataByParam(string asterinfo, string matchfinder, int number)
        //{
        //    List<string> clientsdata = new List<string>();
        //    Regex matchexpression = new Regex(matchfinder);
        //    foreach (Match match in matchexpression.Matches(asterinfo))
        //    {
        //        string data = asterinfo.Substring(match.Index).Remove(matchfinder.Length + number);
        //        clientsdata.Add(data);
        //    }
        //    return clientsdata;
        //}
        ///// <summary>
        ///// Извлечение данных из информации
        ///// </summary>
        ///// <param name="asterInfo">Информация в строковой переменной</param>
        ///// <param name="matchfinder"></param>
        ///// <param name="clientsdata"></param>
        ///// <param name="more"></param>
        //public static string FindInResponse(string asterInfo, string matchfinder/*, bool moreВот этот аргумент передается очень умным человеком, только для того, чтобы работала перегурзка. Браво!*/)
        //{
        //    Regex matchExpression = new Regex(matchfinder);
        //    if (!matchExpression.Match(asterInfo).Success)
        //        return null;

        //    string sentence = asterInfo.Substring(matchExpression.Match(asterInfo).Index + matchfinder.Length);
        //    int startIndex = sentence.IndexOf('\n');
        //    //2 решения
        //    //sentence = sentence.Replace(System.Environment.NewLine, "");
        //    //string removedBreaks = sentence.Replace("\r\n", "").Replace("\n", "").Replace("\r", "");
        //    return sentence;
        //}

        ///// <summary>
        ///// Извлечение данных из информации
        ///// </summary>
        ///// <param name="asterInfo">Информация в строковой переменной</param>
        ///// <param name="matchfinder">Указатель на искомые данные</param>
        ///// <param name="clientsdata">Извлечённые данные</param>
        ///// <param name="listOfClients">Коллекция массивов строк для извлечённых данных</param>
        //public static string[] DataExtraction(string asterInfo, string matchfinder, string[] clientsdata)
        //{
        //    int num = 0;
        //    if (new Regex(matchfinder).Matches(asterInfo).Count == 0)
        //        return null;

        //    foreach (Match match in new Regex(matchfinder).Matches(asterInfo))
        //    {
        //        string sentence = asterInfo.Substring(match.Index + matchfinder.Length);
        //        int startIndex = sentence.IndexOf('\r');
        //        sentence = sentence.Remove(startIndex);
        //        if (num == clientsdata.Length)
        //        {
        //            break;
        //        }
        //        clientsdata[num] = sentence;
        //        num++;
        //    }

        //    return (string[])clientsdata.Clone();
        //}



        ///// <summary>
        ///// Извлечение данных из иформации
        ///// </summary>
        ///// <param name="asterInfo">Строковая переменная, из которой извлекаются данные</param>
        ///// <param name="matchfinder">Совпадение, которое нужно отысказть</param>
        ///// <param name="clientsdata">Коллекция строк, в которую извлечены данные</param>
        //public static List<string> DataExtraction(string asterInfo, string matchfinder)
        //{
        //    List<string> clientsdata = new List<string>();
        //    Regex matchExpression = new Regex(matchfinder);
        //    foreach (Match match in matchExpression.Matches(asterInfo))
        //    {
        //        string sentence = asterInfo.Substring(matchExpression.Match(asterInfo).Index + matchfinder.Length);
        //        int startIndex = sentence.IndexOf('\n');
        //        if (startIndex == -1)
        //            return null;

        //        sentence = sentence.Remove(startIndex);
        //        clientsdata.Add(sentence);
        //    }
        //    return clientsdata;
        //}
        #endregion
    }
}

