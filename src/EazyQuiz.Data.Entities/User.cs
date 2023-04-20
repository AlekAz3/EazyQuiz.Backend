using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EazyQuiz.Data.Entities;

/// <summary>
/// Описание пользователя
/// </summary>
[Table("Users")]
public class User
{
    /// <summary>
    /// Ид
    /// </summary>
    [Key]
    public Guid Id { get; set; }

    /// <summary>
    /// Ник
    /// </summary>
    public string Username { get; set; } = string.Empty;

    /// <summary>
    /// Возраст
    /// </summary>
    public DateTimeOffset BirthDate { get; set; }

    /// <summary>
    /// Пол
    /// </summary>
    public string Gender { get; set; } = string.Empty;

    /// <summary>
    /// Счёт
    /// </summary>
    public int Points { get; set; }

    /// <summary>
    /// Страна
    /// </summary>
    public string Country { get; set; } = string.Empty;

    /// <summary>
    /// Время последней активности
    /// </summary>
    public DateTimeOffset LastActiveTime { get; set; }

    /// <summary>
    /// Роль
    /// </summary>
    public string Role { get; set; } = string.Empty;

    /// <summary>
    /// Пароль Хэш
    /// </summary>
    public string? PasswordHash { get; set; }

    /// <summary>
    /// Соль пароля
    /// </summary>
    public string? PasswordSalt { get; set; }

    public ICollection<UsersAnswers> UsersAnswers { get; set; } = new List<UsersAnswers>();

    public ICollection<UsersQuesions> UsersQuesions { get; set; } = new List<UsersQuesions>();
}
