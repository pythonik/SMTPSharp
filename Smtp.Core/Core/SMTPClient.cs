using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using Smtp.Net.Command;
using System.Text;
using System.Diagnostics;

namespace Smtp.Net.Core
{
    public class SMTPClient
    {
        private string EOF = "\r\n";

        private int CONNECT_TIMEOUT = 1000;

        private int WAIT_TIMEOUT = 5000;

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
                Debug.WriteLine($"Failed to ping {this.serverName}");
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
                connectToRemote();
            }

            return SMTPCommandResultCode.None;
        }

        private void connectToRemote()
        {
            try
            {
                this.tcpClient = new TcpClient();
                if (!this.tcpClient.ConnectAsync(this.serverName, this.Port).Wait(CONNECT_TIMEOUT))
                {
                    Debug.WriteLine($"Failed to connect {this.serverName}");
                }
                else
                {
                    readConnectRemoteResult();
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.ToString());
            }
        }

        private void readConnectRemoteResult()
        {
            var buffer = new byte[1024];
            var netStream = tcpClient.GetStream();
            var readin = netStream.ReadAsync(buffer, 0, buffer.Length);
            if (readin.Wait(WAIT_TIMEOUT))
            {
                var serverResponse = Encoding.ASCII.GetString(buffer, 0, readin.Result);
                Debug.WriteLine(serverResponse);
            }
            else
            {
                Debug.WriteLine("Failed to read connect Result");
            }
        }
    }
}
