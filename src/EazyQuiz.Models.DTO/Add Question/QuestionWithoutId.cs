using System;
using System.Collections.Generic;

namespace EazyQuiz.Models.DTO
{
    /// <summary>
    /// Вопрос без Ид
    /// </summary>
    /// <remarks>Переименовать, используется для добавления вопросов</remarks>
    public class QuestionWithoutId
    {
        /// <summary>
        /// Текст вопроса
        /// </summary>
        public string Text { get; set; } = string.Empty;

        /// <summary>
        /// Коллекция ответов
        /// </summary>
        public IReadOnlyCollection<AnswerWithoutId> Answers { get; set; } = Array.Empty<AnswerWithoutId>();
    }
}
