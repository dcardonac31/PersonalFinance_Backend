using PersonalFinance.Infraestructure.DataAcces.Entities.Base;
using System;
using System.ComponentModel.DataAnnotations;

namespace PersonalFinance.Infraestructure.DataAcces.Entities
{
    public class BudgetType : BaseEntity
    {
        [Required]
        public string DescriptionTypeBudget { get; set; }
    }
}
