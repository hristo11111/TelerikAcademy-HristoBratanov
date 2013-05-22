using System;

class FallDown
{
    static void Main()
    {
        int num0 = 0;
        int num1 = 0;
        int num2 = 0;
        int num3 = 0;
        int num4 = 0;
        int num5 = 0;
        int num6 = 0;
        int num7 = 0;
        int sumOfColl0 = 0;
        int sumOfColl1 = 0;
        int sumOfColl2 = 0;
        int sumOfColl3 = 0;
        int sumOfColl4 = 0;
        int sumOfColl5 = 0;
        int sumOfColl6 = 0;
        int sumOfColl7 = 0;

        // find how many boxes there are in each column

        for (int rows = 0; rows <= 7; rows++)
        {
            int number = Int32.Parse(Console.ReadLine());
            for (int colls = 0; colls <= 7; colls++)
            {
                int cell = number >> colls;
                if ((cell & 1) == 1)
                {
                    if (colls == 0) sumOfColl0 = sumOfColl0 + 1;
                    if (colls == 1) sumOfColl1 = sumOfColl1 + 1;
                    if (colls == 2) sumOfColl2 = sumOfColl2 + 1;
                    if (colls == 3) sumOfColl3 = sumOfColl3 + 1;
                    if (colls == 4) sumOfColl4 = sumOfColl4 + 1;
                    if (colls == 5) sumOfColl5 = sumOfColl5 + 1;
                    if (colls == 6) sumOfColl6 = sumOfColl6 + 1;
                    if (colls == 7) sumOfColl7 = sumOfColl7 + 1;
                }
            }
        }

        // depending on the count of boxes in each column, calculate numbers from 0 to 7

        while (sumOfColl0 > 0)
        {
            switch (sumOfColl0)
            {
                case 8: num0 = num0 + 1; sumOfColl0 = sumOfColl0 - 1; break;
                case 7: num1 = num1 + 1; sumOfColl0 = sumOfColl0 - 1; break;
                case 6: num2 = num2 + 1; sumOfColl0 = sumOfColl0 - 1; break;
                case 5: num3 = num3 + 1; sumOfColl0 = sumOfColl0 - 1; break;
                case 4: num4 = num4 + 1; sumOfColl0 = sumOfColl0 - 1; break;
                case 3: num5 = num5 + 1; sumOfColl0 = sumOfColl0 - 1; break;
                case 2: num6 = num6 + 1; sumOfColl0 = sumOfColl0 - 1; break;
                case 1: num7 = num7 + 1; sumOfColl0 = sumOfColl0 - 1; break;
            }
        }
        while (sumOfColl1 > 0)
        {
            switch (sumOfColl1)
            {
                case 8: num0 = num0 + 2; sumOfColl1 = sumOfColl1 - 1; break;
                case 7: num1 = num1 + 2; sumOfColl1 = sumOfColl1 - 1; break;
                case 6: num2 = num2 + 2; sumOfColl1 = sumOfColl1 - 1; break;
                case 5: num3 = num3 + 2; sumOfColl1 = sumOfColl1 - 1; break;
                case 4: num4 = num4 + 2; sumOfColl1 = sumOfColl1 - 1; break;
                case 3: num5 = num5 + 2; sumOfColl1 = sumOfColl1 - 1; break;
                case 2: num6 = num6 + 2; sumOfColl1 = sumOfColl1 - 1; break;
                case 1: num7 = num7 + 2; sumOfColl1 = sumOfColl1 - 1; break;
            }
        }
        while (sumOfColl2 > 0)
        {
            switch (sumOfColl2)
            {
                case 8: num0 = num0 + 4; sumOfColl2 = sumOfColl2 - 1; break;
                case 7: num1 = num1 + 4; sumOfColl2 = sumOfColl2 - 1; break;
                case 6: num2 = num2 + 4; sumOfColl2 = sumOfColl2 - 1; break;
                case 5: num3 = num3 + 4; sumOfColl2 = sumOfColl2 - 1; break;
                case 4: num4 = num4 + 4; sumOfColl2 = sumOfColl2 - 1; break;
                case 3: num5 = num5 + 4; sumOfColl2 = sumOfColl2 - 1; break;
                case 2: num6 = num6 + 4; sumOfColl2 = sumOfColl2 - 1; break;
                case 1: num7 = num7 + 4; sumOfColl2 = sumOfColl2 - 1; break;
            }            
        }
        while (sumOfColl3 > 0)
        {
            switch (sumOfColl3)
            {
                case 8: num0 = num0 + 8; sumOfColl3 = sumOfColl3 - 1; break;
                case 7: num1 = num1 + 8; sumOfColl3 = sumOfColl3 - 1; break;
                case 6: num2 = num2 + 8; sumOfColl3 = sumOfColl3 - 1; break;
                case 5: num3 = num3 + 8; sumOfColl3 = sumOfColl3 - 1; break;
                case 4: num4 = num4 + 8; sumOfColl3 = sumOfColl3 - 1; break;
                case 3: num5 = num5 + 8; sumOfColl3 = sumOfColl3 - 1; break;
                case 2: num6 = num6 + 8; sumOfColl3 = sumOfColl3 - 1; break;
                case 1: num7 = num7 + 8; sumOfColl3 = sumOfColl3 - 1; break;
            }
        }
        while (sumOfColl4 > 0)
        {
            switch (sumOfColl4)
            {
                case 8: num0 = num0 + 16; sumOfColl4 = sumOfColl4 - 1; break;
                case 7: num1 = num1 + 16; sumOfColl4 = sumOfColl4 - 1; break;
                case 6: num2 = num2 + 16; sumOfColl4 = sumOfColl4 - 1; break;
                case 5: num3 = num3 + 16; sumOfColl4 = sumOfColl4 - 1; break;
                case 4: num4 = num4 + 16; sumOfColl4 = sumOfColl4 - 1; break;
                case 3: num5 = num5 + 16; sumOfColl4 = sumOfColl4 - 1; break;
                case 2: num6 = num6 + 16; sumOfColl4 = sumOfColl4 - 1; break;
                case 1: num7 = num7 + 16; sumOfColl4 = sumOfColl4 - 1; break;
            }
        }
        while (sumOfColl5 > 0)
        {
            switch (sumOfColl5)
            {
                case 8: num0 = num0 + 32; sumOfColl5 = sumOfColl5 - 1; break;
                case 7: num1 = num1 + 32; sumOfColl5 = sumOfColl5 - 1; break;
                case 6: num2 = num2 + 32; sumOfColl5 = sumOfColl5 - 1; break;
                case 5: num3 = num3 + 32; sumOfColl5 = sumOfColl5 - 1; break;
                case 4: num4 = num4 + 32; sumOfColl5 = sumOfColl5 - 1; break;
                case 3: num5 = num5 + 32; sumOfColl5 = sumOfColl5 - 1; break;
                case 2: num6 = num6 + 32; sumOfColl5 = sumOfColl5 - 1; break;
                case 1: num7 = num7 + 32; sumOfColl5 = sumOfColl5 - 1; break;
            }
        }
        while (sumOfColl6 > 0)
        {
            switch (sumOfColl6)
            {
                case 8: num0 = num0 + 64; sumOfColl6 = sumOfColl6 - 1; break;
                case 7: num1 = num1 + 64; sumOfColl6 = sumOfColl6 - 1; break;
                case 6: num2 = num2 + 64; sumOfColl6 = sumOfColl6 - 1; break;
                case 5: num3 = num3 + 64; sumOfColl6 = sumOfColl6 - 1; break;
                case 4: num4 = num4 + 64; sumOfColl6 = sumOfColl6 - 1; break;
                case 3: num5 = num5 + 64; sumOfColl6 = sumOfColl6 - 1; break;
                case 2: num6 = num6 + 64; sumOfColl6 = sumOfColl6 - 1; break;
                case 1: num7 = num7 + 64; sumOfColl6 = sumOfColl6 - 1; break;
            }
        }
        while (sumOfColl7 > 0)
        {
            switch (sumOfColl7)
            {
                case 8: num0 = num0 + 128; sumOfColl7 = sumOfColl7 - 1; break;
                case 7: num1 = num1 + 128; sumOfColl7 = sumOfColl7 - 1; break;
                case 6: num2 = num2 + 128; sumOfColl7 = sumOfColl7 - 1; break;
                case 5: num3 = num3 + 128; sumOfColl7 = sumOfColl7 - 1; break;
                case 4: num4 = num4 + 128; sumOfColl7 = sumOfColl7 - 1; break;
                case 3: num5 = num5 + 128; sumOfColl7 = sumOfColl7 - 1; break;
                case 2: num6 = num6 + 128; sumOfColl7 = sumOfColl7 - 1; break;
                case 1: num7 = num7 + 128; sumOfColl7 = sumOfColl7 - 1; break;
            }
        }
        Console.WriteLine(num0);
        Console.WriteLine(num1);
        Console.WriteLine(num2);
        Console.WriteLine(num3);
        Console.WriteLine(num4);
        Console.WriteLine(num5);
        Console.WriteLine(num6);
        Console.WriteLine(num7);
    }
}
