using System;

namespace EazyQuiz.Models.DTO
{
    /// <summary>
    ///     ДТО Истории ответов на вопрос
    /// </summary>
    public class UserAnswerHistory
    {
        /// <summary>
        ///     Текст вопроса
        /// </summary>
        public string QuestionText { get; set; } = string.Empty;

        /// <summary>
        ///     Текст ответа пользователя
        /// </summary>
        public string AnswerText { get; set; } = string.Empty;

        /// <summary>
        ///     Правильность ответа пользователя
        /// </summary>
        public bool IsCorrect { get; set; }

        /// <summary>
        ///     Время ответа пользователя
        /// </summary>
        public DateTimeOffset AnswerTime { get; set; }
    }
}
