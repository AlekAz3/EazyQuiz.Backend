using EazyQuiz.Cryptography;
using EazyQuiz.Models.Database;
using EazyQuiz.Models.DTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace EazyQuiz.Web.Api;

/// <summary>
/// Класс реальзующий <inheritdoc cref="IUserService"/>
/// </summary>
public class UserService : IUserService
{
    /// <summary>
    /// <inheritdoc cref="DataContext"/>
    /// </summary>
    private readonly DataContext _dataContext;

    /// <summary>
    /// <inheritdoc cref="IConfiguration"/>
    /// </summary>
    private readonly IConfiguration _config;

    private readonly ILogger<UserService> _log;

    public UserService(DataContext dataContext, IConfiguration config, ILogger<UserService> logger)
    {
        _dataContext = dataContext;
        _config = config;
        _log = logger;
    }

    public async Task<UserResponse> Authenticate(UserAuth auth)
    {
        var user = await _dataContext.User.FirstOrDefaultAsync(x => x.Username == auth.Username);
        if (user == null)
        {
            var userResponse = new UserResponse(0, "", 0, "", 0, "", "");
            _log.LogInformation("{@User} not found", auth);
            return userResponse;
        }

        if (PasswordHash.Verify(Encoding.UTF8.GetBytes(auth.Password!.PasswordHash), user.PasswordHash))
        {
            string token = GenerateJwtToken(user);
            var userResponse = new UserResponse(user.Id, user.Username, user.Age, user.Gender, user.Points, user.Country, token);
            _log.LogInformation("{@User}", userResponse);
            return userResponse;
        }
        var response = new UserResponse(0, "", 0, "", 0, "", "");
        _log.LogInformation("Wrong password", auth);
        return response;

    }

    public async Task<IEnumerable<User>> GetAll()
    {
        var user = await _dataContext.User.ToListAsync();

        return user;

    }

    public async Task<User> GetById(int id)
    {
        var user = await _dataContext.User.FirstOrDefaultAsync(x => x.Id == id);
        if (user == null)
        {
            throw new ArgumentException("User does not exist");
        }
        return user;
    }

    public async Task RegisterNewUser(UserRegister user)
    {
        _log.LogInformation("Register {@User}", user);

        var newUser = new User()
        {
            Id = GetLastId(),
            Age = user.Age,
            Country = user.Country,
            Gender = user.Gender,
            PasswordHash = Encoding.UTF8.GetBytes(user.Password!.PasswordHash),
            PasswordSalt = Encoding.UTF8.GetBytes(user.Password!.PasswordSalt),
            Points = 0,
            Username = user.Username,
            RegistrationTime = DateTime.Now
        };
        await _dataContext.User.AddAsync(newUser);
        await _dataContext.SaveChangesAsync();
    }

    private int GetLastId()
    {
        return _dataContext.User.Select(x => x.Id).Count() + 1;
    }

    private string GenerateJwtToken(User user)
    {
        if (user == null)
        {
            throw new ArgumentNullException(nameof(user));
        }

        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512);
        var claims = new[]
        {
            new Claim(ClaimTypes.NameIdentifier,user.Username),
            new Claim(ClaimTypes.Country ,user.Country)
        };
        var token = new JwtSecurityToken(_config["Jwt:Issuer"],
            _config["Jwt:Audience"],
            claims,
            expires: DateTime.Now.AddDays(1),
            signingCredentials: credentials);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    public async Task<string> GetUserSalt(string userName)
    {
        byte[] user = await _dataContext.User.Where(x => userName == x.Username).Select(x => x.PasswordSalt).FirstOrDefaultAsync();
        if (user == null)
        {
            _log.LogInformation("User does not exist");
            return "";
        }
        _log.LogInformation("user {@User}", user);
        return Encoding.UTF8.GetString(user);
    }


    public async Task<bool> CheckUniqueUsername(string userName)
    {
        var checkUser = await _dataContext.User.FirstOrDefaultAsync(x => x.Username == userName);
        if (checkUser == null)
        {
            return false;
        }
        return true;
    }
}
