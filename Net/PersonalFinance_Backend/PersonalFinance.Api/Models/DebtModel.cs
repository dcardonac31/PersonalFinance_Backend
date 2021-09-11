using System;

namespace PersonalFinance.Api.Models
{
    public class DebtModel
    {
        public int Id { get; set; }
        public int ThirdPartyId { get; set; }
        public DateTime StartDate { get; set; }
        public decimal CreditAmount { get; set; }
        public int TermInMonths { get; set; }
        public decimal MonthlyInterest { get; set; }
        public decimal CurrentAmount { get; set; }
        public DateTime DateUpdate { get; set; }
        public bool InArrears { get; set; }
        public int NumberMonthsIntArrears { get; set; }
        public bool Paid { get; set; }
    }
}
