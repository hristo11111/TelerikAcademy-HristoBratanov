using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class MinAndMax
{
    static void Main()
    {
        int maxNumber = Int32.MinValue;
        int minNumber = Int32.MaxValue;
        Console.Write("n = ");
        int n = int.Parse(Console.ReadLine());
        for (int i = 0; i < n; i++)
        {
            Console.Write("enter a number = ");
            int number = int.Parse(Console.ReadLine());
            if (number > maxNumber)
            {
                maxNumber = number;
            }
            if (number < minNumber)
            {
                minNumber = number;
            }
        }
        Console.WriteLine("maximal number is = " + maxNumber);
        Console.WriteLine("minimal number is = " + minNumber);
        
    }
}
