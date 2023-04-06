using EazyQuiz.Web.Api.Services;
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
                .CreateLogger();

        builder.Logging.ClearProviders()
            .AddSerilog(logger);

        builder.Services.AddControllers()
            .AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.PropertyNamingPolicy = null;
            });

        builder.Services.AddDbContext<DataContext>()
             .AddScoped<UserService>()
             .AddScoped<QuestionsService>()
             .AddScoped<HistoryService>()
             .AddScoped<UsersQuestionService>()
             .AddEndpointsApiExplorer()
             .AddAuth(builder.Configuration); //Добавление JWT


        builder.Services.AddSwaggerWithAuth();

        builder.Services.AddAutoMapper();

        var app = builder.Build();

        app.UseSwagger()
           .UseSwaggerUI();

        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

        app.UseHttpsRedirection();

        app.UseAuthentication()
           .UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}
