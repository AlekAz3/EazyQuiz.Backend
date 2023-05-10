namespace EazyQuiz.Models.DTO
{
    /// <summary>
    /// Получить вопросы от пользователей по фильтру
    /// </summary>
    public class UserQuestionFilter : IPagingQuery
    {
        /// <summary>
        /// Статус вопроса
        /// </summary>
        public string? Status { get; set; }
        public int? PageNumber { get; set; }
        public int? PageSize { get; set; }
    }
}
