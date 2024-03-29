using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EazyQuiz.Data.Entities;

/// <summary>
///     Временное хранение предложенных вопросов от пользователей
/// </summary>
[Table("UsersQuestions")]
public class UsersQuestions
{
    /// <summary>
    ///     Ид
    /// </summary>
    [Key]
    public Guid Id { get; set; }

    /// <summary>
    ///     Ид пользователя
    /// </summary>
    public Guid UserId { get; set; }

    /// <summary>
    ///     Текст предложенного вопроса
    /// </summary>
    public string QuestionText { get; set; } = string.Empty;

    /// <summary>
    ///     Текст правильного ответа
    /// </summary>
    public string AnswerText { get; set; } = string.Empty;

    /// <summary>
    ///     Статус
    /// </summary>
    public string Status { get; set; } = string.Empty;

    /// <summary>
    ///     Последнее обновление
    /// </summary>
    public DateTimeOffset LastUpdate { get; set; }

    /// <summary>
    ///     Пользователь
    /// </summary>
    public User? User { get; set; }
}
