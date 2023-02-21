using System.ComponentModel.DataAnnotations.Schema;

namespace EazyQuiz.Models.Database;
/// <summary>
/// Ответы пользователей
/// </summary>
[Table("UsersAnswers")]
public class UsersAnswers
{
    /// <summary>
    /// Ид
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Ид Юзера
    /// </summary>
    public int IdUser { get; set; }

    /// <summary>
    /// Ид Ответа 
    /// </summary>
    public int IdAnswer { get; set; }

    /// <summary>
    /// Ид вопроса
    /// </summary>
    public int IdQuestion { get; set; }
}
