﻿using FiguresLibrary;
using FiguresLibrary.Models;
using FiguresLibrary.Models.Base;

START_MENU:
PrintMenu();
var inputFigure = Console.ReadLine();
if (string.IsNullOrEmpty(inputFigure)) goto START_MENU;

try
{
    var factory = new FigureFactory();
    Shape createdFigure  = factory.CreateFigure(inputFigure);
    Console.WriteLine("Введите следующие аргументы:");
    createdFigure.Arguments = InputArguments(createdFigure.SquareArgumentsDefinition);
    // createdFigure.try
    Console.WriteLine("Площадь =" + createdFigure.CalculateSquare());
}
catch (Exception exception)
{
    Console.WriteLine("Возникла ошибка при вычислениях:");
    Console.WriteLine(exception);
    goto START_MENU;
}

void PrintMenu()
{
    Console.WriteLine();
    Console.WriteLine(
        "Меню калькулятора площади фигур:\n" +
        $"{Circle.ID} - Круг\n" +
        $"{Triangle.ID} - Треугольник");
}

double[] InputArguments(string[] arguments)
{
    double[] resultArgs = new double[arguments.Length];
    for (int i = 0; i < arguments.Length; i++)
    {
        ARGUMENT_INPUT:
        Console.Write($"Введите аргумент <{arguments[i]}>");
        var strArgument = Console.ReadLine();
        if (double.TryParse(strArgument, out var parsedArg))
        {
            resultArgs[i] = parsedArg;
        }
        else
        {
            Console.WriteLine("Возникла ошибка при вводе аргумента!\n" +
                              "Введите аргумент занова!");
            goto ARGUMENT_INPUT;
        }
        Console.WriteLine();
    }

    return resultArgs;
}