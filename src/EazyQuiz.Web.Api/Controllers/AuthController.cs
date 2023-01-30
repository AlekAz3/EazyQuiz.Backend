using EazyQuiz.Models;
using EazyQuiz.Web.Api.Abstractions;
using EazyQuiz.Web.Api.Infrastructure;
using EazyQuiz.Web.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace EazyQuiz.Web.Api.Controllers;
[Route("api/[controller]/[action]")]
[ApiController]
public class AuthController : Controller
{
    private readonly DataContext _dataContext;
    private readonly ILogger<AuthController> _log;
    private readonly IConfiguration _config;
    private readonly IUserService _userService;

    public AuthController(DataContext dataContext, ILogger<AuthController> logger, IConfiguration config, IUserService userService)
    {
        _dataContext = dataContext;
        _log = logger;
        _config = config;
        _userService = userService;
    }

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

    [HttpGet]
    public IActionResult GetUserByPassword([FromQuery] UserAuth auth)
    {
        var userResponse = _userService.Authenticate(auth);
        _log.LogInformation("User {@User} was login", userResponse);
        return new JsonResult(Ok(userResponse));
    }

    private int GetLastId()
    {
        return _dataContext.User!.Select(x => x.Id).Count() + 1;
    }
}
