namespace EazyQuiz.Models.DTO
{
    /// <summary>
    /// ДТО при входе пользователя в систему 
    /// </summary>
    public class UserAuth
    {
        /// <summary>
        /// Логин
        /// </summary>
        public string? Username { get; set; }

        /// <summary>
        /// Пароль
        /// </summary>
        public string PasswordHash { get; set; }
    }
}
