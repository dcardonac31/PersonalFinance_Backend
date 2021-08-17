using System;

namespace PersonalFinance.Api.Models
{
    public class SavingModel
    {
        public int Id { get; set; }
        public int ThirdPartyId { get; set; }
        public DateTime StartDate { get; set; }
        public decimal SavedInitialAmount { get; set; }
        public decimal SavingGoal { get; set; }
        public int TermInMonths { get; set; }
        public decimal CurrentBalanceSaved { get; set; }
        public DateTime DateUpdate { get; set; }
        public bool InArrears { get; set; }
        public int NumberMonthsIntArrears { get; set; }
        public bool SavingFinished { get; set; }
    }
}
