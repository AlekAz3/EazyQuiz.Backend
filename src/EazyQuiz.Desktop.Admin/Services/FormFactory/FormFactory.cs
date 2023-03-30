using Microsoft.Extensions.DependencyInjection;

namespace EazyQuiz.Desktop.Admin;

/// <summary>
/// Реализация <inheritdoc cref="IFormFactory"/>
/// </summary>
public class FormFactory : IFormFactory
{
    /// <summary>
    /// <inheritdoc cref="IServiceScope"/>
    /// </summary>
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
