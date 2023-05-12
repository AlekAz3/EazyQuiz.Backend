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

    /// <inheritdoc cref="ILogger{TCategoryName}"/>
    private readonly ILogger<ThemesController> _logger;

    public ThemesController(ThemesService service, ILogger<ThemesController> logger)
    {
        _service = service;
        _logger = logger;
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
    /// <param name="themeName">Название темы </param>
    /// <param name="token">Токен отмены запроса</param>
    /// <remarks>Только для администратора</remarks>
    [HttpPost]
    public async Task<IActionResult> AddTheme([FromBody] string themeName, CancellationToken token)
    {
        var role = User.Claims.First(x => x.Type == ClaimTypes.Role).Value;
        if (role != "Admin")
        {
            return BadRequest();
        }
        await _service.AddTheme(themeName, token);
        _logger.LogInformation("Была добавлена новая тема: {ThemeName}", themeName);
        return Ok();
    }
}
