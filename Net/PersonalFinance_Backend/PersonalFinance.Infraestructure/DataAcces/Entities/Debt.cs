using PersonalFinance.Infraestructure.DataAcces.Entities.Base;
using System;
using System.ComponentModel.DataAnnotations;

namespace PersonalFinance.Infraestructure.DataAcces.Entities
{
    public class Debt : BaseEntity
    {
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
    }
}
