using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PersonalFinance.Infraestructure.DataAcces.Entities;
using System.Diagnostics.CodeAnalysis;

namespace PersonalFinance.Infraestructure.DataAcces.Context.Configurations
{
    [ExcludeFromCodeCoverage]
    public class BudgetTypeConfig : IEntityTypeConfiguration<BudgetType>
    {
        public void Configure(EntityTypeBuilder<BudgetType> builder)
        {
            builder.ToTable("BudgetType");

            builder.HasKey(e => new { e.Id }).HasName("PK_BudgetType");

            builder.Property(e => e.Id)
                .ValueGeneratedOnAdd();

            builder.Property(e => e.DescriptionTypeBudget)
                .IsRequired();

            builder.Property(e => e.CreationDate);


            builder.Property(e => e.CreationUser);


            builder.Property(e => e.ModifiedDate)
                .HasDefaultValue(null);

            builder.Property(e => e.ModificationUser)
                .HasDefaultValue(null);

            builder.Property(e => e.Deleted)
                .HasDefaultValue(false)
                .IsRequired();
        }
    }
}
