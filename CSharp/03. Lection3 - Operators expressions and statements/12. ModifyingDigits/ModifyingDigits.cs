using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class ModifyingDigits
{
    static void Main()
    {
        int newNumber;
        Console.Write("enter an integer: ");
        int number = int.Parse(Console.ReadLine());
        Console.WriteLine("enter position: ");
        byte position = byte.Parse(Console.ReadLine());
        int checkPosition = number & (1 << position);
        if (checkPosition == 0)
        {
            newNumber = number | (1 << position);
            Console.WriteLine("integer: " + number + " in binary = " + Convert.ToString(number, 2).PadLeft(32, '0'));
            Console.WriteLine("the {0} position of {1} is 0", position, number);
            Console.WriteLine("this position changes from 0 to 1 and the new integer is {0}", newNumber);
            Console.WriteLine("the binary of {0} is = ", newNumber + " is = " + Convert.ToString(newNumber, 2).PadLeft(32, '0'));
        }
        else
        {
            newNumber = ~(~number | (1 << position));
            Console.WriteLine("integer: " + number + " in binary = " + Convert.ToString(number, 2).PadLeft(32, '0'));
            Console.WriteLine("the {0} position of {1} is 1", position, number);
            Console.WriteLine("this position changes from 1 to 0 and the new integer is {0}", newNumber);
            Console.WriteLine("the binary of {0} is = ", newNumber + " is = " + Convert.ToString(newNumber, 2).PadLeft(32, '0'));
        }
    }
}