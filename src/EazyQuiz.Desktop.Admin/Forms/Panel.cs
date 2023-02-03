namespace EazyQuiz.Desktop.Admin;
public partial class Panel : Form
{
    /// <summary>
    /// <inheritdoc cref="UserToken/>
    /// </summary>
    private readonly UserToken _userToken;

    public Panel(UserToken userToken)
    {
        _userToken = userToken;
        InitializeComponent();
    }

    public void Open()
    {
        StatusLabel.Text = $"{_userToken.User.UserName}\n{_userToken.User.Age}\n{_userToken.User.Country}";
        TokenLabel.Text = _userToken.User.Token;
        Show();
    }
}
