using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace EazyQuiz.Models.Database;

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
    /// Почта
    /// </summary>
    public int Age { get; set; }

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
    /// Время Регистрации
    /// </summary>
    public DateTimeOffset RegistrationTime { get; set; }

    /// <summary>
    /// Пароль Хэш
    /// </summary>
    [JsonIgnore]
    public byte[]? PasswordHash { get; set; }

    /// <summary>
    /// Соль пароля
    /// </summary>
    [JsonIgnore]
    public byte[]? PasswordSalt { get; set; }
}
