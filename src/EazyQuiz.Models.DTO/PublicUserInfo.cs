namespace EazyQuiz.Models.DTO
{
    /// <summary>
    ///     Публичная информация о пользователе
    /// </summary>
    public class PublicUserInfo
    {
        /// <summary>
        ///     Ник
        /// </summary>
        public string UserName { get; set; } = string.Empty;

        /// <summary>
        ///     Колличество очков
        /// </summary>
        public int Points { get; set; }
    }
}
