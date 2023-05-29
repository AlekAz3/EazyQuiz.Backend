using EazyQuiz.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EazyQuiz.Data;

/// <summary>
/// Конфигурация сущности <see cref="Feedback"/>
/// </summary>
internal class FeedbackEntityConfiguration : IEntityTypeConfiguration<Feedback>
{
    public void Configure(EntityTypeBuilder<Feedback> builder)
    {
        builder.HasOne(a => a.User)
            .WithMany(x => x.Feedbacks)
            .HasForeignKey(p => p.UserId);
    }
}
