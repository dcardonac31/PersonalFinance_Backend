using System;
using System.Diagnostics.CodeAnalysis;

namespace PersonalFinance.Domain.Dtos
{
    [ExcludeFromCodeCoverage]
    public class FinancialMovementDto
    {
        public int Id { get; set; }
        public int AssociatedDebtId { get; set; }
        public DateTime MovementDate { get; set; }
        public decimal MovementValue { get; set; }
        public string MovementDetail { get; set; }
        public DateTime? ModificationDate { get; set; }
        public string ModificationUser { get; set; }
        public DateTime? CreationDate { get; set; }
        public string CreationUser { get; set; }
        public bool Deleted { get; set; }
    }
}
