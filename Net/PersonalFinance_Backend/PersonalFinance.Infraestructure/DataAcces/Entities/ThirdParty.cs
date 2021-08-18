using PersonalFinance.Infraestructure.DataAcces.Entities.Base;
using System.ComponentModel.DataAnnotations;

namespace PersonalFinance.Infraestructure.DataAcces.Entities
{
    public class ThirdParty : BaseEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public bool NaturalPersona { get; set; }
    }
}
