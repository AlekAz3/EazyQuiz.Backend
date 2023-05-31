namespace EazyQuiz.Models.DTO
{
    /// <summary>
    /// Токен
    /// </summary>
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
