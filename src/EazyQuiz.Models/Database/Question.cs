using System.ComponentModel.DataAnnotations;

namespace EazyQuiz.Models;
public class Question
{
    [Key]
    public int Id { get; set; }
    public string? Text { get; set; }
    public int Points { get; set; }

}
