using System;
using System.ComponentModel.DataAnnotations;

namespace PersonalFinance.Infraestructure.DataAcces.Entities
{
    public class MonthlyBudget
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
        [Required]
        public DateTime CreationDate { get; set; }
        [Required]
        public string CreationUser { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string ModificationUser { get; set; }
        [Required]
        public bool Deleted { get; set; }
    }


}
