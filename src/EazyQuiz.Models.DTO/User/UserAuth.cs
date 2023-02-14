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
        /// <inheritdoc cref="UserPassword"/>
        /// </summary>
        public UserPassword? Password { get; set; }

        public UserAuth(string? username, UserPassword password)
        {
            Username = username;
            Password = password;
        }

        public UserAuth() { }
    }
}
