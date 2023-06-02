using System.ComponentModel.DataAnnotations.Schema;

namespace EazyQuiz.Data.Entities;

/// <summary>
///     Ответы пользователей
/// </summary>
[Table("UsersAnswers")]
public class UsersAnswer
{
    /// <summary>
    ///     Ид
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    ///     Ид пользователя
    /// </summary>
    public Guid UserId { get; set; }

    /// <summary>
    ///     Ид Ответа
    /// </summary>
    public Guid AnswerId { get; set; }

    /// <summary>
    ///     Ид вопроса
    /// </summary>
    public Guid QuestionId { get; set; }

    /// <summary>
    ///     Время ответа на вопрос
    /// </summary>
    public DateTimeOffset AnswerTime { get; set; }

    /// <summary>
    ///     Правильный ответ
    /// </summary>
    public bool IsCorrect { get; set; }

    public User User { get; set; } = null!;
    public Answer Answer { get; set; } = null!;
    public Question Question { get; set; } = null!;
}
