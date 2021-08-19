using System;

namespace PersonalFinance.Api.Models
{
    public class DebtDetailModel
    {
        public int Id { get; set; }
        public int DebtId { get; set; }
        public DateTime RegistrationDate { get; set; }
        public decimal FeeValue { get; set; }
        public decimal InterestValue { get; set; }
        public decimal AmortizedCapital { get; set; }
        public decimal OutstandingCapital { get; set; }
    }
}
