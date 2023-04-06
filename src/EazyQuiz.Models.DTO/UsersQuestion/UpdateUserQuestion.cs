using System;

namespace EazyQuiz.Models.DTO
{
    public class UpdateUserQuestion
    {
        /// <summary>
        /// Ид
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Текст вопроса
        /// </summary>
        public string? QuestionText { get; set; }

        /// <summary>
        /// Текст ответа
        /// </summary>
        public string? AnswerText { get; set; }

        /// <summary>
        /// Статус
        /// </summary>
        public string? Status { get; set; }
    }
}
