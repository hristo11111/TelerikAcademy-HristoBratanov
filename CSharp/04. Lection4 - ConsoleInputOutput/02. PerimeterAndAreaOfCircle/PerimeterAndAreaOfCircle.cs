using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class PerimeterAndAreaOfCircle
{
    static void Main()
    {
        Console.Write("the radius of the circle is: ");
        double radius = double.Parse(Console.ReadLine());
        Console.WriteLine("perimeter is: {0} \narea is: {1}", 2 * Math.PI * radius, Math.PI * radius*radius);
    }
}
