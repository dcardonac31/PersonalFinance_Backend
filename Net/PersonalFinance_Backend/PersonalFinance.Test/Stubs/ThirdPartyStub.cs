using PersonalFinance.Api.Models;
using PersonalFinance.Domain.Dtos;
using PersonalFinance.Infraestructure.DataAcces.Entities;
using System;
using System.Collections.Generic;

namespace PersonalFinance.Test.Stubs
{
    public static class ThirdPartyStub
    {
        public static readonly ThirdPartyDto thirdPartyDto1 = new()
        {
            Id = 1,
            Name = "Cooperativa JFK",
            NaturalPerson = false,
            CreationDate = DateTime.Now,
            CreationUser = "dcardonac",
            ModificationDate = null,
            ModificationUser = null,
            Deleted = false,
        };

        public static readonly ThirdPartyDto thirdPartyDto2 = new()
        {
            Id = 2,
            Name = "Pepito Perez",
            NaturalPerson = true,
            CreationDate = DateTime.Now,
            CreationUser = "dcardonac",
            ModificationDate = null,
            ModificationUser = null,
            Deleted = false,
        };

        public static readonly List<ThirdPartyDto> lstThirdPartyDto = new()
        {
            thirdPartyDto1,
            thirdPartyDto2
        };

        public static readonly ThirdPartyModel thirdPartyModel = new()
        {
            Id = 1,
            Name = "Cooperativa JFK",
            NaturalPerson = false,
        };

        public static readonly ThirdParty thirdParty1 = new()
        {
            Id = 1,
            Name = "Cooperativa JFK",
            NaturalPerson = false,
            CreationDate = DateTime.Now,
            CreationUser = "dcardonac",
            ModificationDate = null,
            ModificationUser = null,
            Deleted = false,
        };

        public static readonly ThirdParty thirdParty2 = new()
        {
            Id = 2,
            Name = "Pepito Perez",
            NaturalPerson = true,
            CreationDate = DateTime.Now,
            CreationUser = "dcardonac",
            ModificationDate = null,
            ModificationUser = null,
            Deleted = false,
        };

        public static readonly List<ThirdParty> lstThirdParty = new List<ThirdParty>
        {
            thirdParty1,
            thirdParty2
        };
    }
}
