using System;
using System.Collections.Generic;

namespace EazyQuiz.Models.DTO
{
    public class QuestionWithAnswers
    {
        public Guid QuestionId { get; set; }
        public string Text { get; set; } = string.Empty;
        public IReadOnlyCollection<Answer> Answers { get; set; } = Array.Empty<Answer>();
    }
}
