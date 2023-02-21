namespace EazyQuiz.Models.DTO
{
    public class QuestionResponse
    {
        /// <summary>
        /// Ид вопроса
        /// </summary>
        public int IdQuestion { get; set; }

        /// <summary>
        /// Тест вопроса
        /// </summary>
        public string TextQuestion { get; set; } = string.Empty;

        /// <summary>
        /// Ид правильного ответа
        /// </summary>
        public int IdCorrectAnswer { get; set; }

        /// <summary>
        /// Тест правильного ответа 
        /// </summary>
        public string TextCorrectAnswer { get; set; } = string.Empty;

        /// <summary>
        /// Ид первого неправильного ответа
        /// </summary>
        public int IdFirstAnswer { get; set; }

        /// <summary>
        /// Текст первого неправильного ответа
        /// </summary>
        public string TextFirstAnswer { get; set; } = string.Empty;

        /// <summary>
        /// Ид второго неправильного ответа
        /// </summary>
        public int IdSecondAnswer { get; set; }

        /// <summary>
        /// Текст второго неправильного ответа
        /// </summary>
        public string TextSecondAnswer { get; set; } = string.Empty;

        /// <summary>
        /// Ид третьего неправильного ответа
        /// </summary>
        public int IdThirdAnswer { get; set; }

        /// <summary>
        /// Текст третьего неправильного ответа
        /// </summary>
        public string TextThirdAnswer { get; set; } = string.Empty;
    }
}
