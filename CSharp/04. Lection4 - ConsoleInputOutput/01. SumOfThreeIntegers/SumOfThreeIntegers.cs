using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class SumOfThreeIntegers
{
    static void Main()
    {
        Console.Write("integer1 = ");
        int num1 = int.Parse(Console.ReadLine());
        Console.Write("integer2 = ");
        int num2 = int.Parse(Console.ReadLine());
        Console.Write("integer3 = ");
        int num3 = int.Parse(Console.ReadLine());
        Console.WriteLine("the sum of {0}, {1} and {2} is = {3}", num1, num2, num3, num1 + num2 + num3);
    }
}
