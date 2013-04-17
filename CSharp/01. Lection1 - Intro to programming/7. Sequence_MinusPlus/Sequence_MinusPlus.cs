using System;

class Sequence_MinusPlus
{
    static void Main()
    {
        int k = -3;
        int counter = 0;
        for (int i = 2; counter < 5; i += 2)
        {
            Console.WriteLine(i);
            Console.WriteLine(k);
            k = k - 2;
            counter = counter + 1;
        }
    }
}

