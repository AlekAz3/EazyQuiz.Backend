using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace EazyQuiz.Models;
/// <summary>
/// Описание пользователя
/// </summary>
public class User
{
    /// <summary>
    /// Ид
    /// </summary>
    [Key]
    public int Id { get; set; }

    /// <summary>
    /// Почта/Логин
    /// </summary>
    public string? Email { get; set; }

    /// <summary>
    /// Ник
    /// </summary>
    public string? UserName { get; set; }

    /// <summary>
    /// Почта
    /// </summary>
    public int Age { get; set; }

    /// <summary>
    /// Пол
    /// </summary>
    public int Gender { get; set; }

    /// <summary>
    /// Счёт
    /// </summary>
    public int Points { get; set; }

    /// <summary>
    /// Страна
    /// </summary>
    public string? Country { get; set; }

    /// <summary>
    /// Пароль
    /// </summary>
    [JsonIgnore]
    public string? Password { get; set; }
}
