#define LOG
using System;
using System.IO;
using System.Threading;

namespace BCTI
{
    public class EventLogs
    {
        /// <summary>
        /// Структура для события записи в лог
        /// Нужна для журнала событий
        /// </summary>
        public class EventLogArgs : EventArgs
        {
            public EventLogArgs(string _event)
            {
                EventName = _event;
                AdditionalInfo = string.Empty;
            }
            public EventLogArgs(string _event, string _addInfo)
            {
                EventName = _event;
                AdditionalInfo = _addInfo;
            }
            public string EventName { get; private set; }
            public string AdditionalInfo { get; private set; }
        }
        public static event EventHandler<EventLogArgs> StreamWriteEvent;
        public static AutoResetEvent EventSemaphore = new AutoResetEvent(true);
        /// <summary>
        /// Путь у папке логов с разметкой текущей даты
        /// </summary>
        public static string EventLogFilePath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\B-Cti\\log\\" + DateTime.Today.ToShortDateString() + "\\";
        #region StaticWriteLogMethods
        /// <summary>
        /// Событие и дополнительная информация
        /// </summary>
        /// <param name="_event"></param>
        /// <param name="addInfo"></param>
        public static void WriteLog(string _event, string addInfo)
        {
            EventLogArgs e = new EventLogArgs(_event, addInfo);
#if LOG
            EventSemaphore.WaitOne();
            try
            {
                if (!Directory.Exists(EventLogFilePath))
                {
                    Directory.CreateDirectory(EventLogFilePath);
                }
                StreamWriter log = new StreamWriter(EventLogFilePath + "EventLog.log", true);
                DateTime date = DateTime.Now;
                log.WriteLine("# " + date);
                log.WriteLine(_event);
                log.WriteLine(addInfo);
                log.WriteLine();
                log.Close();
            }
            catch (Exception)
            {
                EventSemaphore.Set();
                return;
            }
            StreamWriteEvent?.Invoke(null, e);
            EventSemaphore.Set();
#endif
        }
        /// <summary>
        /// Только событие без дополнительной информации
        /// </summary>
        /// <param name="_event"></param>
        public static void WriteLog(string _event)
        {
            EventLogArgs e = new EventLogArgs(_event);
#if LOG
            EventSemaphore.WaitOne();
            try
            {
                if (!Directory.Exists(EventLogFilePath))
                {
                    Directory.CreateDirectory(EventLogFilePath);
                }
                StreamWriter log = new StreamWriter(EventLogFilePath + "EventLog.log", true);
                DateTime date = DateTime.Now;
                log.WriteLine("# " + date);
                log.WriteLine(e.EventName);
                log.WriteLine();
                log.Close();
            }
            catch (Exception)
            {
                EventSemaphore.Set();
                return;
            }
            StreamWriteEvent?.Invoke(null, e);
            EventSemaphore.Set();
#endif
        } 
        #endregion
    }
    public class HotkeyLog
    {
        /// <summary>
        /// Структура для события записи в лог
        /// Нужна для журнала событий
        /// </summary>
        public class EventLogArgs : EventArgs
        {
            public EventLogArgs(string _event)
            {
                EventName = _event;
                AdditionalInfo = string.Empty;
            }
            public EventLogArgs(string _event, string _addInfo)
            {
                EventName = _event;
                AdditionalInfo = _addInfo;
            }
            public string EventName { get; private set; }
            public string AdditionalInfo { get; private set; }
        }
        public static event EventHandler<EventLogArgs> StreamWriteEvent;
        public static AutoResetEvent EventSemaphore = new AutoResetEvent(true);
        /// <summary>
        /// Путь у папке логов с разметкой текущей даты
        /// </summary>
        public static string EventLogFilePath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\B-Cti\\log\\" + DateTime.Today.ToShortDateString() + "\\";
        #region StaticWriteLogMethods
        /// <summary>
        /// Событие и дополнительная информация
        /// </summary>
        /// <param name="_event"></param>
        /// <param name="addInfo"></param>
        public static void WriteLog(string _event, string addInfo)
        {
            EventLogArgs e = new EventLogArgs(_event, addInfo);
#if LOG
            EventSemaphore.WaitOne();
            try
            {
                if (!Directory.Exists(EventLogFilePath))
                {
                    Directory.CreateDirectory(EventLogFilePath);
                }
                StreamWriter log = new StreamWriter(EventLogFilePath + "Hotkey.log", true);
                DateTime date = DateTime.Now;
                log.WriteLine("# " + date);
                log.WriteLine(_event);
                log.WriteLine(addInfo);
                log.WriteLine();
                log.Close();
            }
            catch (Exception)
            {
                EventSemaphore.Set();
                return;
            }
            StreamWriteEvent?.Invoke(null, e);
            EventSemaphore.Set();
#endif
        }
        /// <summary>
        /// Только событие без дополнительной информации
        /// </summary>
        /// <param name="_event"></param>
        public static void WriteLog(string _event)
        {
            EventLogArgs e = new EventLogArgs(_event);
#if LOG
            EventSemaphore.WaitOne();
            try
            {
                if (!Directory.Exists(EventLogFilePath))
                {
                    Directory.CreateDirectory(EventLogFilePath);
                }
                StreamWriter log = new StreamWriter(EventLogFilePath + "Hotkey.log", true);
                DateTime date = DateTime.Now;
                log.WriteLine("# " + date);
                log.WriteLine(e.EventName);
                log.WriteLine();
                log.Close();
            }
            catch (Exception)
            {
                EventSemaphore.Set();
                return;
            }
            StreamWriteEvent?.Invoke(null, e);
            EventSemaphore.Set();
#endif
        }
        #endregion
    }
}
