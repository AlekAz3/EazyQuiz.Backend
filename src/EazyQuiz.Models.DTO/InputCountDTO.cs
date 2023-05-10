using System.Collections.Generic;

namespace EazyQuiz.Models.DTO
{
    /// <summary>
    /// Данные для отображения с общим количеством
    /// </summary>
    public class InputCountDTO<T>
    {
        /// <summary>
        /// Общее количество
        /// </summary>
        public long Count { get; private set; }

        /// <summary>
        /// Элементы
        /// </summary>
        public IEnumerable<T> Items { get; private set; }

        public InputCountDTO(long count, IEnumerable<T> items)
        {
            Count = count;
            Items = items;
        }
    }
}
