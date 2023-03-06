using System;

namespace EazyQuiz.Models.DTO
{
    public class Answer
    {
        public Guid AnswerId { get; set; }
        public string? AnswerText { get; set; }
        public bool IsCorrect { get; set; }
    }
}
