namespace FiguresLibrary.Models.Base;

/// <summary>
/// Базовый интерфейс фигуры
/// </summary>
public abstract class Shape
{
    /// <summary>
    /// Уникальный иднтификатор фигуры
    /// </summary>
    public abstract string Id { get; }

    /// <summary>
    /// Аргументы для вычисления фигуры
    /// </summary>
    public double[] Arguments { get; set; }

    /// <summary>
    /// Описание аргументов для вычисления площади фигуры
    /// </summary>
    public string[] SquareArgumentsDefinition { get; protected init; }


    /// <summary>
    /// Конструктор
    /// </summary>
    private protected Shape()
    {
        
    }

    /// <summary>
    /// Вычисление площади фигуры
    /// </summary>
    /// <returns>площадь фигуры</returns>
    /// <exception cref="ArithmeticException">не удалось получить вычислить площадь</exception>
    public abstract double CalculateSquare();

    /// <summary>
    /// Проверка результата вычисления
    /// <remarks> простой аналог защитного программирования через контракты Code Contracts</remarks>
    /// </summary>
    /// <param name="calculationResult">результат площади фигуры</param>
    /// <exception cref="ArithmeticException">Не удалось корректно вычислить площадь</exception>
    protected void CheckSquareResult(double calculationResult)
    {
        if (double.IsInfinity(calculationResult) || double.IsNaN(calculationResult) || double.IsNegative(calculationResult))
            throw new ArithmeticException("Не удалось корректно вычислить площадь!");
    }

    /// <summary>
    /// проверяет аргументы и сопоставляет их с ожидаеыми аргументами, описанными в SquareArgumentsDefinition
    /// </summary>
    protected virtual void MapArguments()
    {
        if (Arguments is null) throw new NullReferenceException(nameof(Arguments));
        
        if (SquareArgumentsDefinition.Length!= Arguments.Length)
        {
            throw new ArgumentOutOfRangeException(nameof(SquareArgumentsDefinition),
                $"Expected {SquareArgumentsDefinition.Length} parameters instead of {Arguments.Length} " +
                $"in function {nameof(CalculateSquare)}");
        }
    }
}