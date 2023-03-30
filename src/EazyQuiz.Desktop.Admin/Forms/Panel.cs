using EazyQuiz.Extensions;
using EazyQuiz.Models.DTO;

namespace EazyQuiz.Desktop.Admin;

/// <summary>
/// Панель для добавления вопросов 
/// </summary>
public partial class Panel : Form
{
    /// <inheritdoc cref="ApiProvider"/>
    private readonly ApiProvider _apiProvider;

    public Panel(ApiProvider apiProvider)
    {
        _apiProvider = apiProvider;
        InitializeComponent();
    }

    /// <summary>
    /// Открыть окно
    /// </summary>
    public void Open()
    {
        Show();
    }

    /// <summary>
    /// Отправить вопрос на сервер 
    /// </summary>
    private async void SendQuestionToServer(object sender, EventArgs e)
    {
        if (QuestionInput.Text.IsNullOrEmpty() || FirstAnswerInput.Text.IsNullOrEmpty() || SecondAnswerInput.Text.IsNullOrEmpty() || ThirdAnswerInput.Text.IsNullOrEmpty() || ForthAnswerInput.Text.IsNullOrEmpty())
        {
            MessageBox.Show("Есть пустое поле", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        var question = new QuestionWithoutId()
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
        await _apiProvider.SendNewQuestion(question);
        MessageBox.Show("Вопрос отправлен", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);

        foreach (Control c in Controls)
        {
            if (c is RichTextBox)
            {
                c.Text = string.Empty;
            }
        }

    }
}
