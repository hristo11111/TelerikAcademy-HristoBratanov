using System;
using System.Numerics;

class Tribonachi
{
    static void Main()
    {
        BigInteger num1 = BigInteger.Parse(Console.ReadLine());
        BigInteger num2 = BigInteger.Parse(Console.ReadLine());
        BigInteger num3 = BigInteger.Parse(Console.ReadLine());
        int nthElement = Int32.Parse(Console.ReadLine());
        BigInteger lastNumber = 0;
        if (nthElement == 1)
        {
            Console.WriteLine(num1);
        }
        else if (nthElement == 2)
        {
            Console.WriteLine(num2);
        }
        else if (nthElement == 3)
        {
            Console.WriteLine(num3);
        }
        else if (nthElement > 3)
        {
            for (int i = 0; i < nthElement - 3; i++)
            {
                lastNumber = num1 + num2 + num3;
                num1 = num2;
                num2 = num3;
                num3 = lastNumber;

            }
            Console.WriteLine(lastNumber);
        }
        
    }
}
