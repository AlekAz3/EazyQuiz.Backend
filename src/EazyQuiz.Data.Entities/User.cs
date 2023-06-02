using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EazyQuiz.Data.Entities;

/// <summary>
///     Описание пользователя
/// </summary>
[Table("Users")]
public class User
{
    /// <summary>
    ///     Ид
    /// </summary>
    [Key]
    public Guid Id { get; set; }

    /// <summary>
    ///     Ник
    /// </summary>
    public string Username { get; set; } = string.Empty;

    /// <summary>
    ///     Счёт
    /// </summary>
    public int Points { get; set; }

    /// <summary>
    ///     Страна
    /// </summary>
    public string Country { get; set; } = string.Empty;

    /// <summary>
    ///     Время последней активности
    /// </summary>
    public DateTimeOffset LastActiveTime { get; set; }

    /// <summary>
    ///     Роль
    /// </summary>
    public string Role { get; set; } = string.Empty;

    /// <summary>
    ///     Пароль Хэш
    /// </summary>
    public string? PasswordHash { get; set; }

    /// <summary>
    ///     Соль пароля
    /// </summary>
    public string? PasswordSalt { get; set; }

    /// <summary>
    ///     Токен обновления
    /// </summary>
    public string? RefreshToken { get; set; }

    /// <summary>
    ///     Коллекция ответов пользователей
    /// </summary>
    public ICollection<UsersAnswer> UsersAnswers { get; set; } = new List<UsersAnswer>();

    /// <summary>
    ///     Коллекция предложенных вопросов от пользователей
    /// </summary>
    public ICollection<UsersQuestions> UsersQuestions { get; set; } = new List<UsersQuestions>();

    /// <summary>
    ///     Коллекция отзывов
    /// </summary>
    public ICollection<Feedback> Feedbacks { get; set; } = new List<Feedback>();
}
