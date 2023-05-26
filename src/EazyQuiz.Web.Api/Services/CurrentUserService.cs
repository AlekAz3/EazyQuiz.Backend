using EazyQuiz.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace EazyQuiz.Web.Api;

public class CurrentUserService
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly DataContext _context;
    private readonly Lazy<Task<User>> _currentUser;
    public CurrentUserService(IHttpContextAccessor httpContextAccessor, DataContext context)
    {
        _httpContextAccessor = httpContextAccessor;
        _context = context;
        _currentUser = new Lazy<Task<User>>(GetCurrentUserFromDatabase);
    }

    public Guid GetUserId()
    {
        return Guid.Parse(_httpContextAccessor.HttpContext.User.Claims.First(x => x.Type == ClaimTypes.NameIdentifier).Value);
    }

    public string GetUserRole()
    {
        return _httpContextAccessor.HttpContext.User.Claims.First(x => x.Type == ClaimTypes.Role).Value;
    }

    public async Task<User> GetCurrentUser()
    {
        return await _currentUser.Value;
    }

    private async Task<User> GetCurrentUserFromDatabase()
    {
        var userIdClaim = GetUserId();

        var user = await _context.User
            .AsNoTracking()
            .FirstOrDefaultAsync(u => u.Id == userIdClaim);

        return user;
    }
}
