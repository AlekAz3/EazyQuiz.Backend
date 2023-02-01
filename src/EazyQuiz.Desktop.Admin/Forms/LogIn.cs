using EazyQuiz.Models;
namespace EazyQuiz.Desktop.Admin;

public partial class LogIn : Form
{
    private readonly ApiProvider _apiProvider;
    private readonly UserToken _userToken;

    public LogIn(ApiProvider apiProvider, UserToken userToken)
    {
        _apiProvider = apiProvider;
        _userToken = userToken;
        InitializeComponent();
    }

    private void EnterButtonClick(object sender, EventArgs e)
    {
        string email = EmailTextBox.Text;
        string password = PasswordTextBox.Text;
        var userAuth = new UserAuth(email, password);
        _userToken.User = _apiProvider.Authtenticate(userAuth);
    }
}
