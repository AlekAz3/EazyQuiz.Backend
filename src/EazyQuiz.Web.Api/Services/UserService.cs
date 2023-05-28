using AutoMapper;
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

    /// <inheritdoc cref="IMapper"/>
    private readonly IMapper _mapper;

    public UserService(DataContext dataContext, IConfiguration config, IMapper mapper)
    {
        _dataContext = dataContext;
        _config = config;
        _mapper = mapper;
    }

    /// <summary>
    /// Аутентифицировать пользователя
    /// </summary>
    /// <param name="auth">Логин и пароль в <see cref="UserAuth"/></param>
    public async Task<UserResponse> Authenticate(UserAuth auth)
    {
        var user = await _dataContext.Set<User>()
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Username == auth.Username);

        if (user == null)
        {
            return null;
        }

        if (auth.PasswordHash.Replace(' ', '+') == user.PasswordHash)
        {
            var userResponse = _mapper.Map<UserResponse>(user);
            userResponse.Token = GenerateJwtToken(user);

            return userResponse;
        }
        return null;
    }

    /// <summary>
    /// Записать в бд информацию о новом пользователе
    /// </summary>
    public async Task RegisterNewUser(UserRegister user)
    {
        var newUser = _mapper.Map<User>(user);

        await _dataContext.Set<User>().AddAsync(newUser);
        await _dataContext.SaveChangesAsync();
    }

    /// <summary>
    /// Сгенерировать JWT токен 
    /// </summary>
    private string GenerateJwtToken(User user)
    {
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512);
        var claims = new[]
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Role, user.Role)
        };
        var token = new JwtSecurityToken(_config["Jwt:Issuer"],
            _config["Jwt:Audience"],
            claims,
            expires: DateTime.Now.AddDays(1),
            signingCredentials: credentials);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    /// <summary>
    /// Получить "Соль" пользователя
    /// </summary>
    public async Task<string> GetUserSalt(string userName)
    {
        string userSalt = await _dataContext.Set<User>()
            .AsNoTracking()
            .Where(x => userName == x.Username)
            .Select(x => x.PasswordSalt)
            .FirstOrDefaultAsync();

        if (userSalt == null)
        {
            return "";
        }
        return userSalt;
    }
}
