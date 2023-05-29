using Microsoft.EntityFrameworkCore;

namespace EazyQuiz.Web.Api;

/// <summary>
/// Контекст подключения к базе данных
/// </summary>
public class DataContext : DbContext
{
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
