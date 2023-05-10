using AutoMapper;
using EazyQuiz.Models.DTO;
using Microsoft.EntityFrameworkCore;

namespace EazyQuiz.Web.Api;

/// <summary>
/// Сервис лидерборда
/// </summary>
public class LeaderboardService
{
    /// <inheritdoc cref="DataContext"/>
    private readonly DataContext _context;

    /// <inheritdoc cref="IMapper"/>
    private readonly IMapper _mappper;

    public LeaderboardService(DataContext context, IMapper mappper)
    {
        _context = context;
        _mappper = mappper;
    }

    /// <summary>
    /// Получить список лидеров по фильтру 
    /// </summary>
    /// <param name="filter">Фильтр</param>
    /// <param name="token">Токен отмены запроса</param>
    /// <returns>Коллекция пользователей</returns>
    internal async Task<IReadOnlyCollection<PublicUserInfo>> GetByFilter(LeaderboardRequest filter, CancellationToken token)
    {
        var query = _context.User.AsQueryable();
        if (filter.Country is not null)
        {
            query = query.Where(x => x.Country == filter.Country);
        }
        query = query.OrderByDescending(x => x.Points).Take(filter.Count);
        var users = await query.ToListAsync(token);

        var result = users.Select(_mappper.Map<PublicUserInfo>).ToList();
        return result;
    }

    /// <summary>
    /// Получить место пользователя в таблицы лидеров
    /// </summary>
    /// <param name="userId">Ид пользователя</param>
    /// <param name="country">Страна</param>
    /// <param name="token">Токен отмены запроса</param>
    /// <returns>Место в таблице лидеров</returns>
    internal async Task<int> GetCurrentUserScore(Guid userId, string country, CancellationToken token)
    {
        var users = await _context.User
            .Where(x => country == null || x.Country == country)
            .OrderByDescending(x => x.Points)
            .ToListAsync(token);
        return users.FindIndex(x => x.Id == userId) + 1;
    }
}
