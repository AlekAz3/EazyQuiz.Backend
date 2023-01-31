
namespace EazyQuiz.Models;
/// <summary>
/// ДТО при входе пользователя в систему 
/// </summary>
public class UserAuth
{
    /// <summary>
    /// Почта/Логин
    /// </summary>
    public string? Email { get; set; }

    /// <summary>
    /// Пароль
    /// </summary>
    public string? Password { get; set; }
}
