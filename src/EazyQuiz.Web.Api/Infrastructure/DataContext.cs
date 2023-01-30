using EazyQuiz.Models;
using EazyQuiz.Models.Database;
using Microsoft.EntityFrameworkCore;

namespace EazyQuiz.Web.Api.Infrastructure;

public class DataContext : DbContext
{
    public DbSet<User>? User { get; set; }
    public DbSet<Question>? Questions { get; set; }
    private readonly IConfiguration _config;
    private readonly ILogger<DataContext> _logger;

    public DataContext(IConfiguration config, ILogger<DataContext> logger)
    {
        _config = config;
        _logger = logger;
        Database.EnsureCreated();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        string connectionString = _config.GetConnectionString(nameof(DataContext));
        optionsBuilder.UseSqlServer(connectionString);
    }
}
