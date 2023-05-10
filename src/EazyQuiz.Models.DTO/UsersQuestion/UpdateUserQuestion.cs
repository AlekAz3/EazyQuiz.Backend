using System;

namespace EazyQuiz.Models.DTO
{
    /// <summary>
    /// Обновить состояние вопроса пользователя 
    /// </summary>
    public class UpdateUserQuestion
    {
        /// <summary>
        /// Ид
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Статус
        /// </summary>
        public string? Status { get; set; }
    }
}
