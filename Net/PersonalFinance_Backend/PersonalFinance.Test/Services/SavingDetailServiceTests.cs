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
    public class SavingDetailServiceTests
    {
        private MockRepository _mockRepository;

        private Mock<IRepository<SavingDetail>> _repository;

        [TestInitialize]
        public void TestInitialize()
        {
            AutoMapper.Mapper.Reset();
            AutoMapperConfig.CreateMaps();
            _mockRepository = new MockRepository(MockBehavior.Strict);
            _repository = _mockRepository.Create<IRepository<SavingDetail>>();
        }

        private SavingDetailService CreateService()
        {
            return new SavingDetailService(_repository.Object);
        }

        [TestMethod]
        [Owner("David Sneider Cardona Cardenas")]
        public async Task GetByIdAsync_ReturnsEntityWithValues_WhenIdExists()
        {
            // Arrange
            _repository.Setup(x => x.FirstOrDefaultAsync(
                                        It.IsAny<Expression<Func<SavingDetail, bool>>>(),
                                        It.IsAny<Expression<Func<SavingDetail, object>>[]>())
                ).ReturnsAsync(SavingDetailStub.savingDetail1);
            var service = CreateService();

            // Act
            var result = await service.GetByIdAsync(SavingDetailStub.savingDetail1.Id);

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
                                It.IsAny<Expression<Func<SavingDetail, bool>>>(),
                                It.IsAny<Expression<Func<SavingDetail, object>>[]>())
                            ).Returns(Task.FromResult<SavingDetail>(null));
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
                                        It.IsAny<Expression<Func<SavingDetail, bool>>>(),
                                        It.IsAny<int>(),
                                        It.IsAny<int>(),
                                        It.IsAny<string>(),
                                        It.IsAny<bool>()
                              )).ReturnsAsync(SavingDetailStub.lstSavingDetail);
            var service = this.CreateService();
            int page = 1;
            int limit = 100;
            string orderBy = null;
            bool ascending = true;

            // Act
            var result = await service.GetAllAsync(page, limit, orderBy, ascending);

            // Assert
            CollectionAssert.Equals(SavingDetailStub.lstSavingDetailDto, result);
            _repository.VerifyAll();
        }

        [TestMethod]
        [Owner("David Sneider Cardona Cardenas")]
        public void Post_ReturnsTrueInTuple_WhenInsertData()
        {
            // Arrange
            _repository.Setup(x => x.Insert(It.IsAny<SavingDetail>())).Returns(true);
            var service = CreateService();
            SavingDetailDto entity = SavingDetailStub.savingDetailDto1;

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
            _repository.Setup(x => x.Insert(It.IsAny<SavingDetail>())).Returns(false);
            var service = CreateService();
            SavingDetailDto entity = SavingDetailStub.savingDetailDto1;

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
                                        It.IsAny<Expression<Func<SavingDetail, bool>>>(),
                                        It.IsAny<Expression<Func<SavingDetail, object>>[]>())
                            ).ReturnsAsync(SavingDetailStub.savingDetail1);
            _repository.Setup(x => x.Update(It.IsAny<SavingDetail>())).Returns(true);
            var service = CreateService();
            int id = 1;
            SavingDetailDto entity = SavingDetailStub.savingDetailDto1;

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
                                        It.IsAny<Expression<Func<SavingDetail, bool>>>(),
                                        It.IsAny<Expression<Func<SavingDetail, object>>[]>())
                            ).ReturnsAsync(SavingDetailStub.savingDetail1);
            _repository.Setup(x => x.Update(It.IsAny<SavingDetail>())).Returns(false);
            var service = CreateService();
            SavingDetailDto entity = SavingDetailStub.savingDetailDto2;

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
                                        It.IsAny<Expression<Func<SavingDetail, bool>>>(),
                                        It.IsAny<Expression<Func<SavingDetail, object>>[]>())
                             ).ReturnsAsync(SavingDetailStub.savingDetail1);
            _repository.Setup(x => x.Delete(It.IsAny<SavingDetail>())).Returns(true);
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
                                        It.IsAny<Expression<Func<SavingDetail, bool>>>(),
                                        It.IsAny<Expression<Func<SavingDetail, object>>[]>())
                             ).Returns(Task.FromResult<SavingDetail>(null));
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
                                        It.IsAny<Expression<Func<SavingDetail, bool>>>(),
                                        It.IsAny<Expression<Func<SavingDetail, object>>[]>())
                             ).ReturnsAsync(SavingDetailStub.savingDetail1);
            _repository.Setup(x => x.Update(It.IsAny<SavingDetail>())).Returns(true);

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
                                        It.IsAny<Expression<Func<SavingDetail, bool>>>(),
                                        It.IsAny<Expression<Func<SavingDetail, object>>[]>()
                             )).Returns(Task.FromResult<SavingDetail>(null));

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
