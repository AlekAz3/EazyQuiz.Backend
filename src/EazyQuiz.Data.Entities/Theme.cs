namespace EazyQuiz.Data.Entities;


public class Theme
{
    public Guid Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public bool Enabled { get; set; }

    public IEnumerable<Question> Questions { get; set; } = Enumerable.Empty<Question>();
}
