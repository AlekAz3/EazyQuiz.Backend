using EazyQuiz.Models;
using System.Text.Json;

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
        MessageBox.Show(JsonSerializer.Serialize(_apiProvider.Authtenticate(userAuth)));
    }
}
