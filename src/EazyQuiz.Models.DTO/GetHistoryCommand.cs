namespace EazyQuiz.Models.DTO
{
    /// <summary>
    ///     Команда для получения истории с пагинацией
    /// </summary>
    public class GetHistoryCommand : IPagingQuery
    {
        public int? PageNumber { get; set; }

        public int? PageSize { get; set; }
    }
}
