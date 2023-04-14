using AutoMapper;
using EazyQuiz.Data.Entities;
using EazyQuiz.Models.DTO;
using Microsoft.EntityFrameworkCore;

namespace EazyQuiz.Web.Api;

public class QuestionsService
{
    /// <inheritdoc cref="DataContext"/>
    private readonly DataContext _dataContext;

    /// <inheritdoc cref="ILogger{TCategoryName}"/>
    private readonly ILogger<QuestionsService> _logger;

    /// <inheritdoc cref="IMapper"/>
    private readonly IMapper _mapper;

    public QuestionsService(DataContext dataContext, ILogger<QuestionsService> logger, IMapper mapper)
    {
        _dataContext = dataContext;
        _logger = logger;
        _mapper = mapper;
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
            user.IsCorrect = true;
            _dataContext.Update(a);
        }

        _logger.LogInformation("User Answer Question {@User}", user);
        await _dataContext.UserAnswer.AddAsync(user);
        await _dataContext.SaveChangesAsync();
    }

    /// <summary>
    /// Добавить вопрос в базу данных
    /// </summary>
    public async Task AddQuestion(QuestionWithoutId question)
    {
        _logger.LogInformation("New Question {@Question}", question);
        var questionId = Guid.NewGuid();
        var questionEntity = new Question()
        {
            Id = questionId,
            Text = question.Text,
            ThemeId = question.ThemeId,
            Answers = question.Answers.Select(x => new Answers()
            {
                Text = x.Text,
                IsCorrect = x.IsCorrect,
                QuestionId = questionId
            }).ToList(),
        };
        _dataContext.Add(questionEntity);
        await _dataContext.SaveChangesAsync();
    }

    public async Task<IReadOnlyCollection<QuestionWithAnswers>> GetQuestionsByFilter(GetQuestionCommand command, CancellationToken token)
    {
        var questions = await _dataContext.Question
            .Where(x => x.ThemeId == command.ThemeId)
            .OrderBy(x => EF.Functions.Random())
            .Take(command.Count)
            .ToListAsync(token);

        var questionsWithAnswers = questions.Select(x => new QuestionWithAnswers()
        {
            QuestionId = x.Id,
            Text = x.Text,
            Answers = x.Answers.Select(x => _mapper.Map<Answer>(x)).ToList()
        }).ToArray();

        _logger.LogInformation("{@QuestionsWithAnswers}", questions);

        return questionsWithAnswers;
    }
}
