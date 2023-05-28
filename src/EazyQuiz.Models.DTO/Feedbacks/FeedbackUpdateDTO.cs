using System;

namespace EazyQuiz.Models.DTO
{
    /// <summary>
    /// ДТО обновление статуса вопроса
    /// </summary>
    public class FeedbackUpdateDTO
    {
        /// <summary>
        /// Ид вопроса
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Статус
        /// </summary>
        public string Status { get; set; } = string.Empty;
    }
}
