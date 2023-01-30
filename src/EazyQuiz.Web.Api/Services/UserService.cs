using EazyQuiz.Models;
using EazyQuiz.Web.Api.Abstractions;
using EazyQuiz.Web.Api.Infrastructure;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace EazyQuiz.Web.Api.Services;

public class UserService : IUserService
{
    private readonly DataContext _dataContext;
    private readonly ILogger<UserService> _log;
    private readonly IConfiguration _config;

    public UserService(DataContext dataContext, ILogger<UserService> logger, IConfiguration config)
    {
        _dataContext = dataContext;
        _log = logger;
        _config = config;
    }

    public UserResponse Authenticate(UserAuth auth)
    {
        var user = _dataContext.User.SingleOrDefault(x => x.Email == auth.Email && x.Password == auth.Password);

        // return null if user not found
        if (user == null)
        {
            throw new ArgumentException("User does not exist");
        }

        // authentication successful so generate jwt token
        var token = GenerateJwtToken(user);

        return new UserResponse(user, token);

    }

    public IEnumerable<User> GetAll()
    {
        var user = _dataContext.User.ToList();

        return user;

    }

    public User GetById(int id)
    {
        var user = _dataContext.User.FirstOrDefault(x => x.Id == id);
        if (user == null)
        {
            throw new ArgumentException("User does not exist");
        }
        return user;
    }

    private string GenerateJwtToken(User user)
    {
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
        var claims = new[]
        {
            new Claim(ClaimTypes.NameIdentifier,user.UserName),
            new Claim(ClaimTypes.Email ,user.Email),
            new Claim(ClaimTypes.Country ,user.Country)
        };
        var token = new JwtSecurityToken(_config["Jwt:Issuer"],
            _config["Jwt:Audience"],
            claims,
            expires: DateTime.Now.AddMinutes(15),
            signingCredentials: credentials);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
