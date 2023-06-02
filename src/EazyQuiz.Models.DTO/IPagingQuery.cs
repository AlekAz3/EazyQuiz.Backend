namespace EazyQuiz.Models.DTO
{
    /// <summary>
    ///     Параметры пагинации
    /// </summary>
    public interface IPagingQuery
    {
        /// <summary>
        ///     Номер страницы
        /// </summary>
        public int? PageNumber { get; set; }

        /// <summary>
        ///     Размер страницы
        /// </summary>
        public int? PageSize { get; set; }
    }
}
