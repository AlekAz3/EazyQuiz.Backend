namespace EazyQuiz.Models.DTO
{
    /// <summary>
    /// ДТО Возвращаемое сервером после авторизации
    /// </summary>
    public class UserResponse
    {
        /// <summary>
        /// Ид
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Ник
        /// </summary>
        public string? UserName { get; set; }

        /// <summary>
        /// Возраст
        /// </summary>
        public int Age { get; set; }

        /// <summary>
        /// Пол
        /// </summary>
        public string Gender { get; set; } = string.Empty;

        /// <summary>
        /// Счёт
        /// </summary>
        public int Points { get; set; }

        /// <summary>
        /// Страна
        /// </summary>
        public string? Country { get; set; }

        /// <summary>
        /// JWT Токен
        /// </summary>
        public string? Token { get; set; }

        public UserResponse(int id, string? userName, int age, string gender, int points, string? country, string? token)
        {
            Id = id;
            UserName = userName;
            Age = age;
            Gender = gender;
            Points = points;
            Country = country;
            Token = token;
        }
    }
}
