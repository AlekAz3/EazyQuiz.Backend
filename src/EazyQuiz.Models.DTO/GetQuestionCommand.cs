using System;

namespace EazyQuiz.Models.DTO
{
    /// <summary>
    ///     Команда для получения вопросу по фильтру
    /// </summary>
    public class GetQuestionCommand
    {
        /// <summary>
        ///     Ид темы вопроса
        /// </summary>
        public Guid? ThemeId { get; set; }

        /// <summary>
        ///     Количество вопросов
        /// </summary>
        public int Count { get; set; } = 10;
    }
}
