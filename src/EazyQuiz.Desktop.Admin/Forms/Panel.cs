using EazyQuiz.Models.DTO;

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
        Show();
    }

    private void SendQuestionToServer(object sender, EventArgs e)
    {
        var quws = new QuestionWithoutId()
        {
            Text = QuestionInput.Text,
        }
    }
}
