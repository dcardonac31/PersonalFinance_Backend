using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PersonalFinance.Infraestructure.DataAcces.Entities;
using System.Diagnostics.CodeAnalysis;

namespace PersonalFinance.Infraestructure.DataAcces.Context.Configurations
{
    [ExcludeFromCodeCoverage]
    public class MonthlyBudgetConfig : IEntityTypeConfiguration<MonthlyBudget>
    {
        public void Configure(EntityTypeBuilder<MonthlyBudget> builder)
        {
            builder.ToTable("MonthlyBudget");

            builder.HasKey(e => new { e.Id }).HasName("PK_MonthlyBudget");

            builder.Property(e => e.Id)
                .ValueGeneratedOnAdd();

            builder.Property(e => e.FinancialMovementId)
                .IsRequired();

            builder.Property(e => e.BudgetTypeId)
                .IsRequired();

            builder.Property(e => e.ExpectedSpending)
                .HasDefaultValue(0)
                .IsRequired();

            builder.Property(e => e.GeneratedSpending)
                .HasDefaultValue(0)
                .IsRequired();

            builder.Property(e => e.BudgedDate)
                .IsRequired();

            builder.Property(e => e.CreationDate);

            builder.Property(e => e.CreationUser);

            builder.Property(e => e.ModifiedDate);

            builder.Property(e => e.ModificationUser);

            builder.Property(e => e.Deleted)
                .HasDefaultValue(false)
                .IsRequired();
        }
    }
}
