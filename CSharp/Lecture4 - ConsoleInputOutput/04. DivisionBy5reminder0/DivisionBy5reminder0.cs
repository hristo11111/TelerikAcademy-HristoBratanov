using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class DivisionBy5reminder0
{
    static void Main()
    {
        uint count = 0;
        Console.Write("integer1 = ");
        uint integer1 = uint.Parse(Console.ReadLine());
        Console.Write("integer2 = ");
        uint integer2 = uint.Parse(Console.ReadLine());
        if (integer1 < integer2)
        {
            for (uint i = integer1; i <= integer2; i++)
            {
                if (i % 5 == 0)
                {
                    count = count + 1;
                }
            }
            Console.WriteLine("there are {0} numbers between {1} and {2}, which divided by 5 has reminder 0", count, integer1, integer2);
        }
        else
        {
            for (uint i = integer2; i <= integer1; i++)
            {
                if (i % 5 == 0)
                {
                    count = count + 1;
                }
            }
            Console.WriteLine("there are {0} numbers between {1} and {2}, which divided by 5 has reminder 0", count, integer1, integer2);
        }
        
    }
}
