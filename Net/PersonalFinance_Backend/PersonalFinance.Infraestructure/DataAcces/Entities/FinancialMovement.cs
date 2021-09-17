using PersonalFinance.Infraestructure.DataAcces.Entities.Base;
using System;
using System.ComponentModel.DataAnnotations;

namespace PersonalFinance.Infraestructure.DataAcces.Entities
{
    public class FinancialMovement : BaseEntity
    {
        [Required]
        public int MovementTypeId { get; set; }
        public int? AssociatedDebtId { get; set; }
        public int? AssociatedSavingId { get; set; }
        [Required]
        public DateTime MovementDate { get; set; }
        [Required]
        public decimal MovementValue { get; set; }
        [Required]
        public string MovementDetail { get; set; }
    }
}
