using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PersonalFinance.Infraestructure.DataAcces.Entities;
using System.Diagnostics.CodeAnalysis;

namespace PersonalFinance.Infraestructure.DataAcces.Context.Configurations
{
    [ExcludeFromCodeCoverage]
    public class DebtDetailConfig : IEntityTypeConfiguration<DebtDetail>
    {
        public void Configure(EntityTypeBuilder<DebtDetail> builder)
        {
            builder.ToTable("DebtDetail");

            builder.HasKey(e => new { e.Id }).HasName("PK_DebtDetail");

            builder.Property(e => e.Id)
                .ValueGeneratedOnAdd();

            builder.Property(e => e.DebtId)
                .IsRequired();

            builder.Property(e => e.RegistrationDate)
                .IsRequired();

            builder.Property(e => e.FeeValue)
                .HasDefaultValue(0)
                .IsRequired();

            builder.Property(e => e.InterestValue)
                .HasDefaultValue(0)
                .IsRequired();

            builder.Property(e => e.AmortizedCapital)
                .HasDefaultValue(0)
                .IsRequired();

            builder.Property(e => e.OutstandingCapital)
                .HasDefaultValue(0)
                .IsRequired();

            builder.Property(e => e.CreationDate);

            builder.Property(e => e.CreationUser);

            builder.Property(e => e.ModificationDate);

            builder.Property(e => e.ModificationUser);

            builder.Property(e => e.Deleted)
                .HasDefaultValue(false)
                .IsRequired();

            builder.HasIndex(e => e.CreationDate).HasDatabaseName("IX_TBL_DebtDetail_CreationDate");

            builder.HasIndex(e => e.DebtId).HasDatabaseName("IX_TBL_DebtDetail_DebtId");

            builder.HasOne<Debt>().WithMany().HasForeignKey(r => r.DebtId).HasConstraintName("FK_DebtDetail_DebtId");
        }
    }
}
