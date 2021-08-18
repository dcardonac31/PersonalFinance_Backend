using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PersonalFinance.Infraestructure.DataAcces.Entities;
using System.Diagnostics.CodeAnalysis;

namespace PersonalFinance.Infraestructure.DataAcces.Context.Configurations
{
    [ExcludeFromCodeCoverage]
    public class SavingConfig : IEntityTypeConfiguration<Saving>
    {
        public void Configure(EntityTypeBuilder<Saving> builder)
        {
            builder.ToTable("Saving");

            builder.HasKey(e => new { e.Id }).HasName("PK_Saving");

            builder.Property(e => e.Id)
                .ValueGeneratedOnAdd();

            builder.Property(e => e.ThirdPartyId)
                .IsRequired();

            builder.Property(e => e.StartDate)
                .IsRequired();

            builder.Property(e => e.SavedInitialAmount)
                .HasDefaultValue(0)
                .IsRequired();

            builder.Property(e => e.SavingGoal)
                .HasDefaultValue(0)
                .IsRequired();

            builder.Property(e => e.TermInMonths)
                .HasDefaultValue(0)
                .IsRequired();

            builder.Property(e => e.CurrentBalanceSaved)
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

            builder.Property(e => e.SavingFinished)
                .HasDefaultValue(false)
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
