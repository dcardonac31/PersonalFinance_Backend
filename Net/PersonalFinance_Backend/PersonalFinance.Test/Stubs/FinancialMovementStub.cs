using PersonalFinance.Api.Models;
using PersonalFinance.Domain.Dtos;
using PersonalFinance.Infraestructure.DataAcces.Entities;
using System;
using System.Collections.Generic;

namespace PersonalFinance.Test.Stubs
{
    public static class FinancialMovementStub
    {
        public static readonly FinancialMovementDto financialMovementDto1 = new()
        {
            Id = 1,
            MovementTypeId = 1,
            AssociatedDebtId = 1,
            AssociatedSavingId = 0,
            MovementDate = DateTime.Now,
            MovementValue = 100000,
            MovementDetail = "FWfwfw",
            CreationDate = DateTime.Now,
            CreationUser = "dcardonac",
            ModificationDate = null,
            ModificationUser = null,
            Deleted = false,
        };

        public static readonly FinancialMovementDto financialMovementDto2 = new()
        {
            Id = 2,
            MovementTypeId = 2,
            AssociatedDebtId = 2,
            AssociatedSavingId = 0,
            MovementDate = DateTime.Now,
            MovementValue = 100000,
            MovementDetail = "FWfwfw",
            CreationDate = DateTime.Now,
            CreationUser = "dcardonac",
            ModificationDate = null,
            ModificationUser = null,
            Deleted = false,
        };

        public static readonly List<FinancialMovementDto> lstFinancialMovementDto = new()
        {
            financialMovementDto1,
            financialMovementDto2
        };

        public static readonly FinancialMovementModel financialMovementModel = new()
        {
            Id = 1,
            MovementTypeId = 1,
            AssociatedDebtId = 1,
            AssociatedSavingId = 0,
            MovementDate = DateTime.Now,
            MovementValue = 100000,
            MovementDetail = "FWfwfw"
        };

        public static readonly FinancialMovement financialMovement1 = new()
        {
            Id = 1,
            MovementTypeId = 1,
            AssociatedDebtId = 1,
            AssociatedSavingId = 0,
            MovementDate = DateTime.Now,
            MovementValue = 100000,
            MovementDetail = "FWfwfw",
            CreationDate = DateTime.Now,
            CreationUser = "dcardonac",
            ModificationDate = null,
            ModificationUser = null,
            Deleted = false,
        };

        public static readonly FinancialMovement financialMovement2 = new()
        {
            Id = 2,
            MovementTypeId = 2,
            AssociatedDebtId = 2,
            AssociatedSavingId = 0,
            MovementDate = DateTime.Now,
            MovementValue = 100000,
            MovementDetail = "FWfwfw",
            CreationDate = DateTime.Now,
            CreationUser = "dcardonac",
            ModificationDate = null,
            ModificationUser = null,
            Deleted = false,
        };

        public static readonly List<FinancialMovement> lstFinancialMovement = new List<FinancialMovement>
        {
            financialMovement1,
            financialMovement2
        };
    }
}
