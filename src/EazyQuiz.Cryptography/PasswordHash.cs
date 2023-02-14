using EazyQuiz.Models.DTO;
using System.Security.Cryptography;
using System.Text;

namespace EazyQuiz.Cryptography;

public class PasswordHash
{
    /// <summary>
    /// Размер Соли 256 Бит
    /// </summary>
    private const int SaltSize = 32;

    /// <summary>
    /// Размер готового хэша 512 бит 
    /// </summary>
    private const int KeySize = 64;

    /// <summary>
    /// Количество итерация
    /// </summary>
    private const int Iterations = 1000;

    /// <summary>
    /// Алгоритм Хэширования 
    /// </summary>
    private static readonly HashAlgorithmName Algorithm = HashAlgorithmName.SHA512;

    /// <summary>
    /// Хиширование пароля 
    /// </summary>
    /// <param name="password">Пароль</param>
    /// <returns>Хэш пароля и Соль</returns>
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

    /// <summary>
    /// Хэшированние пароля с конкрентной солью 
    /// </summary>
    /// <param name="password">Пароль</param>
    /// <param name="salt">Соль</param>
    /// <returns>Хэш пароля</returns>
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

    /// <summary>
    /// Сравнение хэшей
    /// </summary>
    /// <param name="inputHash">Первый хэш</param>
    /// <param name="hash2">Второй хэш</param>
    /// <returns>true если равны</returns>
    public static bool Verify(byte[] inputHash, byte[] hash2)
    {
        return CryptographicOperations.FixedTimeEquals(inputHash, hash2);
    }
}
