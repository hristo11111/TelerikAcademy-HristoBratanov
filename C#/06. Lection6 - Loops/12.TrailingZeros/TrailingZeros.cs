using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

class TrailingZeros
{
    static void Main()
    {
        Console.WriteLine("n = ");
        int n = int.Parse(Console.ReadLine());
        double nDivided;
        double integralPart;
        int sum = 0;
        for (int i = 5; i <= n;)
        {
            nDivided = n / i;
            integralPart = Math.Truncate(nDivided);
            if (integralPart >=1 )
                {
                    sum = sum + (int)integralPart;
                }
            i = i * 5;
        }
        Console.WriteLine(sum);
    }
}
