namespace EazyQuiz.Models.DTO
{
    public class AnswerWithoutId
    {
        public string Text { get; set; } = string.Empty;
        public bool IsCorrect { get; set; }
    }
}
