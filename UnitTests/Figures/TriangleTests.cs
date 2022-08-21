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
    
    [Theory]
    [InlineData(1,1,1,false)]
    [InlineData(3,4,5,true)]
    [InlineData(9,9,1,false)]
    [InlineData(0,0,0,false)]
    public void ShouldCalculateIsOrthogonal(double sideA,double sideB,double sideC,bool expected)
    {
        //Arrange

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
        var actual = circle.IsOrthogonal();

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
        var circle = new Triangle()
        {
            Arguments = new[]
            {
                sideA,
                sideB,
                sideC
            }
        };

        //Assert
        Assert.Throws<ArgumentOutOfRangeException>(()=>circle.MapArguments());
    }

}