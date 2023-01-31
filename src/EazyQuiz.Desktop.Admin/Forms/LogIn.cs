using EazyQuiz.Models;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace EazyQuiz.Desktop.Admin;

public partial class LogIn : Form
{
    private readonly ApiProvider _apiProvider;

    public LogIn(ApiProvider apiProvider)
    {
        InitializeComponent();
        _apiProvider = apiProvider;
    }

    private void EnterButtonClick(object sender, EventArgs e)
    {
        string email = EmailTextBox.Text;
        string password = PasswordTextBox.Text;
        var userAuth = new UserAuth(email, password);
        MessageBox.Show(_apiProvider.Authtenticate(userAuth).Email);
    }
}
