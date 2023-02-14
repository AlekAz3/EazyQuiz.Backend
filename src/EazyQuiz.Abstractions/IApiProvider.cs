using EazyQuiz.Models.DTO;

namespace EazyQuiz.Desktop.Admin;
public interface IApiProvider
{
    UserResponse Authtenticate(string username, string password);
    bool CheckUsername(string userName);
    string GetUserSaltByUsername(string userName);
    void Dispose();
}
