using System;
using System.Net.Sockets;
using System.Net;
using AsteriskManager.Exceptions;

namespace AsteriskManager.Connect
{
    class SocketConnection
    {
        public Socket Socket { get; set; }
        public TcpClient tcpClient { get; set; }
        private enum connectionType
        {
            DefaultSocket = 0,
            TcpSocket = 1
        }
        private connectionType CurrectConnction;
        #region Конструкторы
        /// <summary>
        /// Конструктор по умолчанию, используется с функциями и переменными старой библиотеки
        /// Использует низкоуровневый сокет
        /// </summary>
        public SocketConnection()
        {
            Socket = this.GetSocket();
            CurrectConnction = connectionType.DefaultSocket;
        }
        public SocketConnection(Socket nSocket)
        {
            Socket = nSocket;
            CurrectConnction = connectionType.DefaultSocket;
        }

        /// <summary>
        /// Новый конструктор 1 для использования с tcpClient сокетом
        /// оздает новый экземпляр класса TcpClient и устанавливает удаленное соединение с использованием в параметрах DNS-имени и номера порта
        /// </summary>
        /// <param name="host"></param> Адрес хоста клиента
        /// <param name="port"></param> Адрес порта клиента
        public SocketConnection(IPEndPoint ipEnd)
        {
            //clientSocket = this.GetSocket();
            tcpClient = new TcpClient(ipEnd);
            CurrectConnction = connectionType.TcpSocket;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="host"></param>
        /// <param name="port"></param>
        public SocketConnection(string host, int port)
        {
            //clientSocket = this.GetSocket();
            tcpClient = new TcpClient(host, port);
            CurrectConnction = connectionType.TcpSocket;
        }
        /// <summary>
        /// Конструктор 2 для использования с tcp
        /// Использует уже созданный сокет
        /// </summary>
        /// <param name="nClient"></param>
        public SocketConnection(TcpClient nClient)
        {
            //clientSocket = this.GetSocket();
            tcpClient = nClient;
            CurrectConnction = connectionType.TcpSocket;
        }

        #endregion
        /// <summary>
        /// Возвращает тип используемого сокета
        /// </summary>
        /// <returns></returns>
        public int GetConnectionType()
        {
            return (Int32)CurrectConnction;
        }
        /// <summary>
        /// Функция закрывающая подключение к серверу, а также освобождает все ресурсы используемые ей
        /// </summary>
        public bool closeTCPConnection()
        {
            try
            {
                tcpClient.Client.Shutdown(SocketShutdown.Both);
                tcpClient.Client.Close();
                tcpClient.Close();
                return true;
            }
            catch (SocketException)
            {
                return false;
            }
        }

        #region tcpClientInfo
        /// <summary>
        /// Возвращает состояние подключения для tcpClient
        /// </summary>
        /// <returns></returns>
        public bool IsTcpConnected()
        {
            return tcpClient.Connected;
        }
        /// <summary>
        /// Возвращает сам сокет со всей информацией
        /// </summary>
        /// <returns></returns>
        public TcpClient TcpClientSocket()
        {
            return tcpClient;
        }
        /// <summary>
        /// 2 функции с информацией о сетевом подключении локального компьютера
        /// </summary>
        /// <returns>Возвращают Адресс и порт соответственно</returns>
        #region LocalInfo
        public IPAddress LocalAdress()
        {
            return ((IPEndPoint)(tcpClient.Client.LocalEndPoint)).Address;
        }
        public int LocalPort()
        {
            return ((IPEndPoint)(tcpClient.Client.LocalEndPoint)).Port;
        }
        #endregion
        /// <summary>
        /// 2 функции информации о удаленном сервере
        /// </summary>
        /// <returns>Возвращают информацию о Адресе сервера и порте подключения</returns>
        #region RemoteServerInfo
        public IPAddress RemoteAdress()
        {
            return ((IPEndPoint)(tcpClient.Client.RemoteEndPoint)).Address;
        }
        public int RemotePort()
        {
            return ((IPEndPoint)(tcpClient.Client.RemoteEndPoint)).Port;
        }
        #endregion
        #endregion

        #region СтараяБиблиотека
        /// <summary>
        /// Создание нового сокета
        /// </summary>
        /// <returns>Возвращает сокет</returns>
        public Socket GetSocket()
        {
            Socket newsocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            // Don't allow another socket to bind to this port.
            newsocket.ExclusiveAddressUse = true;
            // Timeout 3 seconds
            newsocket.SendTimeout = 30000;
            newsocket.ReceiveTimeout = 70000;
            // Set the Time To Live (TTL) to 42 router hops.
            newsocket.Ttl = 42;
            return newsocket;
        }
        /// <summary>
        /// По ip адресу получает точку подключения к серверу Астериск
        /// </summary>
        /// <param name="ipserver">Строка ip адреса</param>
        /// <returns>Возвращение точки подключения</returns>
        public IPEndPoint getEndPoint(string ipserver, string port)
        {
            IPEndPoint serverEndPoint = new IPEndPoint(IPAddress.Parse(ipserver), Convert.ToInt32(port));
            return serverEndPoint;
        }
        public IPEndPoint getEndPoint(string ipserver, int port)
        {
            try
            {
                IPEndPoint serverEndPoint = new IPEndPoint(IPAddress.Parse(ipserver), port);
                return serverEndPoint;
            }
            catch (FormatException)
            {
                throw new AmiException("Wrong IP Adress");
            }
            catch (ArgumentOutOfRangeException)
            {

                throw new AmiException("Wrong Port");
            }
        }
        /// <summary>
        /// Возвращает информацию о состоянии подключения Сокета
        /// </summary>
        /// <returns>Подключен или не подключен</returns>
        public bool IsSockConnected()
        {
            return Socket.Connected;
        }
        /// <summary>
        /// Функция закрывает подключение
        /// </summary>
        public void CloseSocket()
        {
            try
            {
                if (Socket.Connected)
                {
                    //Socket.EndConnect();
                    Socket.Shutdown(SocketShutdown.Both);
                    Socket.Close();
                }
            }
            catch (SocketException)
            {
                return;
            }
        }
        #endregion
    }
}
