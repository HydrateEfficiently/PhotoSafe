using PhotoSafe.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhotoSafe.Services
{
    public interface IPhotoFileService
    {
        Task<string> GetFileUrl(Photo photo);
    }
}
