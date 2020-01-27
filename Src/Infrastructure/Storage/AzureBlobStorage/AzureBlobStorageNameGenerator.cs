using System.Text.RegularExpressions;
using Player.Infrastructure.Storage.AzureBlobStorage.Interfaces;

namespace Player.Infrastructure.Blobs.AzureBlobStorage
{
    public class AzureBlobStorageNameGenerator : IStorageNameGenerator
    {
        public string GenerateName(string unformattedString)
        {
            var rgx = new Regex("[^a-zA-Z0-9]");
            return rgx.Replace(unformattedString.ToLower().Trim(), "-");
        }
    }
}
