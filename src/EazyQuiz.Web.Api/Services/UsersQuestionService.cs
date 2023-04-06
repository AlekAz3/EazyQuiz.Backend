using AutoMapper;
using EazyQuiz.Extensions;
using EazyQuiz.Models.Database;
using EazyQuiz.Models.DTO;
using Microsoft.EntityFrameworkCore;

namespace EazyQuiz.Web.Api.Services;

/// <summary>
/// Сервис по работе с предложенными вопросами от пользователей 
/// </summary>
public class UsersQuestionService
{
    /// <inheritdoc cref="DataContext"/>
    private readonly DataContext _context;

    /// <inheritdoc cref="IMapper"/>
    private readonly IMapper _mapper;

    public UsersQuestionService(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    /// <summary>
    /// Добавить предложенный вопрос от пользователя
    /// </summary>
    /// <param name="questionByUser">Вопрос с ответом от пользователя</param>
    /// <param name="token">Токен отмены</param>
    public async Task AddNewUserQuestionToQueue(AddQuestionByUser questionByUser, CancellationToken token)
    {
        var question = _mapper.Map<UsersQuesions>(questionByUser);
        await _context.UsersQuestions.AddAsync(question, token);
        await _context.SaveChangesAsync(token);
    }

    /// <summary>
    /// Получить коллекцию предложенных пользователем вопросов
    /// </summary>
    /// <param name="userId">Ид пользователя</param>
    /// <param name="command">Параметры фильтрации</param>
    /// <param name="token">Токен отмены запроса</param>
    /// <returns>Коллекция вопросов</returns>
    public async Task<InputCountDTO<QuestionByUserResponse>> GetUsersQuestions(Guid userId, GetHistoryCommand command, CancellationToken token)
    {
        int totalCount = await _context.UsersQuestions
            .AsNoTracking()
            .Where(x => x.UserId == userId)
            .CountAsync(token);

        var usersQuestions = await _context.UsersQuestions
            .AsNoTracking()
            .OrderByDescending(x => x.LastUpdate)
            .Where(x => x.UserId == userId)
            .AddPagination(command)
            .ToListAsync(token);

        var result = usersQuestions.Select(x => _mapper.Map<QuestionByUserResponse>(x));

        return new InputCountDTO<QuestionByUserResponse>(totalCount, result);
    }

    /// <summary>
    /// Получить коллекцию предложенных вопросов от пользователей 
    /// </summary>
    /// <param name="filter">Фильтр</param>
    /// <param name="token">Токен отмены запросы</param>
    /// <returns>Коллекция вопросов</returns>
    /// <remarks>Используется для админки</remarks>
    public async Task<IReadOnlyCollection<UserQuestionResponse>> GetByFilter(UserQuestionFilter filter, CancellationToken token)
    {
        var data = await _context.UsersQuestions
            .AsNoTracking()
            .Where(x => filter.Status.IsNullOrEmpty() || x.Status == filter.Status)
            .AddPagination(filter)
            .ToListAsync(token);

        var kek = data.Select(x => _mapper.Map<UserQuestionResponse>(x)).ToList();
        return kek;
    }

    /// <summary>
    /// Обновить статус предложенного вопроса от пользователя
    /// </summary>
    /// <param name="question">Вопрос</param>
    /// <param name="token">Токен отмены запроса</param>
    public async Task UpdateUserQuestion(UpdateUserQuestion question, CancellationToken token)
    {
        var data = await _context.UsersQuestions
            .Where(x => x.Id == question.Id).SingleOrDefaultAsync(token);

        if (!question.Status.IsNullOrEmpty())
        {
            data.Status = question.Status;
        }

        data.LastUpdate = DateTimeOffset.Now;

        _context.Update(data);

        await _context.SaveChangesAsync(token);
    }
}
