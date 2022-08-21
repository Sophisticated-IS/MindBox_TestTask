using FiguresLibrary.Models.Figures;
using FiguresLibrary.Models.Figures.Base;

namespace FiguresLibrary.Models;

public sealed class FigureFactory
{
    public Shape CreateFigure(string id)
    {
        return id switch
        {
            "Circle" => new Circle(),
            "Triangle" => new Triangle(),
            _ => throw new ArgumentException("Figure was not found!", nameof(id))
        };
    } 
}