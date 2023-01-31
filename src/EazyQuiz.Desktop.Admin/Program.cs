using Microsoft.Extensions.DependencyInjection;
using Serilog;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace EazyQuiz.Desktop.Admin;

internal static class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    private static void Main()
    {
        var host = Host.CreateDefaultBuilder()
                     .ConfigureServices((context, services) =>
                     {
                         ConfigureServices(context.Configuration, services);
                     })
                     .Build();

        var services = host.Services;
        var mainForm = services.GetRequiredService<LogIn>();
        Application.Run(mainForm);
    }

    private static void ConfigureServices(IConfiguration configuration, IServiceCollection services)
    {
        services.AddSingleton<LogIn>();
        services.AddScoped<ApiProvider>();
    }
}
