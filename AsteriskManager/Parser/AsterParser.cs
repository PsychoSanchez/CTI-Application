//#define CONSOLEDEBUG
using System;
using System.Collections.Generic;
using AsteriskManager.Manager.Event;
using System.Threading;

namespace AsteriskManager.Parser
{
    class AsterParser
    {
        /// <summary>
        /// Ивент для запуска парса
        /// </summary>
        public static AutoResetEvent startParse = new AutoResetEvent(false);
        /// <summary>
        /// Общая память для сообщения
        /// </summary>
        public static string Response { get; set; }
        /// <summary>
        /// Функция парсер Respose сообщений
        /// </summary>
        /// <param name="Responses">Получает список Response сообещний для структуризации</param>
        private static void ParseResponse(List<string> Responses)
        {
            foreach (string _message in Responses)
            {
                string message = Helper.GetParameterValue(_message, "Response: ");
                switch (message)
                {
                    case "Success":

                        if (_message.Contains("Message: "))
                        {
                            if (_message.Contains("Authentication"))
                            {
                                if (_message.Contains(Helper.MachineID))
                                    new LoginEvent(_message);
                            }
                            else if (_message.Contains("Originate successfully"))
                            {
                                if (_message.Contains(Helper.MachineID))
                                    new OriginateEvent(_message);
                            }
                        }
                        else if (_message.Contains("Channeltype: ") && _message.Contains("Context: ") && _message.Contains("Address-IP: "))
                        {
                            if (_message.Contains(Helper.MachineID))
                                new SIPShowPeerEvent(_message);
                        }
                        else if (_message.Contains("Challenge: "))
                        {
                            new ChallengeEvent(_message);
                        }
                        break;
                    case "Error":
                        if (_message.Contains("Authentication"))
                        {
                            if (_message.Contains(Helper.MachineID))
                                new LoginEvent();
                        }
                        else if (_message.Contains("Peer") && _message.Contains("not found"))
                        {
                            if (_message.Contains(Helper.MachineID))
                                new SIPShowPeerEvent();
                        }
                        else if (_message.Contains("Extension") && _message.Contains("not exist"))
                        {
                            if (_message.Contains(Helper.MachineID))
                                new OriginateEvent();
                        }
                        break;
                    case "Follows":
                        if (_message.Contains("Channel              Location"))
                        {
                            if (_message.Contains(Helper.MachineID))
                                new CoreShowChannelsEvent(Helper.GetChannelsInfo(_message));
                        }
                        break;
                    default:
                        break;
                }

            }
        }
        /// <summary>
        /// Функция парсер Event сообщений
        /// </summary>
        /// <param name="Events">Получает список Event сообещний для структуризации</param>
        private static void ParseEvent(List<string> Events)
        {
            foreach (string _message in Events)
            {
                string sub = Helper.GetParameterValue(_message, "Event: ");
                switch (sub)
                {
                    case "Bridge":
#if CONSOLEDEBUG
                        Console.WriteLine("Пришло сообщение с bridge");
#endif
                        break;
                    case "Dial":
                        var SubEvent = Helper.GetParameterValue(_message, "SubEvent: ");
                        if (SubEvent.Equals("End"))
                        {
                            new DialEndEvent(_message);
                        }
                        else
                        {
                            new DialBegin11(_message);
                        }
                        break;
                    case "DialBegin":
                        new DialBeginEvent(_message);
                        break;
                    case "DialEnd":
                        new DialEndEvent(_message);
                        break;
                    case "ExstensionStatus":
#if CONSOLEDEBUG
                        Console.WriteLine("Пришло сообщение со ExstensionStatus клиента");
#endif
                        break;
                    case "Hangup":
                        new HangupEvent(_message);
                        break;
                    case "Hold":
                        new HoldEvent(_message);
                        break;
                    case "MusicOnHold":
#if CONSOLEDEBUG
                        Console.WriteLine("Пришло сообщение с MusicOnHold");
#endif
                        break;
                    case "NewCallerid":
                        new NewstateEvent(_message);
                        break;
                    case "Newchannel":
                        new NewChannelEvent(_message);
                        break;
                    case "Newstate":
                        new NewstateEvent(_message);
                        break;
                    case "OriginateResponse":
                        if (_message.Contains(Helper.MachineID))
                            new OriginateResponseEvent(_message);
                        break;
                    case "ParkedCall":
                        if (_message.Contains(Helper.MachineID))
                            new ParkedCallEvent(_message);
                        break;
                    case "ParkedCallsComplete":
                        if (_message.Contains(Helper.MachineID))
                            new ParkedCallsCompleteEvent();
                        break;

                    case "PeerEntry":
                        if (_message.Contains(Helper.MachineID))
                            new PeerEntryEvent(_message);
                        break;

                    case "PeerStatus":
#if CONSOLEDEBUG
                        Console.WriteLine("Пришло сообщение со PeerStatus клиента");
#endif
                        break;
                    case "PeerlistComplete":
                        if (_message.Contains(Helper.MachineID))
                            new PeerlistCompleteEvent(_message);
                        break;
                    case "SoftHangupRequest":
                        //new HangupEvent(_message);
                        break;
                    case "Status":
                        if (_message.Contains(Helper.MachineID))
                            new StatusEvent(_message);
                        break;
                    case "StatusComplete":
#if CONSOLEDEBUG
                        Console.WriteLine("Пришло сообщение со StatusComplete клиента");
#endif
                        break;
                    case "RTCPSent":
                        break;
                    case "RTCPReceived":
                        break;
                    case "Unhold":
                        new UnholdEvent(_message);
                        break;
                    default:
                        break;
                }

            }
        }
        /// <summary>
        /// Основная функция Парсера, крутится в цикле (Ожидающая)
        /// Начинает выполнять действие только когда получит сингнал
        /// Отбрасывает ненужные пакеты и структурирует Response и Event
        /// Ждет следующую пачку сообщений
        /// </summary>
        public static void ParseServerMessage()
        {

            ///Мигающий семафор
            startParse.WaitOne(10000);
            ///Копируем сообщения из общей памяти в локальную и делим на отдельные сообщения
            try
            {
                var messages = Response.Split(Helper.END_MESSAGE, StringSplitOptions.RemoveEmptyEntries);
                List<string> events = new List<string>();
                List<string> responses = new List<string>();
                foreach (string _message in messages)
                {
                    if (_message.Contains("Event: "))
                    {
                        if (!_message.Contains("VarSet")/* && !(_message.Contains("RTCPReceived") && !(_message.Contains("RTCPSent")*/)
                        {
                            events.Add(_message);
                        }
                    }
                    if (_message.Contains("Response: "))
                    {
                        if (!_message.Contains("Pong"))
                        {
                            responses.Add(_message);
                        }
                        else
                        {
                            //DO THMSNG WITH PING
                            //var message = _message.Substring(_message.IndexOf("Timestamp: "));
                            //message += Helper.LINE_SEPARATOR;
                            //int startPos = message.LastIndexOf("Timestamp: ") + "Timestamp: ".Length;
                            //int length = message.IndexOf(LINE_SEPARATOR) - startPos;
                            //string sub = message.Substring(startPos, length);
                            //string sub = DataParser.GetParameterValue(_message, "Timestamp: ");
                            //Console.WriteLine(sub);
                            //var epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
                            //var date = DateTime.Now;
                            //Console.WriteLine(Convert.ToInt64((date - epoch).TotalSeconds));
                        }

                    }
                }
                //var watch = Stopwatch.StartNew();
                ////ParseEvent;
                if (events.Count > 0)
                {
                    ParseEvent(events);
                }
                //////ParseResponse;
                if (responses.Count > 0)
                {
                    ParseResponse(responses);
                }
            }
            catch
            {

            }

            //ParseEvent(Events);
            //ParseResponse(Responses);
            //watch.Stop();
            //Console.WriteLine("Время фовафжаоджфо" + watch.ElapsedMilliseconds);
        }
    }
}
