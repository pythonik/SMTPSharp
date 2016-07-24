namespace Smtp.Net
{
    public abstract class SMTPCommand
    {
        public abstract string Name { get; }

        public abstract string CommandString { get; }
    }
}
