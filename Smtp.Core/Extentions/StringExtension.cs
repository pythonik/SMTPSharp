using Smtp.Net.Command;

namespace Smtp.Net.Core
{
    public static class StringExtension
    {
        public const int RESULTCODELEN = 3;

        public const int MESSAGESTARTINDEX = 4;

        public static SMTPCommandResultCode GetStatusCode ( this string responseString )
        {
            var statusCode = 0;
            if ( int.TryParse( responseString.Substring( 0, RESULTCODELEN ), out statusCode ) )
            {
                return ( SMTPCommandResultCode ) statusCode;
            }

            return SMTPCommandResultCode.None;
        }

        public static string GetResponseMessage ( this string responseString )
        {
            var responseMessage = string.Empty;
            if ( responseString.Length > MESSAGESTARTINDEX )
            {
                int lengthOfMessage = responseString.Length - MESSAGESTARTINDEX;
                responseMessage = responseString.Substring( MESSAGESTARTINDEX, lengthOfMessage );
            }

            return responseMessage;
        }
    }
}