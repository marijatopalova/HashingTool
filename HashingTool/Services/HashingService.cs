using System.Security.Cryptography;

namespace HashingTool.Services
{
    public class HashingService : IHashingService
    {
        public string ComputeHash(string base64Data)
        {
            var dataBytes = Convert.FromBase64String(base64Data);
            var hashBytes = SHA256.HashData(dataBytes);

            return Convert.ToBase64String(hashBytes);
        }

        public bool ValidateHash(string base64Data, string expectedHash)
        {
            var computedHash = ComputeHash(base64Data);
            return string.Equals(computedHash, expectedHash, StringComparison.OrdinalIgnoreCase);
        }
    }
}
