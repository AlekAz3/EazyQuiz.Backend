using System;

namespace EazyQuiz.Models.DTO
{
    public class UserQuestionFilter : IPagingQuery
    {
        public Guid? UserId { get; set; }
        public string? Status { get; set; }
        public int? PageNumber { get; set; }
        public int? PageSize { get; set; }
    }
}
