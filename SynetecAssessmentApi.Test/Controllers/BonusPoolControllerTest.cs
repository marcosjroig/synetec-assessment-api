using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using SynetecAssessmentApi.Controllers;
using Xunit;

namespace SynetecAssessmentApi.Test.Controllers
{
    public class BonusPoolControllerTest
    {
        private readonly BonusPoolController _controller;

        public BonusPoolControllerTest()
        {
            _controller = new BonusPoolController();
        }

        [Fact]
        public void Get_WhenCalled_ReturnsValues()
        {
            // Arrange
            IEnumerable<string> expectedValues = new string[] { "value1", "value2" };

            // Act
            var okResult = _controller.GetAll() as OkObjectResult;
            var values = okResult.Value as IEnumerable<string>;

            // Assert
            Assert.Equal(expectedValues, values);
        }
    }
}
