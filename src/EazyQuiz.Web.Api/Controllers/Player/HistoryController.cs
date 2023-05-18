using EazyQuiz.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace EazyQuiz.Web.Api;

/// <summary>
/// Контроллер управления истории 
/// </summary>
public class HistoryController : BaseController
{
    /// <inheritdoc cref="HistoryService"/>
    private readonly HistoryService _service;

    public HistoryController(HistoryService service)
    {
        _service = service;
    }

    /// <summary>
    /// Получить историю ответов по пагинации
    /// </summary>
    /// <param name="command">Параметры пагинации</param>
    /// <param name="token">Токен отмены запроса</param>
    /// <returns>Коллекцию ответов пользователя <see cref="UserAnswerHistory"/></returns>
    [HttpGet]
    public async Task<IActionResult> GetHistoryByFilter([FromQuery] GetHistoryCommand command, CancellationToken token)
    {
        var userId = Guid.Parse(User.Claims.First(x => x.Type == ClaimTypes.NameIdentifier).Value);

        var list = await _service.GetHistoryByFilter(userId, command, token);
        return Ok(list);
    }
}
