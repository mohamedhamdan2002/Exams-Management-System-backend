using Domain.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Data.Configurations
{
    internal class ExamQuestionConfiguration : IEntityTypeConfiguration<ExamQuestion>
    {
        public void Configure(EntityTypeBuilder<ExamQuestion> builder)
        {
            builder.HasKey(x => new { x.ExamId, x.QuestionId }); // composite key

            // one-to-many (question - to - exams)
            builder.HasOne(examQuestion => examQuestion.Question)
                .WithMany(question => question.Exams)
                .HasForeignKey(examQuestion => examQuestion.QuestionId);

            // one-to-many (exam - to - questions)
            builder.HasOne(examQuestion => examQuestion.Exam)
                .WithMany(exam => exam.Questions)
                .HasForeignKey(examQuestion => examQuestion.ExamId);
        }
    }
}
