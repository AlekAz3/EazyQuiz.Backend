using System;

namespace EazyQuiz.Models.DTO
{
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
