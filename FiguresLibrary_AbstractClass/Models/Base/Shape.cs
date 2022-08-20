namespace FiguresLibrary.Models.Base;

public abstract class Shape
{
    /// <summary>
    /// Вычисление площади фигуры
    /// </summary>
    /// <returns>площадь фигуры</returns>
    public abstract double CalculateSquare();

    /// <summary>
    /// Конструктор
    /// </summary>
    internal Shape()
    {
        
    }
}