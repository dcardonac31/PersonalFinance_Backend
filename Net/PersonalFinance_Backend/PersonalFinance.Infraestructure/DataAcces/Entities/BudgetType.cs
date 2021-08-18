using PersonalFinance.Infraestructure.DataAcces.Entities.Base;
using System;
using System.ComponentModel.DataAnnotations;

namespace PersonalFinance.Infraestructure.DataAcces.Entities
{
    public class BudgetType : BaseEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string DescriptionTypeBudget { get; set; }
    }
}
