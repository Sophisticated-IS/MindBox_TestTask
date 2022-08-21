using FiguresLibrary.Models.Figures.Base;

namespace FiguresLibrary.Models.Figures;
public sealed class Circle : Shape
{
    public const string ID = "Circle";

    private double _radius;

    public override string Id => ID;

    /// <summary>
    /// Конструктор
    /// </summary>
    public Circle()
    {
        SquareArgumentsDefinition = new string[]
        {
            "Radius"
        };
    }

    public override double CalculateSquare() 
    {
        var square = Math.PI * Math.Pow(_radius, 2);
        
        CheckSquareResult(square);

        return square;
    }

    public override void MapArguments()
    {
        base.MapArguments();
        
        _radius = Arguments[0];
        if (_radius < 0) throw new Exception("Радиус круга должен быть положительным числом!");
    }
}