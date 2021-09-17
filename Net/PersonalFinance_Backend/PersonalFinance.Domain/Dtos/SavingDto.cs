using System;
using System.Diagnostics.CodeAnalysis;

namespace PersonalFinance.Domain.Dtos
{
    [ExcludeFromCodeCoverage]
    public class SavingDto
    {
        public int Id { get; set; }
        public int ThirdPartyId { get; set; }
        public DateTime StartDate { get; set; }
        public decimal SavingGoal { get; set; }
        public int TermInMonths { get; set; }
        public DateTime DateUpdate { get; set; }
        public bool InArrears { get; set; }
        public int NumberMonthsIntArrears { get; set; }
        public string SavingDescription { get; set; }
        public bool SavingFinished { get; set; }
        public DateTime? ModificationDate { get; set; }
        public string ModificationUser { get; set; }
        public DateTime? CreationDate { get; set; }
        public string CreationUser { get; set; }
        public bool Deleted { get; set; }
    }
}
