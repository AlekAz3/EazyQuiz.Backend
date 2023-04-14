using EazyQuiz.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace EazyQuiz.Data
{
    public class AnswersEntityConfigurations : IEntityTypeConfiguration<Answers>
    {
        public void Configure(EntityTypeBuilder<Answers> builder)
        {
            builder.HasOne(a => a.Question)
                .WithMany(x => x.Answers)
                .HasForeignKey(p => p.QuestionId);
        }
    }
}
