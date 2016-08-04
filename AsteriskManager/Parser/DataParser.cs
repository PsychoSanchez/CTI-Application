using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace AsteriskManager.Parser
{
    class DataParser
    {
        /// <summary>
        /// Поиск параметра в ответе из запроса. Пока не протестирую не пойму как она работает.
        /// Так что пока оставлю так.
        /// </summary>
        /// <param name="asterInfo">Информация в строковой переменной</param>
        /// <param name="matchfinder">Указатель на искомые данные</param>
        public static string GetParameterValue(string asterInfo, string parameterName)
        {
            Regex matchExpression = new Regex(parameterName);
            if (!matchExpression.Match(asterInfo).Success)
                return null;

            string sentence = asterInfo.Substring(matchExpression.Match(asterInfo).Index + parameterName.Length);
            int startIndex = sentence.IndexOf('\r');
            if (startIndex == -1)
                startIndex = sentence.IndexOf('\n');
            if (startIndex == -1)
                return null;

            sentence = sentence.Remove(startIndex);
            return sentence;
        }
        /// <summary>
        /// Возвращает все данные по определенному параметру
        /// </summary>
        /// <param name="asterInfo">Информация в строковой переменной</param>
        /// <param name="matchfinder">Указатель на искомые данные</param>
        /// <param name="clientsdata">Извлечённые данные</param>
        /// <param name="number">Число, определяющее количество извлекаемых символов</param>
        public static List<string> GetDataByParam(string asterInfo, string matchfinder, int number)
        {
            List<string> clientsdata = new List<string>();
            Regex matchExpression = new Regex(matchfinder);
            foreach (Match match in matchExpression.Matches(asterInfo))
            {
                string data = asterInfo.Substring(match.Index).Remove(matchfinder.Length + number);
                clientsdata.Add(data);
            }
            return clientsdata;
        }
        /// <summary>
        /// Извлечение данных из информации
        /// </summary>
        /// <param name="asterInfo">Информация в строковой переменной</param>
        /// <param name="matchfinder"></param>
        /// <param name="clientsdata"></param>
        /// <param name="more"></param>
        public static string FindInResponse(string asterInfo, string matchfinder/*, bool moreВот этот аргумент передается очень умным человеком, только для того, чтобы работала перегурзка. Браво!*/)
        {
            Regex matchExpression = new Regex(matchfinder);
            if (!matchExpression.Match(asterInfo).Success)
                return null;

            string sentence = asterInfo.Substring(matchExpression.Match(asterInfo).Index + matchfinder.Length);
            int startIndex = sentence.IndexOf('\n');
            //2 решения
            //sentence = sentence.Replace(System.Environment.NewLine, "");
            //string removedBreaks = sentence.Replace("\r\n", "").Replace("\n", "").Replace("\r", "");
            return sentence;
        }

        /// <summary>
        /// Извлечение данных из информации
        /// </summary>
        /// <param name="asterInfo">Информация в строковой переменной</param>
        /// <param name="matchfinder">Указатель на искомые данные</param>
        /// <param name="clientsdata">Извлечённые данные</param>
        /// <param name="listOfClients">Коллекция массивов строк для извлечённых данных</param>
        public static string[] DataExtraction(string asterInfo, string matchfinder, string[] clientsdata)
        {
            int num = 0;
            if (new Regex(matchfinder).Matches(asterInfo).Count == 0)
                return null;

            foreach (Match match in new Regex(matchfinder).Matches(asterInfo))
            {
                string sentence = asterInfo.Substring(match.Index + matchfinder.Length);
                int startIndex = sentence.IndexOf('\r');
                sentence = sentence.Remove(startIndex);
                if (num == clientsdata.Length)
                {
                    break;
                }
                clientsdata[num] = sentence;
                num++;
            }

            return (string[])clientsdata.Clone();
        }

      

        /// <summary>
        /// Извлечение данных из иформации
        /// </summary>
        /// <param name="asterInfo">Строковая переменная, из которой извлекаются данные</param>
        /// <param name="matchfinder">Совпадение, которое нужно отысказть</param>
        /// <param name="clientsdata">Коллекция строк, в которую извлечены данные</param>
        public static List<string> DataExtraction(string asterInfo, string matchfinder)
        {
            List<string> clientsdata = new List<string>();
            Regex matchExpression = new Regex(matchfinder);
            foreach (Match match in matchExpression.Matches(asterInfo))
            {
                string sentence = asterInfo.Substring(matchExpression.Match(asterInfo).Index + matchfinder.Length);
                int startIndex = sentence.IndexOf('\n');
                if (startIndex == -1)
                    return null;

                sentence = sentence.Remove(startIndex);
                clientsdata.Add(sentence);
            }
            return clientsdata;
        }
    }
}
