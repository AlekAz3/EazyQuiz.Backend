namespace EazyQuiz.Models.DTO
{

    /// <summary>
    /// Команда для получения истории ответов
    /// </summary>
    public class AnswersGetHistoryCommand : IPagingQuery
    {
        public int? PageNumber { get; set; }

        public int? PageSize { get; set; }
    }
}
