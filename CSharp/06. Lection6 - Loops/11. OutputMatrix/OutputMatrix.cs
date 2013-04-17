using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class OutputMatrix
{
    static void Main()
    {
        // трябва ли да са поместени в таблица като примера???
        Console.WriteLine("n, (n<20) = ");
        int n = int.Parse(Console.ReadLine());
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                Console.Write(i + j + 1);
            }
            Console.WriteLine();
        }
    }
}
