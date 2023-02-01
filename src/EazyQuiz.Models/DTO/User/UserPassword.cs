namespace EazyQuiz.Models;
/// <summary>
/// ДТО для хранения хэша пароля и соли 
/// </summary>
public class UserPassword
{
    /// <summary>
    /// Хэш
    /// </summary>
    public byte[] PasswordHash { get; set; }

    /// <summary>
    /// Соль
    /// </summary>
    public byte[] PasswordSalt { get; set; }

    public UserPassword(byte[] passwordHash, byte[] passwordSalt)
    {
        PasswordHash = passwordHash;
        PasswordSalt = passwordSalt;
    }
}
