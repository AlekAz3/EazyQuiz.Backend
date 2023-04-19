using EazyQuiz.Extensions;
using EazyQuiz.Models.DTO;
using Microsoft.EntityFrameworkCore;

namespace EazyQuiz.Web.Api.Services;

public class HistoryService
{
    /// <inheritdoc cref="DataContext"/>
    private readonly DataContext _context;

    public HistoryService(DataContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Получить коллекцию истории ответов по пагинации
    /// </summary>
    /// <param name="userId">Ид игрока</param>
    /// <param name="command">Параметры пагинации</param>
    /// <param name="token">Токен отмены запроса</param>
    public async Task<InputCountDTO<UserAnswerHistory>> GetHistoryByFilter(Guid userId, GetHistoryCommand command, CancellationToken token)
    {
        int totalCount = await _context.UserAnswer
            .AsNoTracking()
            .Where(x => x.UserId == userId)
            .CountAsync(token);

        var userAnswers = await _context.UserAnswer
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
