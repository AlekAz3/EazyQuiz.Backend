namespace EazyQuiz.Models.DTO
{
    /// <summary>
    /// Ответ без Ид
    /// </summary>
    /// <remarks>Переименовать, используется для добавления вопросов</remarks>
    public class AnswerInputDTO
    {
        /// <summary>
        /// Текст ответа
        /// </summary>
        public string Text { get; set; } = string.Empty;

        /// <summary>
        /// Правильность ответа
        /// </summary>
        public bool IsCorrect { get; set; }
    }
}
