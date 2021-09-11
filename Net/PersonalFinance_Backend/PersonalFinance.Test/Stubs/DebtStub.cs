using PersonalFinance.Api.Models;
using PersonalFinance.Domain.Dtos;
using PersonalFinance.Infraestructure.DataAcces.Entities;
using System;
using System.Collections.Generic;

namespace PersonalFinance.Test.Stubs
{
    public static class DebtStub
    {
        public static readonly DebtDto debtDto1 = new()
        {
            Id = 1,
            ThirdPartyId = 1,
            StartDate = DateTime.Now,
            CreditAmount = 1000000,
            TermInMonths = 12,
            MonthlyInterest = 1.8m,
            CurrentAmount = 800000,
            DateUpdate = DateTime.Now,
            InArrears = false,
            NumberMonthsIntArrears = 0,
            Paid = false,
            CreationDate = DateTime.Now,
            CreationUser = "dcardonac",
            ModificationDate = null,
            ModificationUser = null,
            Deleted = false,
        };

        public static readonly DebtDto debtDto2 = new()
        {
            Id = 2,
            ThirdPartyId = 2,
            StartDate = DateTime.Now,
            CreditAmount = 1000000,
            TermInMonths = 12,
            MonthlyInterest = 1.8m,
            CurrentAmount = 0,
            DateUpdate = DateTime.Now,
            InArrears = false,
            NumberMonthsIntArrears = 0,
            Paid = true,
            CreationDate = DateTime.Now,
            CreationUser = "dcardonac",
            ModificationDate = null,
            ModificationUser = null,
            Deleted = false,
        };

        public static readonly List<DebtDto> lstDebtDto = new()
        {
            debtDto1,
            debtDto2
        };

        public static readonly DebtModel debtModel = new()
        {
            Id = 1,
            ThirdPartyId = 1,
            StartDate = DateTime.Now,
            CreditAmount = 1000000,
            TermInMonths = 12,
            MonthlyInterest = 1.8m,
            CurrentAmount = 800000,
            DateUpdate = DateTime.Now,
            InArrears = false,
            NumberMonthsIntArrears = 0,
            Paid = false,
        };

        public static readonly Debt debt1 = new()
        {
            Id = 1,
            ThirdPartyId = 1,
            StartDate = DateTime.Now,
            CreditAmount = 1000000,
            TermInMonths = 12,
            MonthlyInterest = 1.8m,
            CurrentAmount = 800000,
            DateUpdate = DateTime.Now,
            InArrears = false,
            NumberMonthsIntArrears = 0,
            Paid = false,
            CreationDate = DateTime.Now,
            CreationUser = "dcardonac",
            ModificationDate = null,
            ModificationUser = null,
            Deleted = false,
        };

        public static readonly Debt debt2 = new()
        {
            Id = 2,
            ThirdPartyId = 2,
            StartDate = DateTime.Now,
            CreditAmount = 1000000,
            TermInMonths = 12,
            MonthlyInterest = 1.8m,
            CurrentAmount = 0,
            DateUpdate = DateTime.Now,
            InArrears = false,
            NumberMonthsIntArrears = 0,
            Paid = true,
            CreationDate = DateTime.Now,
            CreationUser = "dcardonac",
            ModificationDate = null,
            ModificationUser = null,
            Deleted = false,
        };

        public static readonly List<Debt> lstDebt = new List<Debt>
        {
            debt1,
            debt2
        };
    }
}
