using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class GreaterOfTwoNumbers
{
    static void Main()
    {
        Console.Write("num1 = ");
        int num1 = int.Parse(Console.ReadLine());
        Console.Write("num2 = ");
        int num2 = int.Parse(Console.ReadLine());
        int difference = num1 - num2;
        int sign = (difference >> 31) & 1;
        int max = num1 - difference * sign;
        Console.WriteLine(max);
    }
}
