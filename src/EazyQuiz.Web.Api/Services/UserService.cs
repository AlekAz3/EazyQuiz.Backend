using EazyQuiz.Models;
using EazyQuiz.Web.Api.Abstractions;
using EazyQuiz.Web.Api.Infrastructure;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace EazyQuiz.Web.Api.Services;

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
    /// <inheritdoc cref="ILogger{TCategoryName}"/>
    /// </summary>
    private readonly ILogger<UserService> _log;

    /// <summary>
    /// <inheritdoc cref="IConfiguration"/>
    /// </summary>
    private readonly IConfiguration _config;

    public UserService(DataContext dataContext, ILogger<UserService> logger, IConfiguration config)
    {
        _dataContext = dataContext;
        _log = logger;
        _config = config;
    }

    /// <summary>
    /// Проверка на наличие игрока в базе 
    /// </summary>
    /// <param name="auth"><inheritdoc cref="UserAuth"/></param>
    /// <returns>Объект<see cref="UserResponse"/></returns>
    /// <exception cref="ArgumentException">Игрок не найден</exception>
    public UserResponse Authenticate(UserAuth auth)
    {
        var user = _dataContext.User.SingleOrDefault(x => x.Email == auth.Email && x.Password == auth.Password);

        if (user == null)
        {
            throw new ArgumentException("User does not exist");
        }

        string token = GenerateJwtToken(user);

        return new UserResponse(user, token);

    }

    /// <summary>
    /// Возвращает список всех игроков
    /// </summary>
    /// <returns>Список пользователей</returns>
    public IEnumerable<User> GetAll()
    {
        var user = _dataContext.User.ToList();

        return user;

    }

    /// <summary>
    /// Получение игрока по Ид
    /// </summary>
    /// <param name="id">Ид</param>
    /// <returns><see cref="User"/></returns>
    /// <exception cref="ArgumentException">Игрок не найден</exception>
    public User GetById(int id)
    {
        var user = _dataContext.User.FirstOrDefault(x => x.Id == id);
        if (user == null)
        {
            throw new ArgumentException("User does not exist");
        }
        return user;
    }

    /// <summary>
    /// Генерация JWT токена
    /// </summary>
    /// <param name="user">Объект игрока</param>
    /// <returns>Строка JWT токена</returns>
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
