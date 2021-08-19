using PersonalFinance.Infraestructure.DataAcces.Entities.Base;
using System;
using System.ComponentModel.DataAnnotations;

namespace PersonalFinance.Infraestructure.DataAcces.Entities
{
    public class DebtDetail : BaseEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int DebtId { get; set; }
        [Required]
        public DateTime RegistrationDate { get; set; }
        [Required]
        public decimal FeeValue { get; set; }
        [Required]
        public decimal InterestValue { get; set; }
        [Required]
        public decimal AmortizedCapital { get; set; }
        [Required]
        public decimal OutstandingCapital { get; set; }
    }
}
