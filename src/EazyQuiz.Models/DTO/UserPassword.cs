namespace EazyQuiz.Models.DTO;
public class UserPassword
{
    public byte[] PasswordHash { get; set; }

    public byte[] PasswordSalt { get; set; }

    public UserPassword(byte[] passwordHash, byte[] passwordSalt)
    {
        PasswordHash = passwordHash;
        PasswordSalt = passwordSalt;
    }
}
