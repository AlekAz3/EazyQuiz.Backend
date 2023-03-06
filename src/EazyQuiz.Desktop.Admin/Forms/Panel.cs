namespace EazyQuiz.Desktop.Admin;
public partial class Panel : Form
{
    /// <summary>
    /// <inheritdoc cref="UserToken/>
    /// </summary>
    private readonly UserToken _userToken;
    private readonly ApiProvider _apiProvider;

    public Panel(UserToken userToken, ApiProvider apiProvider)
    {
        _userToken = userToken;
        _apiProvider = apiProvider;
        InitializeComponent();
    }

    public void Open()
    {
        StatusLabel.Text = $"{_userToken.User.UserName}\n{_userToken.User.Age}\n{_userToken.User.Country}";
        TokenLabel.Text = _userToken.User.Token;
        Show();
    }

    private void button1_Click(object sender, EventArgs e)
    {
        var question = _apiProvider.GetQuestion(_userToken.User.Token);
        MessageBox.Show(question.Text);

    }
}
