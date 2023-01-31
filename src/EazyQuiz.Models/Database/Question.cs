using System.ComponentModel.DataAnnotations;

namespace EazyQuiz.Models;
/// <summary>
/// Описание обьекта вопроса
/// </summary>
public class Question
{
    /// <summary>
    /// Ид
    /// </summary>
    [Key]
    public int Id { get; set; }

    /// <summary>
    /// Тест вопроса
    /// </summary>
    public string? Text { get; set; }

    /// <summary>
    /// Количество очков
    /// </summary>
    public int Points { get; set; }

}
