using PersonalFinance.Infraestructure.DataAcces.Entities.Base;
using System;
using System.ComponentModel.DataAnnotations;

namespace PersonalFinance.Infraestructure.DataAcces.Entities
{
    public class MonthlyBudget : BaseEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int FinancialMovementId { get; set; }
        [Required]
        public int BudgetTypeId { get; set; }
        [Required]
        public decimal ExpectedSpending { get; set; }
        [Required]
        public decimal GeneratedSpending { get; set; }
        [Required]
        public DateTime BudgedDate { get; set; }
    }


}
