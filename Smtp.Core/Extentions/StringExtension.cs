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
        public const int RESULT_CODE_LEN = 3;
        public const int MESSAGE_START_INDEX = 4;
        public static SMTPCommandResultCode GetStatusCode(this String responseString)
        {
            var statusCode = 0;
            if(int.TryParse(responseString.Substring(0, RESULT_CODE_LEN), out statusCode))
            {
                return (SMTPCommandResultCode)statusCode;
            }
            return SMTPCommandResultCode.None;
        }

        public static string GetResponseMessage(this String responseString)
        {
            int lengthOfMessage = responseString.Length - MESSAGE_START_INDEX;
            return responseString.Substring(MESSAGE_START_INDEX, lengthOfMessage);
        }
    }
}

