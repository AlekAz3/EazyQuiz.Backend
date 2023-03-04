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


        builder.Services.AddControllers();
        builder.Services.AddDbContext<DataContext>();
        builder.Services.AddScoped<IUserService, UserService>();
        builder.Services.AddScoped<IQuestionsService, QuestionsService>();
        builder.Services.AddEndpointsApiExplorer();

        builder.Services.AddAuth(builder.Configuration); //Добавление JWT
        builder.Services.AddSwaggerWithAuth();


        var app = builder.Build();


        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthentication();
        app.UseAuthorization();


        app.MapControllers();

        app.Run();
    }
}
