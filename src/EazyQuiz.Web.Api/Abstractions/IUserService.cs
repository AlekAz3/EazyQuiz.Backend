using EazyQuiz.Models;

namespace EazyQuiz.Web.Api.Abstractions;
/// <summary>
/// Интерфейс для работы с пользователями
/// </summary>
public interface IUserService
{
    UserResponse Authenticate(UserAuth auth);
    IEnumerable<User> GetAll();
    User GetById(int id);
}
