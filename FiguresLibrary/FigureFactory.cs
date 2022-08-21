using FiguresLibrary.Models;
using FiguresLibrary.Models.Base;

namespace FiguresLibrary;

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