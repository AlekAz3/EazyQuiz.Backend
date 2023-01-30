namespace EazyQuiz.Models;
public class UserResponse
{
    public int Id { get; set; }

    public string? Email { get; set; }

    public string? UserName { get; set; }

    public int Age { get; set; }

    public int Gender { get; set; }

    public int Points { get; set; }

    public string? Country { get; set; }

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
