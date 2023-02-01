using EazyQuiz.Models;

namespace EazyQuiz.Desktop.Admin;
public partial class Registration : Form
{
    /// <summary>
    /// <inheritdoc cref="IFormFactory/>
    /// </summary>
    private readonly IFormFactory _formFactory;

    /// <summary>
    /// <inheritdoc cref="ApiProvider/>
    /// </summary>
    private readonly ApiProvider _apiProvider;

    public Registration(IFormFactory formFactory, ApiProvider apiProvider)
    {
        _formFactory = formFactory;
        _apiProvider = apiProvider;
        InitializeComponent();
    }

    /// <summary>
    /// Показать это окно
    /// </summary>
    public void Open()
    {
        if (!Application.OpenForms.OfType<Registration>().Any())
        {
            Show();
        }
    }

    /// <summary>
    /// Действия при нажатии кнопки "Зарегистрироваться"
    /// </summary>
    private void RegisterButtonClick(object sender, EventArgs e)
    {
        var userRegister = new UserRegister()
        {
            Email = EmailInput.Text,
            Password = PasswordInput.Text,
            UserName = UsernameInput.Text,
            Age = (int)AgeInput.Value,
            Gender = GenderInput.SelectedIndex + 1,
            Country = GenderInput.SelectedText
        };
        _apiProvider.Registrate(userRegister);
        MessageBox.Show("Регистрация прошла успешно");
        Close();
    }

    /// <summary>
    /// Действия при нажатии кнопки "Вход"
    /// </summary>
    private void EnterButtonClick(object sender, EventArgs e)
    {
        Close();
        _formFactory.Create<LogIn>().Open();
    }
}