using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class FindTheBit
{
    static void Main()
    {
        Console.Write("enter an integer: ");
        int number = int.Parse(Console.ReadLine());
        int numberAndMask = number & (1 << 3);
        int checkNumber = numberAndMask >> 3;
        if (checkNumber == 1)
        {
            Console.WriteLine("the binary of: " + number + " is: " + Convert.ToString(number,2).PadLeft(32, '0'));
            Console.WriteLine("and the 3rd digit of {0} is 1", number);
        }
        else
        {
            Console.WriteLine("the binary of " + number + " is: " + Convert.ToString(number, 2).PadLeft(32, '0'));
            Console.WriteLine("and the 3rd digit of {0} is 0", number);
        }    
    }
}
