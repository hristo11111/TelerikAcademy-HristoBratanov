using System;

class QuadraticEquation
{
    static void Main()
    {
        Console.Write("coefficient A is: ");
        double coeffA = Single.Parse(Console.ReadLine());
        Console.Write("coefficient B is: ");
        double coeffB = Single.Parse(Console.ReadLine());
        Console.Write("coefficient C is: ");
        double coeffC = Single.Parse(Console.ReadLine());
        double x1, x2;
        double discriminant = Math.Pow(coeffB, 2) - (4 * coeffA * coeffC);
        if (discriminant < 0)
        {
            Console.WriteLine("there is no solution of the quadratic equation");
        }
        if (discriminant == 0)
        {
            x1 = -(coeffB / 2 * coeffA);
            Console.WriteLine("this equation has one root: x = {0}", x1);
        }
        if (discriminant > 0)
        {
            x1 = ((-coeffB + Math.Sqrt(discriminant)) / (2 * coeffA));
            x2 = ((-coeffB - Math.Sqrt(discriminant)) / (2 * coeffA));
            Console.WriteLine("this equation has two roots: x1 = {0}; x2 = {1}", x1, x2);
        }
    }
}
