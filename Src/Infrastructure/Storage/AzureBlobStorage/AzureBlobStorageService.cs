using System;
using System.IO;
using System.Linq;
using Azure.Storage.Blobs;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Blob;
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
            /*var client = _storageAuthenticator.Authenticate();
            var blobName = _storageNameGenerator.GenerateName(name);
            BlobContainerClient containerClient;*/
            var blobName = _storageNameGenerator.GenerateName(name);
            var cloudBlobClient = new CloudBlobClient(new Uri("http://172.20.0.1"), new StorageCredentials("devstoreaccount1", @"Eby8vdM02xNOcqFlqUwJPLlmEtlCDXJ1OUzFT50uSRZ6IFsuFq2UVErCz4I6tq/K1SZFPTOtr/KBHBeksoGMGw=="));
            var container = cloudBlobClient.GetContainerReference("songs");
            container.CreateIfNotExistsAsync();

            var blob = container.GetBlockBlobReference(blobName);
            blob.Properties.ContentType = "audio/mp3";
            blob.UploadFromStreamAsync(stream);

            /*if(!ContainerExists(client, SongsContainerName))
            {
                containerClient = client.CreateBlobContainer(SongsContainerName);
            }
            else
            {
                containerClient = client.GetBlobContainerClient(SongsContainerName);
            }

            var blobClient = containerClient.Up(blobName);
            blobClient.SetHttpHeaders(new BlobHttpHeaders { ContentType = "audio/mp3" });
            blobClient.Upload(stream);*/

        }

        private bool ContainerExists(BlobServiceClient client, string name)
        {
            return client.GetBlobContainers().Any(bc => bc.Name == name);
        }
    }
}
