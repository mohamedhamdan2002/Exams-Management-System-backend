using Domain.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Data.Configurations
{
    internal class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(category => category.Id);

            builder.Property(categeroy => categeroy.Name)
                .HasColumnType("VARCHAR")
                .HasMaxLength(50);

            builder.Property(categeroy => categeroy.Description)
                .HasColumnType("VARCHAR")
                .HasMaxLength(250)
                .IsRequired(false);

        }
    }
}
