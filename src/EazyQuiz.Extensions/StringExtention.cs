using System.Collections.Generic;
using System.Linq;

namespace EazyQuiz.Extensions
{
    /// <summary>
    /// Класс расширений для <see cref="string"/>
    /// </summary>
    public static class StringExtension
    {
        /// <summary>
        /// Английский алфавит Большой
        /// </summary>
        private static readonly List<char> AlphabetUpperCase = new List<char>
        {
        'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I',
        'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R',
        'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z'
        };

        /// <summary>
        /// Английский алфавит маленький
        /// </summary>
        private static readonly List<char> AlphabetLowerCase = new List<char>
        {
        'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i',
        'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r',
        's', 't', 'u', 'v', 'w', 'x', 'y', 'z'
        };

        /// <summary>
        /// Цифры
        /// </summary>
        private static readonly List<char> Numeric = new List<char>
        {
        '0','1', '2', '3', '4', '5', '6', '7', '8', '9'
        };

        /// <summary>
        /// Проверка на равенство строк
        /// </summary>
        /// <param name="a">Первая строка</param>
        /// <param name="b">Вторая строка</param>
        /// <returns>true если равны </returns>
        public static bool IsEqual(this string a, string b)
        {
            return a == b;
        }

        /// <summary>
        /// В строке больше 8ми символов
        /// </summary>
        /// <param name="str">Строка</param>
        /// <returns>true - если больше</returns>
        public static bool IsMoreEightSymbols(this string str)
        {
            return str.Length >= 8;
        }

        /// <summary>
        /// Проверка на наличие большой буквы
        /// </summary>
        /// <param name="str">Строка</param>
        /// <returns>true - если есть хотя бы одна большая буква</returns>
        public static bool IsContaintsUpperCaseLetter(this string str)
        {
            var result = str.Where(letter => AlphabetUpperCase.Contains(letter)).ToList();

            if (result.Count == 0)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Проверка на наличие маленькой буквы
        /// </summary>
        /// <param name="str">Строка</param>
        /// <returns>true - если есть хотя бы одна маленькая буква</returns>
        public static bool IsContaintsLowerCaseLetter(this string str)
        {
            var result = str.Where(letter => AlphabetLowerCase.Contains(letter)).ToList();

            if (result.Count == 0)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Проверка на наличие хотя бы одной цифры
        /// </summary>
        /// <param name="str">строка</param>
        /// <returns>true - если есть цифра</returns>
        public static bool IsContaintsNumeric(this string str)
        {
            var result = str.Where(letter => Numeric.Contains(letter)).ToList();

            if (result.Count == 0)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Проверка на Null или Пустую строку
        /// </summary>
        /// <param name="str">Строка</param>
        /// <returns>true - если строка null или пустая</returns>
        public static bool IsNullOrEmpty(this string str)
        {
            if (str == null)
            {
                return true;
            }
            if (str.Length == 0)
            {
                return true;
            }
            if (str == " ")
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Проверка на запрещённые символы(в проле можно использовать только те символы которые в списках)
        /// </summary>
        /// <param name="str">Строка</param>
        /// <returns>true если нет запретных символов</returns>
        public static bool IsNoBannedSymbols(this string str)
        {
            var result = str.Where(letter => Numeric.Contains(letter) || AlphabetLowerCase.Contains(letter) || AlphabetUpperCase.Contains(letter)).ToList();
            return result.Count == str.Length;
        }
    }
}
