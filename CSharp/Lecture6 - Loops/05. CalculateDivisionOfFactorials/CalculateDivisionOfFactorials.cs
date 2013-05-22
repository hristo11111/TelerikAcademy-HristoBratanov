using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class CalculateDivisionOfFactorials
{
    static void Main()
    {
        Console.Write("n, (n>1) = ");
        int n = int.Parse(Console.ReadLine());
        Console.Write("k, (k>n) = ");
        int k = int.Parse(Console.ReadLine());
        decimal factorial = 1;
        decimal result;
        decimal additionToResult = 1;
        for (int i = 1; i <= k; i++)
        {
            factorial = factorial * i;
        }
        if (n < k/2)
        {
            for (int i = k - n; i > n; i--)
            {
                additionToResult = additionToResult * i;
            }
            result = factorial / additionToResult;
            Console.WriteLine(result);
        }
        if (n == k/2)
        {
            result = factorial;
            Console.WriteLine(result);
        }
        if (n > k/2)
        {
            for (int i = k-n+1; i <= n; i++)
            {
                additionToResult = additionToResult * i;
            }
            result = factorial * additionToResult;
            Console.WriteLine(result);
        }
    }
}
