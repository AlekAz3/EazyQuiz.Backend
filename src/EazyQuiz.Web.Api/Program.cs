using EazyQuiz.Web.Api.Infrastructure;
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
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();
        app.UseAuthentication();

        app.MapControllers();

        app.Run();
    }
}
