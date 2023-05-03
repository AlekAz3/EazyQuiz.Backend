using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EazyQuiz.Data.Entities;

/// <summary>
/// Описание обьекта ответа
/// </summary>
[Table("Answers")]
public class Answer
{
    /// <summary>
    /// Ид вопроса
    /// </summary>
    [Key] public Guid Id { get; set; }

    /// <summary>
    /// Текст ответа на вопрос
    /// </summary>
    public string Text { get; set; } = string.Empty;

    /// <summary>
    /// Правильный ответ
    /// </summary>
    public bool IsCorrect { get; set; }

    /// <summary>
    /// Ид вопроса
    /// </summary>
    public Guid QuestionId { get; set; }

    public Question? Question { get; set; }
    public ICollection<UsersAnswer> UsersAnswers { get; set; } = new List<UsersAnswer>();
}
