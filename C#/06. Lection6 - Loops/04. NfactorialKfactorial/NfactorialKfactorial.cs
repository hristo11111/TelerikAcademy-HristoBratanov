using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class NfactorialKfactorial
{
    static void Main()
    {
        Console.Write("enter n (n > 1) = ");
        int n = int.Parse(Console.ReadLine());
        Console.Write("enter k (k > n > 1) = ");
        int k = int.Parse(Console.ReadLine());
        double result = 1;
        for (int i = n + 1; i <= k; i++)
        {
            result = result * i;
        }
        Console.WriteLine("{0}!/{1}! = {2}", n, k, (1 / result));
    }
}
