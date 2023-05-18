using EazyQuiz.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EazyQuiz.Data;

/// <summary>
/// Конфигурация сущности <see cref="Theme"/>
/// </summary>
internal class ThemesEntityConfiguration : IEntityTypeConfiguration<Theme>
{
    public void Configure(EntityTypeBuilder<Theme> builder)
    {

    }
}
