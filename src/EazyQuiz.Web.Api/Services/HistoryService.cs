using EazyQuiz.Extensions;
using EazyQuiz.Models.Database;
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

    public async Task<InputCountDTO<UserAnswerHistory>> GetHistoryByFilter(AnswersGetHistoryCommand command, CancellationToken token)
    {
        int totalCount = await _context.UserAnswer
            .AsNoTracking()
            .Where(x => x.UserId == command.UserId)
            .CountAsync(token);

        var a = await _context.UserAnswer
            .AsNoTracking()
            .Where(x => x.UserId == command.UserId)
            .AddPagination(command)
            .ToListAsync(token);

        var res = a.Select(x => new UserAnswerHistory()
        {
            QuestionText = _context.Question.AsNoTracking().Where(q => q.Id == x.QuestionId).SingleOrDefault().Text,
            AnswerText = _context.Answer.AsNoTracking().Where(a => a.Id == x.AnswerId).SingleOrDefault().Text,
            IsCorrect = x.IsCorrect
        });

        return new InputCountDTO<UserAnswerHistory>(totalCount, res);
    }
}
