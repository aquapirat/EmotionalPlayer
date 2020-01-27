using Player.Infrastructure.Storage.AzureBlobStorage.Interfaces;
using Azure.Storage.Blobs;
using Microsoft.Extensions.Options;

namespace Player.Infrastructure.Blobs.AzureBlobStorage
{
    public class AzureBlobStorageAuthenticator : IStorageAuthenticator
    {
        private readonly AzureBlobStorageCredentials _credentials;

        public AzureBlobStorageAuthenticator(IOptions<AzureBlobStorageCredentials> options)
        {
            _credentials = options.Value;
        }

        public BlobServiceClient Authenticate()
        {
            return new BlobServiceClient(_credentials.ConnectionString);
        }
    }
}
