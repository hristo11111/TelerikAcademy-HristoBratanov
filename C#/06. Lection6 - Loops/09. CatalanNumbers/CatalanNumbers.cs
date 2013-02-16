using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class CatalanNumbers
{
    static void Main()
    {
        Console.WriteLine("n = ");
        int n = int.Parse(Console.ReadLine());
        decimal divident = 1;
        decimal divisor1 = 1;
        decimal divisor2 = 1;
        for (int i = 2*n; i >= 1; i--)
			{
                divident = divident * i;
            }
        for (int i = n+1; i >=1 ; i--)
        {
            divisor1 = divisor1 * i;
        }
        for (int i = n; i >= 1; i--)
        {
            divisor2 = divisor2 * i;
        }
        Console.WriteLine("the Cataln number for n = {0} is: {1}", n, divident / (divisor1 * divisor2));
    }
}
