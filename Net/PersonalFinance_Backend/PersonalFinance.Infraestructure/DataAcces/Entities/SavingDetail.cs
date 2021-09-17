using PersonalFinance.Infraestructure.DataAcces.Entities.Base;
using System;
using System.ComponentModel.DataAnnotations;

namespace PersonalFinance.Infraestructure.DataAcces.Entities
{
    public class SavingDetail : BaseEntity
    {
        [Required]
        public int SavingId { get; set; }
        [Required]
        public DateTime RegistrationDate { get; set; }
        [Required]
        public decimal Value { get; set; }
        [Required]
        public bool Retired { get; set; }
    }
}
