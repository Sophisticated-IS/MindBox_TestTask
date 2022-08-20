using FiguresLibrary.Base;

namespace FiguresLibrary;

public sealed class Circle : Shape
{
    private readonly double _radius;
    
    /// <summary>
    /// Конструктор
    /// </summary>
    public Circle(double radius)
    {
        _radius = radius;
    }

    public override double CalculateSquare() 
    {
        var square = 2 * Math.PI * Math.Pow(_radius, 2);
        return square;
    }
}