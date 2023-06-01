using System;

namespace EazyQuiz.Models.DTO
{
    /// <summary>
    /// ДТО Возвращаемое сервером после авторизации
    /// </summary>
    [Serializable]
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
        /// JWT Токен с Refrash токен 
        /// </summary>
        public Token? Token { get; set; }
    }
}
