using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PhotoSafe.Utility
{
    public static class StreamUtility
    {
        public static byte[] ToByteArray(this Stream stream)
        {
            using (var ms = new MemoryStream())
            {
                stream.CopyTo(ms);
                return ms.ToArray();
            }
        }
    }
}
