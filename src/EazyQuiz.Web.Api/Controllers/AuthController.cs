using EazyQuiz.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

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
    /// <returns></returns>
    [HttpPost]
    public IActionResult RegisterNewPlayer(UserRegister user)
    {
        _userService.RegisterNewUser(user);
        _log.LogInformation("New User was created");
        return new JsonResult(Ok());
    }

    /// <summary>
    /// Вход в систему возвращает <see cref="UserResponse"/> с токеном JWT
    /// </summary>
    /// <param name="auth"></param>
    /// <returns></returns>
    [HttpGet]
    public string GetUserByPassword([FromQuery] UserAuth auth)
    {
        var userResponse = _userService.Authenticate(auth);
        _log.LogInformation("User {@User} was login", userResponse);
        return JsonSerializer.Serialize(userResponse);
    }
}
