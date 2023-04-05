using EazyQuiz.Models.Database;
using Microsoft.EntityFrameworkCore;

namespace EazyQuiz.Web.Api;

/// <summary>
/// Контекст подключения к базе данных
/// </summary>
public class DataContext : DbContext
{
    /// <summary>
    /// Таблица User
    /// </summary>
    public DbSet<User> User { get; set; }

    /// <summary>
    /// Таблица Questions
    /// </summary>
    public DbSet<Question> Question { get; set; }

    /// <summary>
    /// Таблица Answers
    /// </summary>
    public DbSet<Answers> Answer { get; set; }

    /// <summary>
    /// Таблица UsersAnswers
    /// </summary>
    public DbSet<UsersAnswers> UserAnswer { get; set; }

    /// <summary>
    /// Таблица UsersQuesions
    /// </summary>
    public DbSet<UsersQuesions> UsersQuestions { get; set; }

    /// <inheritdoc cref="IConfiguration"/>
    private readonly IConfiguration _config;

    /// <inheritdoc cref="ILogger{TCategoryName}"/>
    private readonly ILogger<DataContext> _log;

    public DataContext(IConfiguration config, ILogger<DataContext> logger)
    {
        _config = config;
        _log = logger;
        Database.EnsureCreated();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        string connectionString = _config.GetConnectionString(nameof(DataContext));
        optionsBuilder.UseNpgsql(connectionString);
    }
}
