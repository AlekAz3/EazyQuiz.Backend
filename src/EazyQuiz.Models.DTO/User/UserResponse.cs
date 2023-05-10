using System;

namespace EazyQuiz.Models.DTO
{
    /// <summary>
    /// ДТО Возвращаемое сервером после авторизации
    /// </summary>
    public class UserResponse
    {
        /// <summary>
        /// Ник
        /// </summary>
        public string? UserName { get; set; }

        /// <summary>
        /// Счёт
        /// </summary>
        public int Points { get; set; }

        /// <summary>
        /// Страна
        /// </summary>
        public string? Country { get; set; }

        /// <summary>
        /// JWT Токен
        /// </summary>
        public string? Token { get; set; }
    }
}
