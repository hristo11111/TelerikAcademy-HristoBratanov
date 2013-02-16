using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class CheckPDigitBinary
{
    static void Main()
    {
        Console.WriteLine("please enter integer for v = ");
        int v = int.Parse(Console.ReadLine());
        Console.WriteLine("which digit of the integer do you want to check");
        int p = int.Parse(Console.ReadLine());
        if ((v & (1 << p)) == 0)
        {
            Console.WriteLine("the {0} digit of the integer {1} is NOT", p, v);
        }
        else
        {
            Console.WriteLine("the {0} digit of the integer {1} is 1", p, v);
        }
    }
}
