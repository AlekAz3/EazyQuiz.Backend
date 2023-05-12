using EazyQuiz.Data.Entities;
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
    public DbSet<Answer> Answer { get; set; }

    /// <summary>
    /// Таблица UsersAnswers
    /// </summary>
    public DbSet<UsersAnswer> UserAnswer { get; set; }

    /// <summary>
    /// Таблица UsersQuestions
    /// </summary>
    public DbSet<UsersQuestions> UsersQuestions { get; set; }

    /// <summary>
    /// Таблица Themes
    /// </summary>
    public DbSet<Theme> Themes { get; set; }

    /// <inheritdoc cref="IConfiguration"/>
    private readonly IConfiguration _config;

    public DataContext(IConfiguration config)
    {
        _config = config;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        string connectionString = _config.GetConnectionString(nameof(DataContext));
        optionsBuilder.UseNpgsql(connectionString);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(Data.AssemblyMarker).Assembly);
    }
}
