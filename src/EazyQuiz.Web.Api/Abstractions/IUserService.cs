using EazyQuiz.Models;

namespace EazyQuiz.Web.Api.Abstractions;

public interface IUserService
{
    UserResponse Authenticate(UserAuth auth);
    IEnumerable<User> GetAll();
    User GetById(int id);
}
