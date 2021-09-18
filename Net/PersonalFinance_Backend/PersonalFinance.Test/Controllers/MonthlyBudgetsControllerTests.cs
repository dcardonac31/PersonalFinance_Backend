﻿using Microsoft.AspNetCore.Http;
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
    public class MonthlyBudgetsControllerTests
    {
        private MockRepository _mockRepository;

        private Mock<ILogger<MonthlyBudgetsController>> _mockLogger;
        private Mock<IMonthlyBudgetService> _mockService;
        private Mock<IBrowserDetector> _mockBrowserDetector;

        [TestInitialize]
        public void TestInitialize()
        {
            AutoMapper.Mapper.Reset();
            AutoMapperConfig.CreateMaps();
            _mockRepository = new MockRepository(MockBehavior.Strict);
            _mockLogger = new Mock<ILogger<MonthlyBudgetsController>>();
            _mockService = _mockRepository.Create<IMonthlyBudgetService>();
            _mockBrowserDetector = _mockRepository.Create<IBrowserDetector>();
        }

        private MonthlyBudgetsController CreateMonthlyBudgetsController()
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
            return new MonthlyBudgetsController(_mockLogger.Object, _mockService.Object, _mockBrowserDetector.Object)
            {
                ControllerContext = controllerContext
            };
        }

        [TestMethod]
        [Owner("David Sneider Cardona Cardenas")]
        public async Task GetByIdAsync_ReturnsOk_WhenModelStateIsValid()
        {
            // Arrange
            _mockService.Setup(sp => sp.GetByIdAsync(1)).ReturnsAsync(MonthlyBudgetStub.monthlyBudgetDto1);
            var monthlyBudgetsController = CreateMonthlyBudgetsController();

            // Act
            var result = await monthlyBudgetsController.GetByIdAsync(1);

            // Assert
            var okResult = result as ObjectResult;
            Assert.IsNotNull(okResult);
            Assert.IsTrue(okResult is OkObjectResult);
            Assert.AreEqual(StatusCodes.Status200OK, okResult.StatusCode);

            var model = okResult.Value as ResponseService<MonthlyBudgetDto>;
            Assert.IsNotNull(model);
            Assert.IsNotNull(okResult);
            Assert.AreEqual(MonthlyBudgetStub.monthlyBudgetDto1, model.Data);
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
                .ReturnsAsync(MonthlyBudgetStub.lstMonthlyBudgetDto);
            var monthlyBudgetsController = CreateMonthlyBudgetsController();
            int? page = 1;
            int? limit = 10;

            // Act
            var result = await monthlyBudgetsController.GetAllAsync(page, limit);

            // Assert
            var okResult = result as ObjectResult;
            Assert.IsNotNull(okResult);
            Assert.IsTrue(okResult is OkObjectResult);
            Assert.AreEqual(StatusCodes.Status200OK, okResult.StatusCode);

            var model = okResult.Value as ResponseService<IEnumerable<MonthlyBudgetDto>>;
            Assert.IsNotNull(model);
            Assert.IsNotNull(okResult);
            CollectionAssert.AreEqual(MonthlyBudgetStub.lstMonthlyBudgetDto, model.Data.ToList());
            _mockService.VerifyAll();
        }

        [TestMethod]
        [Owner("David Sneider Cardona Cardenas")]
        public void Post_ReturnsOk_WhenModelStateIsValid()
        {
            // Arrange
            _mockService.Setup(x => x.Post(It.IsAny<MonthlyBudgetDto>())).Returns((true, 1));
            _mockBrowserDetector.Setup(x => x.Browser.Name).Returns("IE9");

            var monthlyBudgetsController = CreateMonthlyBudgetsController();

            // Act
            var result = monthlyBudgetsController.Post(MonthlyBudgetStub.monthlyBudgetModel);

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
            _mockService.Setup(x => x.PutAsync(It.IsAny<int>(), It.IsAny<MonthlyBudgetDto>())).ReturnsAsync(true);
            _mockBrowserDetector.Setup(x => x.Browser.Name).Returns("IE9");

            var monthlyBudgetsController = CreateMonthlyBudgetsController();

            // Act
            var result = await monthlyBudgetsController.PutAsync(MonthlyBudgetStub.monthlyBudgetModel.Id, MonthlyBudgetStub.monthlyBudgetModel);

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
            var monthlyBudgetsController = CreateMonthlyBudgetsController();

            _mockBrowserDetector.Setup(x => x.Browser.Name).Returns("IE9");

            // Act
            var result = await monthlyBudgetsController.PutAsync(id, MonthlyBudgetStub.monthlyBudgetModel);

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

            var monthlyBudgetsController = CreateMonthlyBudgetsController();

            // Act
            var result = await monthlyBudgetsController.DeleteAsync(1);

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

            var monthlyBudgetsController = CreateMonthlyBudgetsController();

            // Act
            var result = await monthlyBudgetsController.DeleteLogicAsync(1);

            // Assert
            var okResult = result as ObjectResult;
            Assert.IsNotNull(okResult);
            Assert.IsTrue(okResult is OkObjectResult);
            Assert.AreEqual(StatusCodes.Status200OK, okResult.StatusCode);
            _mockService.VerifyAll();
        }
    }
}
