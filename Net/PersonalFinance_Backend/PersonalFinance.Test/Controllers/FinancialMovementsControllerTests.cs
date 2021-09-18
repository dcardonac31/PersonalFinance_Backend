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
    public class FinancialMovementsControllerTests
    {
        private MockRepository _mockRepository;

        private Mock<ILogger<FinancialMovementsController>> _mockLogger;
        private Mock<IFinancialMovementService> _mockService;
        private Mock<IBrowserDetector> _mockBrowserDetector;

        [TestInitialize]
        public void TestInitialize()
        {
            AutoMapper.Mapper.Reset();
            AutoMapperConfig.CreateMaps();
            _mockRepository = new MockRepository(MockBehavior.Strict);
            _mockLogger = new Mock<ILogger<FinancialMovementsController>>();
            _mockService = _mockRepository.Create<IFinancialMovementService>();
            _mockBrowserDetector = _mockRepository.Create<IBrowserDetector>();
        }

        private FinancialMovementsController CreateFinancialMovementsController()
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
            return new FinancialMovementsController(_mockLogger.Object, _mockService.Object, _mockBrowserDetector.Object)
            {
                ControllerContext = controllerContext
            };
        }

        [TestMethod]
        [Owner("David Sneider Cardona Cardenas")]
        public async Task GetByIdAsync_ReturnsOk_WhenModelStateIsValid()
        {
            // Arrange
            _mockService.Setup(sp => sp.GetByIdAsync(1)).ReturnsAsync(FinancialMovementStub.financialMovementDto1);
            var FinancialMovementsController = CreateFinancialMovementsController();

            // Act
            var result = await FinancialMovementsController.GetByIdAsync(1);

            // Assert
            var okResult = result as ObjectResult;
            Assert.IsNotNull(okResult);
            Assert.IsTrue(okResult is OkObjectResult);
            Assert.AreEqual(StatusCodes.Status200OK, okResult.StatusCode);

            var model = okResult.Value as ResponseService<FinancialMovementDto>;
            Assert.IsNotNull(model);
            Assert.IsNotNull(okResult);
            Assert.AreEqual(FinancialMovementStub.financialMovementDto1, model.Data);
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
                .ReturnsAsync(FinancialMovementStub.lstFinancialMovementDto);
            var FinancialMovementsController = CreateFinancialMovementsController();
            int? page = 1;
            int? limit = 10;

            // Act
            var result = await FinancialMovementsController.GetAllAsync(page, limit);

            // Assert
            var okResult = result as ObjectResult;
            Assert.IsNotNull(okResult);
            Assert.IsTrue(okResult is OkObjectResult);
            Assert.AreEqual(StatusCodes.Status200OK, okResult.StatusCode);

            var model = okResult.Value as ResponseService<IEnumerable<FinancialMovementDto>>;
            Assert.IsNotNull(model);
            Assert.IsNotNull(okResult);
            CollectionAssert.AreEqual(FinancialMovementStub.lstFinancialMovementDto, model.Data.ToList());
            _mockService.VerifyAll();
        }

        [TestMethod]
        [Owner("David Sneider Cardona Cardenas")]
        public void Post_ReturnsOk_WhenModelStateIsValid()
        {
            // Arrange
            _mockService.Setup(x => x.Post(It.IsAny<FinancialMovementDto>())).Returns((true, 1));
            _mockBrowserDetector.Setup(x => x.Browser.Name).Returns("IE9");

            var FinancialMovementsController = CreateFinancialMovementsController();

            // Act
            var result = FinancialMovementsController.Post(FinancialMovementStub.financialMovementModel);

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
            _mockService.Setup(x => x.PutAsync(It.IsAny<int>(), It.IsAny<FinancialMovementDto>())).ReturnsAsync(true);
            _mockBrowserDetector.Setup(x => x.Browser.Name).Returns("IE9");

            var FinancialMovementsController = CreateFinancialMovementsController();

            // Act
            var result = await FinancialMovementsController.PutAsync(FinancialMovementStub.financialMovementModel.Id, FinancialMovementStub.financialMovementModel);

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
            var id = 20;
            var FinancialMovementsController = CreateFinancialMovementsController();

            _mockBrowserDetector.Setup(x => x.Browser.Name).Returns("IE9");

            // Act
            var result = await FinancialMovementsController.PutAsync(id, FinancialMovementStub.financialMovementModel);

            // Assert
            Assert.IsInstanceOfType(result, typeof(BadRequestResult));
            _mockService.VerifyAll();
        }


        [TestMethod]
        [Owner("David Sneider Cardona Cardenas")]
        public async Task DeleteAsync_ReturnsOk_WhenModelStateIsValid()
        {
            // Arrange
            _mockService.Setup(sp => sp.DeleteAsync(1)).ReturnsAsync(true);
            _mockBrowserDetector.Setup(x => x.Browser.Name).Returns("IE9");

            var FinancialMovementsController = CreateFinancialMovementsController();

            // Act
            var result = await FinancialMovementsController.DeleteAsync(1);

            // Assert
            var okResult = result as ObjectResult;
            Assert.IsNotNull(okResult);
            Assert.IsTrue(okResult is OkObjectResult);
            Assert.AreEqual(StatusCodes.Status200OK, okResult.StatusCode);
            _mockService.VerifyAll();
        }

        [TestMethod]
        [Owner("David Sneider Cardona Cardenas")]
        public async Task DeleteLogicAsync_ReturnsOk_WhenModelStateIsValid()
        {
            // Arrange
            _mockService.Setup(sp => sp.DeleteLogicAsync(It.IsAny<DeletedInfo<int>>())).ReturnsAsync(true);
            _mockBrowserDetector.Setup(x => x.Browser.Name).Returns("IE9");

            var FinancialMovementsController = CreateFinancialMovementsController();

            // Act
            var result = await FinancialMovementsController.DeleteLogicAsync(1);

            // Assert
            var okResult = result as ObjectResult;
            Assert.IsNotNull(okResult);
            Assert.IsTrue(okResult is OkObjectResult);
            Assert.AreEqual(StatusCodes.Status200OK, okResult.StatusCode);
            _mockService.VerifyAll();
        }
    }
}
