using AutoMapper;
using EazyQuiz.Data.Entities;
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

    /// <inheritdoc cref="CurrentUserService"/>
    private readonly CurrentUserService _currentUser;

    public LeaderboardService(DataContext context, IMapper mappper, CurrentUserService currentUser)
    {
        _context = context;
        _mappper = mappper;
        _currentUser = currentUser;
    }

    /// <summary>
    /// Получить список лидеров по фильтру 
    /// </summary>
    /// <param name="filter">Фильтр</param>
    /// <param name="token">Токен отмены запроса</param>
    /// <returns>Коллекция пользователей</returns>
    internal async Task<IReadOnlyCollection<PublicUserInfo>> GetByFilter(LeaderboardRequest filter, CancellationToken token)
    {
        var users = await _context.Set<User>()
            .AsNoTracking()
            .Where(x => x.Role == "Player")
            .Where(x => filter.Country == null || x.Country == filter.Country)
            .OrderByDescending(x => x.Points)
            .Take(filter.Count)
            .ToListAsync(token);

        return users.Select(_mappper.Map<PublicUserInfo>).ToList();
    }

    /// <summary>
    /// Получить место пользователя в таблицы лидеров
    /// </summary>
    /// <param name="country">Страна</param>
    /// <param name="token">Токен отмены запроса</param>
    /// <returns>Место в таблице лидеров</returns>
    internal async Task<int> GetCurrentUserScore(string country, CancellationToken token)
    {
        var userId = _currentUser.GetUserId();

        var users = await _context.Set<User>()
            .AsNoTracking()
            .Where(x => x.Role == "Player")
            .Where(x => country == null || x.Country == country)
            .OrderByDescending(x => x.Points)
            .ToListAsync(token);
        return users.FindIndex(x => x.Id == userId) + 1;
    }
}
