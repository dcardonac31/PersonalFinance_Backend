using PersonalFinance.Api.Models;
using PersonalFinance.Domain.Dtos;
using PersonalFinance.Infraestructure.DataAcces.Entities;
using System;
using System.Collections.Generic;

namespace PersonalFinance.Test.Stubs
{
    public static class DebtDetailStub
    {
        public static readonly DebtDetailDto debtDetailDto1 = new()
        {
            Id = 1,
            DebtId = 1,
            RegistrationDate = DateTime.Now,
            FeeValue = 448104,
            InterestValue = 265565,
            AmortizedCapital = 182539,
            OutstandingCapital = 19201777,
            CreationDate = DateTime.Now,
            CreationUser = "dcardonac",
            ModificationDate = null,
            ModificationUser = null,
            Deleted = false,
        };

        public static readonly DebtDetailDto debtDetailDto2 = new()
        {
            Id = 2,
            DebtId = 1,
            RegistrationDate = DateTime.Now.AddDays(30),
            FeeValue = 448104,
            InterestValue = 263064,
            AmortizedCapital = 185040,
            OutstandingCapital = 19016737,
            CreationDate = DateTime.Now,
            CreationUser = "dcardonac",
            ModificationDate = null,
            ModificationUser = null,
            Deleted = false,
        };

        public static readonly List<DebtDetailDto> lstDebtDetailDto = new List<DebtDetailDto>
        {
            debtDetailDto1,
            debtDetailDto2
        };

        public static readonly DebtDetailModel debtDetailModel = new()
        {
            Id = 1,
            DebtId = 1,
            RegistrationDate = DateTime.Now,
            FeeValue = 448104,
            InterestValue = 265565,
            AmortizedCapital = 182539,
            OutstandingCapital = 19201777,
        };

        public static readonly DebtDetail debtDetail1 = new()
        {
            Id = 1,
            DebtId = 1,
            RegistrationDate = DateTime.Now,
            FeeValue = 448104,
            InterestValue = 265565,
            AmortizedCapital = 182539,
            OutstandingCapital = 19201777,
        };

        public static readonly DebtDetail debtDetail2 = new()
        {
            Id = 2,
            DebtId = 1,
            RegistrationDate = DateTime.Now.AddDays(30),
            FeeValue = 448104,
            InterestValue = 263064,
            AmortizedCapital = 185040,
            OutstandingCapital = 19016737,
        };

        public static readonly List<DebtDetail> lstDebtDetail = new List<DebtDetail>
        {
            debtDetail1,
            debtDetail2
        };
    }
}
