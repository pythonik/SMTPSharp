using Smtp.Net.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smtp.Net.Core
{
    static class StringExtension
    {
        public static SMTPCommandResultCode GetStatusCode(this String responseString)
        {
            var statusCode = 0;
            if(!int.TryParse(responseString.Substring(0, 3), out statusCode))
            {
                return (SMTPCommandResultCode)statusCode;
            }
            return SMTPCommandResultCode.None;
        }
    }
}

