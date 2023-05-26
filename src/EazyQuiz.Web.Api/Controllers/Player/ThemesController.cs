using EazyQuiz.Models.DTO;
using Microsoft.AspNetCore.Authorization;
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
    private readonly CurrentUserService _currentUser;

    public ThemesController(ThemesService service, ILogger<ThemesController> logger, CurrentUserService currentUser)
    {
        _service = service;
        _logger = logger;
        _currentUser = currentUser;
    }

    /// <summary>
    /// Получить коллекцию всех тем 
    /// </summary>
    /// <param name="token">Токен отмены запроса</param>
    /// <returns>Коллекция тем </returns>
    [HttpGet]
    public async Task<IActionResult> GetAllThemes(CancellationToken token)
    {
        var themes = await _service.GetAllActive(token);
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
        if (_currentUser.GetUserRole() != "Admin")
        {
            return BadRequest();
        }
        await _service.AddTheme(themeName, token);
        _logger.LogInformation("Была добавлена новая тема: {ThemeName}", themeName);
        return Ok();
    }

    [HttpPut]
    public async Task<IActionResult> UpdateThemes([FromBody] IReadOnlyCollection<ThemeResponseWithFlag> themes, CancellationToken token)
    {
        if (_currentUser.GetUserRole() != "Admin")
        {
            return BadRequest();
        }
        await _service.UpdateThemes(themes, token);
        return Ok();
    }

    [HttpGet("all")]
    public async Task<IActionResult> GetAll(CancellationToken token)
    {
        if (_currentUser.GetUserRole() != "Admin")
        {
            return BadRequest();
        }
        var themes = await _service.GetAll(token);
        return Ok(themes);
    }
}
