using EazyQuiz.Models;
namespace EazyQuiz.Desktop.Admin;

public partial class LogIn : Form
{
    private readonly ApiProvider _apiProvider;
    private readonly UserToken _userToken;
    private readonly IFormFactory _formFactory;

    public LogIn(ApiProvider apiProvider, UserToken userToken, IFormFactory formFactory)
    {
        _apiProvider = apiProvider;
        _userToken = userToken;
        _formFactory = formFactory;
        InitializeComponent();
    }

    internal void Open()
    {
        if (!Application.OpenForms.OfType<LogIn>().Any())
        {
            Show();
        }
    }

    private void EnterButtonClick(object sender, EventArgs e)
    {
        string email = EmailTextBox.Text;
        string password = PasswordTextBox.Text;
        var userAuth = new UserAuth(email, password);
        _userToken.User = _apiProvider.Authtenticate(userAuth);
        _formFactory.Create<Panel>().Open();
    }

    private void RegistrationButtonClick(object sender, EventArgs e)
    {
        _formFactory.Create<Registration>().Open();
    }
}
