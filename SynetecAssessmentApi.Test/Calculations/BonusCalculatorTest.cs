using SynetecAssessmentApi.Calculations;
using Xunit;

namespace SynetecAssessmentApi.Test.Calculations
{
    public class BonusCalculatorTest
    {
        [Fact]
        public void GetBonusAmount_WhenCalled_Returns_TheBonusAmount()
        {
            // Arrange
            var bonusCalculator = new BonusCalculator();
            var expected = 1000;

            // Act
            var result = bonusCalculator.GetBonusAmount(2000, 40000, 20000);

           // Assert
           Assert.Equal(expected, result);
        }
    }
}
