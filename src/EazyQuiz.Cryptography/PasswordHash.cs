using EazyQuiz.Models;
using System.Security.Cryptography;
using System.Text;

namespace EazyQuiz.Cryptography;

public class PasswordHash
{
    private const int SaltSize = 32;
    private const int KeySize = 64;
    private const int Iterations = 1000;
    private const string Pepper = "lk$dehfbd^tcgeg@TsgFdcx4deRgfDfD";
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

        return new UserPassword(hash, salt);
    }

    public static byte[] HashWithCurrentSalt(string password, byte[] salt)
    {
        byte[] hash = Rfc2898DeriveBytes.Pbkdf2(
            password,
            salt,
            Iterations,
            Algorithm,
            KeySize
        );

        return hash;
    }


    public static bool Verify(byte[] inputHash, byte[] hash2)
    {
        return CryptographicOperations.FixedTimeEquals(inputHash, hash2);
    }
}
