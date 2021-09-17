using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PersonalFinance.Api.Controllers;
using PersonalFinance.Common.Dtos;
using PersonalFinance.Common.Mapper;
using PersonalFinance.Domain.Dtos;
using PersonalFinance.Domain.Interfaces;
using PersonalFinance.Test.Stubs;
using Shyjus.BrowserDetection;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;

namespace PersonalFinance.Test.Controllers
{
    [TestClass]
    public class SavingDetailControllerTests
    {
        private MockRepository _mockRepository;

        private Mock<ILogger<SavingDetailController>> _mockLogger;
        private Mock<ISavingDetailService> _mockService;
        private Mock<IBrowserDetector> _mockBrowserDetector;

        [TestInitialize]
        public void TestInitialize()
        {
            AutoMapper.Mapper.Reset();
            AutoMapperConfig.CreateMaps();
            _mockRepository = new MockRepository(MockBehavior.Strict);
            _mockLogger = new Mock<ILogger<SavingDetailController>>();
            _mockService = _mockRepository.Create<ISavingDetailService>();
            _mockBrowserDetector = _mockRepository.Create<IBrowserDetector>();
        }

        private SavingDetailController CreateSavingDetailController()
        {
            var identity = new GenericIdentity("dcardonac", ClaimTypes.Name);
            var contextUser = new ClaimsPrincipal(identity);
            var httpContext = new DefaultHttpContext()
            {
                User = contextUser
            };
            var controllerContext = new ControllerContext()
            {
                HttpContext = httpContext
            };
            return new SavingDetailController(_mockLogger.Object, _mockService.Object, _mockBrowserDetector.Object)
            {
                ControllerContext = controllerContext
            };
        }

        [TestMethod]
        [Owner("David Sneider Cardona Cardenas")]
        public async Task GetByIdAsync_ReturnsOk_WhenModelStateIsValid()
        {
            // Arrange
            int id = 1;
            _mockService.Setup(sp => sp.GetByIdAsync(id)).ReturnsAsync(SavingDetailStub.savingDetailDto1);
            var SavingDetailController = CreateSavingDetailController();

            // Act
            var result = await SavingDetailController.GetByIdAsync(id);

            // Assert
            var okResult = result as ObjectResult;
            Assert.IsNotNull(okResult);
            Assert.IsTrue(okResult is OkObjectResult);
            Assert.AreEqual(StatusCodes.Status200OK, okResult.StatusCode);

            var model = okResult.Value as ResponseService<SavingDetailDto>;
            Assert.IsNotNull(model);
            Assert.IsNotNull(okResult);
            Assert.AreEqual(SavingDetailStub.savingDetailDto1, model.Data);
            _mockService.VerifyAll();
        }

        [TestMethod]
        [Owner("David Sneider Cardona Cardenas")]
        public async Task GetAllAsync_ReturnsOk_WhenModelStateIsValid()
        {
            // Arrange
            _mockService.Setup(x => x.GetAllAsync(
                                    It.IsAny<int>(),
                                    It.IsAny<int>(),
                                    It.IsAny<string>(),
                                    It.IsAny<bool>()))
                .ReturnsAsync(SavingDetailStub.lstSavingDetailDto);
            var SavingDetailController = this.CreateSavingDetailController();
            int? page = 1;
            int? limit = 10;

            // Act
            var result = await SavingDetailController.GetAllAsync(page, limit);

            // Assert
            var okResult = result as ObjectResult;
            Assert.IsNotNull(okResult);
            Assert.IsTrue(okResult is OkObjectResult);
            Assert.AreEqual(StatusCodes.Status200OK, okResult.StatusCode);

            var model = okResult.Value as ResponseService<IEnumerable<SavingDetailDto>>;
            Assert.IsNotNull(model);
            Assert.IsNotNull(okResult);
            CollectionAssert.AreEqual(SavingDetailStub.lstSavingDetailDto, model.Data.ToList());
            _mockService.VerifyAll();
        }

        [TestMethod]
        [Owner("David Sneider Cardona Cardenas")]
        public void Post_ReturnsOk_WhenModelStateIsValid()
        {
            // Arrange
            _mockService.Setup(x => x.Post(It.IsAny<SavingDetailDto>())).Returns((true, 1));
            _mockBrowserDetector.Setup(x => x.Browser.Name).Returns("IE9");
            var SavingDetailController = this.CreateSavingDetailController();


            // Act
            var result = SavingDetailController.Post(SavingDetailStub.savingDetailModel);

            // Assert
            var okResult = result as ObjectResult;
            Assert.IsNotNull(okResult);
            Assert.IsTrue(okResult is OkObjectResult);
            Assert.AreEqual(StatusCodes.Status200OK, okResult.StatusCode);
            _mockService.VerifyAll();
        }

        [TestMethod]
        [Owner("David Sneider Cardona Cardenas")]
        public async Task Put_ReturnsOk_WhenModelStateIsValid()
        {
            // Arrange
            _mockService.Setup(x => x.PutAsync(It.IsAny<int>(), It.IsAny<SavingDetailDto>())).ReturnsAsync(true);
            _mockBrowserDetector.Setup(x => x.Browser.Name).Returns("IE9");

            var SavingDetailController = CreateSavingDetailController();

            // Act
            var result = await SavingDetailController.PutAsync(SavingDetailStub.savingDetailModel.Id, SavingDetailStub.savingDetailModel);

            // Assert
            var okResult = result as ObjectResult;
            Assert.IsNotNull(okResult);
            Assert.IsTrue(okResult is OkObjectResult);
            Assert.AreEqual(StatusCodes.Status200OK, okResult.StatusCode);
            _mockService.VerifyAll();
        }

        [TestMethod]
        [Owner("David Sneider Cardona Cardenas")]
        public async Task Put_ReturnsBadRequestResult_WhenIdIsDiferent()
        {
            // Arrange
            var id = 10;
            var SavingDetailController = CreateSavingDetailController();
            _mockBrowserDetector.Setup(x => x.Browser.Name).Returns("IE9");

            // Act
            var result = await SavingDetailController.PutAsync(id, SavingDetailStub.savingDetailModel);

            // Assert
            Assert.IsInstanceOfType(result, typeof(BadRequestResult));
            _mockService.VerifyAll();
        }

        [TestMethod]
        public async Task DeleteAsync_ReturnsOk_WhenModelStateIsValid()
        {
            // Arrange
            _mockService.Setup(sp => sp.DeleteAsync(1)).ReturnsAsync(true);
            _mockBrowserDetector.Setup(x => x.Browser.Name).Returns("IE9");

            var SavingDetailController = CreateSavingDetailController();

            // Act
            var result = await SavingDetailController.DeleteAsync(1);

            // Assert
            var okResult = result as ObjectResult;
            Assert.IsNotNull(okResult);
            Assert.IsTrue(okResult is OkObjectResult);
            Assert.AreEqual(StatusCodes.Status200OK, okResult.StatusCode);
            _mockService.VerifyAll();
        }

        [TestMethod]
        public async Task DeleteLogicAsync_ReturnsOk_WhenModelStateIsValid()
        {
            // Arrange
            _mockService.Setup(sp => sp.DeleteLogicAsync(It.IsAny<DeletedInfo<int>>())).ReturnsAsync(true);
            _mockBrowserDetector.Setup(x => x.Browser.Name).Returns("IE9");

            var SavingDetailController = CreateSavingDetailController();

            // Act
            var result = await SavingDetailController.DeleteLogicAsync(1);

            // Assert
            var okResult = result as ObjectResult;
            Assert.IsNotNull(okResult);
            Assert.IsTrue(okResult is OkObjectResult);
            Assert.AreEqual(StatusCodes.Status200OK, okResult.StatusCode);
            _mockService.VerifyAll();
        }
    }
}
