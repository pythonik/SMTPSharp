using System;
using System.Net.Sockets;
using System.Text;

namespace Smtp.Net.Command
{
    class QUITCommand : SMTPCommand
    {
        public QUITCommand() 
        {
            if ( SMTPCommand.Client == null )
            {
                throw new Exception( "Internal Tcp client is null" );
            }
        }

        public override string Name { get; } = "QUIT";

        public override string CommandString
        {
            get { return $"{this.Name}{LINEFEED}"; }
        }

        public override SMTPCommandResult ExecuteCommand()
        {
            var cmd = Encoding.ASCII.GetBytes( this.CommandString );
            return SMTPCommand.Execute( cmd );
        }
    }
}
