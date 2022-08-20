namespace FiguresLibrary.Models.Base;

/// <summary>
/// Базовый интерфейс фигуры
/// </summary>
public interface IShape
{
    /// <summary>
    /// Вычисление площади фигуры
    /// </summary>
    /// <returns>площадь фигуры</returns>
    /// <exception cref="ArithmeticException">не удалось получить вычислить площадь</exception>
    double CalculateSquare();
}