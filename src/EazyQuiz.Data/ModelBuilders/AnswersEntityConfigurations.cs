using EazyQuiz.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EazyQuiz.Data;

public class AnswersEntityConfigurations : IEntityTypeConfiguration<Answers>
{
    public void Configure(EntityTypeBuilder<Answers> builder)
    {
        builder.HasOne(a => a.Question)
            .WithMany(x => x.Answers)
            .HasForeignKey(p => p.QuestionId);
    }
}
