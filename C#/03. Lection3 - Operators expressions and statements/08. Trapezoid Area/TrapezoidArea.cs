using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class TrapezoidArea
{
    static void Main()
    {
        Console.WriteLine("enter side a: ");
        double a = double.Parse(Console.ReadLine());
        Console.WriteLine("enter side b: ");
        double b = double.Parse(Console.ReadLine());
        Console.WriteLine("enter h: ");
        double h = double.Parse(Console.ReadLine());
        double area = (a + b) / 2 * h;
        Console.WriteLine("the area of this trapezoid is: " + area);
    }
}
