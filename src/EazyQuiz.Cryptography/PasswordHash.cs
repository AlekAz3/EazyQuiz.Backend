using EazyQuiz.Models.DTO;
using System;
using System.Security.Cryptography;

namespace EazyQuiz.Cryptography
{
    public class PasswordHash
    {
        /// <summary>
        /// Размер Соли 256 Бит
        /// </summary>
        private const int SaltSize = 32;

        /// <summary>
        /// Размер хэша 512 бит 
        /// </summary>
        private const int KeySize = 64;

        /// <summary>
        /// Количество итераций
        /// </summary>
        private const int Iterations = 1000;

        /// <summary>
        /// Хиширование пароля 
        /// </summary>
        /// <param name="password">Пароль</param>
        /// <returns>Хэш пароля и Соль</returns>
        public static UserPassword Hash(string password)
        {
            byte[] salt = GenerateSalt();
            var hash = new Rfc2898DeriveBytes(
                password,
                salt,
                Iterations,
                HashAlgorithmName.SHA512
                ).GetBytes(KeySize);

            return new UserPassword(Convert.ToBase64String(hash), Convert.ToBase64String(salt));
        }

        /// <summary>
        /// Хеширование пароля с конкретной солью 
        /// </summary>
        /// <param name="password">Пароль</param>
        /// <param name="salt">Соль</param>
        /// <returns>Хэш пароля</returns>
        public static string HashWithCurrentSalt(string password, string salt)
        {
            var hash = new Rfc2898DeriveBytes(
                password,
                Convert.FromBase64String(salt),
                Iterations,
                HashAlgorithmName.SHA512
                ).GetBytes(KeySize);
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

        /// <summary>
        /// Генерация Соли
        /// </summary>
        /// <returns>Соль</returns>
        private static byte[] GenerateSalt()
        {
            var salt = new byte[SaltSize];
            RandomNumberGenerator.Fill(salt);
            return salt;
        }
    }
}
