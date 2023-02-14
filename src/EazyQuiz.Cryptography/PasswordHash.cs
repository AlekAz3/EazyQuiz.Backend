using EazyQuiz.Models.DTO;
using System.Security.Cryptography;
using System.Text;

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

            return new UserPassword(Encoding.UTF8.GetString(hash), Encoding.UTF8.GetString(salt));
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
                Encoding.UTF8.GetBytes(password),
                Encoding.UTF8.GetBytes(salt),
                Iterations,
                HashAlgorithmName.SHA512
                ).GetBytes(KeySize);

            return Encoding.UTF8.GetString(hash);
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

        private static byte[] GenerateSalt()
        {
            byte[] salt = new byte[SaltSize];

#pragma warning disable SYSLIB0023 // Type or member is obsolete
            using (var random = new RNGCryptoServiceProvider())
            {
                random.GetNonZeroBytes(salt);
            }
#pragma warning restore SYSLIB0023 // Type or member is obsolete
            return salt;
        }

    }
}
