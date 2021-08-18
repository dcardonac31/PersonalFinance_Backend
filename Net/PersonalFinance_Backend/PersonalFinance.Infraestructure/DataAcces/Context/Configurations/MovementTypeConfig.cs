using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PersonalFinance.Infraestructure.DataAcces.Entities;
using System.Diagnostics.CodeAnalysis;

namespace PersonalFinance.Infraestructure.DataAcces.Context.Configurations
{
    [ExcludeFromCodeCoverage]
    public class MovementTypeConfig : IEntityTypeConfiguration<MovementType>
    {
        public void Configure(EntityTypeBuilder<MovementType> builder)
        {
            builder.ToTable("MovementType");

            builder.HasKey(e => new { e.Id }).HasName("PK_MovementType");

            builder.Property(e => e.Id)
                .ValueGeneratedOnAdd();

            builder.Property(e => e.DescriptionTypeMovement)
                .IsRequired();

            builder.Property(e => e.MovementTypeSign)
                .HasDefaultValue(1)
                .IsRequired();

            builder.Property(e => e.CreationDate)
                .IsRequired();

            builder.Property(e => e.CreationUser)
                .IsRequired();

            builder.Property(e => e.ModificationDate);

            builder.Property(e => e.ModificationUser);

            builder.Property(e => e.Deleted)
                .HasDefaultValue(false)
                .IsRequired();
        }
    }
}
