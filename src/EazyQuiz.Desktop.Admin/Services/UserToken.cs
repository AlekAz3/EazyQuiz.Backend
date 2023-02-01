using EazyQuiz.Models;

namespace EazyQuiz.Desktop.Admin;
public class UserToken
{
    public UserResponse User { get; set; } = new UserResponse(0, null, null, 0, 0, 0, null, null);
}
