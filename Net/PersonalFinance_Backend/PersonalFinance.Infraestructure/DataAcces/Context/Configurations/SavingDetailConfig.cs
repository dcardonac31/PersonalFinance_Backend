using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PersonalFinance.Infraestructure.DataAcces.Entities;
using System.Diagnostics.CodeAnalysis;

namespace PersonalFinance.Infraestructure.DataAcces.Context.Configurations
{
    [ExcludeFromCodeCoverage]
    public class SavingDetailConfig : IEntityTypeConfiguration<SavingDetail>
    {
        public void Configure(EntityTypeBuilder<SavingDetail> builder)
        {
            builder.ToTable("SavingDetail");

            builder.HasKey(e => new { e.Id }).HasName("PK_SavingDetail");

            builder.Property(e => e.Id)
                .ValueGeneratedOnAdd();

            builder.Property(e => e.SavingId)
                .IsRequired();

            builder.Property(e => e.RegistrationDate)
                .IsRequired();

            builder.Property(e => e.Value)
                .HasDefaultValue(0)
                .IsRequired();

            builder.Property(e => e.Retired)
                .HasDefaultValue(false)
                .IsRequired();

            builder.Property(e => e.CreationDate);

            builder.Property(e => e.CreationUser);

            builder.Property(e => e.ModificationDate);

            builder.Property(e => e.ModificationUser);

            builder.Property(e => e.Deleted)
                .HasDefaultValue(false)
                .IsRequired();

            builder.HasIndex(e => e.CreationDate).HasDatabaseName("IX_TBL_SavingDetail_CreationDate");

            builder.HasIndex(e => e.SavingId).HasDatabaseName("IX_TBL_SavingDetail_SavingId");

            builder.HasOne<Saving>().WithMany().HasForeignKey(r => r.SavingId).HasConstraintName("FK_SavingDetail_SavingId");

        }
    }
}
