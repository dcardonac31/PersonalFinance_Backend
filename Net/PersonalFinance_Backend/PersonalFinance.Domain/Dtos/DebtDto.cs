using System;
using System.Diagnostics.CodeAnalysis;

namespace PersonalFinance.Domain.Dtos
{
    [ExcludeFromCodeCoverage]
    public class DebtDto
    {
        public int Id { get; set; }
        public int ThirdPartyId { get; set; }
        public DateTime StartDate { get; set; }
        public double CreditAmount { get; set; }
        public int TermInMonths { get; set; }
        public decimal MonthlyInterest { get; set; }
        public DateTime DateUpdate { get; set; }
        public bool InArrears { get; set; }
        public int NumberMonthsIntArrears { get; set; }
        public bool Paid { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModificationUser { get; set; }
        public DateTime? CreationDate { get; set; }
        public string CreationUser { get; set; }
        public bool Deleted { get; set; }
    }

}
