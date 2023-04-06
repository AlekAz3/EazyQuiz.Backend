using System;

namespace EazyQuiz.Models.DTO
{
    /// <summary>
    /// Предложенный вопрос пользователя
    /// </summary>
    public class UserQuestionResponse
    {
        /// <summary>
        /// Ид  
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Текст вопроса 
        /// </summary>
        public string QuestionText { get; set; } = string.Empty;

        /// <summary>
        /// Текст ответа
        /// </summary>
        public string AnswerText { get; set; } = string.Empty;

        /// <summary>
        /// Последнее обновление
        /// </summary>
        public DateTimeOffset LastUpdate { get; set; }

        /// <summary>
        /// Статус
        /// </summary>
        public string Status { get; set; } = string.Empty;
    }
}
