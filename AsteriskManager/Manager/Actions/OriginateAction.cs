using System.Text;
using System.Collections.Generic;
using AsteriskManager.Exceptions;

namespace AsteriskManager.Manager.Actions
{
    class OriginateAction : ActionManager
    {
        #region Переменные
        /// <summary>
        /// Параметры взяты оттуда: http://www.voip-info.org/wiki/view/Asterisk+Manager+API+Action+Originate
        /// </summary>
        private string _account = string.Empty;
        private string _application = string.Empty;
        private string _callerid = string.Empty;
        private string _async = string.Empty;
        private string _channel = string.Empty;
        private string _context = string.Empty;
        private string _data = string.Empty;
        private string _exten = string.Empty;
        private Dictionary<string, string> variables;
        private int _priority = -1;
        private long _timeout = 30000;
        calltype Type;

        enum calltype
        {
            SipToExten = 1,
            AppCommand,
            OutgoingToLoacal,
            Default
        }
        #endregion
        #region Основные параметры
        public string Async
        {
            get { return _async; }
            set { _async = value; }
        }
        /// <summary>
        /// Account code для звонка, 
        /// который включен в детали сгенерированныые для этого звонка 
        /// и будет использован для выставления счета
        /// </summary>
        public string Account
        {
            get { return _account; }
            set { _account = value; }
        }
        /// <summary>
        /// caller id sets on the outgoing channel
        /// </summary>
        public string CallerId
        {
            get { return _callerid; }
            set { _callerid = value; }
        }

        /// <summary>
        /// Обязательная переменная
        /// </summary>
        public string Channel
        {
            get { return _channel; }
            set { _channel = value; }
        }
        /// <summary>
        /// В случае если задан контекст, обязательны Exten и Priority
        /// </summary>
        public string Context
        {
            get { return _context; }
            set { _context = value; }
        }
        /// <summary>
        /// Экстеншн к которому подключаемся
        /// Необходим контекст и приоритет
        /// </summary>
        public string Exten
        {
            get { return _exten; }
            set { _exten = value; }
        }
        /// <summary>
        /// Приоритет подключения к экстеншну
        /// Обязательные поля котнтекст и экстен
        /// </summary>
        public int Priority
        {
            get { return _priority; }
            set { _priority = value; }
        }
        #endregion

        #region Дополнительные параметры
        public Dictionary<string, string> GetVariables()
        {
            return variables;
        }
        public void SetVariables(Dictionary<string, string> vars)
        {
            variables = vars;
        }
        /// <summary>
        /// Название приложения к которому нужно подключиться
        /// </summary>
        public string Application
        {
            get { return _application; }
            set { _application = value; }
        }
        /// <summary>
        /// Дополнительные параметры для приложения
        /// </summary>
        public string Data
        {
            get { return _data; }
            set { _data = value; }
        }
        /// <summary>
        /// Таймаут с момента создания звонка (В секундах)
        /// Канал должен ответить в течении данного промежутка времени, иначе будет сгенерирован OrginateFailureEvent
        /// По умолчанию 30 секунд
        /// </summary>
        public long Timeout
        {
            get { return _timeout / 1000; }
            set { _timeout = value * 1000; }
        }
        #endregion
        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        /// <param name="channel"></param>
        public OriginateAction(string channel)
        {
            _channel = channel;
            Type = calltype.Default;
        }
        /// <summary>
        /// Конструтор для звонка с сип канала на экстеншн 1
        /// </summary>
        /// <param name="client"></param>
        /// <param name="exten"></param>
        /// <param name="priority"></param>
        public OriginateAction(ClientsData client, string exten, int priority)
        {
            _exten = exten;
            _channel = client.getchannel();
            _context = client.Context;
            _priority = priority;
            Type = calltype.SipToExten;
        }
        /// <summary>
        /// Конструтор для звонка с сип канала на экстеншн 2
        /// </summary>
        /// <param name="channel"></param>
        /// <param name="context"></param>
        /// <param name="exten"></param>
        /// <param name="priority"></param>
        public OriginateAction(string channel, string context, string exten, int priority)
        {
            _exten = exten;
            _channel = channel;
            _context = context;
            _priority = priority;
            Type = calltype.SipToExten;
        }

        /// <summary>
        /// Конструктор для вызова команд из приложений на сервере
        /// </summary>
        /// <param name="channel"></param>
        /// <param name="application"></param>
        /// <param name="data"></param>
        public OriginateAction(string channel, string application, string data)
        {
            _application = application;
            _channel = channel;
            _data = data;
            Type = calltype.AppCommand;
        }

        public override string Action
        {
            get
            {
                return "Originate";
            }
        }

        public override string Parameters
        {
            get
            {
                switch (Type)
                {
                    case calltype.Default:
                        {
                            if (string.IsNullOrEmpty(_channel))
                            {
                                throw new AmiException("Failure: Channel is empty in originateaction"); //Допилить эксепшн
                            }
                            StringBuilder sb = new StringBuilder();
                            sb.Append(string.Concat("Channel: ", _channel, Helper.LINE_SEPARATOR));
                            if (!string.IsNullOrEmpty(_context))
                            {
                                sb.Append(string.Concat("Context: ", _context, Helper.LINE_SEPARATOR));
                            }
                            if (!string.IsNullOrEmpty(_exten))
                            {
                                sb.Append(string.Concat("Exten: ", _exten, Helper.LINE_SEPARATOR));
                            }
                            if (_priority != -1)
                            {
                                sb.Append(string.Concat("Priority: ", _priority, Helper.LINE_SEPARATOR));
                            }
                            if (variables.Count > 0)
                            {
                                sb.Append(string.Concat("Variable: "));
                                foreach (KeyValuePair<string, string> value in variables)
                                {
                                    sb.Append(string.Concat(value.Key, "=", value.Value, "|"));
                                }
                                sb.Length--;
                                sb.Append(Helper.LINE_SEPARATOR);
                            }
                            if (_timeout != 30000)
                                sb.Append(string.Concat("Timeout: ", _timeout, Helper.LINE_SEPARATOR));
                            return sb.ToString();
                        }
                    case calltype.AppCommand:
                        {
                            if (string.IsNullOrEmpty(_channel) || string.IsNullOrEmpty(_application) || string.IsNullOrEmpty(_data))
                            {
                                throw new AmiException("Failure: Unable to create appcomand in originateaction"); //Допилить эксепшн
                            }
                            StringBuilder sb = new StringBuilder();
                            sb.Append(string.Concat("Channel: ", _channel, Helper.LINE_SEPARATOR));
                            sb.Append(string.Concat("Application: ", _application, Helper.LINE_SEPARATOR));
                            sb.Append(string.Concat("Data: ", _data, Helper.LINE_SEPARATOR));
                            if (_priority != -1)
                            {
                                sb.Append(string.Concat("Priority: ", _priority, Helper.LINE_SEPARATOR));
                            }
                            if (variables.Count > 0)
                            {
                                sb.Append(string.Concat("Variable: "));
                                int i = 0;
                                foreach (KeyValuePair<string, string> value in variables)
                                {
                                    i++;
                                    if (i == variables.Count)
                                    {
                                        sb.Append(string.Concat(value.Key, value.Value));
                                    }
                                    else
                                    {
                                        sb.Append(string.Concat(value.Key, "=\"", value.Value, "\"", "|"));
                                    }
                                }
                                sb.Length--;
                                sb.Append(Helper.LINE_SEPARATOR);
                            }
                            if (_timeout != 30000)
                                sb.Append(string.Concat("Timeout: ", _timeout, Helper.LINE_SEPARATOR));
                            return sb.ToString();
                        }

                    case calltype.SipToExten:
                        {

                            if (string.IsNullOrEmpty(_channel) || string.IsNullOrEmpty(_context) || string.IsNullOrEmpty(_exten) || _priority == -1)
                            {
                                throw new AmiException("Failure: Channel or context or exten is empty in originateaction"); //Допилить эксепшн
                            }
                            StringBuilder sb = new StringBuilder();
                            sb.Append(string.Concat("Channel: ", _channel, Helper.LINE_SEPARATOR));
                            sb.Append(string.Concat("Context: ", _context, Helper.LINE_SEPARATOR));
                            sb.Append(string.Concat("Exten: ", _exten, Helper.LINE_SEPARATOR));
                            sb.Append(string.Concat("Priority: ", _priority, Helper.LINE_SEPARATOR));
                            if (!string.IsNullOrEmpty(_callerid))
                            {
                                sb.Append(string.Concat("Callerid: ", _callerid, Helper.LINE_SEPARATOR));
                            }
                            if (!string.IsNullOrEmpty(_async))
                            {
                                sb.Append(string.Concat("Async: ", _async, Helper.LINE_SEPARATOR));
                            }
                            if (variables != null)
                                if (variables.Count > 0)
                                {
                                    sb.Append(string.Concat("Variable: "));
                                    int i = 0;
                                    foreach (KeyValuePair<string, string> value in variables)
                                    {
                                        i++;
                                        if (i == variables.Count)
                                        {
                                            sb.Append(string.Concat(value.Key, value.Value));
                                        }
                                        else
                                        {
                                            sb.Append(string.Concat(value.Key, "=\"", value.Value, "\"", "|"));
                                        }
                                    }
                                    sb.Length--;
                                    sb.Append(Helper.LINE_SEPARATOR);
                                }
                            if (_timeout != 30000)
                                sb.Append(string.Concat("Timeout: ", _timeout, Helper.LINE_SEPARATOR));
                            return sb.ToString();
                        }
                    case calltype.OutgoingToLoacal:
                        {
                            if (string.IsNullOrEmpty(_channel) || string.IsNullOrEmpty(_context) || string.IsNullOrEmpty(_exten) || _priority == -1)
                            {
                                throw new AmiException("Failure: Channel or context or exten is empty in originateaction"); //Допилить эксепшн
                            }
                            StringBuilder sb = new StringBuilder();
                            sb.Append(string.Concat("Channel: ", _channel, Helper.LINE_SEPARATOR));
                            sb.Append(string.Concat("Context: ", _context, Helper.LINE_SEPARATOR));
                            sb.Append(string.Concat("Exten: ", _exten, Helper.LINE_SEPARATOR));
                            sb.Append(string.Concat("Priority: ", _priority, Helper.LINE_SEPARATOR));
                            if (!string.IsNullOrEmpty(_callerid))
                            {
                                sb.Append(string.Concat("Callerid: ", _callerid, Helper.LINE_SEPARATOR));
                            }
                            if (_timeout != 30000)
                                sb.Append(string.Concat("Timeout: ", _timeout, Helper.LINE_SEPARATOR));
                            return sb.ToString();

                            //Пока не очень понимаю как это должно работать
                        }
                    default:
                        return null;
                }
            }
        }
    }
}
