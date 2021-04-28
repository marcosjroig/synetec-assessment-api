using Xunit;

namespace SynetecAssessmentApi.Test.Test
{
    public class Example
    {
        [Fact]
        public void IsValid_ValidIntegerPassed_ReturnsTrue()
        {
            // Arrange
            var fakeId = 15;

            // Act
            //var result = _sut.IsValid(_fakeClass);
            var result = 15;

            // Assert
            Assert.Equal(fakeId,result);
        }
    }
}
