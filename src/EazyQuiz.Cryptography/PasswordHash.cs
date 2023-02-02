using EazyQuiz.Models;
using System.Security.Cryptography;
using System.Text;

namespace EazyQuiz.Cryptography;

public class PasswordHash
{
    private const int SaltSize = 32;
    private const int KeySize = 64;
    private const int Iterations = 1000;
    private static readonly HashAlgorithmName Algorithm = HashAlgorithmName.SHA512;

    public static UserPassword Hash(string password)
    {
        byte[] salt = RandomNumberGenerator.GetBytes(SaltSize);
        var saltt = Convert.ToBase64String(salt);
        byte[] hash = Rfc2898DeriveBytes.Pbkdf2(
            password,
            Encoding.UTF8.GetBytes(saltt),
            Iterations,
            Algorithm,
            KeySize
        );

        return new UserPassword(Convert.ToBase64String(hash), Convert.ToBase64String(salt));
    }

    public static string HashWithCurrentSalt(string password, string salt)
    {
        byte[] hash = Rfc2898DeriveBytes.Pbkdf2(
            password,
            Encoding.UTF8.GetBytes(salt),
            Iterations,
            Algorithm,
            KeySize
        );

        return Convert.ToBase64String(hash);
    }

    public static bool Verify(byte[] inputHash, byte[] hash2)
    {
        return CryptographicOperations.FixedTimeEquals(inputHash, hash2);
    }
}
