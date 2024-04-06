using System.Configuration;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace CarServiceDBApp.Authorization
{
    public static class PasswordGenerator
    {
        private static byte[] salt = Convert.FromBase64String(ConfigurationManager.AppSettings["Salt"]);

        public static string GenerateRandomPassword(int length = 12)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789-+_=!№;%:?*";
            Random random = new Random();
            char[] password = new char[length];
            for (int i = 0; i < length; i++)
            {
                password[i] = chars[random.Next(chars.Length)];
            }
            return new string(password);
        }

        public static string HashPassword(string password)
        {
            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 100000,
                numBytesRequested: 256 / 8));

            return hashed;
        }

        public static bool VerifyPassword(string password, string hashedPassword)
        {
            string newHashedPassword = HashPassword(password);
            return newHashedPassword == hashedPassword;
        }
    }
}
