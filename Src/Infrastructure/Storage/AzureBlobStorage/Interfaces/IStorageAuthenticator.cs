using Azure.Storage.Blobs;

namespace Player.Infrastructure.Storage.AzureBlobStorage.Interfaces
{
    public interface IStorageAuthenticator
    {
        BlobServiceClient Authenticate();
    }
}
