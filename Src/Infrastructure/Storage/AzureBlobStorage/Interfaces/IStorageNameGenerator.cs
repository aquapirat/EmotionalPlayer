namespace Player.Infrastructure.Storage.AzureBlobStorage.Interfaces
{
    public interface IStorageNameGenerator
    {
        string GenerateName(string unformattedString);
    }
}
