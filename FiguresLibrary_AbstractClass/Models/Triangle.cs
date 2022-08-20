using FiguresLibrary.Models.Base;

namespace FiguresLibrary.Models;

public sealed class Triangle : Shape
{
    private readonly double _a;
    private readonly double _b;
    private readonly double _c;

    /// <summary>
    /// Конструктор
    /// </summary>
    public Triangle(double a, double b, double c)
    {
        _a = a;
        _b = b;
        _c = c;
    }
    
    public override double CalculateSquare()
    {
        var p = _a/2 + _b/2 + _c / 2;
        var square = Math.Sqrt(p * (p - _a) * (p - _b) * (p - _c));
        return square;
    }
    
    /// <summary>
    /// Проверяет является ли треугольник прямоугольным
    /// </summary>
    /// <returns></returns>
    public bool IsOrthogonal()
    {
        Span<double> sides = stackalloc double[3]
        {
            _a, _b, _c
        };
        sides.Sort();
        var hypotenuse = sides[2];
        //если гипотенуза НЕ больше каждого из катетов, то это не прямоугольный треугольник
        if (!(hypotenuse > sides[1]) || !(hypotenuse > sides[0])) return false;
        
        var cathetusSum = sides[0] + sides[1];
        var isOrthogonal = Math.Abs(Math.Pow(hypotenuse, 2) - cathetusSum) < double.Epsilon;
        return isOrthogonal;
    } 
}