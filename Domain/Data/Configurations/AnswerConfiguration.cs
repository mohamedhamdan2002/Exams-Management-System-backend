using Domain.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Data.Configurations
{
    internal class AnswerConfiguration : IEntityTypeConfiguration<Answer>
    {
        public void Configure(EntityTypeBuilder<Answer> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Question)
                .WithMany()
                .HasForeignKey(x => x.QuestionId);
        }
    }

    internal class BooleanAnswerConfiguration : IEntityTypeConfiguration<BooleanAnswer>
    {
        public void Configure(EntityTypeBuilder<BooleanAnswer> builder)
        {

        }
    }

    internal class ChoiceAnswerConfiguration : IEntityTypeConfiguration<ChoiceAnswer>
    {
        public void Configure(EntityTypeBuilder<ChoiceAnswer> builder)
        {

        }
    }
}
