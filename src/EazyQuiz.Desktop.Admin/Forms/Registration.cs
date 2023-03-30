using EazyQuiz.Extensions;

namespace EazyQuiz.Desktop.Admin;

/// <summary>
/// Форма регистрации новых игроков
/// </summary>
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
        GenderInput.SelectedIndex = 0;
        CountryInput.SelectedIndex = 0;
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
        string password = PasswordInput.Text;
        string passwordVerify = PasswordVerifyInput.Text;
        string username = UsernameInput.Text;
        int age = (int)AgeInput.Value;
        string? gender = GenderInput.SelectedItem.ToString();
        string? country = CountryInput.SelectedItem.ToString();

        if (!(password.IsEqual(passwordVerify) && password.IsNoBannedSymbols() && password.IsContaintsLowerCaseLetter() && password.IsContaintsUpperCaseLetter() && password.IsContaintsNumeric() && password.IsMoreEightSymbols()))
        {
            MessageBox.Show("Неверный пароль", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        if (username.IsNullOrEmpty())
        {
            MessageBox.Show("Неверный ник", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        if (age <= 0)
        {
            MessageBox.Show("Неверный поле возраст", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }
        if (_apiProvider.CheckUsername(username))
        {
            MessageBox.Show("Ник уже существует", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

#pragma warning disable CS8604 // Possible null reference argument.
        Task.Run(() => { return _apiProvider.Registrate(password, username, age, gender, country); });
#pragma warning restore CS8604 // Possible null reference argument.

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
