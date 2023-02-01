using EazyQuiz.Models;
using System.Security.Cryptography;
using System.Text;

namespace EazyQuiz.Cryptography;

public class PasswordHash
{
    private const int SaltSize = 32;
    private const int KeySize = 64;
    private const int Iterations = 1000;
    private const string Pepper = "lkdehfbdtcgegsnGdTsgFdcxdeRgfDfD";
    private static readonly HashAlgorithmName Algorithm = HashAlgorithmName.SHA512;

    public static UserPassword Hash(string password)
    {
        byte[] salt = RandomNumberGenerator.GetBytes(SaltSize);
        byte[] hash = Rfc2898DeriveBytes.Pbkdf2(
            password,
            salt,
            Iterations,
            Algorithm,
            KeySize
        );

        byte[] hash2 = Rfc2898DeriveBytes.Pbkdf2(
            hash,
            Encoding.UTF8.GetBytes(Pepper),
            Iterations,
            Algorithm,
            KeySize
        );

        return new UserPassword(hash2, salt);
    }

    public static bool Verify(string input, UserPassword hash)
    {
        byte[] inputHash = Rfc2898DeriveBytes.Pbkdf2(
            input,
            hash.PasswordSalt,
            Iterations,
            Algorithm,
            KeySize
        );

        byte[] inputHash2 = Rfc2898DeriveBytes.Pbkdf2(
            inputHash,
            Encoding.UTF8.GetBytes(Pepper),
            Iterations,
            Algorithm,
            KeySize
        );

        return CryptographicOperations.FixedTimeEquals(inputHash, hash.PasswordHash);
    }
}
