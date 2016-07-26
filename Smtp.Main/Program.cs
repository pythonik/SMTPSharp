using System;
using Smtp.Net.Core;

namespace Smtp.Main
{
    class Program
    {
        static void Main(string[] args)
        {
            SMTPClient client = new SMTPClient("smtp.gmail.com");
            client.Port = 587;
            client.ExecuteHelo();
        }
    }
}
