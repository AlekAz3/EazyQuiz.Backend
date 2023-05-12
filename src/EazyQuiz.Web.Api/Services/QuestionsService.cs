using AutoMapper;
using EazyQuiz.Data.Entities;
using EazyQuiz.Models.DTO;
using Microsoft.EntityFrameworkCore;

namespace EazyQuiz.Web.Api;

/// <summary>
/// Сервис управляющий вопросами
/// </summary>
public class QuestionsService
{
    /// <inheritdoc cref="DataContext"/>
    private readonly DataContext _dataContext;

    /// <inheritdoc cref="IMapper"/>
    private readonly IMapper _mapper;

    public QuestionsService(DataContext dataContext, IMapper mapper)
    {
        _dataContext = dataContext;
        _mapper = mapper;
    }

    /// <summary>
    /// Записать ответ игрока в базу данных
    /// </summary>
    public async Task WriteUserAnswer(Guid userId, UserAnswer answer)
    {
        var userAnswer = _mapper.Map<UsersAnswer>(answer);
        userAnswer.UserId = userId;
        if ((await _dataContext.Answer.FindAsync(answer.AnswerId)).IsCorrect)
        {
            var player = await _dataContext.User.FindAsync(userId);
            player.Points++;
            player.LastActiveTime = DateTime.UtcNow;
            userAnswer.IsCorrect = true;
            _dataContext.Update(player);
        }

        await _dataContext.UserAnswer.AddAsync(userAnswer);
        await _dataContext.SaveChangesAsync();
    }

    /// <summary>
    /// Добавить вопрос в базу данных
    /// </summary>
    public async Task AddQuestion(QuestionWithoutId question)
    {
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

    /// <summary>
    /// Получить коллекцию вопросов по фильтру
    /// </summary>
    /// <param name="command">Фильтр</param>
    /// <param name="token">Токен отмены запроса</param>
    /// <returns>Коллекция вопросов с ответами</returns>
    public async Task<IReadOnlyCollection<QuestionWithAnswers>> GetQuestionsByFilter(GetQuestionCommand command, CancellationToken token)
    {
        var questionss = _dataContext.Question
            .AsNoTracking()
            .Where(x => command.ThemeId == null || x.ThemeId == command.ThemeId)
            .OrderBy(x => EF.Functions.Random())
            .Take(command.Count)
            .Include(x => x.Answers);

        var questions = await questionss.ToListAsync(token);

        var questionsWithAnswers = questions.Select(x => new QuestionWithAnswers()
        {
            QuestionId = x.Id,
            Text = x.Text,
            Answers = x.Answers.Select(_mapper.Map<AnswerDTO>).ToList(),
        }).ToArray();

        return questionsWithAnswers;
    }
}
