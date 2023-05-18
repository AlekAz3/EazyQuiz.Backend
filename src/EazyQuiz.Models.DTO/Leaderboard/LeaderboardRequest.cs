namespace EazyQuiz.Models.DTO
{
    /// <summary>
    /// Запрос на получение таблицы лидеров по фильтру
    /// </summary>
    public class LeaderboardRequest
    {
        /// <summary>
        /// Количество
        /// </summary>
        public int Count { get; set; } = 5;

        /// <summary>
        /// Страна
        /// </summary>
        public string? Country { get; set; }
    }
}
