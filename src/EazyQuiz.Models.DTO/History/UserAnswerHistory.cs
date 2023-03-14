using System;

namespace EazyQuiz.Models.DTO
{
    public class UserAnswerHistory
    {
        public string QuestionText { get; set; }
        public string AnswerText { get; set; }
        public bool IsCorrect { get; set; }
        public DateTime AnswerTime { get; set; }
    }
}
