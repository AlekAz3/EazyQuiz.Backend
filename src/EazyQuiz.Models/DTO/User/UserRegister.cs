
namespace EazyQuiz.Models;
/// <summary>
/// ДТО полей для регистрации
/// </summary>
public class UserRegister
{
    /// <summary>
    /// Ник
    /// </summary>
    public string Username { get; set; } = string.Empty;

    /// <summary>
    /// <inheritdoc cref="UserPassword"/>
    /// </summary>
    public UserPassword? Password { get; set; }

    /// <summary>
    /// Возраст
    /// </summary>
    public int Age { get; set; }

    /// <summary>
    /// Пол
    /// </summary>
    public string Gender { get; set; } = string.Empty;

    /// <summary>
    /// Страна проживания
    /// </summary>
    public string Country { get; set; } = string.Empty;
}
