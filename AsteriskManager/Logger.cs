#define LOG
using System;
using System.IO;
using System.Threading;

namespace AsteriskManager
{
    public class AmiLogger
    {
        //Путь к папке логов
        public string LogFilePath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\B-Cti\\log\\" + DateTime.Today.ToShortDateString() + "\\";
        //Семафор на запись
        public AutoResetEvent EventSemaphore = new AutoResetEvent(true);
        //Дескриптор до файла
        StreamWriter file = null;
        //Функция записи в лог
        public void WriteLog(string log)
        {
#if LOG
            EventSemaphore.WaitOne();
            DateTime date = DateTime.Now;
            try
            {
                if (!Directory.Exists(LogFilePath))
                {
                    Directory.CreateDirectory(LogFilePath);
                }
                file = new StreamWriter(LogFilePath + "ami"+ ".log", true);
                file.WriteLine(date.ToString());
                file.WriteLine(log);
                file.Close();
            }
            catch (Exception)
            {
                try
                {
                    file.Close();
                }
                catch
                {
                }
            }
            EventSemaphore.Set();

#endif
        }
    }
}
