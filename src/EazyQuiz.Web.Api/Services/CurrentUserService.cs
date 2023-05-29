using EazyQuiz.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace EazyQuiz.Web.Api;

/// <summary>
/// Сервис для получение текущего пользователя
/// </summary>
public class CurrentUserService
{
    /// <inheritdoc cref="IHttpContextAccessor"/>
    private readonly IHttpContextAccessor _httpContextAccessor;

    /// <inheritdoc cref="DataContext"/>
    private readonly DataContext _context;

    /// <summary>
    /// Ленивое получение всей информации о пользователе с базы данных
    /// </summary>
    private readonly Lazy<Task<User>> _currentUser;

    public CurrentUserService(IHttpContextAccessor httpContextAccessor, DataContext context)
    {
        _httpContextAccessor = httpContextAccessor;
        _context = context;
        _currentUser = new Lazy<Task<User>>(GetCurrentUserFromDatabase);
    }

    /// <summary>
    /// Получить Ид текущего пользователя
    /// </summary>
    /// <returns></returns>
    public Guid GetUserId()
    {
        return Guid.Parse(_httpContextAccessor.HttpContext.User.Claims.First(x => x.Type == ClaimTypes.NameIdentifier).Value);
    }

    /// <summary>
    /// Получить роль текущего пользователя
    /// </summary>
    /// <returns></returns>
    public string GetUserRole()
    {
        return _httpContextAccessor.HttpContext.User.Claims.First(x => x.Type == ClaimTypes.Role).Value;
    }

    /// <summary>
    /// Получить текущего пользователя
    /// </summary>
    /// <returns></returns>
    public async Task<User> GetCurrentUser()
    {
        return await _currentUser.Value;
    }

    /// <summary>
    /// Получить пользователя из базы данных
    /// </summary>
    /// <returns>Пользователь</returns>
    private async Task<User> GetCurrentUserFromDatabase()
    {
        var userIdClaim = GetUserId();

        var user = await _context.Set<User>()
            .AsNoTracking()
            .FirstAsync(u => u.Id == userIdClaim);

        return user;
    }
}
