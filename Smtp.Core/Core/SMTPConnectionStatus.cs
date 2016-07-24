namespace Smtp.Net.Core
{
    public enum SMTPConnectionState
    {
        NotInitialized,

        Disconnected,

        Connected,

        Authenticated,
      
        MailFromCommandExecuting,
       
        MailFromCommandExecuted,
       
        RcptToCommandExecuting,
       
        RcptToCommandExecuted,
      
        DataCommandExecuting,

        DataCommandExecuted
    }
}
