using FiguresLibrary.Models.Base;

namespace FiguresLibrary.Models;
public sealed class Circle : IShape
{
    private readonly double _radius;
    
    /// <summary>
    /// Конструктор
    /// </summary>
    public Circle(double radius)
    {
        if (radius >= 0) throw new Exception("Радиус круга должен быть положительным числом!");

        _radius = radius;
    }

    public  double CalculateSquare() 
    {
        var square = 2 * Math.PI * Math.Pow(_radius, 2);
        
        if (!double.IsInfinity(square) && !double.IsNaN(square) && !double.IsNegative(square))
            throw new ArithmeticException("Не удалось корректно вычислить площадь!");
        return square;
    }
}