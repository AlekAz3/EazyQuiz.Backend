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
        string email = EmailTextBox.Text;
        string password = PasswordTextBox.Text;

        _userToken.User = _apiProvider.Authtenticate(email, password);
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
