using System;
using Smtp.Net.Core;

namespace Smtp.Main
{
    class Program
    {
        static void Main(string[] args)
        {
            SMTPClient client = new SMTPClient("smtp.gmail.com");
            Console.WriteLine(client.Ping());
        }
    }
}
