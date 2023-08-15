using HrManager.Core.Entities;
using Xunit;

namespace HrManager.UnitTests.Core.Entities;

public class UserTest
{
    [Fact]
    //[Fact(Skip = "Not Implemented")]
    public void Check_UserIsOfLegalAge_ReturnTrue()
    {
        // Arrange
        var user = new User("Mateus", 45);
        var expected = true;

        // Act
        var result = user.IsOfLegalAge();

        // Assert
        Assert.Equal(expected, result);
        Assert.True(result);
    }

    [Fact]
    public void Check_UserIsNotOfLegalAge_ReturnFalse()
    {
        // Arrange
        var user = new User("Mateus", 17);
        var expected = false;

        // Act
        var result = user.IsOfLegalAge();

        // Assert
        Assert.Equal(expected, result);
        Assert.False(result);
    }
}