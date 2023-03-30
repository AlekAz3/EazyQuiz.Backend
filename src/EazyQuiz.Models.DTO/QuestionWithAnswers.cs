using System;
using System.Collections.Generic;

namespace EazyQuiz.Models.DTO
{
    /// <summary>
    /// Вопрос с ответами
    /// </summary>
    public class QuestionWithAnswers
    {
        /// <summary>
        /// Ид вопроса
        /// </summary>
        public Guid QuestionId { get; set; }

        /// <summary>
        /// Текст вопроса
        /// </summary>
        public string Text { get; set; } = string.Empty;

        /// <summary>
        /// Коллекция ответов на вопрос
        /// </summary>
        public IReadOnlyCollection<Answer> Answers { get; set; } = Array.Empty<Answer>();
    }
}
