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

            builder.Property(e => e.SavingDescription)
                .HasDefaultValue(string.Empty)
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

            builder.HasIndex(e => e.CreationDate).HasDatabaseName("IX_Saving_CreationDate");

            builder.HasIndex(e => e.ThirdPartyId).HasDatabaseName("IX_Saving_ThirdPartyId");

            builder.HasOne<ThirdParty>().WithMany().HasForeignKey(r => r.ThirdPartyId).HasConstraintName("FK_Saving_ThirdPartyId");
        }
    }
}
