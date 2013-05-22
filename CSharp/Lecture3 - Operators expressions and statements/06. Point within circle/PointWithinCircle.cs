using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class PointWithinCircle
{
    static void Main()
    {
        Console.WriteLine("enter x");
        double x = double.Parse(Console.ReadLine());
        Console.WriteLine("enter y");
        double y = double.Parse(Console.ReadLine());
        if ((Math.Pow(x, 2) + Math.Pow(y, 2)) <= 25)
        {
            Console.WriteLine("the point ({0},{1}) is within the circle (0,5)", x, y);
        }
        else
        {
            Console.WriteLine("the point ({0},{1})is NOT within the circle (0,5)", x, y);
        }
    }
}
