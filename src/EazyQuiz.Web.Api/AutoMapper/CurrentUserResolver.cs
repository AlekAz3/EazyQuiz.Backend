using AutoMapper;

namespace EazyQuiz.Web.Api;

/// <summary>
///     Резолвер для автомаппера по получению ид текущего пользователя
/// </summary>
public class CurrentUserResolver : IValueResolver<object, object, Guid>
{
    /// <inheritdoc cref="CurrentUserService" />
    private readonly CurrentUserService _currentUser;

    public CurrentUserResolver(CurrentUserService currentUser)
    {
        _currentUser = currentUser;
    }

    public Guid Resolve(object source, object destination, Guid destMember, ResolutionContext context) =>
        _currentUser.GetUserId();
}
