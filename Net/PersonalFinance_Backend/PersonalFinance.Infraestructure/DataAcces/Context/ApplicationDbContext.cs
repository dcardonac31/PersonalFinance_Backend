using Microsoft.EntityFrameworkCore;
using PersonalFinance.Infraestructure.DataAcces.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;

namespace PersonalFinance.Infraestructure.DataAcces.Context
{
    [ExcludeFromCodeCoverage]
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {

        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> dbContextOptions) : base(dbContextOptions)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("dbo");
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
            Seed(modelBuilder);
        }

        private void Seed(ModelBuilder modelBuilder)
        {

            var listMovementType = new List<MovementType>
            {
                new MovementType {Id = 1 ,DescriptionTypeMovement = "Salario", MovementTypeSign = 1, CreationDate = DateTime.Now, CreationUser= "Migration", Deleted = false}
            };

            modelBuilder.Entity<MovementType>().HasData(listMovementType);

            var listBudgetType = new List<BudgetType>
            {
                new BudgetType {Id = 1, DescriptionTypeBudget = "Mercado", CreationDate = DateTime.Now, CreationUser= "Migration", Deleted = false},
                new BudgetType {Id = 2, DescriptionTypeBudget = "Mercado diario", CreationDate = DateTime.Now, CreationUser= "Migration", Deleted = false},
                new BudgetType {Id = 3, DescriptionTypeBudget = "Pago deudas", CreationDate = DateTime.Now, CreationUser= "Migration", Deleted = false},
                new BudgetType {Id = 4, DescriptionTypeBudget = "Ahorros", CreationDate = DateTime.Now, CreationUser= "Migration", Deleted = false},
                new BudgetType {Id = 5, DescriptionTypeBudget = "Inversiones", CreationDate = DateTime.Now, CreationUser= "Migration", Deleted = false},
                new BudgetType {Id = 6, DescriptionTypeBudget = "Comidas rapidas", CreationDate = DateTime.Now, CreationUser= "Migration", Deleted = false},
                new BudgetType {Id = 7, DescriptionTypeBudget = "Vestuario", CreationDate = DateTime.Now, CreationUser= "Migration", Deleted = false},
                new BudgetType {Id = 8, DescriptionTypeBudget = "Electrodomesticos", CreationDate = DateTime.Now, CreationUser= "Migration", Deleted = false},
                new BudgetType {Id = 9, DescriptionTypeBudget = "Computador", CreationDate = DateTime.Now, CreationUser= "Migration", Deleted = false},
                new BudgetType {Id = 10, DescriptionTypeBudget = "Transporte", CreationDate = DateTime.Now, CreationUser= "Migration", Deleted = false},
                new BudgetType {Id = 11, DescriptionTypeBudget = "Salud", CreationDate = DateTime.Now, CreationUser= "Migration", Deleted = false},
                new BudgetType {Id = 12, DescriptionTypeBudget = "Arriendo", CreationDate = DateTime.Now, CreationUser= "Migration", Deleted = false}
            };

            modelBuilder.Entity<BudgetType>().HasData(listBudgetType);
        }
    }
}
