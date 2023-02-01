using EazyQuiz.Models;

namespace EazyQuiz.Desktop.Admin;
/// <summary>
/// Глобальный параметр  
/// </summary>
public class UserToken
{
    /// <summary>
    /// Инфа об авторизованном пользователе
    /// </summary>
    public UserResponse User { get; set; } = new UserResponse(0, null, null, 0, 0, 0, null, null);
}
