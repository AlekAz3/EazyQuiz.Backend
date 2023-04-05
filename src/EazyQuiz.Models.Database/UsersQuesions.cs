using System.ComponentModel.DataAnnotations;

namespace EazyQuiz.Models.Database;

/// <summary>
/// Временное хранение предложенных вопросов от пользователей
/// </summary>
public class UsersQuesions
{
    /// <summary>
    /// Ид
    /// </summary>
    [Key] public Guid Id { get; set; }

    /// <summary>
    /// Ид пользователя
    /// </summary>
    public Guid UserId { get; set; }

    /// <summary>
    /// Текст предложенного вопроса
    /// </summary>
    public string QuestionText { get; set; } = string.Empty;

    /// <summary>
    /// Текст правильного ответа 
    /// </summary>
    public string AnswerText { get; set; } = string.Empty;

    /// <summary>
    /// Статус 
    /// </summary>
    public string Status { get; set; } = string.Empty;

    /// <summary>
    /// Последнее обновление
    /// </summary>
    public DateTimeOffset LastUpdate { get; set; }
}
