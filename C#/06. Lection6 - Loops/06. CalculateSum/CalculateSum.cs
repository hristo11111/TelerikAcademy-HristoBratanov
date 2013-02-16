using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class CalculateSum
{
    static void Main()
    {
        Console.Write("n = ");
        int n = int.Parse(Console.ReadLine());
        Console.Write("x = ");
        int x = int.Parse(Console.ReadLine());
        double sum = 1;
        int factorial = 1;
        double productOfFactorial = 1;
        int divisor = x;
        for (int i = 0; i < n; i++)
        {
            sum = sum + productOfFactorial/divisor;
            factorial++;
            productOfFactorial = productOfFactorial * factorial;
            divisor = divisor * x;
        }
        Console.WriteLine(sum);
    }
}
