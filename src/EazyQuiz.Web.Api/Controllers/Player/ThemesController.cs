using EazyQuiz.Models.DTO;
using EazyQuiz.Web.Api.Attributes;
using Microsoft.AspNetCore.Mvc;

namespace EazyQuiz.Web.Api;

/// <summary>
///     Контроллер управляющий темами вопросов
/// </summary>
public class ThemesController : BaseController
{
    /// <inheritdoc cref="ILogger{TCategoryName}" />
    private readonly ILogger<ThemesController> _logger;

    /// <inheritdoc cref="ThemesService" />
    private readonly ThemesService _service;

    public ThemesController(ThemesService service, ILogger<ThemesController> logger)
    {
        _service = service;
        _logger = logger;
    }

    /// <summary>
    ///     Получить коллекцию всех активных тем тем
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
    ///     Добавить новую тему
    /// </summary>
    /// <param name="themeName">Название темы </param>
    /// <param name="token">Токен отмены запроса</param>
    /// <remarks>Для администратора</remarks>
    [HttpPost]
    [AdminOnly]
    public async Task<IActionResult> AddTheme([FromBody] string themeName, CancellationToken token)
    {
        await _service.AddTheme(themeName, token);
        _logger.LogInformation("Была добавлена новая тема: {ThemeName}", themeName);
        return Ok();
    }

    /// <summary>
    ///     Обновить колллекцию тем
    /// </summary>
    /// <param name="themes">Темы</param>
    /// <param name="token">Токен отмены запроса</param>
    [HttpPut]
    [AdminOnly]
    public async Task<IActionResult> UpdateThemes([FromBody] IReadOnlyCollection<ThemeResponseWithFlag> themes,
        CancellationToken token)
    {
        await _service.UpdateThemes(themes, token);
        return Ok();
    }

    /// <summary>
    ///     Получить все темы
    /// </summary>
    /// <param name="token">Токен отмены запроса</param>
    /// <returns>Коллекция тем вопросов</returns>
    [HttpGet("all")]
    [AdminOnly]
    public async Task<IActionResult> GetAll(CancellationToken token)
    {
        var themes = await _service.GetAll(token);
        return Ok(themes);
    }
}
