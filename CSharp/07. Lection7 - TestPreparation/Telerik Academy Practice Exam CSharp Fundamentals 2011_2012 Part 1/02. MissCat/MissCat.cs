using System;

class MissCat
{
    static void Main()
    {
        int n = Int32.Parse(Console.ReadLine());
        int sumOf1 = 0;
        int sumOf2 = 0;
        int sumOf3 = 0;
        int sumOf4 = 0;
        int sumOf5 = 0;
        int sumOf6 = 0;
        int sumOf7 = 0;
        int sumOf8 = 0;
        int sumOf9 = 0;
        int sumOf10 = 0;
        for (int i = 1; i <= n; i++)
        {  
            byte voteFor = byte.Parse(Console.ReadLine());
            switch (voteFor)
            {
                case 1: sumOf1 = sumOf1 + 1; break;
                case 2: sumOf2 = sumOf2 + 1; break;
                case 3: sumOf3 = sumOf3 + 1; break;
                case 4: sumOf4 = sumOf4 + 1; break;
                case 5: sumOf5 = sumOf5 + 1; break;
                case 6: sumOf6 = sumOf6 + 1; break;
                case 7: sumOf7 = sumOf7 + 1; break;
                case 8: sumOf8 = sumOf8 + 1; break;
                case 9: sumOf9 = sumOf9 + 1; break;
                case 10: sumOf10 = sumOf10 + 1; break;
            }
        }
        int max = sumOf1;
        byte winner = 1;
        if (sumOf2 > max)
        {
            max = sumOf2;
            winner = 2;
        }
        if (sumOf3 > max)
        {
            max = sumOf3;
            winner = 3;
        }
        if (sumOf4 > max)
        {
            max = sumOf4;
            winner = 4;
        }
        if (sumOf5 > max)
        {
            max = sumOf5;
            winner = 5;
        }
        if (sumOf6 > max)
        {
            max = sumOf6;
            winner = 6;
        }
        if (sumOf7 > max)
        {
            max = sumOf7;
            winner = 7;
        }
        if (sumOf8 > max)
        {
            max = sumOf8;
            winner = 8;
        }
        if (sumOf9 > max)
        {
            max = sumOf9;
            winner = 9;
        }
        if (sumOf10 > max)
        {
            max = sumOf10;
            winner = 10;
        }
        Console.WriteLine(winner);

    }
}
