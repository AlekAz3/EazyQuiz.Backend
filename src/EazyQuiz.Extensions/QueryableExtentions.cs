using EazyQuiz.Models.DTO;
using System.Linq;

namespace EazyQuiz.Extensions
{
    public static class QueryableExtentions
    {
        /// <summary>
        ///     Добавляет пагинацию для IQueryable
        /// </summary>
        /// <param name="query">Исходный IQueryable</param>
        /// <param name="command">Фильтр</param>
        /// <returns>Новый IQueryable с пагинацией</returns>
        public static IQueryable<T> AddPagination<T>(this IQueryable<T> query, IPagingQuery command)
        {
            if (command.PageNumber >= 0 && command.PageSize > 0)
            {
                return query.Skip(command.PageSize.Value * command.PageNumber.Value).Take(command.PageSize.Value);
            }

            return query;
        }
    }
}
