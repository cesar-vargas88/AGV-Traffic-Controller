using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace AGV_Traffic_controller
{
    class TCPServer
    {
        private TcpListener tcpListener;
        private Socket socket;
        private IPAddress ipAddress;
        private Int32 port;
        private ASCIIEncoding asciiEncoding;
        private byte[] receivedDataBuffer;
        private int bytesReceived;

        public TCPServer(string IpAddress, Int32 Port)
        {
            ipAddress = IPAddress.Parse(IpAddress);
            port = Port;

            tcpListener = new TcpListener(ipAddress, port);
            asciiEncoding = new ASCIIEncoding();
            receivedDataBuffer = new byte[1024];
            bytesReceived = 0;
        }

        public string Initialize()
        {
            tcpListener.Start();
            return Environment.NewLine + Environment.NewLine + Environment.NewLine + "The socket Endpoint is :" + tcpListener.LocalEndpoint + Environment.NewLine + "Waiting for a connection.....";
        }
        public string CreateConnection()
        {
            socket = tcpListener.AcceptSocket();
            return Environment.NewLine + "Connection accepted from " + socket.RemoteEndPoint;
        }
        public string VerifyConnection()
        {
            string Message = "";

            if (!socket.Connected)
            {
                Message += Environment.NewLine + Environment.NewLine + "Socket disconnected";
                Message += Initialize();
                Message += CreateConnection();
            }

            return Message;
        }
        public string DestroyConnection()
        {
            if (socket != null)
                socket.Close();
            if (tcpListener != null)
                tcpListener.Stop();

            return Environment.NewLine + Environment.NewLine + "Socket disconnected ";
        }
        public string Listenning()
        {
            Array.Clear(receivedDataBuffer, 0, receivedDataBuffer.Length);
            bytesReceived = socket.Receive(receivedDataBuffer);

            if (bytesReceived == 0)
            {
                socket.Close();
                return "";
            }

            return Encoding.ASCII.GetString(receivedDataBuffer).Substring(0, bytesReceived);
        }
        public void SendMessage(string Message)
        {
            if (socket.Connected)
                socket.Send(asciiEncoding.GetBytes(Message));
            //else
            //    throw new Exception("Missing connection with sokcet");
        }
    }
}
