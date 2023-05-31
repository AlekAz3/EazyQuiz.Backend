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
    /// <inheritdoc cref="ILogger{TCategoryName}"/>
    private readonly ILogger<AuthController> _log;

    /// <inheritdoc cref="UserService"/>
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
        _log.LogInformation("Был зарегистрирован новый игрок с ником: {Username}", user.Username);
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
        var userResponse = await _userService.Authenticate(auth);
        if (userResponse == null)
        {
            return NotFound();
        }
        _log.LogInformation("Игрок {Username} зашел в игру", auth.Username);
        return Ok(userResponse);
    }

    /// <summary>
    /// Получение соли по нику
    /// </summary>
    /// <param name="username">Ник</param>
    [HttpGet("{username}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetUserSalt([FromRoute] string username)
    {
        string userSalt = await _userService.GetUserSalt(username);
        if (userSalt.IsNullOrEmpty())
        {
            _log.LogInformation("Игрок с ником {Username} не был найден", username);
            return NotFound();
        }
        return Ok(userSalt);
    }

    
}
