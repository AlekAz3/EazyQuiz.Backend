using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EazyQuiz.Data.Entities;


/// <summary>
/// Тема для вопросов
/// </summary>
[Table("Themes")]
public class Theme
{
    /// <summary>
    /// Ид
    /// </summary>
    [Key]
    public Guid Id { get; set; }

    /// <summary>
    /// Название темы
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Активность
    /// </summary>
    public bool Enabled { get; set; }

    /// <summary>
    /// Вопросы
    /// </summary>
    public IEnumerable<Question> Questions { get; set; } = Enumerable.Empty<Question>();
}
