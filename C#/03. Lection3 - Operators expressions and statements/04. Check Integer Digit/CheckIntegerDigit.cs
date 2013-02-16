using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class CheckIntegerDigit
{
    static void Main()
    {
        bool result;
        Console.WriteLine("enter an integer: ");
        int number = int.Parse(Console.ReadLine());
        int divideNumber = number / 100;
        if ((divideNumber % 10) == 7)
        {
            result = true;
            Console.WriteLine("the third digit (right-to-left) of number {0} is 7: {1}", number, result);
        }
        else
        {
            result = false;
            Console.WriteLine("the third digit (right-to-left) of number {0} is 7: {1}", number, result);
        }

    }
}
