using System;
using System.ComponentModel.DataAnnotations;

namespace PersonalFinance.Infraestructure.DataAcces.Entities
{
    public class Debt
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int ThirdPartyId { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public decimal CreditAmount { get; set; }
        [Required]
        public int TermInMonths { get; set; }
        [Required]
        public decimal MonthlyInterest { get; set; }
        [Required]
        public decimal CurrentAmount { get; set; }
        [Required]
        public DateTime DateUpdate { get; set; }
        [Required]
        public bool InArrears { get; set; }
        [Required]
        public int NumberMonthsIntArrears { get; set; }
        [Required]
        public bool Paid { get; set; }
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
