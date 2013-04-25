using System;
using System.Linq;

class Test
{
    static void Main()
    {
        Figure figure = new Figure(3, 2);
        Console.WriteLine(figure.Width);
        figure = Figure.GetRotatedFigure(figure, 5);
        Console.WriteLine(figure.Width);
        Console.WriteLine(figure.Height);
    }
}
