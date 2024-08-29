using Domain.Entities.Models;
using Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Data.Configurations
{
    internal class ExamConfiguration : IEntityTypeConfiguration<Exam>
    {
        public void Configure(EntityTypeBuilder<Exam> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(exam => exam.Title)
                .HasColumnType("VARCHAR")
                .HasMaxLength(500);

            builder.Property(exam => exam.Duration)
                .HasColumnType("time");

            builder.Property(exam => exam.Date)
                .HasColumnType("date")
                .HasConversion(
                    v => new DateTime(v.Year, v.Month, v.Day).Date,
                    v => DateOnly.FromDateTime(v)
                 );

            builder.Property(exam => exam.TotalMarks)
                .HasPrecision(6, 3);

            builder.Property(exam => exam.Term)
                .HasColumnType("VARCHAR")
                .HasMaxLength(10)
                .HasConversion(
                    x => x.ToString(), // store it in database as string 
                    x => (TermEnum)Enum.Parse(typeof(TermEnum), x) // convert it to enum in application
                );

            builder.Property(exam => exam.Level)
                .HasColumnType("VARCHAR")
                .HasMaxLength(10)
                .HasConversion(
                    x => x.ToString(),
                    x => (LevelEnum)Enum.Parse(typeof(LevelEnum), x)
                );

            builder.HasOne(exam => exam.Category)
                  .WithMany(category => category.Exams)
                  .HasForeignKey(exam => exam.CategoryId);

            builder.ToTable("Exams");

        }
    }
}
