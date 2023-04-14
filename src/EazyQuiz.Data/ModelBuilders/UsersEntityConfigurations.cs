using EazyQuiz.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EazyQuiz.Data;
internal class UsersEntityConfigurations : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder
            .HasData(new User()
            {
                Id = Guid.NewGuid(),
                Username = "Dev",
                PasswordHash = "H3rq06vpbbJMWds6JlG4BeH4egt3bEm/wVUdqpwBqyBDjSxbB+PHUp9vb/gdM6B4wqql3B/FU888P7GQ9nXDag==",
                PasswordSalt = "ELiNWv7oU1w/a4Wph9boQGdnx2ADiSF9Q0WUI5C0od4="
            });
    }
}
