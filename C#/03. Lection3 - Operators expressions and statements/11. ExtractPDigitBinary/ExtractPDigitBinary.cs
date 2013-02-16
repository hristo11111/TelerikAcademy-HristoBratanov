using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class ExtractPDigitBinary
{
    static void Main()
    {
        Console.Write("enter integer: ");
        int number = int.Parse(Console.ReadLine());
        Console.Write("enter position P: ");
        byte position = byte.Parse(Console.ReadLine());
        int checkPosition = number & (1 << position);
        int checkDigit = checkPosition >> position;
        if (checkDigit == 1)
        {
            Console.WriteLine(number + " in binary = " + Convert.ToString(number, 2).PadLeft(32, '0'));
            Console.WriteLine("the {0} position of number {1} is: 1", position, number);
        }
        else
        {
            Console.WriteLine(number + " in binary = " + Convert.ToString(number, 2).PadLeft(32, '0'));
            Console.WriteLine("the {0} position of number {1} is: 0", position, number);
        }
    }
}
