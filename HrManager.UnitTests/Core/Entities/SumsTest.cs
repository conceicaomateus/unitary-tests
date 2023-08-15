using Xunit;

namespace HrManager.UnitTests.Core.Entities;

public class SumsTest
{
    [Fact]
    public void Sum_FivePlusTwoIsEqualsSeven_ReturnTrue()
    {
        // Arrange
        var first = 5;
        var second = 2;
        var expected = 7;

        // Act 
        var result = first + second;

        //Assert
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(1, 1, 2)]
    [InlineData(14, 78, 92)]
    [InlineData(30, 45, 75)]
    [InlineData(7, 12, 19)]
    public void Sum_FirstPlusSecondIsEqualsThird_ReturnTrue(int first, int second, int expected)
    {
        // Act 
        var result = first + second;

        //Assert
        Assert.Equal(expected, result);
    }
}
