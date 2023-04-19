using EazyQuiz.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EazyQuiz.Data;

public class UserAnswersEntityConfigurations : IEntityTypeConfiguration<UsersAnswers>
{
    public void Configure(EntityTypeBuilder<UsersAnswers> builder)
    {
        builder.HasOne(a => a.User)
            .WithMany(x => x.UsersAnswers)
            .HasForeignKey(p => p.UserId);

        builder.HasOne(a => a.Answer)
            .WithMany(x => x.UsersAnswers)
            .HasForeignKey(p => p.AnswerId);

        builder.HasOne(a => a.Question)
            .WithMany(x => x.UsersAnswers)
            .HasForeignKey(p => p.QuestionId);
    }
}
