using AutoMapper;
using EazyQuiz.Cryptography;
using EazyQuiz.Data.Entities;
using EazyQuiz.Models.DTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace EazyQuiz.Web.Api;

/// <summary>
/// Класс реальзующий <inheritdoc cref="UserService"/>
/// </summary>
public class UserService
{
    /// <inheritdoc cref="DataContext"/>
    private readonly DataContext _dataContext;

    /// <inheritdoc cref="IConfiguration"/>
    private readonly IConfiguration _config;

    /// <inheritdoc cref="ILogger{TCategoryName}"/>
    private readonly ILogger<UserService> _log;

    /// <inheritdoc cref="IMapper"/>
    private readonly IMapper _mapper;

    public UserService(DataContext dataContext, IConfiguration config, ILogger<UserService> logger, IMapper mapper)
    {
        _dataContext = dataContext;
        _config = config;
        _log = logger;
        _mapper = mapper;
    }

    public async Task<UserResponse> Authenticate(UserAuth auth)
    {
        var user = await _dataContext.User
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Username == auth.Username);

        if (user == null)
        {
            _log.LogInformation("{@User} not found", auth);
            return null;
        }

        if (auth.PasswordHash.Replace(' ', '+') == user.PasswordHash)
        {
            var userResponse = _mapper.Map<UserResponse>(user);
            userResponse.Token = GenerateJwtToken(user);

            _log.LogInformation("{@User} auth", userResponse);
            return userResponse;
        }
        _log.LogInformation("Wrong password", auth);
        return null;
    }

    public async Task RegisterNewUser(UserRegister user)
    {
        _log.LogInformation("Register {@User}", user);
        var newUser = _mapper.Map<User>(user);

        await _dataContext.User.AddAsync(newUser);
        await _dataContext.SaveChangesAsync();
    }

    private string GenerateJwtToken(User user)
    {
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512);
        var claims = new[]
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
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
        string userSalt = await _dataContext.User
            .AsNoTracking()
            .Where(x => userName == x.Username)
            .Select(x => x.PasswordSalt)
            .FirstOrDefaultAsync();

        if (userSalt == null)
        {
            return "";
        }
        _log.LogInformation("user salt {@User}", userSalt);
        return userSalt;
    }
}
