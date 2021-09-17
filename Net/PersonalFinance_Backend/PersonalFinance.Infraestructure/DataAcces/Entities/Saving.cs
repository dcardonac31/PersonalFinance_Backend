using PersonalFinance.Infraestructure.DataAcces.Entities.Base;
using System;
using System.ComponentModel.DataAnnotations;

namespace PersonalFinance.Infraestructure.DataAcces.Entities
{
    public class Saving : BaseEntity
    {
        [Required]
        public int ThirdPartyId { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public decimal SavingGoal { get; set; }
        [Required]
        public int TermInMonths { get; set; }
        [Required]
        public decimal CurrentBalanceSaved { get; set; }
        [Required]
        public DateTime DateUpdate { get; set; }
        [Required]
        public bool InArrears { get; set; }
        [Required]
        public int NumberMonthsIntArrears { get; set; }
        [Required]
        public string SavingDescription { get; set; }
        [Required]
        public bool SavingFinished { get; set; }
    }
}
