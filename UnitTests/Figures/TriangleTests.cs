using FiguresLibrary.Models.Figures;
using Xunit;

namespace UnitTests.Figures;

public sealed class TriangleTests
{
    [Fact]
    public void TestCalculateSquare()
    {
        //Arrange
        const double sideA = 3;
        const double sideB = 4;
        const double sideC = 5;
        const double expected = 6;

        //Act
        var circle = new Triangle()
        {
            Arguments = new[]
            {
                sideA,
                sideB,
                sideC
            }
        };
        circle.MapArguments();
        var actual = circle.CalculateSquare();

        //Assert
        Assert.Equal(expected,actual,Math.Pow(10,-6));
    }
}