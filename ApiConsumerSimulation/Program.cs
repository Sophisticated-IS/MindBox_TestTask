using FiguresLibrary.Models;
using FiguresLibrary.Models.Base;


START_MENU:
PrintMenu();
var userInput = Console.ReadKey();
try
{
    double[]? parameters;
    Shape shape;
    switch (userInput.Key)
    {
        case ConsoleKey.D1:
            if (!TryGetParams(1, out parameters))
                goto START_MENU;
            shape = new Circle(parameters[0]);
            Console.WriteLine("Площадь:" + shape.CalculateSquare());
            goto START_MENU;


        case ConsoleKey.D2:
            if (!TryGetParams(3, out parameters))
                goto START_MENU;
            var triangle = new Triangle(parameters[0], parameters[1], parameters[2]);
            shape = triangle;
            Console.WriteLine("Площадь:" + shape.CalculateSquare());
            Console.WriteLine("Теругольник прямоугольный?" + triangle.IsOrthogonal());
            goto START_MENU;
            
        case ConsoleKey.D3:
            break;
        
        default: goto START_MENU;
    }
}
catch (Exception exception)
{
    Console.WriteLine("Возникла ошибка при  вычислениях:");
    Console.WriteLine(exception);
    goto START_MENU;
}


void PrintMenu()
{
    Console.WriteLine();
    Console.WriteLine(
        "Меню калькулятора площади фигур:\n" +
        "1 - Круг\n" +
        "2 - Треугольник\n" +
        "3 - выход");
}

bool TryGetParams(int count, out double[]? parameters)
{
    parameters = null;
    try
    {
        Console.WriteLine();
        Console.WriteLine($"Введите {count} параметра через запятую:");
        var strParams = Console.ReadLine();
        parameters = strParams?.Split(',').Select(double.Parse).ToArray();
        return parameters != null && parameters.Length == count;
    }
    catch (Exception exception)
    {
        Console.WriteLine("Возникла ошибка при вводе параметров:");
        Console.WriteLine(exception);
        return false;
    }
}