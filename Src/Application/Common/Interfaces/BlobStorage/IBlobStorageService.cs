using System.IO;

namespace Player.Application.Common.Interfaces.BlobStorage
{
    public interface IBlobStorageService
    {
        void UploadBlob(string name, Stream stream);
        bool DeleteBlob(string id);        
    }
}
