using System;
using System.Diagnostics;
using System.Net.Sockets;
using System.Text;

namespace Smtp.Net.Command
{
    class HELOCommand : SMTPCommand
    {
        private string domain;

        public HELOCommand(string domain)
        {
            this.domain = domain;
        }

        public HELOCommand(string domain, TcpClient tcpClient) : this(domain)
        {
            if (SMTPCommand.Client == null)
            {
                SMTPCommand.Client = tcpClient;
            }
        }

        public override string Name { get; } = "HELO";

        public override string CommandString
        {
            get { return $"{this.Name} {this.domain}{LINEFEED}"; }
        }

        public override SMTPCommandResult ExecuteCommand()
        {
            var cmd = Encoding.ASCII.GetBytes(this.CommandString);
            return SMTPCommand.Execute(cmd);
        }
    }
}
