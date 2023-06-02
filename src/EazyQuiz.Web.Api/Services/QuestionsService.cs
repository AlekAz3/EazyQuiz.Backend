using AutoMapper;
using EazyQuiz.Data.Entities;
using EazyQuiz.Models.DTO;
using Microsoft.EntityFrameworkCore;

namespace EazyQuiz.Web.Api;

/// <summary>
///     Сервис управляющий вопросами
/// </summary>
public class QuestionsService
{
    /// <inheritdoc cref="CurrentUserService" />
    private readonly CurrentUserService _currentUser;

    /// <inheritdoc cref="DataContext" />
    private readonly DataContext _dataContext;

    /// <inheritdoc cref="IMapper" />
    private readonly IMapper _mapper;

    public QuestionsService(DataContext dataContext, IMapper mapper, CurrentUserService currentUser)
    {
        _dataContext = dataContext;
        _mapper = mapper;
        _currentUser = currentUser;
    }

    /// <summary>
    ///     Записать ответ игрока в базу данных
    /// </summary>
    public async Task WriteUserAnswer(UserAnswer answer)
    {
        var user = await _currentUser.GetCurrentUser();

        var userAnswer = _mapper.Map<UsersAnswer>(answer);
        userAnswer.UserId = user.Id;

        if ((await _dataContext.Set<Answer>().FindAsync(answer.AnswerId)).IsCorrect)
        {
            user.Points++;
            user.LastActiveTime = DateTime.UtcNow;
            userAnswer.IsCorrect = true;
            _dataContext.Update(user);
        }

        await _dataContext.Set<UsersAnswer>().AddAsync(userAnswer);
        await _dataContext.SaveChangesAsync();
    }

    /// <summary>
    ///     Добавить вопрос в базу данных
    /// </summary>
    public async Task AddQuestion(QuestionInputDTO question)
    {
        var questionId = Guid.NewGuid();
        var questionEntity = new Question
        {
            Id = questionId,
            Text = question.Text,
            ThemeId = question.ThemeId,
            Answers = question.Answers.Select(x => new Answer
            {
                Text = x.Text, IsCorrect = x.IsCorrect, QuestionId = questionId
            }).ToList()
        };
        _dataContext.Add(questionEntity);
        await _dataContext.SaveChangesAsync();
    }

    /// <summary>
    ///     Получить коллекцию вопросов по фильтру
    /// </summary>
    /// <param name="command">Фильтр</param>
    /// <param name="token">Токен отмены запроса</param>
    /// <returns>Коллекция вопросов с ответами</returns>
    public async Task<IReadOnlyCollection<QuestionWithAnswers>> GetQuestionsByFilter(GetQuestionCommand command,
        CancellationToken token)
    {
        var userId = _currentUser.GetUserId();

        var questionss = _dataContext.Set<Question>()
            .AsNoTracking()
            .Where(x => !x.UsersAnswers.Any(x => x.UserId == userId))
            .Include(x => x.Answers)
            .OrderBy(x => EF.Functions.Random())
            .Where(x => command.ThemeId == null || x.ThemeId == command.ThemeId)
            .Take(command.Count);


        var questions = await questionss.ToListAsync(token);

        var questionsWithAnswers = questions.Select(x => new QuestionWithAnswers
        {
            QuestionId = x.Id, Text = x.Text, Answers = x.Answers.Select(_mapper.Map<AnswerDTO>).ToList()
        }).ToArray();

        return questionsWithAnswers;
    }
}
