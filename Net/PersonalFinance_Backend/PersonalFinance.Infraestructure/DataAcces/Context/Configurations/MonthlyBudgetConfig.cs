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

            builder.Property(e => e.ModificationDate);

            builder.Property(e => e.ModificationUser);

            builder.Property(e => e.Deleted)
                .HasDefaultValue(false)
                .IsRequired();

            builder.HasIndex(e => e.CreationDate).HasDatabaseName("IX_MonthlyBudget_CreationDate");

            builder.HasIndex(e => e.FinancialMovementId).HasDatabaseName("IX_MonthlyBudget_FinancialMovementId");

            builder.HasIndex(e => e.BudgetTypeId).HasDatabaseName("IX_MonthlyBudget_BudgetTypeId");

            builder.HasOne<FinancialMovement>().WithMany().HasForeignKey(r => r.FinancialMovementId).HasConstraintName("FK_MonthlyBudget_FinancialMovementId");

            builder.HasOne<BudgetType>().WithMany().HasForeignKey(r => r.BudgetTypeId).HasConstraintName("FK_MonthlyBudget_BudgetTypeId");

        }
    }
}
