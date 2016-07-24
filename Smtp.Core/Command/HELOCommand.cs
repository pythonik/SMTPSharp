using System;

namespace Smtp.Net.Command
{
    class HELOCommand : SMTPCommand
    {
        private string domain;

        public HELOCommand(string domain)
        {
            this.domain = domain;
        }

        public override string Name { get; } = "HELO";

        public override string CommandString
        {
            get { return string.Format("{0} {1}", this.Name, this.domain); }
        }
    }
}
