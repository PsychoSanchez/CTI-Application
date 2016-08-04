
using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Sockets;
using System.Net;
using System.Threading;
using System.Text.RegularExpressions;
using System.IO;
using System.ComponentModel;
using System.Windows;

namespace VirtualServer
{
    public class MessageEvents
    {
        public static event EventHandler<MessageEventArgs> WaitingForRecieve;
        public static event EventHandler<MessageEventArgs> RecievedMessage;
        public static event EventHandler @continue;
        public class MessageEventArgs : EventArgs
        {
            public string Message = string.Empty;
            public MessageEventArgs(string Message)
            {
                this.Message = Message;
            }
        }
        public static void RaiseMessageSend(string message)
        {
            WaitingForRecieve?.Invoke(null, new MessageEventArgs(message));
        }
        public static void Continue()
        {
            @continue?.Invoke(null, null);
        }
        public static void RaiseRecievedMessage(string message)
        {
            RecievedMessage?.Invoke(null, new MessageEventArgs(message));
        }
    }
    public static class Helper
    {
        #region ApiConstants

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
        public static string GetParameterValue(string SourceString, string parameterName)
        {
            if (SourceString.Contains(parameterName))
            {
                var message = SourceString.Substring(SourceString.IndexOf(parameterName));
                message += Helper.LINE_SEPARATOR;
                int startPos = parameterName.Length;
                int length = message.IndexOf(Helper.LINE_SEPARATOR) - startPos;
                message = message.Substring(startPos, length);
                return message;
            }
            else
                return string.Empty;
        }
    }

    public class Simulator
    {
        public List<ServerEntity> MessageLne = new List<ServerEntity>();
        public DateTime StartDate;
        public DateTime EndDate;
        public enum EntityType
        {
            Action = 0,
            Event,
            Response
        }
        public class ServerEntity
        {
            public DateTime EntityTime;
            public string Message;
            public EntityType MessageType = EntityType.Event;
            public ServerEntity(DateTime time, string ServerMessage)
            {
                EntityTime = time;
                Message = ServerMessage;
                switch (ServerMessage.Substring(0, ServerMessage.IndexOf(":")))
                {
                    case "Action":
                        MessageType = EntityType.Action;
                        break;
                    case "Event":
                        MessageType = EntityType.Event;
                        break;
                    case "Response":
                        MessageType = EntityType.Response;
                        break;
                    default:
                        MessageType = EntityType.Event;
                        break;
                }
            }
        }
        public Simulator(string filepath)
        {
            try
            {
                if (File.Exists(filepath))
                {
                    StreamReader file = new StreamReader(filepath);
                    string Message = string.Empty;
                    DateTime TryMessageTime = new DateTime();
                    DateTime MessageTime = new DateTime();
                    while (file.Peek() > 0)
                    {
                        string _line = file.ReadLine();
                        if (DateTime.TryParse(_line, out TryMessageTime))
                        {
                            MessageTime = TryMessageTime;
                            continue;
                        }
                        else
                        {
                            if (_line != string.Empty)
                                Message += _line + "\r\n";
                            else if (Message != string.Empty)
                            {
                                Message += "\r\n";
                            }
                        }

                        if (Message.EndsWith("\r\n\r\n"))
                        {
                            if (!string.IsNullOrEmpty(Message))
                            {
                                MessageLne.Add(new ServerEntity(MessageTime, Message));
                                Message = string.Empty;
                            }
                        }
                    }
                    if (MessageLne.Count > 0)
                    {
                        StartDate = MessageLne[0].EntityTime;
                        EndDate = MessageLne[MessageLne.Count - 1].EntityTime;
                    }
                    else
                    {
                        throw new Exception("Очередь сообщений пуста");
                    }
                }
                else
                {
                    throw new Exception("Файл по данному пути не найден");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Unable to load simulation because: " + ex.Message);
            }
        }
    }


    public class Server
    {
        public class ActionMessageManager
        {
            public string TestActionID;
            public string ActualActionID;
            private string TestMessage;
            private string ActualMessage;
            private string _TestActionID;
            private string _ActualActionID;

            public AutoResetEvent AсtionSend = new AutoResetEvent(false);
            public AutoResetEvent TestId = new AutoResetEvent(true);
            public AutoResetEvent ActualId = new AutoResetEvent(true);

            public bool aRecieved = false;
            public bool aWainintg = false;
            public void ActionRecieved(string ActionID, string Message)
            {
                ActualId.WaitOne();
                ActualMessage = Message;
                _ActualActionID = ActionID;
                aRecieved = true;
                SetSemaphore();
            }
            public void ActionWaiting(string ActionID, string Message)
            {
                if (Message.Contains("Action: Status"))
                    return;
                TestId.WaitOne();
                TestMessage = Message;
                _TestActionID = ActionID;
                aWainintg = true;
                SetSemaphore();
                AсtionSend.WaitOne();
            }
            void SetSemaphore()
            {
                if (aRecieved == true && aWainintg == true)
                {
                    string Message = ActualMessage;
                    if (ActualMessage.Contains("Key: ") && ActualMessage.Contains("AuthType: "))
                    {
                        Message = ActualMessage.Substring(0, ActualMessage.IndexOf("Key: "));
                    }
                    if (TestMessage.Replace(_TestActionID, _ActualActionID).Contains(Message))
                    {
                        TestActionID = _TestActionID;
                        ActualActionID = _ActualActionID;
                        aWainintg = false;
                        TestId.Set();
                        aRecieved = false;
                        ActualId.Set();
                        AсtionSend.Set();
                    }
                    else
                    {
                        MessageEvents.RaiseMessageSend("Сообщение не совапало с ожидаемым: " + TestMessage);
                    }
                }
            }
            public void SkipAction()
            {
                TestId.Set();
                AсtionSend.Set();
            }
        }
        // Класс-обработчик клиента
        public class Client
        {
            public int MessageID = 0;
            private ClientSimInfo info;
            BackgroundWorker Reciever;
            BackgroundWorker Sender;
            ActionMessageManager manager;

            private void SendMessage(string Message)
            {
                if (Message.Contains("ActionID: "))
                {
                    Message = Message.Replace(manager.TestActionID, manager.ActualActionID);
                }

                if (!Message.EndsWith("\r\n\r\n"))
                {
                    Message += "\r\n\r\n";
                }
                if (Message == "\r\n\r\n" || string.IsNullOrEmpty(Message))
                    return;
                //Console.WriteLine(MessageID);
                byte[] Buffer = Encoding.ASCII.GetBytes(Message);
                info._client.GetStream().Write(Buffer, 0, Buffer.Length);
            }

            private void SendPing(string ActionID)
            {
                string Message = string.Empty;
                Message += "Response: Success\r\nActionID: " + ActionID + "\r\nPing: Pong\r\nTimestamp: 1462362070.431879\r\n\r\n";
                byte[] Buffer = Encoding.ASCII.GetBytes(Message);
                info._client.GetStream().Write(Buffer, 0, Buffer.Length);
            }
            public Client(ClientSimInfo data)
            {
                manager = new ActionMessageManager();
                info = data;
                info._client.ReceiveTimeout = 100000;
                info._client.SendTimeout = 1000000;
                Reciever = new BackgroundWorker();
                Reciever.WorkerSupportsCancellation = true;
                Reciever.DoWork += Reciever_DoWork;
                Reciever.RunWorkerAsync();

                Sender = new BackgroundWorker();
                Sender.WorkerSupportsCancellation = true;
                Sender.DoWork += Sender_DoWork;
                Sender.RunWorkerAsync();
                MessageEvents.@continue += MessageEvents_Continue;
            }



            public void ClientDesconnect()
            {
                Reciever.CancelAsync();
                Sender.CancelAsync();
                info._client.Close();
            }

            private void MessageEvents_Continue(object sender, EventArgs e)
            {
                manager.SkipAction();
            }


            private void Sender_DoWork(object sender, DoWorkEventArgs e)
            {
                while (!e.Cancel && MessageID < info._sim.MessageLne.Count)
                {
                    if (info._sim.MessageLne[MessageID].MessageType == Simulator.EntityType.Action)
                    {
                        if (!info._sim.MessageLne[MessageID].Message.Contains("Ping"))
                        {
                            MessageEvents.RaiseMessageSend(info._sim.MessageLne[MessageID].Message);
                            manager.ActionWaiting(Helper.GetParameterValue(info._sim.MessageLne[MessageID].Message, "ActionID: "), info._sim.MessageLne[MessageID].Message);
                        }
                        MessageID++;
                        continue;
                    }
                    else
                    {
                        ///Send
                        try
                        {
                            SendMessage(info._sim.MessageLne[MessageID].Message);
                        }
                        catch
                        {
                            ClientDesconnect();
                            return;
                        }
                    }
                    try
                    {
                        if (info._sim.MessageLne[MessageID].EntityTime >= info._sim.StartDate && info._sim.MessageLne[MessageID].EntityTime <= info._sim.EndDate)
                        {
                            if ((MessageID + 1) < info._sim.MessageLne.Count)
                                Thread.Sleep((int)(info._sim.MessageLne[MessageID + 1].EntityTime - info._sim.MessageLne[MessageID].EntityTime).TotalMilliseconds + 5);
                        }
                        else
                        {
                            Thread.Sleep(3);
                        }
                    }
                    catch (ArgumentOutOfRangeException)
                    {
                        ClientDesconnect();
                        return;
                    }
                    MessageID++;
                }
            }

            private void Reciever_DoWork(object sender, DoWorkEventArgs e)
            {
                string Request = "";
                byte[] Buffer = new byte[1024];
                int Count;
                try
                {
                    while (!e.Cancel && ((Count = info._client.GetStream().Read(Buffer, 0, Buffer.Length)) > 0))
                    {
                        Request += Encoding.ASCII.GetString(Buffer, 0, Count);

                        if (Request.EndsWith("\r\n\r\n") || Request.Length > 4096)
                        {
                            if (Request.Contains("Ping"))
                            {
                                SendPing(Helper.GetParameterValue(Request, "ActionID: "));
                                Request = string.Empty;
                                continue;
                            }
                            if (Request.Substring(0, "Action".Length) == "Action")
                            {
                                MessageEvents.RaiseRecievedMessage(Request);
                                string[] ReqMes = Request.Split(Helper.END_MESSAGE, StringSplitOptions.RemoveEmptyEntries);
                                for (int i = 0; i < ReqMes.Length; i++)
                                {
                                    manager.ActionRecieved(Helper.GetParameterValue(Request, "ActionID: "), ReqMes[i]);
                                }
                            }
                        }
                        Request = string.Empty;
                        continue;
                    }
                }
                catch
                {
                    ClientDesconnect();
                    return;
                }
            }
        }


        TcpListener Listener;
        Simulator _sim;
        List<TcpClient> clinents = new List<TcpClient>();
        public class ClientSimInfo
        {
            public TcpClient _client;
            public Simulator _sim;
        }
        BackgroundWorker listener = new BackgroundWorker();
        // Запуск сервера
        public Server(int Port, Simulator sim)
        {
            _sim = sim;
            Listener = new TcpListener(IPAddress.Any, Port);
            listener.DoWork += Listener_DoWork;
            listener.WorkerSupportsCancellation = true;
            listener.RunWorkerAsync();
        }

        private void Listener_DoWork(object sender, DoWorkEventArgs e)
        {
            Listener.Start();
            while (!e.Cancel)
            {
                ClientSimInfo data = new ClientSimInfo();
                data._client = Listener.AcceptTcpClient();
                foreach (var cl in clinents)
                {
                    if (cl == data._client)
                        break;
                }
                if (clinents.Count > 0)
                {
                    continue;
                }
                try
                {
                    data._sim = _sim;
                }
                catch
                {
                    continue;
                }
                clinents.Add(data._client);
                Thread Thread = new Thread(new ParameterizedThreadStart(ClientThread));
                Thread.Start(data);
            }
        }

        static void ClientThread(Object StateInfo)
        {
            new Client((ClientSimInfo)StateInfo);
        }

        public void StopServer()
        {
            if (Listener != null)
            {
                Listener.Stop();
            }
            listener.CancelAsync();
        }

    }
}
