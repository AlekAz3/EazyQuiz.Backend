using EazyQuiz.Extensions;
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

    private async void SendQuestionToServer(object sender, EventArgs e)
    {
        if (QuestionInput.Text.IsNullOrEmpty() || FirstAnswerInput.Text.IsNullOrEmpty() || SecondAnswerInput.Text.IsNullOrEmpty() || ThirdAnswerInput.Text.IsNullOrEmpty() || ForthAnswerInput.Text.IsNullOrEmpty())
        {
            MessageBox.Show("Есть пустое поле", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        var quws = new QuestionWithoutId()
        {
            Text = QuestionInput.Text,
            Answers = new List<AnswerWithoutId>()
            {
                new AnswerWithoutId()
                {
                    Text = FirstAnswerInput.Text,
                    IsCorrect = IsFirstAnswerCorrect.Checked
                },
                new AnswerWithoutId()
                {
                    Text = SecondAnswerInput.Text,
                    IsCorrect = IsSecondAnswerCorrect.Checked
                },
                new AnswerWithoutId()
                {
                    Text = ThirdAnswerInput.Text,
                    IsCorrect = IsThirdAnswerCorrect.Checked
                },
                new AnswerWithoutId()
                {
                    Text = ForthAnswerInput.Text,
                    IsCorrect = IsForthAnswerCorrect.Checked
                },
            }
        };
        await _apiProvider.SendNewQuestion(quws);
        MessageBox.Show("Вопрос отправлен", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
        QuestionInput.Text = "";
        FirstAnswerInput.Text = "";
        SecondAnswerInput.Text = "";
        ThirdAnswerInput.Text = "";
        ForthAnswerInput.Text = "";
    }
}
