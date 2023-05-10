using EazyQuiz.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace EazyQuiz.Web.Api;

/// <summary>
/// Контроллер управляющий таблицей лидеров
/// </summary>
public class LeaderboardController : BaseController
{
    /// <inheritdoc cref="LeaderboardService"/>
    private readonly LeaderboardService _service;

    /// <inheritdoc cref="ILogger{TCategoryName}"/>
    private readonly ILogger<LeaderboardController> _log;

    public LeaderboardController(LeaderboardService service, ILogger<LeaderboardController> log)
    {
        _service = service;
        _log = log;
    }

    /// <summary>
    /// Получить таблицу лидеров по фильтру
    /// </summary>
    /// <param name="filter">Фильтр</param>
    /// <param name="token">Токен отмены запрса</param>
    /// <returns>Коллекция пользователей</returns>
    [HttpGet]
    public async Task<IActionResult> GetByFilter([FromQuery] LeaderboardRequest filter, CancellationToken token)
    {
        var users = await _service.GetByFilter(filter, token);
        _log.LogInformation("Get Leaderboard");
        return Ok(users);
    }

    /// <summary>
    /// Получить место конкретного игрока
    /// </summary>
    /// <param name="country">Страна</param>
    /// <param name="token">Токен отмены запроса</param>
    /// <returns>Место игрока в таблице лидеров</returns>
    [HttpGet("user")]
    public async Task<IActionResult> GetUser([FromQuery] string country, CancellationToken token)
    {
        var userId = Guid.Parse(User.Claims.First(x => x.Type == ClaimTypes.NameIdentifier).Value);
        var score = await _service.GetCurrentUserScore(userId, country, token);
        _log.LogInformation("GetCurrentUserScore {UserId}, {Score}", userId, score);
        return Ok(score);
    }
}
