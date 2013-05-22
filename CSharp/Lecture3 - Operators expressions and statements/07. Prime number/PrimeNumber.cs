using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class PrimeNumber
{
    static void Main()
    {
        bool isPrime = true;
        Console.WriteLine("enter a number from 2 to 100 including: ");
        int number = int.Parse(Console.ReadLine());
        for (int divider = 2; divider <= Math.Sqrt(number); divider++)
        {
            if ((number % divider) == 0)
            {
                isPrime = false;
            }           
        }
        Console.WriteLine("{0} is even: {1}", number, isPrime);
    }
}
