using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class SumOfNNumbersFromConsole
{
    static void Main()
    {
        double sum = 0;
        Console.Write("please enter number n= ");
        uint n = uint.Parse(Console.ReadLine());
        Console.WriteLine("enter {0} numbers", n);
        for (uint counter = 1; counter <= n; counter++)
        {
            Console.Write("number {0} = ", counter);
            double newNumber = Single.Parse(Console.ReadLine());
            sum = sum + newNumber;
        }
        Console.WriteLine("the sum of numbers n ({0}) is: {1}", n, sum);
    }
}
