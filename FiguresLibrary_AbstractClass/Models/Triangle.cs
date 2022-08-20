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
}