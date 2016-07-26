using System;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using Smtp.Net.Command;
using System.Text;
using System.Collections.Generic;

namespace Smtp.Net.Core
{
    public class SMTPClient
    {
        private string EOF = "\r\n";

        private TcpClient tcpClient;

        private SMTPConnectionState state = SMTPConnectionState.NotInitialized;

        private string serverName;

        private int port;

        private Queue<byte[]> bufferQueue;

        public SMTPClient(string serverName)
        {
            this.serverName = serverName;
        }

        public string Domain { get; set; } = Environment.MachineName;

        public int Port { get; set; } = 25;

        public bool Ping()
        {
            bool pingResult = false;
            
            Ping ping = new Ping();
            try
            {
                PingReply reply = ping.Send(this.serverName);
                pingResult = reply.Status == IPStatus.Success;
            }
            catch
            {
            }

            return pingResult;
        }

        public SMTPCommandResultCode ExecuteHelo()
        {
            return this.ExecuteCommand(new HELOCommand(this.Domain));
        }

        private SMTPCommandResultCode ExecuteCommand(SMTPCommand command)
        {
            if (this.state == SMTPConnectionState.NotInitialized)
            {
                initializeBuffer();
                connectToRemote();
            }

            return SMTPCommandResultCode.None;
        }

        private void initializeBuffer()
        {
            //bufferQueue = new Queue<byte[]>(128);
            //for(int i =0;i<128;i++)
            //{
            //    bufferQueue.Enqueue(new byte[]())

            //}
        }

        private void connectToRemote()
        {
            try
            {
                this.tcpClient = new TcpClient(this.serverName, this.Port);
                
                byte[] bytes = new byte[1024];
                var netStream = tcpClient.GetStream();
                var count = 0;
                do
                {
                    count = netStream.Read(bytes, 0, 1024);
                    netStream.Position = netStream.Length - 2;
                    byte[] lastTwoBytes = netStream.ToByteArray();



                } while (count > 0);



                if (tcpClient.Connected)
                {
                    this.state = SMTPConnectionState.Connected;
                }
            }
            catch
            {

            }
        }

        private void extractLine()
        {
            
        }
    }
}
