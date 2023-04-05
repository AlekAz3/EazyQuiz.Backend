using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EazyQuiz.Models.DTO.UsersQuestion
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
