namespace Smtp.Net.Command
{
    public abstract class SMTPCommand
    {
        public abstract string Name { get; }

        public abstract string CommandString { get; }
    }
}
