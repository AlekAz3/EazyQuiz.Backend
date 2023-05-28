using EazyQuiz.Data.Entities;
using EazyQuiz.Extensions;
using EazyQuiz.Models.DTO;
using Microsoft.EntityFrameworkCore;

namespace EazyQuiz.Web.Api;

/// <summary>
/// Сервис по работе с историей ответов пользователей 
/// </summary>
public class HistoryService
{
    /// <inheritdoc cref="DataContext"/>
    private readonly DataContext _context;

    /// <inheritdoc cref="CurrentUserService"/>
    private readonly CurrentUserService _currentUser;

    public HistoryService(DataContext context, CurrentUserService currentUser)
    {
        _context = context;
        _currentUser = currentUser;
    }

    /// <summary>
    /// Получить коллекцию истории ответов по пагинации
    /// </summary>
    /// <param name="command">Параметры пагинации</param>
    /// <param name="token">Токен отмены запроса</param>
    public async Task<InputCountDTO<UserAnswerHistory>> GetHistoryByFilter(GetHistoryCommand command, CancellationToken token)
    {
        var userId = _currentUser.GetUserId();

        int totalCount = await _context.Set<UsersAnswer>()
            .AsNoTracking()
            .Where(x => x.UserId == userId)
            .CountAsync(token);

        var userAnswers = await _context.Set<UsersAnswer>()
            .AsNoTracking()
            .OrderByDescending(x => x.AnswerTime)
            .Where(x => x.UserId == userId)
            .Include(x => x.Answer)
            .Include(x => x.Question)
            .AddPagination(command)
            .ToListAsync(token);

        var res = userAnswers.Select(x => new UserAnswerHistory()
        {
            QuestionText = x.Question.Text,
            AnswerText = x.Answer.Text,
            IsCorrect = x.IsCorrect,
            AnswerTime = x.AnswerTime,
        });

        return new InputCountDTO<UserAnswerHistory>(totalCount, res);
    }
}
