using EazyQuiz.Extensions;
using EazyQuiz.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace EazyQuiz.Web.Api;

/// <summary>
/// Контроллер Входа/Регистрации
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class AuthController : Controller
{
    /// <summary>
    /// <inheritdoc cref="ILogger{TCategoryName}"/>
    /// </summary>
    private readonly ILogger<AuthController> _log;

    /// <summary>
    /// <inheritdoc cref="UserService"/>
    /// </summary>
    private readonly UserService _userService;

    public AuthController(ILogger<AuthController> logger, UserService userService)
    {
        _log = logger;
        _userService = userService;
    }

    /// <summary>
    /// Запись в БД нового игрока/пользователя 
    /// </summary>
    /// <param name="user">Логин и Пароль в <see cref="UserRegister"/></param>
    [HttpPost]
    public async Task<IActionResult> RegisterNewPlayer([FromBody] UserRegister user)
    {
        await _userService.RegisterNewUser(user);
        _log.LogInformation("New User was created {@User}", user);
        return Ok();
    }

    /// <summary>
    /// Вход в систему возвращает <see cref="UserResponse"/> с токеном JWT
    /// </summary>
    /// <param name="auth"></param>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserResponse))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetUserByPassword([FromQuery] UserAuth auth)
    {
        _log.LogInformation("Login {@User}", auth);
        var userResponse = await _userService.Authenticate(auth);
        if (userResponse == null)
        {
            return NotFound();
        }
        return Ok(userResponse);
    }

    /// <summary>
    /// Получение соли по нику
    /// </summary>
    /// <param name="userName">Ник</param>
    [HttpGet("{userName}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetUserSalt([FromRoute] string userName)
    {
        string userSalt = await _userService.GetUserSalt(userName);
        if (userSalt.IsNullOrEmpty())
        {
            return NotFound();
        }
        return Ok(userSalt);
    }
}
