using System.ComponentModel.DataAnnotations;
namespace EazyQuiz.Models;
public class User
{
    [Key]
    public int Id { get; set; }

    public string? Email { get; set; }

    public string? Password { get; set; }

    public string? UserName { get; set; }

    public int Age { get; set; }

    public int Gender { get; set; }

    public int Points { get; set; }

    public string? Country { get; set; }
}
