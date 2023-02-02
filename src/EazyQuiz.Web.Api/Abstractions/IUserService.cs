using EazyQuiz.Models;

namespace EazyQuiz.Web.Api;
/// <summary>
/// Интерфейс для работы с пользователями
/// </summary>
public interface IUserService
{
    /// <summary>
    /// Аунтетификация игрока
    /// </summary>
    /// <param name="auth">Логин и Пароль <see cref="UserAuth"/></param>
    /// <returns>Инфа о пользователе и JWT токен в <see cref="UserResponse"/></returns>
    UserResponse Authenticate(UserAuth auth);

    /// <summary>
    /// Получение списка всех игроков
    /// </summary>
    /// <returns>Список игроков</returns>
    IEnumerable<User> GetAll();

    /// <summary>
    /// Получение инфы пользователя по Ид
    /// </summary>
    /// <param name="id">Ид</param>
    /// <returns>Инфа о пользевателе в <see cref="User"/></returns>
    User GetById(int id);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="email"></param>
    /// <returns></returns>
    string GetUserSalt(string email);

    /// <summary>
    /// Запись нового пользователя в базу данных
    /// </summary>
    /// <param name="user">Данные регистрации пользователя в <see cref="UserRegister"/></param>
    void RegisterNewUser(UserRegister user);
}
