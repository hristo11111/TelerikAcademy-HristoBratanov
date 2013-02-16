using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class RectangleArea
{
    static void Main()
    {
        Console.WriteLine("enter height (in cm): ");
        double height = double.Parse(Console.ReadLine());
        Console.WriteLine("enter width (in cm): ");
        double width = double.Parse(Console.ReadLine());
        double area = height * width;
        Console.WriteLine("The area of the rectangle is: " + area + " square cm");
    }
}
