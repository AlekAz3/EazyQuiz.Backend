namespace EazyQuiz.Models.DTO
{
    /// <summary>
    /// Отправить обратную связь на сервер
    /// </summary>
    public class FeedbackRequest
    {
        /// <summary>
        /// Текст
        /// </summary>
        public string Text { get; set; } = null!;

        /// <summary>
        /// Почта
        /// </summary>
        public string Email { get; set; } = string.Empty;
    }
}
