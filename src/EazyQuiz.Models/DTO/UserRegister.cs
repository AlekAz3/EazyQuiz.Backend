
namespace EazyQuiz.Models;
/// <summary>
/// ДТО полей для регистрации
/// </summary>
public class UserRegister
{
    /// <summary>
    /// Почта/Логин
    /// </summary>
    public string? Email { get; set; }

    /// <summary>
    /// Пароль
    /// </summary>
    public string? Password { get; set; }

    /// <summary>
    /// Ник
    /// </summary>
    public string? UserName { get; set; }

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
    public string? Country { get; set; }
}