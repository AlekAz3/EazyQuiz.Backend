using EazyQuiz.Models.Database;
using EazyQuiz.Models.DTO;
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
    public async Task<string> GetUserByPassword([FromBody] UserAuth auth)
    {
        _log.LogInformation("Login {@User}", auth);
        var userResponse = await _userService.Authenticate(auth);
        return JsonSerializer.Serialize(userResponse);
    }

    /// <summary>
    /// Получение соли по нику
    /// </summary>
    /// <param name="userName">Ник</param>
    [HttpGet]
    public async Task<string> GetUserSalt(string userName)
    {
        string userSalt = await _userService.GetUserSalt(userName);

        return userSalt;
    }


    /// <summary>
    /// Проверка уникальности ника
    /// </summary>
    /// <param name="userName">Ник</param>
    /// <returns>true - если ник НЕ уникален</returns>
    [HttpGet]
    public async Task<bool> CheckUniqueUsername(string userName)
    {
        return await _userService.CheckUniqueUsername(userName);
    }
}
