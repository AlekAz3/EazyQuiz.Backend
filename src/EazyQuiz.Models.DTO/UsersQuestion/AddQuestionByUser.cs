namespace EazyQuiz.Models.DTO
{
    /// <summary>
    /// ДТО добавление кастомного вопроса от пользователя
    /// </summary>
    public class AddQuestionByUser
    {
        /// <summary>
        /// Текст вопроса
        /// </summary>
        public string QuestionText { get; set; } = string.Empty;

        /// <summary>
        /// Текст ответа
        /// </summary>
        public string AnswerText { get; set; } = string.Empty;
    }
}
