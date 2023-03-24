using EazyQuiz.Models.DTO;
using System.Linq;

namespace EazyQuiz.Extensions
{
    public static class QueryableExtentions
    {
        /// <summary>
        /// Добавляет пагинацию для IQueryable
        /// </summary>
        /// <param name="query">Исходный IQueryable</param>
        /// <param name="command">Фильтр</param>
        /// <returns>Новый IQueryable с пагинацией</returns>
        public static IQueryable<T> AddPagination<T>(this IQueryable<T> query, IPagingQuery command)
        {
            if (command.PageNumber >= 0 && command.PageSize > 0)
            {
                return AddPagination(query, command.PageNumber.Value, command.PageSize.Value);
            }

            return query;
        }

        /// <summary>
        /// Добавляет пагинацию для IQueryable
        /// </summary>
        /// <param name="query">Исходный IQueryable</param>
        /// <returns>Новый IQueryable с пагинацией</returns>
        private static IQueryable<T> AddPagination<T>(this IQueryable<T> query, int pageNumber, int pageSize)
        {
            return query.Skip(pageSize * pageNumber).Take(pageSize);
        }
    }
}
