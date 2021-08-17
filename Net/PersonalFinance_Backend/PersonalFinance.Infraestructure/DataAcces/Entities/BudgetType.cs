using System;
using System.ComponentModel.DataAnnotations;

namespace PersonalFinance.Infraestructure.DataAcces.Entities
{
    public class BudgetType
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string DescriptionTypeBudget { get; set; }
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
