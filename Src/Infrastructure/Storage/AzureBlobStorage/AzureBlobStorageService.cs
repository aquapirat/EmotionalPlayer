using System.IO;
using System.Linq;
using Azure.Storage.Blobs;
using Player.Application.Common.Interfaces.BlobStorage;
using Player.Infrastructure.Storage.AzureBlobStorage.Interfaces;

namespace Player.Infrastructure.Storage.AzureBlobStorage
{
    public class AzureBlobStorageService : IBlobStorageService
    {
        private const string SongsContainerName = "songs";

        private readonly IStorageNameGenerator _storageNameGenerator;
        private readonly IStorageAuthenticator _storageAuthenticator;

        public AzureBlobStorageService(IStorageNameGenerator storageNameGenerator,
            IStorageAuthenticator storageAuthenticator)
        {
            _storageNameGenerator = storageNameGenerator;
            _storageAuthenticator = storageAuthenticator;
        }

        public bool DeleteBlob(string name)
        {
            var client = _storageAuthenticator.Authenticate();
            var blobName = _storageNameGenerator.GenerateName(name);
            var containerClient = client.GetBlobContainerClient(SongsContainerName);

            return containerClient.DeleteBlobIfExists(blobName);
        }

        public void UploadBlob(string name, Stream stream)
        {
            var client = _storageAuthenticator.Authenticate();
            var blobName = _storageNameGenerator.GenerateName(name);
            BlobContainerClient containerClient;

            if(!ContainerExists(client, SongsContainerName))
            {
                containerClient = client.CreateBlobContainer(SongsContainerName);
            }
            else
            {
                containerClient = client.GetBlobContainerClient(SongsContainerName);
            }

            containerClient.UploadBlob(blobName, stream);

        }

        private bool ContainerExists(BlobServiceClient client, string name)
        {
            return client.GetBlobContainers().Any(bc => bc.Name == name);
        }
    }
}
