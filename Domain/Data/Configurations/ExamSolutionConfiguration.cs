using Domain.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Data.Configurations
{
    internal class ExamSolutionConfiguration : IEntityTypeConfiguration<ExamSolution>
    {
        public void Configure(EntityTypeBuilder<ExamSolution> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(solution => solution.Exam)
                .WithMany(exam => exam.Solutions)
                .HasForeignKey(solution => solution.ExamId);
        }
    }
}
