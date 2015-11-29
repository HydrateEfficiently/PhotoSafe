using Microsoft.AspNet.Http;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Net.Http.Headers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PhotoSafe.Utility
{
    public static class FormFileUtility
    {
        public static byte[] ToByteArray(this IFormFile formFile)
        {
            using (var stream = formFile.OpenReadStream())
            {
                return stream.ToByteArray();
            }
        }

        public static string GetFileName(this IFormFile formFile)
        {
            var cd = formFile.ContentDisposition;
            var cdv = ContentDispositionHeaderValue.Parse(cd);
            return Path.GetFileName(cdv.FileName.Trim('"'));
        }
    }
}
