namespace HashingTool.Services
{
    public interface IHashingService
    {
        string ComputeHash(string base64Data);

        bool ValidateHash(string base64Data, string expectedHash);
    }
}
