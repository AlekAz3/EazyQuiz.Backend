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
    /// <inheritdoc cref="UserPassword"/>
    /// </summary>
    public UserPassword? Password { get; set; }

    public UserAuth(string? email, UserPassword password)
    {
        Email = email;
        Password = password;
    }

    public UserAuth() { }
}
