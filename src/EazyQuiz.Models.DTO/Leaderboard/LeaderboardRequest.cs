namespace EazyQuiz.Models.DTO
{
    public class LeaderboardRequest
    {
        public int Count { get; set; } = 5;
        public string? Country { get; set; }
    }
}
