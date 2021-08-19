using System;

namespace PersonalFinance.Api.Models
{
    public class FinancialMovementModel
    {
        public int Id { get; set; }
        public int MovementTypeId { get; set; }
        public int AssociatedDebtId { get; set; }
        public int AssociatedSavingId { get; set; }
        public DateTime MovementDate { get; set; }
        public decimal MovementValue { get; set; }
        public string MovementDetail { get; set; }
    }
}
