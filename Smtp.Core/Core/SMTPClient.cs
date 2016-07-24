using System.Net.NetworkInformation;
using System.Net.Sockets;

namespace Smtp.Net.Core
{
    public class SMTPClient
    {
        public readonly int DefaultPort = 25;

        private TcpClient tcpClient;

        private string serverName;

        private int port;

        public SMTPClient(string serverName)
        {
            this.serverName = serverName;
            this.port = this.DefaultPort;
        }

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
    }
}
