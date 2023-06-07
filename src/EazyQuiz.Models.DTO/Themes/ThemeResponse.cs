using System;

namespace EazyQuiz.Models.DTO
{
    /// <summary>
    ///     Дто темы для вопросов
    /// </summary>
    public class ThemeResponse
    {
        /// <summary>
        ///     Ид темы
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        ///     Название темы
        /// </summary>
        public string Name { get; set; } = string.Empty;
    }
}
