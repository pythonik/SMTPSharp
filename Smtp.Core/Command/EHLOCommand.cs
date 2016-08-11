using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Smtp.Net.Command
{
    class EHLOCommand : SMTPCommand
    {
        private string domain;

        public EHLOCommand(string domain)
        {
            this.domain = domain;
        }

        public EHLOCommand(string domain, TcpClient tcpClient) : this(domain)
        {
            if (SMTPCommand.Client == null)
            {
                SMTPCommand.Client = tcpClient;
            }
        }

        public override string CommandString
        {
            get
            {
                return $"{this.Name} {this.domain}{LINEFEED}";
            }
        }

        public override string Name { get; } = "EHLO";

        public override SMTPCommandResult ExecuteCommand()
        {
            var cmd = Encoding.ASCII.GetBytes(this.CommandString);
            return SMTPCommand.Execute(cmd);
        }
    }
}
