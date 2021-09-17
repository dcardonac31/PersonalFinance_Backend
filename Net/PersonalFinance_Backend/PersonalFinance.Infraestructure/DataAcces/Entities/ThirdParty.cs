using PersonalFinance.Infraestructure.DataAcces.Entities.Base;
using System.ComponentModel.DataAnnotations;

namespace PersonalFinance.Infraestructure.DataAcces.Entities
{
    public class ThirdParty : BaseEntity
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public bool NaturalPerson { get; set; }
    }
}
