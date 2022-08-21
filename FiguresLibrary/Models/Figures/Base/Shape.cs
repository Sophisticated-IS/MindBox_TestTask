namespace FiguresLibrary.Models.Figures.Base;

/// <summary>
/// Базовый интерфейс фигуры
/// </summary>
public abstract class Shape
{
    private bool _wasMapArgumentsCalled;
    
    /// <summary>
    /// Уникальный идентификатор фигуры
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
    /// <exception cref="ArithmeticException">не удалось корректно вычислить площадь фигуры</exception>
    /// <exception cref="InvalidOperationException"> Не был вызван метод MapArguments ля сопоставления аргументов</exception>
    public virtual double CalculateSquare()
    {
        if (!_wasMapArgumentsCalled)
            throw new InvalidOperationException(
                $"Arguments weren't mapped! Call method {nameof(MapArguments)} before calculations!");

        return 0;
    }

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
    /// Проверяет аргументы и сопоставляет их с ожидаемыми аргументами, описанными в SquareArgumentsDefinition
    /// </summary>
    /// <exception cref="NullReferenceException">Была передана ссылка null</exception>
    /// <exception cref="ArgumentOutOfRangeException">Количество переданных аргументов, не совпало с необходимым или один из аргументов был меньше нуля</exception>
    public virtual void MapArguments()
    {
        if (Arguments is null) throw new NullReferenceException(nameof(Arguments));
        
        if (SquareArgumentsDefinition.Length!= Arguments.Length)
        {
            throw new ArgumentOutOfRangeException(nameof(SquareArgumentsDefinition),
                $"Expected {SquareArgumentsDefinition.Length} parameters instead of {Arguments.Length} " +
                $"in function {nameof(CalculateSquare)}");
        }

        for (var i = 0; i < Arguments.Length; i++)
        {
            var argument = Arguments[i];
            if (argument < 0)
            {
                throw new ArgumentOutOfRangeException(
                    $"Expected argument <{SquareArgumentsDefinition[i]}> was less than zero!");
            }
        }

        _wasMapArgumentsCalled = true;
    }
}