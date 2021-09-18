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
    public class SavingsControllerTests
    {
        private MockRepository _mockRepository;

        private Mock<ILogger<SavingsController>> _mockLogger;
        private Mock<ISavingService> _mockService;
        private Mock<IBrowserDetector> _mockBrowserDetector;

        [TestInitialize]
        public void TestInitialize()
        {
            AutoMapper.Mapper.Reset();
            AutoMapperConfig.CreateMaps();
            _mockRepository = new MockRepository(MockBehavior.Strict);
            _mockLogger = new Mock<ILogger<SavingsController>>();
            _mockService = _mockRepository.Create<ISavingService>();
            _mockBrowserDetector = _mockRepository.Create<IBrowserDetector>();
        }

        private SavingsController CreateSavingController()
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
            return new SavingsController(_mockLogger.Object, _mockService.Object, _mockBrowserDetector.Object)
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
            _mockService.Setup(sp => sp.GetByIdAsync(id)).ReturnsAsync(SavingStub.savingDto1);
            var SavingController = CreateSavingController();

            // Act
            var result = await SavingController.GetByIdAsync(id);

            // Assert
            var okResult = result as ObjectResult;
            Assert.IsNotNull(okResult);
            Assert.IsTrue(okResult is OkObjectResult);
            Assert.AreEqual(StatusCodes.Status200OK, okResult.StatusCode);

            var model = okResult.Value as ResponseService<SavingDto>;
            Assert.IsNotNull(model);
            Assert.IsNotNull(okResult);
            Assert.AreEqual(SavingStub.savingDto1, model.Data);
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
                .ReturnsAsync(SavingStub.lstSavingDto);
            var SavingController = this.CreateSavingController();
            int? page = 1;
            int? limit = 10;

            // Act
            var result = await SavingController.GetAllAsync(page, limit);

            // Assert
            var okResult = result as ObjectResult;
            Assert.IsNotNull(okResult);
            Assert.IsTrue(okResult is OkObjectResult);
            Assert.AreEqual(StatusCodes.Status200OK, okResult.StatusCode);

            var model = okResult.Value as ResponseService<IEnumerable<SavingDto>>;
            Assert.IsNotNull(model);
            Assert.IsNotNull(okResult);
            CollectionAssert.AreEqual(SavingStub.lstSavingDto, model.Data.ToList());
            _mockService.VerifyAll();
        }

        [TestMethod]
        [Owner("David Sneider Cardona Cardenas")]
        public void Post_ReturnsOk_WhenModelStateIsValid()
        {
            // Arrange
            _mockService.Setup(x => x.Post(It.IsAny<SavingDto>())).Returns((true, 1));
            _mockBrowserDetector.Setup(x => x.Browser.Name).Returns("IE9");
            var SavingController = this.CreateSavingController();


            // Act
            var result = SavingController.Post(SavingStub.savingModel);

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
            _mockService.Setup(x => x.PutAsync(It.IsAny<int>(), It.IsAny<SavingDto>())).ReturnsAsync(true);
            _mockBrowserDetector.Setup(x => x.Browser.Name).Returns("IE9");

            var SavingController = CreateSavingController();

            // Act
            var result = await SavingController.PutAsync(SavingStub.savingModel.Id, SavingStub.savingModel);

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
            var SavingController = CreateSavingController();
            _mockBrowserDetector.Setup(x => x.Browser.Name).Returns("IE9");

            // Act
            var result = await SavingController.PutAsync(id, SavingStub.savingModel);

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

            var SavingController = CreateSavingController();

            // Act
            var result = await SavingController.DeleteAsync(1);

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

            var SavingController = CreateSavingController();

            // Act
            var result = await SavingController.DeleteLogicAsync(1);

            // Assert
            var okResult = result as ObjectResult;
            Assert.IsNotNull(okResult);
            Assert.IsTrue(okResult is OkObjectResult);
            Assert.AreEqual(StatusCodes.Status200OK, okResult.StatusCode);
            _mockService.VerifyAll();
        }
    }
}
