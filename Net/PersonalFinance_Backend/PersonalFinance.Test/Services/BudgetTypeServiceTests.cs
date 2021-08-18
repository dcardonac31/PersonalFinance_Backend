﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PersonalFinance.Common.Dtos;
using PersonalFinance.Common.Mapper;
using PersonalFinance.Domain.Dtos;
using PersonalFinance.Domain.Services;
using PersonalFinance.Infraestructure.DataAcces.Entities;
using PersonalFinance.Infraestructure.DataAcces.Repository;
using PersonalFinance.Test.Stubs;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PersonalFinance.Test.Services
{
    [TestClass]
    public class BudgetTypeServiceTests
    {
        private static MockRepository _mockRepository;
        private static Mock<IRepository<BudgetType>> _repository;

        [TestInitialize]
        public void TestInitialize()
        {
            AutoMapper.Mapper.Reset();
            AutoMapperConfig.CreateMaps();
            _mockRepository = new MockRepository(MockBehavior.Strict);
            _repository = _mockRepository.Create<IRepository<BudgetType>>();
        }

        private BudgetTypeService CreateService()
        {
            return new BudgetTypeService(_repository.Object);
        }

        [TestMethod]
        [Owner("David Sneider Cardona Cardenas")]
        public async Task GetByIdAsync_ReturnsEntityWithValues_WhenIdExists()
        {
            // Arrange
            _repository.Setup(x => x.FirstOrDefaultAsync(
                                        It.IsAny<Expression<Func<BudgetType, bool>>>(),
                                        It.IsAny<Expression<Func<BudgetType, object>>[]>())
                              ).ReturnsAsync(BudgetTypeStub.budgetType1);
            var service = CreateService();

            // Act
            var result = await service.GetByIdAsync(BudgetTypeStub.budgetTypeDto1.Id);

            // Assert
            Assert.IsNotNull(result);
            _repository.VerifyAll();
        }

        [TestMethod]
        [Owner("David Sneider Cardona Cardenas")]
        public async Task GetByIdAsync_ReturnsEntityNull_WhenIdNotExists()
        {
            // Arrange
            _repository.Setup(x => x.FirstOrDefaultAsync(
                                        It.IsAny<Expression<Func<BudgetType, bool>>>(),
                                        It.IsAny<Expression<Func<BudgetType, object>>[]>())
                             ).Returns(Task.FromResult<BudgetType>(null));
            var service = CreateService();
            int Id = 15;

            //Act
            var result = await service.GetByIdAsync(Id);

            //Assert
            Assert.IsTrue(result is null);
            _repository.VerifyAll();
        }

        [TestMethod]
        [Owner("David Sneider Cardona Cardenas")]
        public async Task GetAllAsync_ReturnsIEnumerableEntityWithValues_WhenExistsData()
        {
            // Arrange
            _repository.Setup(x => x.GetAllAsync(
                                        It.IsAny<Expression<Func<BudgetType, bool>>>(),
                                        It.IsAny<int>(),
                                        It.IsAny<int>(),
                                        It.IsAny<string>(),
                                        It.IsAny<bool>()
                             )).ReturnsAsync(BudgetTypeStub.lstBudgetType);
            var service = this.CreateService();
            int page = 1;
            int limit = 100;
            string orderBy = null;
            bool ascending = true;

            // Act
            var result = await service.GetAllAsync(page, limit, orderBy, ascending);

            // Assert
            CollectionAssert.Equals(BudgetTypeStub.lstBudgetTypeDto, result);
            _repository.VerifyAll();
        }

        [TestMethod]
        [Owner("David Sneider Cardona Cardenas")]
        public void Post_ReturnsTrueInTuple_WhenInsertData()
        {
            // Arrange
            _repository.Setup(x => x.Insert(It.IsAny<BudgetType>())).Returns(true);
            var service = CreateService();
            BudgetTypeDto entity = BudgetTypeStub.budgetTypeDto1;

            // Act
            var (status, id) = service.Post(entity);

            // Assert
            Assert.IsTrue(status);
            _repository.VerifyAll();
        }

        [TestMethod]
        [Owner("David Sneider Cardona Cardenas")]
        public void Post_ReturnsFalseInTuple_WhenNotInsertData()
        {
            // Arrange
            _repository.Setup(x => x.Insert(It.IsAny<BudgetType>())).Returns(false);
            var service = CreateService();
            BudgetTypeDto entity = BudgetTypeStub.budgetTypeDto1;

            // Act
            var (status, id) = service.Post(entity);

            // Assert
            Assert.IsFalse(status);
            _repository.VerifyAll();
        }

        [TestMethod]
        [Owner("David Sneider Cardona Cardenas")]
        public async Task PutAsync_ReturnsTrue_WhenIdExistsAndUpdateData()
        {
            // Arrange
            _repository.Setup(x => x.FirstOrDefaultAsync(
                                        It.IsAny<Expression<Func<BudgetType, bool>>>(),
                                        It.IsAny<Expression<Func<BudgetType, object>>[]>())
                             ).ReturnsAsync(BudgetTypeStub.budgetType1);
            _repository.Setup(x => x.Update(It.IsAny<BudgetType>())).Returns(true);
            var service = CreateService();
            int id = 1;
            BudgetTypeDto entity = BudgetTypeStub.budgetTypeDto1;

            // Act
            var result = await service.PutAsync(id, entity);

            // Assert
            Assert.IsTrue(result);
            _repository.VerifyAll();
        }

        [TestMethod]
        [Owner("David Sneider Cardona Cardenas")]
        public async Task PutAsync_ReturnsFalse_WhenIdExistsAndUpdateData()
        {
            // Arrange
            _repository.Setup(x => x.FirstOrDefaultAsync(
                                        It.IsAny<Expression<Func<BudgetType, bool>>>(),
                                        It.IsAny<Expression<Func<BudgetType, object>>[]>())
                             ).Returns(Task.FromResult<BudgetType>(null));
            var service = CreateService();
            BudgetTypeDto entity = BudgetTypeStub.budgetTypeDto2;

            // Act
            var result = await service.PutAsync(entity.Id, entity);

            // Assert
            Assert.IsFalse(result);
            _repository.VerifyAll();
        }

        [TestMethod]
        [Owner("David Sneider Cardona Cardenas")]
        public async Task DeleteAsync_ReturnsTrue_WhenIdExistsAndDeleteData()
        {
            // Arrange
            _repository.Setup(x => x.FirstOrDefaultAsync(
                                        It.IsAny<Expression<Func<BudgetType, bool>>>(),
                                        It.IsAny<Expression<Func<BudgetType, object>>[]>())
                             ).ReturnsAsync(BudgetTypeStub.budgetType1);
            _repository.Setup(x => x.Delete(It.IsAny<BudgetType>())).Returns(true);
            var service = CreateService();
            int id = 4;

            // Act
            var result = await service.DeleteAsync(id);

            // Assert
            Assert.IsTrue(result);
            _repository.VerifyAll();
        }

        [TestMethod]
        [Owner("David Sneider Cardona Cardenas")]
        public async Task DeleteAsync_ReturnsFalse_WhenIdExistsAndDeleteData()
        {
            // Arrange
            _repository.Setup(x => x.FirstOrDefaultAsync(
                                        It.IsAny<Expression<Func<BudgetType, bool>>>(),
                                        It.IsAny<Expression<Func<BudgetType, object>>[]>())
                             ).Returns(Task.FromResult<BudgetType>(null));
            var service = CreateService();
            int id = 15;

            // Act
            var result = await service.DeleteAsync(id);

            // Assert
            Assert.IsFalse(result);
            _repository.VerifyAll();
        }

        [TestMethod]
        [Owner("David Sneider Cardona Cardenas")]
        public async Task DeleteLogicAsync_ReturnsTrue_WhenIdExistsAndUpdateData()
        {
            // Arrange
            _repository.Setup(x => x.FirstOrDefaultAsync(
                                        It.IsAny<Expression<Func<BudgetType, bool>>>(),
                                        It.IsAny<Expression<Func<BudgetType, object>>[]>()
                              )).ReturnsAsync(BudgetTypeStub.budgetType1);
            _repository.Setup(x => x.Update(It.IsAny<BudgetType>())).Returns(true);

            var service = CreateService();
            DeletedInfo<int> entity = new(4, "dcardonac");

            // Act
            var result = await service.DeleteLogicAsync(entity);

            // Assert
            Assert.IsTrue(result);
            _mockRepository.VerifyAll();
        }

        [TestMethod]
        [Owner("David Sneider Cardona Cardenas")]
        public async Task DeleteLogicAsync_ReturnsFalse_WhenIdExistsAndUpdateData()
        {
            // Arrange
            _repository.Setup(x => x.FirstOrDefaultAsync(
                                        It.IsAny<Expression<Func<BudgetType, bool>>>(),
                                        It.IsAny<Expression<Func<BudgetType, object>>[]>()
                              )).Returns(Task.FromResult<BudgetType>(null));

            var service = CreateService();
            DeletedInfo<int> entity = new(4, "dcardonac");

            // Act
            var result = await service.DeleteLogicAsync(entity);

            // Assert
            Assert.IsFalse(result);
            _mockRepository.VerifyAll();
        }
    }
}
