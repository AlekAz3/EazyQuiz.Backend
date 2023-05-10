using System;

namespace EazyQuiz.Models.DTO
{
    /// <summary>
    /// ДТО ответа пользователя на вопрос
    /// </summary>
    public class UserAnswer
    {
        /// <summary>
        /// Ид вопроса
        /// </summary>
        public Guid QuestionId { get; set; }

        /// <summary>
        /// Ид ответа
        /// </summary>
        public Guid AnswerId { get; set; }
    }
}
