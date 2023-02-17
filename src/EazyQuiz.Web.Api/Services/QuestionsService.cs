using EazyQuiz.Models.Database;
using EazyQuiz.Models.DTO;
using Microsoft.EntityFrameworkCore;

namespace EazyQuiz.Web.Api;

public class QuestionsService
{
    private readonly DataContext _dataContext;
    private readonly ILogger<QuestionsService> _logger;

    public QuestionsService(DataContext dataContext, ILogger<QuestionsService> logger)
    {
        _dataContext = dataContext;
        _logger = logger;
    }

    public async Task<QuestionResponse> GetQuestion()
    {
        var question = _dataContext.Question.Find(new Random().Next(1, GetQuestionCount()));
        var answerList = await _dataContext.Answer.Where(a => a.IdQuestion == question.Id).ToListAsync();
        var correctAnswer = answerList.Single(a => a.IsCorrect);
        var notCorrectAnswers = answerList.Where(a => !a.IsCorrect).ToList();

        return new QuestionResponse()
        {
            IdCorrectAnswer = correctAnswer.Id,
            TextCorrectAnswer = correctAnswer.Text,
            IdFirstAnswer = notCorrectAnswers[0].Id,
            TextFirstAnswer = notCorrectAnswers[0].Text,
            IdSecondAnswer = notCorrectAnswers[1].Id,
            TextSecondAnswer = notCorrectAnswers[1].Text,
            IdThirdAnswer = notCorrectAnswers[2].Id,
            TextThirdAnswer = notCorrectAnswers[2].Text
        };
    }

    public async Task WriteUserAnswer(UserAnswer answer)
    {
        var user = new UsersAnswers()
        {
            Id = GetUserAnswer(),
            IdAnswer = answer.IdAnswer,
            IdQuestion = answer.IdQuestion,
            IdUser = answer.IdUser
        };
        _logger.LogInformation("User Answer Question {@User}", user);
        await _dataContext.UserAnswer.AddAsync(user);
        await _dataContext.SaveChangesAsync();
    }

    private int GetQuestionCount()
    {
        return _dataContext.Question.Count();
    }

    private int GetUserAnswer()
    {
        return _dataContext.UserAnswer.Count();
    }
}
