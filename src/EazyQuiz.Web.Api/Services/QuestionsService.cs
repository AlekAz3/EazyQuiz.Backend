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
        var userAnswer = _mapper.Map<UsersAnswer>(answer);

        if ((await _dataContext.Answer.FindAsync(answer.AnswerId)).IsCorrect)
        {
            var player = await _dataContext.User.FindAsync(answer.UserId);
            player.Points++;
            player.LastActiveTime = DateTime.UtcNow;
            userAnswer.IsCorrect = true;
            _dataContext.Update(player);
        }

        _logger.LogInformation("User Answer Question {@User}", userAnswer);
        await _dataContext.UserAnswer.AddAsync(userAnswer);
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
            Answers = question.Answers.Select(x => new Answer()
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
        var questionss = _dataContext.Question
            .AsNoTracking()
            .Where(x => command.ThemeId == null || x.ThemeId == command.ThemeId)
            .OrderBy(x => EF.Functions.Random())
            .Take(command.Count)
            .Include(x => x.Answers);

        var questions = await questionss.ToListAsync(token);

        _logger.LogInformation("{@QuestionsWithAnswers}", questionss.ToQueryString());

        var questionsWithAnswers = questions.Select(x => new QuestionWithAnswers()
        {
            QuestionId = x.Id,
            Text = x.Text,
            Answers = x.Answers.Select(x => _mapper.Map<AnswerDTO>(x)).ToList(),
        }).ToArray();

        return questionsWithAnswers;
    }
}
