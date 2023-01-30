using EazyQuiz.Web.Api.Abstractions;
using EazyQuiz.Web.Api.Infrastructure;
using EazyQuiz.Web.Api.Services;
using Serilog;

namespace EazyQuiz.Web.Api;

public class Program
{
    public static void Main(string[] args)
    {

        var builder = WebApplication.CreateBuilder(args);

        var logger = new LoggerConfiguration()
        .ReadFrom.Configuration(builder.Configuration)
        .Enrich.FromLogContext()
                .WriteTo.Console()
                .CreateLogger();

        // Add services to the container.

        builder.Logging.ClearProviders();
        builder.Logging.AddSerilog(logger);


        builder.Services.AddControllers();
        builder.Services.AddDbContext<DataContext>();
        builder.Services.AddScoped<IUserService, UserService>();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddAuth(builder.Configuration);


        var app = builder.Build();

        // Configure the HTTP request pipeline.
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
