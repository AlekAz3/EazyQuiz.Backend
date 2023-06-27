using Serilog;

namespace EazyQuiz.Web.Api;

public class Startup
{
    private IConfiguration Configuration { get; }

    private IWebHostEnvironment Environment { get; }

    public Startup(IConfiguration configuration, IWebHostEnvironment environment)
    {
        Configuration = configuration;
        Environment = environment;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers()
            .AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.PropertyNamingPolicy = null;
            });

        services
            .AddHttpContextAccessor()
            .AddDbContext<DataContext>()
            .AddEazyQuizServices()
            .AddEndpointsApiExplorer()
            .AddAuth(Configuration); //Добавление JWT
        
        services.AddSwaggerWithAuth();
        services.AddAutoMapper();
    }

    public void Configure(IApplicationBuilder app)
    {
        if (Environment.IsDevelopment())
        {
            app.UseSwagger()
                .UseSwaggerUI(configure =>
                {
                    configure.RoutePrefix = string.Empty;
                    configure.SwaggerEndpoint("/swagger/v1/swagger.json", "Eazy Quiz Api");

                });
        }
        if (Environment.IsProduction())
        {
            app.UseHttpsRedirection();
        }

        app.UseRouting();

        app.UseEazyQuizMiddleware();
        
        app.UseAuthentication()
            .UseAuthorization();

        
        app.UseEndpoints(endpointRouteBuilder =>
        {
            endpointRouteBuilder.MapControllers();
        });
    }
}
