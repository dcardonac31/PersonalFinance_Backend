using System;
using System.Diagnostics.CodeAnalysis;

namespace PersonalFinance.Domain.Dtos
{
    [ExcludeFromCodeCoverage]
    public class ThirdPartyDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool NaturalPerson { get; set; }
        public DateTime? ModificationDate { get; set; }
        public string ModificationUser { get; set; }
        public DateTime? CreationDate { get; set; }
        public string CreationUser { get; set; }
        public bool Deleted { get; set; }
    }
}
