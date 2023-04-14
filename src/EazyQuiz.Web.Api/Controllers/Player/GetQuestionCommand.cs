namespace EazyQuiz.Web.Api;

public class GetQuestionCommand
{
    public Guid ThemeId { get; set; }
    public int Count { get; set; }
}
