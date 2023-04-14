using EazyQuiz.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EazyQuiz.Data;

public class UsersEntityConfigurations : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder
            .HasData(new User()
            {
                Id = Guid.NewGuid(),
                Username = "Dev",
                RegistrationTime = new DateTimeOffset(new DateTime(2023, 1, 1), new TimeSpan(0, 3, 0, 0)),
                PasswordHash = "H3rq06vpbbJMWds6JlG4BeH4egt3bEm/wVUdqpwBqyBDjSxbB+PHUp9vb/gdM6B4wqql3B/FU888P7GQ9nXDag==",
                PasswordSalt = "ELiNWv7oU1w/a4Wph9boQGdnx2ADiSF9Q0WUI5C0od4="
            });
    }
}
