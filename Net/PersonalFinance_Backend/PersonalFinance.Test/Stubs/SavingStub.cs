using PersonalFinance.Api.Models;
using PersonalFinance.Domain.Dtos;
using PersonalFinance.Infraestructure.DataAcces.Entities;
using System;
using System.Collections.Generic;

namespace PersonalFinance.Test.Stubs
{
    public static class SavingStub
    {
        public static readonly SavingDto savingDto1 = new()
        {
            Id = 1,
            ThirdPartyId = 1,
            StartDate = DateTime.Now,
            SavingGoal = 2500000,
            TermInMonths = 12,
            DateUpdate = DateTime.Now,
            InArrears = false,
            NumberMonthsIntArrears = 0,
            SavingDescription = "Compra Computador",
            SavingFinished = false,
            CreationDate = DateTime.Now,
            CreationUser = "dcardonac",
            ModificationDate = null,
            ModificationUser = null,
            Deleted = false,
        };

        public static readonly SavingDto savingDto2 = new()
        {
            Id = 2,
            ThirdPartyId = 2,
            StartDate = DateTime.Now,
            SavingGoal = 2500000,
            TermInMonths = 12,
            DateUpdate = DateTime.Now,
            InArrears = false,
            NumberMonthsIntArrears = 0,
            SavingDescription = "Abono JFK",
            SavingFinished = false,
            CreationDate = DateTime.Now,
            CreationUser = "dcardonac",
            ModificationDate = null,
            ModificationUser = null,
            Deleted = false,
        };

        public static readonly List<SavingDto> lstSavingDto = new()
        {
            savingDto1,
            savingDto2
        };

        public static readonly SavingModel savingModel = new()
        {
            Id = 1,
            ThirdPartyId = 1,
            StartDate = DateTime.Now,
            SavingGoal = 2500000,
            TermInMonths = 12,
            DateUpdate = DateTime.Now,
            InArrears = false,
            NumberMonthsIntArrears = 0,
            SavingDescription = "Compra Computador",
            SavingFinished = false
        };

        public static readonly Saving saving1 = new()
        {
            Id = 1,
            ThirdPartyId = 1,
            StartDate = DateTime.Now,
            SavingGoal = 2500000,
            TermInMonths = 12,
            DateUpdate = DateTime.Now,
            InArrears = false,
            NumberMonthsIntArrears = 0,
            SavingDescription = "Compra Computador",
            SavingFinished = false,
            CreationDate = DateTime.Now,
            CreationUser = "dcardonac",
            ModificationDate = null,
            ModificationUser = null,
            Deleted = false,
        };

        public static readonly Saving saving2 = new()
        {
            Id = 2,
            ThirdPartyId = 2,
            StartDate = DateTime.Now,
            SavingGoal = 2500000,
            TermInMonths = 12,
            DateUpdate = DateTime.Now,
            InArrears = false,
            NumberMonthsIntArrears = 0,
            SavingDescription = "Abono JFK",
            SavingFinished = false,
            CreationDate = DateTime.Now,
            CreationUser = "dcardonac",
            ModificationDate = null,
            ModificationUser = null,
            Deleted = false,
        };

        public static readonly List<Saving> lstSaving = new List<Saving>
        {
            saving1,
            saving2
        };
    }
}
