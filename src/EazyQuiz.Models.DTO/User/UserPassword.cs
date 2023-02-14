namespace EazyQuiz.Models.DTO
{
    /// <summary>
    /// ДТО для хранения хэша пароля и соли 
    /// </summary>
    public class UserPassword
    {
        /// <summary>
        /// Хэш
        /// </summary>
        public string PasswordHash { get; set; }

        /// <summary>
        /// Соль
        /// </summary>
        public string PasswordSalt { get; set; }

        public UserPassword(string passwordHash, string passwordSalt)
        {
            PasswordHash = passwordHash;
            PasswordSalt = passwordSalt;
        }
    }
}
