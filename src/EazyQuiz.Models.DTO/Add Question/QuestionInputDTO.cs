using System;
using System.Collections.Generic;

namespace EazyQuiz.Models.DTO
{
    /// <summary>
    /// Вопрос без Ид
    /// </summary>
    /// <remarks>Переименовать, используется для добавления вопросов</remarks>
    public class QuestionInputDTO
    {
        /// <summary>
        /// Текст вопроса
        /// </summary>
        public string Text { get; set; } = string.Empty;

        /// <summary>
        /// Ид темы
        /// </summary>
        public Guid ThemeId { get; set; }

        /// <summary>
        /// Коллекция ответов
        /// </summary>
        public IReadOnlyCollection<AnswerInputDTO> Answers { get; set; } = Array.Empty<AnswerInputDTO>();
    }
}
