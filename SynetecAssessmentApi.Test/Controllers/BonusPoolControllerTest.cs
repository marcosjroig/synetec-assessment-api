using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SynetecAssessmentApi.Controllers;
using SynetecAssessmentApi.Dtos;
using SynetecAssessmentApi.Test.Helpers;
using Xunit;

namespace SynetecAssessmentApi.Test.Controllers
{
    public class BonusPoolControllerTest
    {
        private readonly BonusPoolController _controller;

        public BonusPoolControllerTest()
        {
            var constructorModel = ControllerHelper.GetConstructorParameters();
            _controller = new BonusPoolController(constructorModel.BonusPoolService, constructorModel.Mapper);
        }

        [Fact]
        public async Task Get_WhenCalled_Returns_EmployeeList()
        {
            // Arrange
            var expected = 12;

            // Act
            if (await _controller.GetAll() is OkObjectResult result)
            {
                var employees = result.Value as IEnumerable<EmployeeDto>;

                // Assert
                Assert.NotNull(employees);
                Assert.Equal(expected, employees.Count());
            }
        }

        [Fact]
        public async Task Post_WhenCalled_Returns_CalculationResults()
        {
            // Arrange
            var bonusDto = new CalculateBonusDto { SelectedEmployeeId = 1, TotalBonusPoolAmount = 120000 };


            // Act
            if (await _controller.CalculateBonus(bonusDto) is OkObjectResult result)
            {
                var calculatorResult = result.Value as BonusPoolCalculatorResultDto;

                // Assert
                Assert.NotNull(calculatorResult);
                Assert.Equal("John Smith", calculatorResult.Employee.Fullname);
                Assert.Equal("Accountant (Senior)", calculatorResult.Employee.JobTitle);
                Assert.Equal(60000, calculatorResult.Employee.Salary);
                Assert.Equal("Finance", calculatorResult.Employee.Department.Title);
                Assert.Equal(10996, calculatorResult.Amount);
            }
        }
    }
}
