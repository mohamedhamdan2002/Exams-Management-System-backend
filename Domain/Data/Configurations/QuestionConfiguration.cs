using Domain.Entities.Models;
using Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Data.Configurations
{
    internal class QuestionConfiguration : IEntityTypeConfiguration<Question>
    {
        public void Configure(EntityTypeBuilder<Question> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(question => question.Title)
                .HasColumnType("VARCHAR")
                .HasMaxLength(500);

            builder.Property(question => question.Difficulty)
                .HasColumnType("VARCHAR")
                .HasMaxLength(10)
                .HasConversion(
                    x => x.ToString(),
                    x => (DifficultyEnum)Enum.Parse(typeof(DifficultyEnum), x)
                );

            builder.UseTpcMappingStrategy();
        }
    }

    internal class TrueAndFalseQuestionConfiguration : IEntityTypeConfiguration<TrueAndFalseQuestion>
    {
        public void Configure(EntityTypeBuilder<TrueAndFalseQuestion> builder)
        {
            builder.ToTable("TrueAndFalseQuestions");
        }
    }
    internal class MultipleChoiceQuestionConfiguration : IEntityTypeConfiguration<MultipleChoiceQuestion>
    {
        public void Configure(EntityTypeBuilder<MultipleChoiceQuestion> builder)
        {
            builder.ToTable("MultipleChoiceQuestions");
        }
    }
}
