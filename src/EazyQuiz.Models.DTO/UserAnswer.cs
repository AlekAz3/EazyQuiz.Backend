using System;

namespace EazyQuiz.Models.DTO
{
    public class UserAnswer
    {
        /// <summary>
        /// Ид Игрока
        /// </summary>
        public Guid UserId { get; set; }

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
