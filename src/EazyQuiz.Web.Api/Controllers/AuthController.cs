using EazyQuiz.Models.DTO;
using EazyQuiz.Models;
using EazyQuiz.Web.Api.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace EazyQuiz.Web.Api.Controllers;
[Route("api/[controller]/[action]")]
[ApiController]
public class AuthController : Controller
{
    private readonly DataContext _dataContext;
    private readonly ILogger<AuthController> _log;
    private readonly IConfiguration _config;

    public AuthController(DataContext dataContext, ILogger<AuthController> logger, IConfiguration config)
    {
        _dataContext = dataContext;
        _log = logger;
        _config = config;
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
        var user = _dataContext.User!.Where(x => x.Email == auth.Email && x.Password == x.Password).FirstOrDefault();
        if (user == null)
        {
            _log.LogInformation("User {@User} not found", auth);
            return BadRequest();
        }
        var userResponse = new UserResponse(user, "Token");
        _log.LogInformation("User {@User} was login", userResponse);
        return new JsonResult(Ok(userResponse));
    }

    private int GetLastId()
    {
        return _dataContext.User!.Select(x => x.Id).Count() + 1;
    }
}
