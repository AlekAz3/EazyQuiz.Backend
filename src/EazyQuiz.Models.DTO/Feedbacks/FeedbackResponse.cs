using System;

namespace EazyQuiz.Models.DTO
{
    /// <summary>
    ///     ДТО обратной связи пользователей
    /// </summary>
    public class FeedbackResponse
    {
        /// <summary>
        ///     Ид
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        ///     Текст
        /// </summary>
        public string Text { get; set; } = string.Empty;

        /// <summary>
        ///     Почта
        /// </summary>
        public string Email { get; set; } = string.Empty;

        /// <summary>
        ///     Статус
        /// </summary>
        public string Status { get; set; } = string.Empty;
    }
}
