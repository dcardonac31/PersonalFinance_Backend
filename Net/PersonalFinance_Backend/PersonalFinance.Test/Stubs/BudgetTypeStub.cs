using PersonalFinance.Api.Models;
using PersonalFinance.Domain.Dtos;
using PersonalFinance.Infraestructure.DataAcces.Entities;
using System;
using System.Collections.Generic;

namespace PersonalFinance.Test.Stubs
{
    public static class BudgetTypeStub
    {
        public static readonly BudgetTypeDto budgetTypeDto1 = new()
        {
            Id = 1,
            DescriptionTypeBudget = "Mercado",
            CreationDate = DateTime.Now,
            CreationUser = "dcardonac",
            ModificationDate = null,
            ModificationUser = null,
            Deleted = false,
        };

        public static readonly BudgetTypeDto budgetTypeDto2 = new()
        {
            Id = 2,
            DescriptionTypeBudget = "Mercado diario",
            CreationDate = DateTime.Now,
            CreationUser = "dcardonac",
            ModificationDate = null,
            ModificationUser = null,
            Deleted = false,
        };

        public static readonly List<BudgetTypeDto> lstBudgetTypeDto = new()
        {
            budgetTypeDto1,
            budgetTypeDto2
        };

        public static readonly BudgetTypeModel budgetTypeModel = new()
        {
            Id = 3,
            DescriptionTypeBudget = "Pago deudas"
        };

        public static readonly BudgetType budgetType1 = new()
        {
            Id = 4,
            DescriptionTypeBudget = "Ahorros",
            CreationDate = DateTime.Now,
            CreationUser = "dcardonac",
            ModificationDate = null,
            ModificationUser = null,
            Deleted = false,
        };

        public static readonly BudgetType budgetType2 = new()
        {
            Id = 5,
            DescriptionTypeBudget = "Inversiones",
            CreationDate = DateTime.Now,
            CreationUser = "dcardonac",
            ModificationDate = null,
            ModificationUser = null,
            Deleted = false,
        };

        public static readonly List<BudgetType> lstBudgetType = new List<BudgetType>
        {
            budgetType1,
            budgetType2
        };
    }
}
