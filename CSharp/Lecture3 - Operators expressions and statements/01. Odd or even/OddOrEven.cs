using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class OddOrEven
{
    static void Main()
    {
        Console.WriteLine("enter a number: ");
        int var1 = int.Parse(Console.ReadLine());
        int result = (var1 % 2);
        if (result == 0)
        {
            Console.WriteLine("This is an even number");
        }
        else
        {
            Console.WriteLine("This is an odd number");
        }
    }
}
