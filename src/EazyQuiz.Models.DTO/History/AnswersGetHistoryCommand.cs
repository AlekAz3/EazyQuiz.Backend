namespace EazyQuiz.Models.DTO
{
    public class AnswersGetHistoryCommand : IPagingQuery
    {
        public int? PageNumber { get; set; }

        public int? PageSize { get; set; }
    }
}
