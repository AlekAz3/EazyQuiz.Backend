namespace EazyQuiz.Models.DTO
{
    public class UserAnswer
    {
        /// <summary>
        /// Ид Игрока
        /// </summary>
        public int IdUser { get; set; }

        /// <summary>
        /// Ид вопроса
        /// </summary>
        public int IdQuestion { get; set; }

        /// <summary>
        /// Ид ответа
        /// </summary>
        public int IdAnswer { get; set; }
    }
}
