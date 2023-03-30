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

        builder.Logging.ClearProviders();
        builder.Logging.AddSerilog(logger);


        builder.Services.AddControllers()
            .AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.PropertyNamingPolicy = null;
            });

        builder.Services.AddDbContext<DataContext>();
        builder.Services.AddScoped<UserService>();
        builder.Services.AddScoped<QuestionsService>();
        builder.Services.AddScoped<HistoryService>();
        builder.Services.AddEndpointsApiExplorer();

        builder.Services.AddAuth(builder.Configuration); //Добавление JWT
        builder.Services.AddSwaggerWithAuth();

        builder.Services.AddAutoMapper();

        var app = builder.Build();

        app.UseSwagger();
        app.UseSwaggerUI();

        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        //app.UseHttpsRedirection();

        app.UseAuthentication();
        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}
