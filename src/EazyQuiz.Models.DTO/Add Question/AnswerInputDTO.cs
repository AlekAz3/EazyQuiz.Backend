namespace EazyQuiz.Models.DTO
{
    /// <summary>
    ///     Ответ без Ид
    /// </summary>
    public class AnswerInputDTO
    {
        /// <summary>
        ///     Текст ответа
        /// </summary>
        public string Text { get; set; } = string.Empty;

        /// <summary>
        ///     Правильность ответа
        /// </summary>
        public bool IsCorrect { get; set; }
    }
}
