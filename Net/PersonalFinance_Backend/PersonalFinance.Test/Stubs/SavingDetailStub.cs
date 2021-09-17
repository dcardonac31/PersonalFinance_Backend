using PersonalFinance.Api.Models;
using PersonalFinance.Domain.Dtos;
using PersonalFinance.Infraestructure.DataAcces.Entities;
using System;
using System.Collections.Generic;

namespace PersonalFinance.Test.Stubs
{
    public static class SavingDetailStub
    {
        public static readonly SavingDetailDto savingDetailDto1 = new()
        {
            Id = 1,
            SavingId = 1,
            RegistrationDate = DateTime.Now,
            Value = 83333,
            Retired = false,
            CreationDate = DateTime.Now,
            CreationUser = "dcardonac",
            ModificationDate = null,
            ModificationUser = null,
            Deleted = false
        };

        public static readonly SavingDetailDto savingDetailDto2 = new()
        {
            Id = 2,
            SavingId = 1,
            RegistrationDate = DateTime.Now,
            Value = 83333,
            Retired = false,
            CreationDate = DateTime.Now,
            CreationUser = "dcardonac",
            ModificationDate = null,
            ModificationUser = null,
            Deleted = false
        };

        public static readonly List<SavingDetailDto> lstSavingDetailDto = new()
        {
            savingDetailDto1,
            savingDetailDto2
        };

        public static readonly SavingDetailModel savingDetailModel = new()
        {
            Id = 1,
            SavingId = 1,
            RegistrationDate = DateTime.Now,
            Value = 83333,
            Retired = false
        };

        public static readonly SavingDetail savingDetail1 = new()
        {
            Id = 1,
            SavingId = 1,
            RegistrationDate = DateTime.Now,
            Value = 83333,
            Retired = false,
            CreationDate = DateTime.Now,
            CreationUser = "dcardonac",
            ModificationDate = null,
            ModificationUser = null,
            Deleted = false
        };

        public static readonly SavingDetail savingDetail2 = new()
        {
            Id = 2,
            SavingId = 1,
            RegistrationDate = DateTime.Now,
            Value = 83333,
            Retired = false,
            CreationDate = DateTime.Now,
            CreationUser = "dcardonac",
            ModificationDate = null,
            ModificationUser = null,
            Deleted = false
        };

        public static readonly List<SavingDetail> lstSavingDetail = new List<SavingDetail>
        {
            savingDetail1,
            savingDetail2
        };
    }
}
