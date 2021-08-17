using System;

namespace PersonalFinance.Api.Models
{
    public class MonthlyBudgetModel
    {
        public int Id { get; set; }
        public int FinancialMovementId { get; set; }
        public int BudgetTypeId { get; set; }
        public decimal ExpectedSpending { get; set; }
        public decimal GeneratedSpending { get; set; }
        public DateTime BudgedDate { get; set; }
    }
}
