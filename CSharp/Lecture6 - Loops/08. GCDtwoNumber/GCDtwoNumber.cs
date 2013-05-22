using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class GCDtwoNumber
{
    static void Main()
    {
        Console.Write("num1 = ");
        int num1 = int.Parse(Console.ReadLine());
        Console.Write("num2 = ");
        int num2 = int.Parse(Console.ReadLine());
        int originalNum1 = num1;
        int originalNum2 = num2;
        while (num1 != 0 && num2 != 0)
        {
            if (num1 > num2)
            {
                num1 = num1 % num2;
            }
            else
            {
                num2 = num2 % num1;
            }
        }
        if (originalNum1 != 0 && originalNum2 != 0 && num1 == 0)
        {
            Console.WriteLine("GCD of {0} and {1} is = {2}", originalNum1, originalNum2, num2);
        }
        else if (originalNum1 != 0 && originalNum2 != 0 && num2 == 0)
        {
            Console.WriteLine("GCD of {0} and {1} is = {2}", originalNum1, originalNum2, num1);
        }
        if (originalNum1 == 0 || originalNum2 == 0)
        {
            Console.WriteLine("Please enter non nulable integers");
        }
    }
}
