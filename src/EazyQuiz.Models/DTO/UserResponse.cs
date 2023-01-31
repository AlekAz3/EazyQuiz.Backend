namespace EazyQuiz.Models;
/// <summary>
/// ДТО Возвращаемое сервером после авторизации
/// </summary>
public class UserResponse
{
    /// <summary>
    /// Ид
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Почта
    /// </summary>
    public string? Email { get; set; }

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
    /// Счёт
    /// </summary>
    public int Points { get; set; }

    /// <summary>
    /// Страна
    /// </summary>
    public string? Country { get; set; }

    /// <summary>
    /// JWT Токен
    /// </summary>
    public string? Token { get; set; }

    public UserResponse(User user, string token)
    {
        Id = user.Id;
        Email = user.Email;
        UserName = user.UserName;
        Age = user.Age;
        Gender = user.Gender;
        Points = user.Points;
        Country = user.Country;
        Token = token;
    }
}
