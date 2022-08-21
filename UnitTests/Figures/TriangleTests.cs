using FiguresLibrary.Models.Figures;
using Xunit;

namespace UnitTests.Figures;

public sealed class TriangleTests
{
    [Theory]
    [InlineData(3,4,5,6)]
    [InlineData(0,0,0,0)]
    public void ShouldCalculateSquare(double sideA,double sideB,double sideC,double expected)
    {
        //Arrange

        //Act
        var triangle = new Triangle()
        {
            Arguments = new[]
            {
                sideA,
                sideB,
                sideC
            }
        };
        triangle.MapArguments();
        var actual = triangle.CalculateSquare();

        //Assert
        Assert.Equal(expected,actual,Math.Pow(10,-6));
    }
    
    [Theory]
    [InlineData(1,1,1,false)]
    [InlineData(3,4,5,true)]
    [InlineData(9,9,1,false)]
    [InlineData(0,0,0,false)]
    [InlineData(double.MaxValue,0,0,false)]
    [InlineData(double.PositiveInfinity,0,0,false)]
    [InlineData(double.NaN,0,0,false)]
    [InlineData(double.NaN,double.MaxValue,double.PositiveInfinity,false)]
    public void ShouldCalculateIsOrthogonal(double sideA,double sideB,double sideC,bool expected)
    {
        //Arrange

        //Act
        var triangle = new Triangle()
        {
            Arguments = new[]
            {
                sideA,
                sideB,
                sideC
            }
        };
        triangle.MapArguments();
        var actual = triangle.IsOrthogonal();

        //Assert
        Assert.Equal(expected,actual);
    }
    
    [Theory]
    [InlineData(-1,1,1)]
    [InlineData(1,-1,1)]
    [InlineData(1,1,-1)]
    public void Add_NegativeArguments_ThrowsException(double sideA,double sideB,double sideC)
    {
        //Arrange

        //Act
        var triangle = new Triangle()
        {
            Arguments = new[]
            {
                sideA,
                sideB,
                sideC
            }
        };

        //Assert
        Assert.Throws<ArgumentOutOfRangeException>(()=>triangle.MapArguments());
    }
    
    [Theory]
    [InlineData(double.NaN,1,1)]
    [InlineData(1,double.NaN,1)]
    [InlineData(1,1,double.NaN)]
    [InlineData(double.PositiveInfinity,1,3)]
    [InlineData(double.MaxValue,1,3)]
    [InlineData(double.MaxValue,double.MaxValue,double.MaxValue)]
    public void NotNumbersArguments_ThrowsException(double sideA,double sideB,double sideC)
    {
        //Arrange

        //Act
        var triangle = new Triangle()
        {
            Arguments = new[]
            {
                sideA,
                sideB,
                sideC
            }
        };
        triangle.MapArguments();

        //Assert
        Assert.Throws<ArithmeticException>(()=>triangle.CalculateSquare());
    }
    
    [Theory]
    [InlineData(new double[] { 1d, 2d, 3d,4d })]
    [InlineData(new double[] { 1d})]
    public void InvalidArgumentsAmount_ThrowsException(double[] arguments)
    {
        //Arrange

        //Act
        var triangle = new Triangle()
        {
            Arguments = arguments.ToArray()
        };
        

        //Assert
        Assert.Throws<ArgumentOutOfRangeException>(()=>triangle.MapArguments());
    }
    
  

}