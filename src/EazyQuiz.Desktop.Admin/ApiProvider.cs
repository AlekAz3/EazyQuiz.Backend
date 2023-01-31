using Microsoft.Extensions.Configuration;

namespace EazyQuiz.Desktop.Admin;
public class ApiProvider
{
    private readonly IConfiguration _config;

    public ApiProvider(IConfiguration config)
    {
        _config = config;
    }
}
