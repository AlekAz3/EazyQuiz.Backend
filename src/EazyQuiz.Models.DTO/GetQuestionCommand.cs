using System;

namespace EazyQuiz.Models.DTO
{
    public class GetQuestionCommand
    {
        public Guid ThemeId { get; set; }
        public int Count { get; set; }
    }
}
