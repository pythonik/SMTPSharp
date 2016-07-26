using System;
using System.IO;


namespace Smtp.Net.Core
{
    static class StreamExtension
    {
        public static Byte[] ToByteArray(this Stream stream)
        {
            var mm = new MemoryStream();
            stream.CopyTo(mm);
            return mm.ToArray();
        }
    }
}
