using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EazyQuiz.Data.Entities;

/// <summary>
/// Описание объекта вопроса
/// </summary>
[Table("Questions")]
public class Question
{
    /// <summary>
    /// Ид
    /// </summary>
    [Key]
    public Guid Id { get; set; }

    /// <summary>
    /// Тест вопроса
    /// </summary>
    public string? Text { get; set; }

    /// <summary>
    /// Ид темы
    /// </summary>
    public Guid ThemeId { get; set; }

    /// <summary>
    /// Тема
    /// </summary>
    public Theme? Theme { get; set; }

    public ICollection<Answer> Answers { get; set; } = new List<Answer>();
    public ICollection<UsersAnswer> UsersAnswers { get; set; } = new List<UsersAnswer>();
}
