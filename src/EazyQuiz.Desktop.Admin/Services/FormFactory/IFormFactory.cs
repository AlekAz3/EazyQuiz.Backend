
namespace EazyQuiz.Desktop.Admin;
public interface IFormFactory
{
    T Create<T>() where T : Form;
}
