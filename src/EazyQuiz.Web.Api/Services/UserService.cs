using AutoMapper;
using EazyQuiz.Data.Entities;
using EazyQuiz.Models.DTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace EazyQuiz.Web.Api;

/// <summary>
///     Класс реальзующий <inheritdoc cref="UserService" />
/// </summary>
public class UserService
{
    /// <inheritdoc cref="IConfiguration" />
    private readonly IConfiguration _config;

    /// <inheritdoc cref="DataContext" />
    private readonly DataContext _context;

    /// <inheritdoc cref="CurrentUserService" />
    private readonly CurrentUserService _currentUser;

    /// <inheritdoc cref="IMapper" />
    private readonly IMapper _mapper;

    public UserService(DataContext context, CurrentUserService currentUser, IConfiguration config, IMapper mapper)
    {
        _context = context;
        _currentUser = currentUser;
        _config = config;
        _mapper = mapper;
    }

    /// <summary>
    ///     Аутентифицировать пользователя
    /// </summary>
    /// <param name="auth">Логин и пароль в <see cref="UserAuth" /></param>
    public async Task<UserResponse> Authenticate(UserAuth auth)
    {
        var user = await _context.Set<User>()
            .FirstOrDefaultAsync(x => x.Username == auth.Username);

        if (user == null)
        {
            return null;
        }

        if (auth.PasswordHash.Replace(' ', '+') == user.PasswordHash)
        {
            var userResponse = _mapper.Map<UserResponse>(user);

            string newRefreshToken = GenerateRefreshToken();
            user.RefreshToken = newRefreshToken;

            var token = new Token { Jwt = GenerateJwtToken(user), RefrashToken = newRefreshToken };

            userResponse.Token = token;

            await _context.SaveChangesAsync();

            return userResponse;
        }

        return null;
    }

    /// <summary>
    ///     Записать в бд информацию о новом пользователе
    /// </summary>
    public async Task RegisterNewUser(UserRegister user)
    {
        var newUser = _mapper.Map<User>(user);

        await _context.Set<User>().AddAsync(newUser);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    ///     Сгенерировать JWT токен
    /// </summary>
    private string GenerateJwtToken(User user)
    {
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512);
        var claims = new[]
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()), new Claim(ClaimTypes.Role, user.Role)
        };
        var token = new JwtSecurityToken(_config["Jwt:Issuer"],
            _config["Jwt:Audience"],
            claims,
            expires: DateTime.Now.AddHours(3),
            signingCredentials: credentials);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    public async Task<Token> RefreshJwtToken(string refreshToken, CancellationToken cancellationToken)
    {
        var user = await _context.Set<User>()
            .SingleOrDefaultAsync(x => x.RefreshToken == refreshToken, cancellationToken);

        if (user is null)
        {
            throw new ArgumentException($"{refreshToken} is not valid");
        }

        string jwtToken = GenerateJwtToken(user);
        string newRefreshToken = GenerateRefreshToken();

        user.RefreshToken = newRefreshToken;

        await _context.SaveChangesAsync(cancellationToken);

        var token = new Token { Jwt = jwtToken, RefrashToken = newRefreshToken };

        return token;
    }

    private string GenerateRefreshToken()
    {
        byte[] randomNumber = new byte[64];

        RandomNumberGenerator.Fill(randomNumber);

        return Convert.ToBase64String(randomNumber);
    }

    /// <summary>
    ///     Получить "Соль" пользователя
    /// </summary>
    public async Task<string> GetUserSalt(string userName)
    {
        string userSalt = await _context.Set<User>()
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

    /// <summary>
    ///     Смена ника пользователя
    /// </summary>
    /// <param name="newUsername">Новый ник</param>
    /// <param name="cancellationToken">Токен отмены запроса</param>
    public async Task ChangeUsername(string newUsername, CancellationToken cancellationToken)
    {
        var user = await _currentUser.GetCurrentUser();

        user.Username = newUsername;

        _context.Set<User>().Update(user);

        await _context.SaveChangesAsync(cancellationToken);
    }

    /// <summary>
    ///     Сменить пароль
    /// </summary>
    /// <param name="newPassword">Новый пароль</param>
    /// <param name="cancellationToken">Токен отмены запроса</param>
    public async Task ChangePassword(UserPassword newPassword, CancellationToken cancellationToken)
    {
        var user = await _currentUser.GetCurrentUser();

        user.PasswordHash = newPassword.PasswordHash;
        user.PasswordSalt = newPassword.PasswordSalt;

        _context.Set<User>().Update(user);
        await _context.SaveChangesAsync(cancellationToken);
    }
}
