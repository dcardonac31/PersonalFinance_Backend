using PersonalFinance.Api.Models;
using PersonalFinance.Domain.Dtos;
using PersonalFinance.Infraestructure.DataAcces.Entities;
using System;
using System.Collections.Generic;

namespace PersonalFinance.Test.Stubs
{
    public static class MonthlyBudgetStub
    {
        public static readonly MonthlyBudgetDto monthlyBudgetDto1 = new()
        {
            Id = 1,
            FinancialMovementId = 1,
            BudgetTypeId = 1,
            ExpectedSpending = 100000,
            GeneratedSpending = 120000,
            BudgedDate = DateTime.Now,
            CreationDate = DateTime.Now,
            CreationUser = "dcardonac",
            ModificationDate = null,
            ModificationUser = null,
            Deleted = false
        };

        public static readonly MonthlyBudgetDto monthlyBudgetDto2 = new()
        {
            Id = 2,
            FinancialMovementId = 2,
            BudgetTypeId = 2,
            ExpectedSpending = 0,
            GeneratedSpending = 120000,
            BudgedDate = DateTime.Now,
            CreationDate = DateTime.Now,
            CreationUser = "dcardonac",
            ModificationDate = null,
            ModificationUser = null,
            Deleted = false
        };

        public static readonly List<MonthlyBudgetDto> lstMonthlyBudgetDto = new()
        {
            monthlyBudgetDto1,
            monthlyBudgetDto2
        };

        public static readonly MonthlyBudgetModel monthlyBudgetModel = new()
        {
            Id = 1,
            FinancialMovementId = 1,
            BudgetTypeId = 1,
            ExpectedSpending = 100000,
            GeneratedSpending = 120000
        };

        public static readonly MonthlyBudget monthlyBudget1 = new()
        {
            Id = 1,
            FinancialMovementId = 1,
            BudgetTypeId = 1,
            ExpectedSpending = 100000,
            GeneratedSpending = 120000,
            BudgedDate = DateTime.Now,
            CreationDate = DateTime.Now,
            CreationUser = "dcardonac",
            ModificationDate = null,
            ModificationUser = null,
            Deleted = false,
        };

        public static readonly MonthlyBudget monthlyBudget2 = new()
        {
            Id = 2,
            FinancialMovementId = 2,
            BudgetTypeId = 2,
            ExpectedSpending = 0,
            GeneratedSpending = 120000,
            BudgedDate = DateTime.Now,
            CreationDate = DateTime.Now,
            CreationUser = "dcardonac",
            ModificationDate = null,
            ModificationUser = null,
            Deleted = false
        };

        public static readonly List<MonthlyBudget> lstMonthlyBudget = new List<MonthlyBudget>
        {
            monthlyBudget1,
            monthlyBudget2
        };
    }
}
