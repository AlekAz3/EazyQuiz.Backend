using System;

namespace EazyQuiz.Models.DTO.UsersQuestion
{
    /// <summary>
    /// Просмотр пользователю своих предложенных вопросов
    /// </summary>
    public class QuestionByUserResponse
    {
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
