using FiguresLibrary.Models.Figures.Base;

namespace FiguresLibrary.Models.Figures;

public sealed class Triangle : Shape
{
    public const string ID = "Triangle";

    private  double _a;
    private  double _b;
    private  double _c;

    public override string Id => ID;

    /// <summary>
    /// Конструктор
    /// </summary>
    public Triangle()
    {
        SquareArgumentsDefinition = new string[]
        {
            "SideA",
            "SideB",
            "SideC",
        };
    }

    public override double CalculateSquare()
    {
        var p = _a/2 + _b/2 + _c / 2;
        var square = Math.Sqrt(p * (p - _a) * (p - _b) * (p - _c));

        CheckSquareResult(square);
        
        return square;
    }

    public override void MapArguments()
    {
        base.MapArguments();

        _a = Arguments[0];
        _b = Arguments[1];
        _c = Arguments[2];
        if (!(_a>0 && _b>0 && _c>0)) throw new Exception("Стороны треугольника должны быть больше нуля!");
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
        
        var cathetusPowerSum = Math.Pow(sides[0],2) + Math.Pow(sides[1],2);
        var isOrthogonal = Math.Abs(Math.Pow(hypotenuse, 2) - cathetusPowerSum) < double.Epsilon;
        return isOrthogonal;
    }
}