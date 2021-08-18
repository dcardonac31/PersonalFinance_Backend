using PersonalFinance.Infraestructure.DataAcces.Entities.Base;
using System;
using System.ComponentModel.DataAnnotations;

namespace PersonalFinance.Infraestructure.DataAcces.Entities
{
    public class MovementType : BaseEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string DescriptionTypeMovement { get; set; }
        [Required]
        public int MovementTypeSign { get; set; }
    }
}
