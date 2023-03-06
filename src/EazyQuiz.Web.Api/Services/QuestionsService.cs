using AutoMapper;
using EazyQuiz.Models.Database;
using EazyQuiz.Models.DTO;
using Microsoft.EntityFrameworkCore;

namespace EazyQuiz.Web.Api;

public class QuestionsService
{
    private readonly DataContext _dataContext;
    private readonly ILogger<QuestionsService> _logger;
    private readonly IMapper _mapper;

    public QuestionsService(DataContext dataContext, ILogger<QuestionsService> logger, IMapper mapper)
    {
        _dataContext = dataContext;
        _logger = logger;
        _mapper = mapper;
    }

    public async Task<QuestionWithAnswers> GetQuestion()
    {
        var rand = new Random();

        int skipper = rand.Next(0, _dataContext.Question.Count());
        var question = _dataContext.Question
            .AsNoTracking()
            .OrderBy(x => Guid.NewGuid())
            .Skip(skipper)
            .Take(1)
            .FirstOrDefault();

        var answerList = await _dataContext.Answer
            .AsNoTracking()
            .Where(a => a.QuestionId == question.Id)
            .ToListAsync();

        var a = new QuestionWithAnswers()
        {
            QuestionId = question.Id,
            Text = question.Text,
            Answers = answerList.Select(x => _mapper.Map<Answer>(x)).ToList()
        };
        _logger.LogInformation("{@A}", a);
        return a;
    }

    public async Task WriteUserAnswer(UserAnswer answer)
    {
        var user = _mapper.Map<UsersAnswers>(answer);

        if (_dataContext.Answer.Find(answer.AnswerId).IsCorrect)
        {
            var a = await _dataContext.User.FindAsync(answer.UserId);
            a.Points++;
            _dataContext.Update(a);
        }

        _logger.LogInformation("User Answer Question {@User}", user);
        await _dataContext.UserAnswer.AddAsync(user);
        await _dataContext.SaveChangesAsync();
    }

    private int GetQuestionCount()
    {
        return _dataContext.Question.Count() + 1;
    }
}
