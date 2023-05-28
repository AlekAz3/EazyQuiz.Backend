using EazyQuiz.Models.DTO;
using Microsoft.AspNetCore.Mvc;

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

    /// <inheritdoc cref="CurrentUserService"/>
    private readonly CurrentUserService _currentUser;

    public ThemesController(ThemesService service, ILogger<ThemesController> logger, CurrentUserService currentUser)
    {
        _service = service;
        _logger = logger;
        _currentUser = currentUser;
    }

    /// <summary>
    /// Получить коллекцию всех активных тем тем 
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
    /// <remarks>Для администратора</remarks>
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

    /// <summary>
    /// Обновить колллекцию тем
    /// </summary>
    /// <param name="themes">Темы</param>
    /// <param name="token">Токен отмены запроса</param>
    /// <remarks>Для администратора</remarks>
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

    /// <summary>
    /// Получить все темы
    /// </summary>
    /// <param name="token">Токен отмены запроса</param>
    /// <returns>Коллекция тем вопросов</returns>
    /// <remarks>Для администратора</remarks>
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
