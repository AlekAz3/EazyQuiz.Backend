using Serilog;

namespace EazyQuiz.Web.Api;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        var logger = new LoggerConfiguration()
        .ReadFrom.Configuration(builder.Configuration) //Использование Serilog
        .Enrich.FromLogContext()
                .WriteTo.Console()
                .WriteTo.File($@".\logs\{DateTimeOffset.Now:dd-MM-yyyy}\log.txt", rollingInterval: RollingInterval.Hour)
                .CreateLogger();

        builder.Logging.ClearProviders()
            .AddSerilog(logger);

        builder.Services.AddControllers()
            .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.PropertyNamingPolicy = null;
                });

        builder.Services
             .AddHttpContextAccessor()
             .AddDbContext<DataContext>()
             .AddEazyQuizServices()
             .AddEndpointsApiExplorer()
             .AddAuth(builder.Configuration); //Добавление JWT


        builder.Services.AddSwaggerWithAuth();

        builder.Services.AddAutoMapper();

        var app = builder.Build();

        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

        app.UseSwagger()
           .UseSwaggerUI();

        if (app.Environment.IsProduction())
        {
            app.UseHttpsRedirection();
        }

        app.UseAuthentication()
           .UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}
