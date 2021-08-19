using System;

namespace PersonalFinance.Api.Models
{
    public class SavingDetailModel
    {
        public int Id { get; set; }
        public int SavingId { get; set; }
        public DateTime RegistrationDate { get; set; }
        public decimal Value { get; set; }
        public bool Retired { get; set; }
    }
}
