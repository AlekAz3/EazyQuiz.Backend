namespace EazyQuiz.Desktop.Admin;

/// <summary>
/// Интерфейс фабрика по создаю форм
/// </summary>
public interface IFormFactory
{
    /// <summary>
    /// Создание экземпляра класса наследника от <see cref="Form"/>
    /// </summary>
    /// <typeparam name="T"><see cref="Form"/></typeparam>
    /// <returns><see cref="Form"/></returns>
    T Create<T>() where T : Form;
}
