using EazyQuiz.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace EazyQuiz.Data;

public class UserQuestionsEntityConfigurations : IEntityTypeConfiguration<UsersQuesions>
{
    public void Configure(EntityTypeBuilder<UsersQuesions> builder)
    {
        builder.HasOne(a => a.User)
            .WithMany(x => x.UsersQuesions)
            .HasForeignKey(p => p.UserId);
    }
}
