using System;
using System.Diagnostics.CodeAnalysis;

namespace PersonalFinance.Domain.Dtos
{
    [ExcludeFromCodeCoverage]
    public class MonthlyBudgetDto
    {
        public int Id { get; set; }
        public int FinancialMovementId { get; set; }
        public int BudgetTypeId { get; set; }
        public decimal ExpectedSpending { get; set; }
        public decimal GeneratedSpending { get; set; }
        public DateTime BudgedDate { get; set; }
        public DateTime? ModificationDate { get; set; }
        public string ModificationUser { get; set; }
        public DateTime? CreationDate { get; set; }
        public string CreationUser { get; set; }
        public bool Deleted { get; set; }
    }
}
