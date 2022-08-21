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
        Assert.Equal(expected,actual,Math.Pow(10,-6));
    }
    
    [Fact]
    public void Add_NegativeArguments_ThrowsException()
    {
        //Arrange
        const double radius = -1;
        //Act
        var circle = new Circle()
        {
            Arguments = new[]
            {
              radius
            }
        };

        //Assert
        Assert.Throws<ArgumentOutOfRangeException>(()=>circle.MapArguments());
    }
    
    [Theory]
    [InlineData(double.NaN)]
    [InlineData(double.PositiveInfinity)]
    [InlineData(double.MaxValue)]
    public void NotNumbersArguments_ThrowsException(double radius)
    {
        //Arrange
        
        
        //Act
        var circle = new Circle()
        {
            Arguments = new[]
            {
                radius
            }
        };
        circle.MapArguments();
            
        //Assert
        Assert.Throws<ArithmeticException>(()=>circle.CalculateSquare());
    }
    
    [Theory]
    [InlineData(new double[] { 1d, 2d })]
    [InlineData(new double[] { })]
    public void InvalidArgumentsAmount_ThrowsException(double[] arguments)
    {
        //Arrange
        
        
        //Act
        var circle = new Circle()
        {
            Arguments = arguments
        };

        //Assert
        Assert.Throws<ArgumentOutOfRangeException>(()=>circle.MapArguments());
    }
}