using Microsoft.Extensions.DependencyInjection;

namespace EazyQuiz.Desktop.Admin;
public class FormFactory : IFormFactory
{
    private readonly IServiceScope _scope;

    public FormFactory(IServiceScopeFactory scopeFactory)
    {
        _scope = scopeFactory.CreateScope();
    }

    public T Create<T>() where T : Form
    {
        return _scope.ServiceProvider.GetRequiredService<T>();
    }
}
