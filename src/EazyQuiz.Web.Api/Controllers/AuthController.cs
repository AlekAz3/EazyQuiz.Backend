using EazyQuiz.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace EazyQuiz.Web.Api;
/// <summary>
/// Контроллер Входа/Регистрации
/// </summary>
[Route("api/[controller]/[action]")]
[ApiController]
public class AuthController : Controller
{
    /// <summary>
    /// <inheritdoc cref="ILogger{TCategoryName}"/>
    /// </summary>
    private readonly ILogger<AuthController> _log;

    /// <summary>
    /// <inheritdoc cref="IUserService"/>
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
    public async Task<IActionResult> RegisterNewPlayer(UserRegister user)
    {
        await _userService.RegisterNewUser(user);
        _log.LogInformation("New User was created {@User}", user);
        return Ok();
    }

    /// <summary>
    /// Вход в систему возвращает <see cref="UserResponse"/> с токеном JWT
    /// </summary>
    /// <param name="auth"></param>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserResponse))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetUserByPassword([FromBody] UserAuth auth)
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
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetUserSalt(string userName)
    {
        string userSalt = await _userService.GetUserSalt(userName);
        if (userSalt == "")
        {
            return NotFound();
        }
        return new OkObjectResult(userSalt);
    }

    /// <summary>
    /// Проверка уникальности ника
    /// </summary>
    /// <param name="userName">Ник</param>
    /// <returns>true - если ник НЕ уникален</returns>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
    public async Task<IActionResult> CheckUniqueUsername(string userName)
    {
        return Ok(await _userService.CheckUniqueUsername(userName));
    }
}
