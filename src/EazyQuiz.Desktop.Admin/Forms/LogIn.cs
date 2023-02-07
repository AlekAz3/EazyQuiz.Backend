using EazyQuiz.Extensions;
using EazyQuiz.Models;

namespace EazyQuiz.Desktop.Admin;

public partial class LogIn : Form
{
    /// <summary>
    /// <inheritdoc cref="ApiProvider/>
    /// </summary>
    private readonly ApiProvider _apiProvider;

    /// <summary>
    /// <inheritdoc cref="UserToken/>
    /// </summary>
    private readonly UserToken _userToken;

    /// <summary>
    /// <inheritdoc cref="IFormFactory/>
    /// </summary>
    private readonly IFormFactory _formFactory;

    public LogIn(ApiProvider apiProvider, UserToken userToken, IFormFactory formFactory)
    {
        _apiProvider = apiProvider;
        _userToken = userToken;
        _formFactory = formFactory;
        InitializeComponent();
    }

    /// <summary>
    /// Открытие окна
    /// </summary>
    internal void Open()
    {
        if (!Application.OpenForms.OfType<LogIn>().Any())
        {
            Show();
        }
    }

    /// <summary>
    /// Действия при нажатии кнопки "Вход"
    /// </summary>
    private void EnterButtonClick(object sender, EventArgs e)
    {
        string username = UsernameInput.Text;
        string password = PasswordInput.Text;

        if (username.IsNullOrEmpty() || username.IsNullOrEmpty())
        {
            MessageBox.Show("Есть пустые поля", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        _userToken.User = _apiProvider.Authtenticate(username, password);

        if (_userToken.User.Id == 0)
        {
            MessageBox.Show("Неверный логин/пароль", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        _formFactory.Create<Panel>().Open();
    }

    /// <summary>
    /// Действия при нажатии кнопки "Регистрация"
    /// </summary>
    private void RegistrationButtonClick(object sender, EventArgs e)
    {
        _formFactory.Create<Registration>().Open();
    }
}
