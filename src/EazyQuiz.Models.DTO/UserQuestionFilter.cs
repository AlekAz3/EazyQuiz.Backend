using System;

namespace EazyQuiz.Models.DTO
{
    public class UserQuestionFilter : IPagingQuery
    {
        public string? Status { get; set; }
        public int? PageNumber { get; set; }
        public int? PageSize { get; set; }
    }
}
