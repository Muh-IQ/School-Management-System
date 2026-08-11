using System.Security.Cryptography;

namespace Modules.User.Application.Helpers;

public static class PasswordHelper
{
    public static string GenerateRandomPassword(int length = 12)
    {
        const string chars =
            "ABCDEFGHIJKLMNOPQRSTUVWXYZ" +
            "abcdefghijklmnopqrstuvwxyz" +
            "0123456789" +
            "!@#$%^&*";

        return string.Create(length, chars, (buffer, chars) =>
        {
            for (int i = 0; i < buffer.Length; i++)
            {
                buffer[i] = chars[RandomNumberGenerator.GetInt32(chars.Length)];
            }
        });
    }

    public static string HashPassword(string password)
    {
        byte[] salt = RandomNumberGenerator.GetBytes(16);

        byte[] hash = Rfc2898DeriveBytes.Pbkdf2(
            password,
            salt,
            100_000,
            HashAlgorithmName.SHA256,
            32);

        return $"{Convert.ToBase64String(salt)}.{Convert.ToBase64String(hash)}";
    }
}