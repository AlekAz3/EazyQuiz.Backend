using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EazyQuiz.Data.Entities;

/// <summary>
/// Обратная связь
/// </summary>
[Table("Feedbacks")]
public class Feedback
{
    /// <summary>
    /// Ид
    /// </summary>
    [Key]
    public Guid Id { get; set; }

    /// <summary>
    /// Ид пользователя
    /// </summary>
    public Guid UserId { get; set; }

    /// <summary>
    /// Текст
    /// </summary>
    public string Text { get; set; } = string.Empty;

    /// <summary>
    /// Почта
    /// </summary>
    public string Email { get; set; } = string.Empty;

    /// <summary>
    /// Статус
    /// </summary>
    public string Status { get; set; } = string.Empty;

    /// <summary>
    /// Пользователь
    /// </summary>
    public User? User { get; set; }
}
