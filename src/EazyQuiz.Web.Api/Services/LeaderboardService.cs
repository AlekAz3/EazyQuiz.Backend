using AutoMapper;
using EazyQuiz.Models.DTO;
using Microsoft.EntityFrameworkCore;

namespace EazyQuiz.Web.Api;

public class LeaderboardService
{
    private readonly DataContext _context;
    private readonly IMapper _mappper;

    public LeaderboardService(DataContext context, IMapper mappper)
    {
        _context = context;
        _mappper = mappper;
    }

    internal async Task<IReadOnlyCollection<PublicUserInfo>> GetByFilter(LeaderboardRequest filter, CancellationToken token)
    {
        var query = _context.User.AsQueryable();
        if (filter.Country is not null)
        {
            query = query.Where(x => x.Country == filter.Country);
        }
        query = query.OrderBy(x => x.Points).Take(filter.Count);
        var users = await query.ToListAsync(token);

        var result = users.Select(_mappper.Map<PublicUserInfo>).ToList();
        return result;
    }

    internal async Task<int> GetCurrentUserScore(Guid userId, CancellationToken token)
    {
        var users = await _context.User.OrderBy(x => x.Points).ToListAsync(token);
        return users.FindIndex(x => x.Id == userId) + 1;
    }
}
