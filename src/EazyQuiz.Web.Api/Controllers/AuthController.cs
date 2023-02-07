using EazyQuiz.Models;
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
    private readonly IUserService _userService;

    public AuthController(ILogger<AuthController> logger, IUserService userService)
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
        _log.LogInformation("New User was created");
        return Ok();
    }

    /// <summary>
    /// Вход в систему возвращает <see cref="UserResponse"/> с токеном JWT
    /// </summary>
    /// <param name="auth"></param>
    [HttpGet]
    public async Task<IActionResult> GetUserByPassword([FromBody] UserAuth auth)
    {
        var userResponse = await _userService.Authenticate(auth);
        return new JsonResult(userResponse);
    }

    /// <summary>
    /// Получение соли по нику
    /// </summary>
    /// <param name="userName">Ник</param>
    [HttpGet]
    public async Task<string> GetUserSalt(string userName)
    {
        _log.LogInformation(" 1 GetSalt {Email}", userName);
        string userSalt = await _userService.GetUserSalt(userName);
        _log.LogInformation(" 2 GetSalt {UserSalt}", userSalt);

        return userSalt;
    }
}
