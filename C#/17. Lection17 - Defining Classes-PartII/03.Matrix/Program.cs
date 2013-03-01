using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Matrix_T<int> metr = new Matrix_T<int>(5,8);
        Matrix_T<int> ma = new Matrix_T<int>(5, 8);
        //int[,] temp1 = new int[4, 5];
        //int[,] temp2 = new int[4, 5];
        metr[1, 2] = 5;
        metr[3, 4] = 6;
        ma[3, 1] = 1;
        ma[3, 4] = 6;
        Matrix_T<int> res = new Matrix_T<int>();
        res = metr + ma;
        if (ma)
        {
            Console.WriteLine(true);
        }
        else
        {
            Console.WriteLine(false);
        }


        
    }
}
