using System.Security.Cryptography;

namespace Projet_DotNet_P6_LJMA.Shared.Helpers
{
    public static class PasswordHasher
    {
        private const int _saltSize = 16; // 128 bits
        private const int _hashSize = 32; // 256 bits
        private const int _iterations = 100000; // Ajustez selon vos besoins de sécurité et de performance
        private static readonly HashAlgorithmName _algorithm = HashAlgorithmName.SHA256;

        public static string HashPassword(string password)
        {
            byte[] salt = RandomNumberGenerator.GetBytes(_saltSize);
            byte[] hash = ComputeHash(password, salt);

            byte[] result = new byte[_saltSize + _hashSize];
            Buffer.BlockCopy(salt, 0, result, 0, _saltSize);
            Buffer.BlockCopy(hash, 0, result, _saltSize, _hashSize);

            return Convert.ToBase64String(result);
        }

        public static bool VerifyPassword(string password, string hashedPassword)
        {
            byte[] hashBytes = Convert.FromBase64String(hashedPassword);
            if (hashBytes.Length != _saltSize + _hashSize)
            {
                return false;
            }

            byte[] salt = new byte[_saltSize];
            byte[] storedHash = new byte[_hashSize];
            Buffer.BlockCopy(hashBytes, 0, salt, 0, _saltSize);
            Buffer.BlockCopy(hashBytes, _saltSize, storedHash, 0, _hashSize);

            byte[] computedHash = ComputeHash(password, salt);

            return CryptographicOperations.FixedTimeEquals(storedHash, computedHash);
        }

        private static byte[] ComputeHash(string password, byte[] salt)
        {
            return Rfc2898DeriveBytes.Pbkdf2(
                password,
                salt,
                _iterations,
                _algorithm,
                _hashSize);
        }
    }
}
