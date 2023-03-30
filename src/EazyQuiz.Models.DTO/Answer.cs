using System;

namespace EazyQuiz.Models.DTO
{
    /// <summary>
    /// ДТО ответа на вопрос
    /// </summary>
    public class Answer
    {
        /// <summary>
        /// Ид
        /// </summary>
        public Guid AnswerId { get; set; }

        /// <summary>
        /// Текст ответа
        /// </summary>
        public string? AnswerText { get; set; }

        /// <summary>
        /// Правильность
        /// </summary>
        public bool IsCorrect { get; set; }
    }
}
