using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using Smtp.Net.Command;

namespace Smtp.Net.Core
{
    public class SMTPClient
    {
        private TcpClient tcpClient;

        private SMTPConnectionState state = SMTPConnectionState.NotInitialized;

        private string serverName;

        private int port;

        private Queue<byte[]> bufferQueue;

        public SMTPClient(string serverName)
        {
            this.serverName = serverName;
            this.tcpClient = new TcpClient();
        }

        public static int WaitTimeOut { get; set; } = 5000;

        public static int ConnectTimeOut { get; set; } = 1000;

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

        public SMTPCommandResultCode ExecuteEhloHelo()
        {
            var helo = new EHLOCommand(this.Domain, this.tcpClient);
            return this.ExecuteCommand(helo);
        }

        public SMTPCommandResultCode ExecuteQuit()
        {
            var quit = new QUITCommand();
            return this.ExecuteCommand(quit);
        }

        private SMTPCommandResultCode ExecuteCommand(SMTPCommand command)
        {
            if (this.state == SMTPConnectionState.NotInitialized)
            {
                this.ConnectToRemote();
            }

            if (this.state == SMTPConnectionState.Connected)
            {
                command.ExecuteCommand();
            }

            return SMTPCommandResultCode.None;
        }

        private void ConnectToRemote()
        {
            try
            {
                if (!this.tcpClient.ConnectAsync(this.serverName, this.Port).Wait(ConnectTimeOut))
                {
                    Debug.WriteLine($"Failed to connect {this.serverName}");
                }
                else
                {
                    if (this.ReadConnectRemoteResult() == SMTPCommandResultCode.ServiceReady)
                    {
                        this.state = SMTPConnectionState.Connected;
                    }
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.ToString());
            }
        }

        private SMTPCommandResultCode ReadConnectRemoteResult()
        {
            var buffer = new byte[1024];
            var netStream = this.tcpClient.GetStream();
            var readin = netStream.ReadAsync(buffer, 0, buffer.Length);
            if (readin.Wait(WaitTimeOut))
            {
                var serverResponse = Encoding.ASCII.GetString(buffer, 0, readin.Result);
                Debug.Write(serverResponse);
                return serverResponse.GetStatusCode();
            }
            else
            {
                Debug.WriteLine("Failed to read connect Result");
            }

            return SMTPCommandResultCode.None;
        }
    }
}
