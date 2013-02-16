using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class NotDivisibleBy3and7
{
    static void Main()
    {
        Console.Write("n = ");
        int n = int.Parse(Console.ReadLine());
        bool isDividable = false;
        for (int i = 1; i <= n; i++)
        {
            if (((i % 3) == 0) && ((i % 7) == 0))
            {
                Console.Write(i + ", ");
                isDividable = true;
            }
        }
        if (isDividable == false)
        {
            Console.WriteLine("there is no number from 1 to {0} dividable by 3 and 7 at the same time", n);
        }
    }
}
