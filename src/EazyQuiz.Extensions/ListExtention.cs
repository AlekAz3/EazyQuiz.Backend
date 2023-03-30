using System;
using System.Collections.Generic;

namespace EazyQuiz.Extensions
{
    /// <summary>
    /// Расширения для <see cref="IList{T}"/>
    /// </summary>
    public static class ListExtention
    {
#pragma warning disable IDE0090 // Use 'new(...)'
        private static readonly Random Random = new Random();
#pragma warning restore IDE0090 // Use 'new(...)'

        /// <summary>
        /// Перемешать коллекцию
        /// </summary>
        /// <typeparam name="T">Тип</typeparam>
        /// <param name="list"></param>
        /// <returns>Коллекция</returns>
        public static IList<T> Shuffle<T>(this IList<T> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = Random.Next(n + 1);
                (list[n], list[k]) = (list[k], list[n]);
            }
            return list;
        }
    }
}
