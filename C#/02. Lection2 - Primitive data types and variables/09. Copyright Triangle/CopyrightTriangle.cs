using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class CopyrightTriangle
{
    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;
        int n = 4;
        Console.Write(new string(' ',n-1));  // first row
        Console.WriteLine('\u00A9');
        for (int row = 1; row < n-1; row++)
        {
            Console.Write(new string(' ', n-row-1));
            for (int col = 0; col < 2; col++)
            {
                 Console.Write('\u00A9' + new string(' ', 2*row-1));
            }
            Console.WriteLine();
        }

        // last row

        for (int i = 1; i <= n; i++)
        {
            Console.Write('\u00A9'+" ");
        }
    }
}
