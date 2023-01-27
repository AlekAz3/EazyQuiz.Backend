namespace EazyQuiz.Models;

/// <summary>
/// Роли пользователей 
/// </summary>
public class Roles
{
    /// <summary>
    /// Id
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Название
    /// </summary>
    public string? Name { get; set; }

    /// <summary>
    /// Удалено
    /// </summary>
    public bool Deleted { get; set; }
}
