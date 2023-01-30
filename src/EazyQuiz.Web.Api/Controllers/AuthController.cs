using EazyQuiz.Models;
using EazyQuiz.Web.Api.Abstractions;
using EazyQuiz.Web.Api.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace EazyQuiz.Web.Api.Controllers;
/// <summary>
/// Контроллер Входа/Регистрации
/// </summary>
[Route("api/[controller]/[action]")]
[ApiController]
public class AuthController : Controller
{
    /// <summary>
    /// <inheritdoc cref="DataContext"/>
    /// </summary>
    private readonly DataContext _dataContext;

    /// <summary>
    /// <inheritdoc cref="ILogger{TCategoryName}"/>
    /// </summary>
    private readonly ILogger<AuthController> _log;

    /// <summary>
    /// <inheritdoc cref="IUserService"/>
    /// </summary>
    private readonly IUserService _userService;

    public AuthController(DataContext dataContext, ILogger<AuthController> logger, IUserService userService)
    {
        _dataContext = dataContext;
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
        var newUser = new User()
        {
            Id = GetLastId(),
            Age = user.Age,
            Country = user.Country,
            Email = user.Email,
            Gender = user.Gender,
            Password = user.Password,
            Points = 0,
            UserName = user.UserName
        };
        _dataContext.User!.Add(newUser);
        _dataContext.SaveChanges();
        _log.LogInformation("New User was created");
        return new JsonResult(Ok());
    }

    /// <summary>
    /// Вход в систему возвращает <see cref="UserResponse"/> с токеном JWT
    /// </summary>
    /// <param name="auth"></param>
    /// <returns></returns>
    [HttpGet]
    public IActionResult GetUserByPassword([FromQuery] UserAuth auth)
    {
        var userResponse = _userService.Authenticate(auth);
        _log.LogInformation("User {@User} was login", userResponse);
        return new JsonResult(Ok(userResponse));
    }

    /// <summary>
    /// Получение последнего Ид для добавления нового игрока/пользователя
    /// </summary>
    /// <returns>Ид нового игрока</returns>
    private int GetLastId()
    {
        return _dataContext.User!.Select(x => x.Id).Count() + 1;
    }
}