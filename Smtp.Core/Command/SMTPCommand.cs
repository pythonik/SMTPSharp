using System;

namespace Smtp.Net.Command
{
    public abstract class SMTPCommand
    {
        public const string LINE_FEED = "\r\n"; 

        public abstract string Name { get; }

        public abstract string CommandString { get; }

        public abstract void Execute ();
    }
}
