using System;
using System.Diagnostics.CodeAnalysis;

namespace PersonalFinance.Domain.Dtos
{
    [ExcludeFromCodeCoverage]
    public class SavingDetailDto
    {
        public int Id { get; set; }
        public int SavingId { get; set; }
        public DateTime RegistrationDate { get; set; }
        public decimal Value { get; set; }
        public bool Retired { get; set; }
        public DateTime? CreationDate { get; set; }
        public string CreationUser { get; set; }
        public bool Deleted { get; set; }
    }
}
