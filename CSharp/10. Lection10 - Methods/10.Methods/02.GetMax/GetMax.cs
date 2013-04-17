using System;
using System.Collections.Generic;

class GetMax
{
    static void Main()
    {
        Console.Write("num1 = ");
        int num1 = Int32.Parse(Console.ReadLine());
        Console.Write("num2 = ");
        int num2 = Int32.Parse(Console.ReadLine());
        Console.Write("num3 = ");
        int num3 = Int32.Parse(Console.ReadLine());
        Console.Write("biggest number is = ");
        int result = MyGetMax(MyGetMax(num1, num2), num3);
        Console.WriteLine(result);
    }
    static int MyGetMax(int integer1, int integer2)
    {
        if (integer1 > integer2)
        {
            return integer1;
        }
        else if (integer1 == integer2)
        {
            return integer1;
        }
        else
        {
            return integer2;
        }
    }
}
