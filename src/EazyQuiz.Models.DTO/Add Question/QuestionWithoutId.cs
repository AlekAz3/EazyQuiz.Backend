using System;
using System.Collections.Generic;

namespace EazyQuiz.Models.DTO
{
    public class QuestionWithoutId
    {
        public string Text { get; set; } = string.Empty;
        public IReadOnlyCollection<AnswerWithoutId> Answers { get; set; } = Array.Empty<AnswerWithoutId>();
    }
}
