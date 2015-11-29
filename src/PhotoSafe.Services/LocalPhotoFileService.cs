using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PhotoSafe.Data;
using System.IO;

namespace PhotoSafe.Services
{
    public class LocalPhotoFileService : IPhotoFileService
    {
        private string _relativePathToPhotos;
        private string _absoluteRoot;

        public LocalPhotoFileService(string absoluteRoot, string relativePathToPhotos)
        {
            _absoluteRoot = absoluteRoot;
            _relativePathToPhotos = relativePathToPhotos;
        }

        public async Task<string> GetFileUrl(Photo photo)
        {
            string relativeFileName = Path.Combine(
                _relativePathToPhotos,
                photo.DepositId.ToString(),
                photo.Id.ToString(),
                photo.ImageUploadFileName);

            string absoluteFileName = _absoluteRoot + relativeFileName;

            if (!File.Exists(absoluteFileName))
            {
                string dirName = Path.GetDirectoryName(absoluteFileName);
                if (!Directory.Exists(dirName))
                {
                    Directory.CreateDirectory(dirName);
                }

                using (var ms = new MemoryStream(photo.ImageUpload.Content))
                using (var fs = new FileStream(absoluteFileName, FileMode.Create))
                {
                    await ms.CopyToAsync(fs);
                }
            }

            return relativeFileName.Replace('\\', '/');
        }
    }
}
