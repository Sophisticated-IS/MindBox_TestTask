using FiguresLibrary.Models.Figures;
using Xunit;

namespace UnitTests.Figures;

public sealed class CircleTests
{
    [Fact]
    public void TestSquareCalculation()
    {
        //Arrange
        const double radius = 10d;
        const double expected = 314.159265;

        //Act
        var circle = new Circle
        {
            Arguments = new[]
            {
                radius
            }
        };
        circle.MapArguments();
        var actual = circle.CalculateSquare();

        //Assert
        Assert.Equal(expected,actual);
    }
}