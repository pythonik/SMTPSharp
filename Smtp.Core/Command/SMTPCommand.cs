using Smtp.Net.Core;
using System;
using System.Diagnostics;
using System.Net.Sockets;
using System.Text;

namespace Smtp.Net.Command
{
    public abstract class SMTPCommand
    {
        public const string LINE_FEED = "\r\n"; 

        public abstract string Name { get; }

        public abstract string CommandString { get; }

        public abstract SMTPCommandResult ExecuteCommand ();

        public static TcpClient Client { get; set; }

        public static SMTPCommandResult Execute(byte[] command)
        {
            var smtpResult = new SMTPCommandResult("", SMTPCommandResultCode.None);
            try
            {
                var writeTask = Client.GetStream().WriteAsync(command, 0, command.Length);
                byte[] result = new byte[1024];
                if (writeTask.Wait(SMTPClient.WaitTimeOut))
                {
                    var readTask = Client.GetStream().ReadAsync(result, 0, 1024);
                    if (readTask.Wait(SMTPClient.WaitTimeOut))
                    {
                        var serverResponse = Encoding.ASCII.GetString(result, 0, readTask.Result);
                        smtpResult.StatusCode = serverResponse.GetStatusCode();
                        smtpResult.Message = serverResponse.GetResponseMessage();
                        Debug.WriteLine(serverResponse);
                    }

                }
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
            return smtpResult;
        }
    }
}
