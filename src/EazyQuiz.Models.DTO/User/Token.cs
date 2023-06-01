using System;

namespace EazyQuiz.Models.DTO
{
    /// <summary>
    /// Токен
    /// </summary>
    [Serializable]
    public class Token
    {
        /// <summary>
        /// Jwt
        /// </summary>
        public string? Jwt { get; set; }

        /// <summary>
        /// RT
        /// </summary>
        public string? RefrashToken { get; set; }
    }
}
