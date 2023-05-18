using EazyQuiz.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EazyQuiz.Data;

/// <summary>
/// Конфигурация сущности <see cref="UsersQuestions"/>
/// </summary>
internal class UserQuestionsEntityConfigurations : IEntityTypeConfiguration<UsersQuestions>
{
    public void Configure(EntityTypeBuilder<UsersQuestions> builder)
    {
        builder.HasOne(a => a.User)
            .WithMany(x => x.UsersQuestions)
            .HasForeignKey(p => p.UserId);
    }
}
