
using AutoMapper;

namespace EazyQuiz.Web.Api;

public class CurrentUserResolver : IValueResolver<object, object, Guid>
{
    private readonly CurrentUserService _currentUser;

    public CurrentUserResolver(CurrentUserService currentUser)
    {
        _currentUser = currentUser;
    }
    public Guid Resolve(object source, object destination, Guid destMember, ResolutionContext context)
    {
        return _currentUser.GetUserId();
    }
}
