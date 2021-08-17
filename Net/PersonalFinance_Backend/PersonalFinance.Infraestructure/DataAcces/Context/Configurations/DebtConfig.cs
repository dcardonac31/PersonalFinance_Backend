using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PersonalFinance.Infraestructure.DataAcces.Entities;
using System.Diagnostics.CodeAnalysis;

namespace PersonalFinance.Infraestructure.DataAcces.Context.Configurations
{
    [ExcludeFromCodeCoverage]
    public class DebtConfig : IEntityTypeConfiguration<Debt>
    {
        public void Configure(EntityTypeBuilder<Debt> builder)
        {
            builder.ToTable("Debt");

            builder.HasKey(e => new { e.Id }).HasName("PK_Debt");

            builder.Property(e => e.Id)
                .ValueGeneratedOnAdd();

            builder.Property(e => e.ThirdPartyId)
                .IsRequired();

            builder.Property(e => e.StartDate)
                .IsRequired();

            builder.Property(e => e.CreditAmount)
                .HasDefaultValue(0)
                .IsRequired();

            builder.Property(e => e.TermInMonths)
                .HasDefaultValue(0)
                .IsRequired();

            builder.Property(e => e.MonthlyInterest)
                .HasDefaultValue(0)
                .IsRequired();

            builder.Property(e => e.CurrentAmount)
                .HasDefaultValue(0)
                .IsRequired();

            builder.Property(e => e.DateUpdate)
                .IsRequired();

            builder.Property(e => e.InArrears)
                .HasDefaultValue(false)
                .IsRequired();

            builder.Property(e => e.NumberMonthsIntArrears)
                .HasDefaultValue(0)
                .IsRequired();

            builder.Property(e => e.Paid)
                .HasDefaultValue(false)
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
