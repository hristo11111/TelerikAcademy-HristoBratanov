using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

class Febunachi
{
    static void Main()
    {
        Console.Write("n = ");
        int n = int.Parse(Console.ReadLine());
        BigInteger previusNumber = -1;
        BigInteger nextNumber = 1;
        BigInteger printNumber;
        Console.Write("the Febunachi sequence for n = {0} is: ",n);
        for (int i = 0; i < n; i++)
        {
            printNumber = previusNumber + nextNumber;
            previusNumber = nextNumber;
            nextNumber = printNumber;
            Console.Write(printNumber + ", ");
        }
    }
}
