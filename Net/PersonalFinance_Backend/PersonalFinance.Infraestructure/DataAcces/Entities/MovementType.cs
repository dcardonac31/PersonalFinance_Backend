using System;
using System.ComponentModel.DataAnnotations;

namespace PersonalFinance.Infraestructure.DataAcces.Entities
{
    public class MovementType
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string DescriptionTypeMovement { get; set; }
        [Required]
        public int MovementTypeSign { get; set; }
        [Required]
        public DateTime CreationDate { get; set; }
        [Required]
        public string CreationUser { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string ModificationUser { get; set; }
        [Required]
        public bool Deleted { get; set; }
    }
}
