using System;

namespace EazyQuiz.Models.DTO
{
    public class AnswersGetHistoryCommand : IPagingQuery
    {
        public Guid UserId { get; set; }

        public int? PageNumber { get; set; }

        public int? PageSize { get; set; }
    }

    /// <summary>
    /// Параметры пагинации
    /// </summary>
    public interface IPagingQuery
    {
        /// <summary>
        /// Номер страницы
        /// </summary>
        public int? PageNumber { get; set; }

        /// <summary>
        /// Размер страницы
        /// </summary>
        public int? PageSize { get; set; }
    }
}
