using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace EazyQuiz.Web.Api;

/// <summary>
/// Контроллер управляющий темами вопросов
/// </summary>
public class ThemesController : BaseController
{
    /// <inheritdoc cref="ThemesService"/>
    private readonly ThemesService _service;

    public ThemesController(ThemesService service)
    {
        _service = service;
    }

    /// <summary>
    /// Получить коллекцию всех тем 
    /// </summary>
    /// <param name="token">Токен отмены запроса</param>
    /// <returns>Коллекция тем </returns>
    [HttpGet]
    public async Task<IActionResult> GetThemes(CancellationToken token)
    {
        var themes = await _service.GetAll(token);
        return Ok(themes);
    }

    /// <summary>
    /// Добавить новую тему 
    /// </summary>
    /// <param name="name">Название темы </param>
    /// <param name="token">Токен отмены запроса</param>
    /// <remarks>Только для администратора</remarks>
    [HttpPost]
    public async Task<IActionResult> AddTheme([FromBody] string name, CancellationToken token)
    {
        var role = User.Claims.First(x => x.Type == ClaimTypes.Role).Value;
        if (role != "Admin")
        {
            return BadRequest();
        }
        await _service.AddTheme(name, token);
        return Ok();
    }
}
