using EazyQuiz.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EazyQuiz.Data;

/// <summary>
/// Конфигурация сущности <see cref="Answer"/>
/// </summary>
internal class AnswersEntityConfigurations : IEntityTypeConfiguration<Answer>
{
    public void Configure(EntityTypeBuilder<Answer> builder)
    {
        builder.HasOne(a => a.Question)
            .WithMany(x => x.Answers)
            .HasForeignKey(p => p.QuestionId);
    }
}
