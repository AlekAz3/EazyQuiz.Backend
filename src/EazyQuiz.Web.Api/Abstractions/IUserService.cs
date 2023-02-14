using EazyQuiz.Models.Database;
using EazyQuiz.Models.DTO;

namespace EazyQuiz.Web.Api;
/// <summary>
/// Интерфейс для работы с пользователями
/// </summary>
public interface IUserService
{
    /// <summary>
    /// Аутентификация игрока
    /// </summary>
    /// <param name="auth">Логин и Пароль <see cref="UserAuth"/></param>
    /// <returns>Инфа о пользователе и JWT токен в <see cref="UserResponse"/></returns>
    Task<UserResponse> Authenticate(UserAuth auth);

    /// <summary>
    /// Получение списка всех игроков
    /// </summary>
    /// <returns>Список игроков</returns>
    Task<IEnumerable<User>> GetAll();

    /// <summary>
    /// Получение инфы пользователя по Ид
    /// </summary>
    /// <param name="id">Ид</param>
    /// <returns>Инфа о пользователе в <see cref="User"/></returns>
    Task<User> GetById(int id);

    /// <summary>
    /// Получение соли по почте 
    /// </summary>
    /// <param name="userName">Почта игрока</param>
    /// <returns>Соль</returns>
    Task<string> GetUserSalt(string userName);

    /// <summary>
    /// Запись нового пользователя в базу данных
    /// </summary>
    /// <param name="user">Данные регистрации пользователя в <see cref="UserRegister"/></param>
    Task RegisterNewUser(UserRegister user);

    /// <summary>
    /// Проверка на уникальность Ника
    /// </summary>
    /// <param name="userName"></param>
    /// <returns></returns>
    Task<bool> CheckUniqueUsername(string userName);
}
