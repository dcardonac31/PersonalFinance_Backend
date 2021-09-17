using Microsoft.VisualStudio.TestTools.UnitTesting;
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
    public class DebtDetailServiceTests
    {
        private MockRepository _mockRepository;

        private Mock<IRepository<DebtDetail>> _repository;

        [TestInitialize]
        public void TestInitialize()
        {
            AutoMapper.Mapper.Reset();
            AutoMapperConfig.CreateMaps();
            _mockRepository = new MockRepository(MockBehavior.Strict);
            _repository = _mockRepository.Create<IRepository<DebtDetail>>();
        }

        private DebtDetailService CreateService()
        {
            return new DebtDetailService(_repository.Object);
        }

        [TestMethod]
        [Owner("David Sneider Cardona Cardenas")]
        public async Task GetByIdAsync_ReturnsEntityWithValues_WhenIdExists()
        {
            // Arrange
            _repository.Setup(x => x.FirstOrDefaultAsync(
                                        It.IsAny<Expression<Func<DebtDetail, bool>>>(),
                                        It.IsAny<Expression<Func<DebtDetail, object>>[]>())
                ).ReturnsAsync(DebtDetailStub.debtDetail1);
            var service = CreateService();

            // Act
            var result = await service.GetByIdAsync(DebtDetailStub.debtDetail1.Id);

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
                                It.IsAny<Expression<Func<DebtDetail, bool>>>(),
                                It.IsAny<Expression<Func<DebtDetail, object>>[]>())
                            ).Returns(Task.FromResult<DebtDetail>(null));
            var service = CreateService();
            int Id = 15;

            // Act
            var result = await service.GetByIdAsync(Id);

            // Assert
            Assert.IsTrue(result is null);
            _repository.VerifyAll();
        }


        [TestMethod]
        [Owner("David Sneider Cardona Cardenas")]
        public async Task GetAllAsync_ReturnsIEnumerableEntityWithValues_WhenExistsData()
        {
            // Arrange
            _repository.Setup(x => x.GetAllAsync(
                                        It.IsAny<Expression<Func<DebtDetail, bool>>>(),
                                        It.IsAny<int>(),
                                        It.IsAny<int>(),
                                        It.IsAny<string>(),
                                        It.IsAny<bool>()
                              )).ReturnsAsync(DebtDetailStub.lstDebtDetail);
            var service = this.CreateService();
            int page = 1;
            int limit = 100;
            string orderBy = null;
            bool ascending = true;

            // Act
            var result = await service.GetAllAsync(page, limit, orderBy, ascending);

            // Assert
            CollectionAssert.Equals(DebtDetailStub.lstDebtDetailDto, result);
            _repository.VerifyAll();
        }

        [TestMethod]
        [Owner("David Sneider Cardona Cardenas")]
        public void Post_ReturnsTrueInTuple_WhenInsertData()
        {
            // Arrange
            _repository.Setup(x => x.Insert(It.IsAny<DebtDetail>())).Returns(true);
            var service = CreateService();
            DebtDetailDto entity = DebtDetailStub.debtDetailDto1;

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
            _repository.Setup(x => x.Insert(It.IsAny<DebtDetail>())).Returns(false);
            var service = CreateService();
            DebtDetailDto entity = DebtDetailStub.debtDetailDto1;

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
                                        It.IsAny<Expression<Func<DebtDetail, bool>>>(),
                                        It.IsAny<Expression<Func<DebtDetail, object>>[]>())
                            ).ReturnsAsync(DebtDetailStub.debtDetail1);
            _repository.Setup(x => x.Update(It.IsAny<DebtDetail>())).Returns(true);
            var service = CreateService();
            int id = 1;
            DebtDetailDto entity = DebtDetailStub.debtDetailDto1;

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
                                        It.IsAny<Expression<Func<DebtDetail, bool>>>(),
                                        It.IsAny<Expression<Func<DebtDetail, object>>[]>())
                            ).ReturnsAsync(DebtDetailStub.debtDetail1);
            _repository.Setup(x => x.Update(It.IsAny<DebtDetail>())).Returns(false);
            var service = CreateService();
            DebtDetailDto entity = DebtDetailStub.debtDetailDto2;

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
                                        It.IsAny<Expression<Func<DebtDetail, bool>>>(),
                                        It.IsAny<Expression<Func<DebtDetail, object>>[]>())
                             ).ReturnsAsync(DebtDetailStub.debtDetail1);
            _repository.Setup(x => x.Delete(It.IsAny<DebtDetail>())).Returns(true);
            var service = this.CreateService();
            int id = 1;

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
                                        It.IsAny<Expression<Func<DebtDetail, bool>>>(),
                                        It.IsAny<Expression<Func<DebtDetail, object>>[]>())
                             ).Returns(Task.FromResult<DebtDetail>(null));
            var service = CreateService();
            int id = 10;

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
                                        It.IsAny<Expression<Func<DebtDetail, bool>>>(),
                                        It.IsAny<Expression<Func<DebtDetail, object>>[]>())
                             ).ReturnsAsync(DebtDetailStub.debtDetail1);
            _repository.Setup(x => x.Update(It.IsAny<DebtDetail>())).Returns(true);

            var service = CreateService();
            DeletedInfo<int> entity = new(1, "dcardonac");

            // Act
            var result = await service.DeleteLogicAsync(entity);

            // Assert
            Assert.IsTrue(result);
            _repository.VerifyAll();
        }

        [TestMethod]
        [Owner("David Sneider Cardona Cardenas")]
        public async Task DeleteLogicAsync_ReturnsFalse_WhenIdExistsAndUpdateData()
        {
            // Arrange
            _repository.Setup(x => x.FirstOrDefaultAsync(
                                        It.IsAny<Expression<Func<DebtDetail, bool>>>(),
                                        It.IsAny<Expression<Func<DebtDetail, object>>[]>()
                             )).Returns(Task.FromResult<DebtDetail>(null));

            var service = CreateService();
            DeletedInfo<int> entity = new(1, "dcardonac");

            // Act
            var result = await service.DeleteLogicAsync(entity);

            // Assert
            Assert.IsFalse(result);
            _repository.VerifyAll();
        }
    }
}
