using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class PointInCircle_OutOfRectangle
{
    static void Main()
    {
        Console.Write("enter x");
        double x = double.Parse(Console.ReadLine());
        Console.Write("enter y");
        double y = double.Parse(Console.ReadLine());
        if (Math.Pow(x - 1, 2) + Math.Pow(y - 1, 2) <= 3 * 3)
        {
            if ((x < -1) | (x > 5) | (y > 1) | (y < -1))
            {
                Console.WriteLine("yes");
            }
            else
            {
                Console.WriteLine("no");
            }
        }
        else
        {
            Console.WriteLine("no");
        }
    }
}
