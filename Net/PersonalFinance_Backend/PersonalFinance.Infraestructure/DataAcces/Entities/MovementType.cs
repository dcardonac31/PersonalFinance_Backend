using PersonalFinance.Infraestructure.DataAcces.Entities.Base;
using System;
using System.ComponentModel.DataAnnotations;

namespace PersonalFinance.Infraestructure.DataAcces.Entities
{
    public class MovementType : BaseEntity
    {
        [Required]
        public string DescriptionTypeMovement { get; set; }
        [Required]
        public int MovementTypeSign { get; set; }
    }
}
