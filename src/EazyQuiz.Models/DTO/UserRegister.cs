
namespace EazyQuiz.Models;
/// <summary>
/// ДТО полей для регистрации
/// </summary>
public class UserRegister
{
    /// <summary>
    /// Почта/Логин
    /// </summary>
    public string Email { get; set; } = string.Empty;

    /// <summary>
    /// Пароль
    /// </summary>
    public string Password { get; set; } = string.Empty;

    /// <summary>
    /// Ник
    /// </summary>
    public string UserName { get; set; } = string.Empty;

    /// <summary>
    /// Возраст
    /// </summary>
    public int Age { get; set; }

    /// <summary>
    /// Пол
    /// </summary>
    public int Gender { get; set; }

    /// <summary>
    /// Страна проживания
    /// </summary>
    public string Country { get; set; } = string.Empty;
}
