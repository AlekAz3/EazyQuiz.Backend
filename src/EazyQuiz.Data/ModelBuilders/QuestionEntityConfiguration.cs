using EazyQuiz.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EazyQuiz.Data;

/// <summary>
///     Конфигурация сущности <see cref="Question" />
/// </summary>
internal class QuestionEntityConfiguration : IEntityTypeConfiguration<Question>
{
    public void Configure(EntityTypeBuilder<Question> builder) =>
        builder.HasOne(a => a.Theme)
            .WithMany(x => x.Questions)
            .HasForeignKey(p => p.ThemeId);
}
