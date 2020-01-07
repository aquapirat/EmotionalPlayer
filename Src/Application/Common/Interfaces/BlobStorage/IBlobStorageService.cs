using System.IO;

namespace Player.Application.Common.Interfaces.BlobStorage
{
    interface IBlobStorageService
    {
        void UploadFile(Stream stream);
        bool DeleteFile(string id);        
    }
}
