using AsteriskManager;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace BCTI.Settings
{
    /// <summary>
    /// Класс для сохранения и загрузки данных о звонках и контактах
    /// </summary>
    public class XMLReadWriter
    {
        private static string path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

        #region HistoryMethods
        public static string HistorOfRingsPath = path + "\\B-Cti\\HistoryOfRings.xml";
        /// <summary>
        /// Проверка на существование файла с историей звонков
        /// </summary>
        /// <returns></returns>
        public static bool IsHistoryExists()
        {
            return File.Exists(path + "\\B-Cti\\HistoryOfRings.xml");
        }
        /// <summary>
        /// Запись истории звонков в файл
        /// </summary>
        /// <param name="ringList">Список звонков</param>
        public static void WriteHistory(List<RingInfo> ringList)
        {
            XmlSerializer xs = new XmlSerializer(typeof(List<RingInfo>));
            if (!Directory.Exists(path + "\\B-cti")) Directory.CreateDirectory(path + "\\B-cti");
            StreamWriter sw = new StreamWriter(path + "\\B-cti\\HistoryOfRings.xml");
            try
            {
                xs.Serialize(sw, ringList);
                sw.Flush();
                sw.Close();
            }
            catch (InvalidOperationException)
            {
                sw.Close();
            }
        }
        /// <summary>
        /// Чтение истории из файла
        /// </summary>
        /// <returns></returns>
        public static List<RingInfo> ReadHistory()
        {
            if (File.Exists(path + "\\B-Cti\\HistoryOfRings.xml"))
            {
                XmlSerializer xs = new XmlSerializer(typeof(List<RingInfo>));
                StreamReader sr = new StreamReader(path + "\\B-Cti\\HistoryOfRings.xml");
                try
                {
                    List<RingInfo> rings = (List<RingInfo>)xs.Deserialize(sr);
                    sr.Close();
                    return rings;
                }
                catch (InvalidOperationException)
                {
                    sr.Close();
                    File.Delete(path + "\\B-Cti\\HistoryOfRings.xml");
                    return new List<RingInfo>();
                }
            }
            else
            {
                StreamWriter sr = new StreamWriter(path + "\\B-Cti\\HistoryOfRings.xml");
                sr.Flush();
                sr.Close();
                //File.Create(path + "\\B-Cti\\HistoryOfRings.xml");
                return new List<RingInfo>();
            }
        }
        #endregion

        #region ContactsMethods
        /// <summary>
        /// Проверка существования файла с контактами
        /// </summary>
        /// <returns></returns>
        public static bool IsContactsExists()
        {
            return File.Exists(path + "\\B-Cti\\ContactsBook.xml");
        }
        /// <summary>
        /// Запись данных о контактах в файл
        /// </summary>
        /// <param name="BookOfContacts"></param>
        public static void WriteContacts(List<ClientsData> BookOfContacts)
        {
            XmlSerializer xs = new XmlSerializer(typeof(List<ClientsData>));
            if (!Directory.Exists(path + "\\B-cti")) Directory.CreateDirectory(path + "\\B-cti");
            StreamWriter sw = new StreamWriter(path + "\\B-cti\\ContactsBook.xml");
            try
            {
                xs.Serialize(sw, BookOfContacts);
                sw.Flush();
                sw.Close();
            }
            catch (InvalidOperationException)
            {
                sw.Close();
            }
        }
        /// <summary>
        /// Чтение данных о контактах из фалйа
        /// </summary>
        /// <returns></returns>
        public static List<ClientsData> ReadContactsL()
        {
            if (File.Exists(path + "\\B-Cti\\ContactsBook.xml"))
            {
                XmlSerializer xs = new XmlSerializer(typeof(List<ClientsData>));
                StreamReader sr = new StreamReader(path + "\\B-Cti\\ContactsBook.xml");
                try
                {
                    List<ClientsData> contacts = (List<ClientsData>)xs.Deserialize(sr);
                    sr.Close();
                    return contacts;
                }
                catch (InvalidOperationException)
                {
                    sr.Close();
                    File.Delete(path + "\\B-Cti\\ContactsBook.xml");
                    return new List<ClientsData>();
                }
            }
            else
            {
                StreamWriter sr = new StreamWriter(path + "\\B-Cti\\ContactsBook.xml");
                sr.Flush();
                sr.Close();
                //File.Create(path + "\\B-Cti\\ContactsBook.xml");
                return new List<ClientsData>();
            }
        }
        /// <summary>
        /// Чтение данных о контактах из фалйа
        /// </summary>
        /// <returns></returns>
        public static Dictionary<string,ClientsData> ReadContactsD()
        {
            if (File.Exists(path + "\\B-Cti\\ContactsBook.xml"))
            {
                XmlSerializer xs = new XmlSerializer(typeof(List<ClientsData>));
                StreamReader sr = new StreamReader(path + "\\B-Cti\\ContactsBook.xml");
                try
                {
                    Dictionary<string, ClientsData> dick = new Dictionary<string, ClientsData>();
                    List<ClientsData> contacts = (List<ClientsData>)xs.Deserialize(sr);
                    foreach(var contact in contacts)
                    {
                        dick.Add(contact.Number, contact);
                        if(!string.IsNullOrEmpty(contact.SecondNumber))
                        {
                            dick.Add(contact.SecondNumber, contact);
                        }
                    }
                    sr.Close();
                    return dick;
                }
                catch (InvalidOperationException)
                {
                    sr.Close();
                    File.Delete(path + "\\B-Cti\\ContactsBook.xml");
                    return new Dictionary<string, ClientsData>();
                }
            }
            else
            {
                StreamWriter sr = new StreamWriter(path + "\\B-Cti\\ContactsBook.xml");
                sr.Flush();
                sr.Close();
                //File.Create(path + "\\B-Cti\\ContactsBook.xml");
                return new Dictionary<string, ClientsData>();
            }
        }
        #endregion
    }
}

