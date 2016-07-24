namespace Smtp.Net.Command
{
    class SMTPCommandResult
    {
        public SMTPCommandResult(string message, SMTPCommandResultCode statusCode)
        {
            this.Message = message;
            this.StatusCode = statusCode;
        }

        public string Message { get; set; } = string.Empty;

        public SMTPCommandResultCode StatusCode { get; set; } = SMTPCommandResultCode.None;
    }
}
