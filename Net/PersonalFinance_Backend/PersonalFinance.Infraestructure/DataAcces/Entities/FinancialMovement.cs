using System;
using System.ComponentModel.DataAnnotations;

namespace PersonalFinance.Infraestructure.DataAcces.Entities
{
    public class FinancialMovement
    {
        [Key]
        public int Id { get; set; }
        public int AssociatedDebtId { get; set; }
        [Required]
        public DateTime MovementDate { get; set; }
        [Required]
        public decimal MovementValue { get; set; }
        [Required]
        public string MovementDetail { get; set; }
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
