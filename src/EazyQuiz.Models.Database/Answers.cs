using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EazyQuiz.Models.Database;

/// <summary>
/// Описание обьекта ответа
/// </summary>
[Table("Answers")]
public class Answers
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
}
