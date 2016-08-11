using System;
using System.Diagnostics;
using System.Net.Sockets;
using System.Text;
using Smtp.Net.Core;

namespace Smtp.Net.Command
{
    public abstract class SMTPCommand
    {
        public const string LINEFEED = "\r\n";

        public static TcpClient Client { get; set; }

        public abstract string Name { get; }

        public abstract string CommandString { get; }

        public static SMTPCommandResult Execute(byte[] command)
        {
            var smtpResult = new SMTPCommandResult(string.Empty, SMTPCommandResultCode.None);
            try
            {
                var writeTask = Client.GetStream().WriteAsync(command, 0, command.Length);
                byte[] result = new byte[1024];
                if (writeTask.Wait(SMTPClient.WaitTimeOut))
                {
                    bool read = true;
                    while (read)
                    {
                        var readTask = Client.GetStream().ReadAsync(result, 0, 1024);
                        if (readTask.Wait(SMTPClient.WaitTimeOut))
                        {
                            var serverResponse = Encoding.ASCII.GetString(result, 0, readTask.Result);
                            smtpResult.StatusCode = serverResponse.GetStatusCode();
                            smtpResult.Message = serverResponse.GetResponseMessage();
                            Debug.WriteLine(serverResponse);
                            Array.Clear(result, 0, 1024);
                            if (readTask.Result < 1024)
                            {
                                break;
                            }
                        }
                        else
                        {
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }

            return smtpResult;
        }

        public abstract SMTPCommandResult ExecuteCommand();
    }
}
