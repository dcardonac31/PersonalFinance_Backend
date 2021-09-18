using PersonalFinance.Api.Models;
using PersonalFinance.Domain.Dtos;
using PersonalFinance.Infraestructure.DataAcces.Entities;
using System;
using System.Collections.Generic;

namespace PersonalFinance.Test.Stubs
{
    public static class MovementTypeStub
    {
        public static readonly MovementTypeDto movementTypeDto1 = new()
        {
            Id = 1,
            DescriptionTypeMovement = "Ingreso salario",
            MovementTypeSign = 1,
            CreationDate = DateTime.Now,
            CreationUser = "dcardonac",
            ModificationDate = null,
            ModificationUser = null,
            Deleted = false,
        };

        public static readonly MovementTypeDto movementTypeDto2 = new()
        {
            Id = 2,
            DescriptionTypeMovement = "Salida compra mercado",
            MovementTypeSign = -1,
            CreationDate = DateTime.Now,
            CreationUser = "dcardonac",
            ModificationDate = null,
            ModificationUser = null,
            Deleted = false,
        };

        public static readonly List<MovementTypeDto> lstMovementTypeDto = new()
        {
            movementTypeDto1,
            movementTypeDto2
        };

        public static readonly MovementTypeModel movementTypeModel = new()
        {
            Id = 1,
            DescriptionTypeMovement = "Ingreso salario",
            MovementTypeSign = 1
        };

        public static readonly MovementType movementType1 = new()
        {
            Id = 1,
            DescriptionTypeMovement = "Ingreso salario",
            MovementTypeSign = 1,
            CreationDate = DateTime.Now,
            CreationUser = "dcardonac",
            ModificationDate = null,
            ModificationUser = null,
            Deleted = false,
        };

        public static readonly MovementType movementType2 = new()
        {
            Id = 2,
            DescriptionTypeMovement = "Salida compra mercado",
            MovementTypeSign = -1,
            CreationDate = DateTime.Now,
            CreationUser = "dcardonac",
            ModificationDate = null,
            ModificationUser = null,
            Deleted = false,
        };

        public static readonly List<MovementType> lstMovementType = new List<MovementType>
        {
            movementType1,
            movementType2
        };
    }
}
