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

    /// <summary>
    /// Получить 10 вопросов с ответами 
    /// </summary>
    /// <returns>Коллекция вопросов</returns>
    public async Task<IReadOnlyCollection<QuestionWithAnswers>> GetTenQuestions()
    {
        var questions = await _dataContext.Question
            .AsNoTracking()
            .OrderBy(x => EF.Functions.Random())
            .Take(10)
            .ToListAsync();

        var question = questions.Select(x => new QuestionWithAnswers()
        {
            QuestionId = x.Id,
            Text = x.Text,
            Answers = _dataContext.Answer
                    .AsNoTracking()
                    .Where(y => y.QuestionId == x.Id)
                    .Select(x => _mapper.Map<Answer>(x))
                    .ToList()
        }).ToArray();

        _logger.LogInformation("{@A}", question);

        return question;
    }

    /// <summary>
    /// Записать ответ игрока в базу данных
    /// </summary>
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

    /// <summary>
    /// Добавить вопрос в базу данных
    /// </summary>
    internal async Task AddQuestion(QuestionWithoutId question)
    {
        _logger.LogInformation("New Question {@Ques}", question);
        var questionId = Guid.NewGuid();
        var questionEntity = new Question()
        {
            Id = questionId,
            Text = question.Text
        };
        var answerEntities = question.Answers
            .Select(x => new Answers()
            {
                Text = x.Text,
                IsCorrect = x.IsCorrect,
                QuestionId = questionId
            });
        _dataContext.Question.Add(questionEntity);
        await _dataContext.SaveChangesAsync();
        _dataContext.Answer.AddRange(answerEntities);
        await _dataContext.SaveChangesAsync();
    }
}
