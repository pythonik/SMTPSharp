using System;
using System.Diagnostics;
using System.Net.Sockets;
using System.Text;

namespace Smtp.Net.Command
{
    class HELOCommand : SMTPCommand
    {
        private string domain;

        private TcpClient tcpClient;

        public HELOCommand ( string domain )
        {
            this.domain = domain;
        }

        public HELOCommand ( string domain, TcpClient tcpClient ) : this( domain )
        {
            this.tcpClient = tcpClient;
        }

        public override string Name { get; } = "HELO";

        public override string CommandString
        {
            get { return string.Format( $"{this.Name} {this.domain}{LINE_FEED}" ); }
        }

        public TcpClient Client { get { return tcpClient; } }

        public override void Execute ()
        {
            byte[] result = new byte[1024];
            var cmd = Encoding.ASCII.GetBytes( CommandString );
            var writeTask = tcpClient.GetStream().WriteAsync(cmd, 0, cmd.Length);
            if ( !writeTask.Wait( 5000 ) )
            {
                Debug.WriteLine( $"{cmd} failed to execute" );
            }
            else
            {
                var readTask = tcpClient.GetStream().ReadAsync( result, 0, 1024 );
                if(!readTask.Wait(5000))
                {
                    
                }
                else
                {
                    var serverResponse = Encoding.ASCII.GetString(result, 0, readTask.Result);
                    Debug.WriteLine( serverResponse );
                }
                
            }

        }
    }
}
