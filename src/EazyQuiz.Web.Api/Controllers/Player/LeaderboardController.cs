using EazyQuiz.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace EazyQuiz.Web.Api;

/// <summary>
/// Контроллер управляющий таблицей лидеров
/// </summary>
public class LeaderboardController : BaseController
{
    /// <inheritdoc cref="LeaderboardService"/>
    private readonly LeaderboardService _service;

    public LeaderboardController(LeaderboardService service)
    {
        _service = service;
    }

    /// <summary>
    /// Получить таблицу лидеров по фильтру
    /// </summary>
    /// <param name="filter">Фильтр</param>
    /// <param name="token">Токен отмены запроса</param>
    /// <returns>Коллекция пользователей</returns>
    [HttpGet]
    public async Task<IActionResult> GetByFilter([FromQuery] LeaderboardRequest filter, CancellationToken token)
    {
        var users = await _service.GetByFilter(filter, token);
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
        var score = await _service.GetCurrentUserScore(country, token);
        return Ok(score);
    }
}
