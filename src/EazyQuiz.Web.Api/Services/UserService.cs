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
        // generate token that is valid for 7 days
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_config["Jwt:Key"]);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[] { new Claim("id", user.Id.ToString()) }),
            Expires = DateTime.UtcNow.AddDays(7),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}
