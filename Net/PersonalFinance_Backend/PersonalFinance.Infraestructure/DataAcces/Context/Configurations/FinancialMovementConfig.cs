using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PersonalFinance.Infraestructure.DataAcces.Entities;
using System.Diagnostics.CodeAnalysis;

namespace PersonalFinance.Infraestructure.DataAcces.Context.Configurations
{
    [ExcludeFromCodeCoverage]
    public class FinancialMovementConfig : IEntityTypeConfiguration<FinancialMovement>
    {
        public void Configure(EntityTypeBuilder<FinancialMovement> builder)
        {
            builder.ToTable("FinancialMovement");

            builder.HasKey(e => new { e.Id }).HasName("PK_FinancialMovement");

            builder.Property(e => e.Id)
                .ValueGeneratedOnAdd();

            builder.Property(e => e.AssociatedDebtId)
                .IsRequired();

            builder.Property(e => e.MovementDate)
                .IsRequired();

            builder.Property(e => e.MovementValue)
                .HasDefaultValue(0)
                .IsRequired();

            builder.Property(e => e.MovementDetail)
                .IsRequired();

            builder.Property(e => e.CreationDate);

            builder.Property(e => e.CreationUser);

            builder.Property(e => e.ModificationDate);

            builder.Property(e => e.ModificationUser);

            builder.Property(e => e.Deleted)
                .HasDefaultValue(false)
                .IsRequired();

        }
    }
}
