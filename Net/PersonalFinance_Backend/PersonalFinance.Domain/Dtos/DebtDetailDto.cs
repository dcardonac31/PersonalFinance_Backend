using System;
using System.Diagnostics.CodeAnalysis;

namespace PersonalFinance.Domain.Dtos
{
    [ExcludeFromCodeCoverage]
    public class DebtDetailDto
    {
        public int Id { get; set; }
        public int DebtId { get; set; }
        public DateTime RegistrationDate { get; set; }
        public decimal FeeValue { get; set; }
        public decimal InterestValue { get; set; }
        public decimal AmortizedCapital { get; set; }
        public decimal OutstandingCapital { get; set; }
        public DateTime? ModificationDate { get; set; }
        public string ModificationUser { get; set; }
        public DateTime? CreationDate { get; set; }
        public string CreationUser { get; set; }
        public bool Deleted { get; set; }
    }

}
