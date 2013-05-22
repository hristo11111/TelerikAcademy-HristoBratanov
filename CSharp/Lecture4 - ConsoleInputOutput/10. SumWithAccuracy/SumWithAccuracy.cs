using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class SumWithAccuracy
{
    static void Main()
    {
        // колко ли цикъла трябва да се направят?
        double sum = 1;
        int num2 = 3;
        for (int num1 = 2; num1 < 300; )
        {
            sum = sum + 1 / (double)num1 - 1 / (double)num2;
            num1 = num1 + 2;
            num2 = num2 + 2;
        }
        Console.WriteLine("{0:F3}", sum);
    }
}
