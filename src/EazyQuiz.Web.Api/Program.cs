using Serilog;

namespace EazyQuiz.Web.Api;

public static class Program
{
    public static void Main(string[] args)
    {
        // var logger = new LoggerConfiguration()
        //     .ReadFrom.Configuration(Configuration) //Использование Serilog
        //     .Enrich.FromLogContext()
        //     .WriteTo.Console()
        //     .WriteTo.File($@".\logs\{DateTimeOffset.Now:dd-MM-yyyy}\log.txt", rollingInterval: RollingInterval.Hour)
        //     .CreateLogger();
        CreateHostBuilder(args)
            .Build()
            .Run();
    }
    
    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .UseSerilog()
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
            });
}
