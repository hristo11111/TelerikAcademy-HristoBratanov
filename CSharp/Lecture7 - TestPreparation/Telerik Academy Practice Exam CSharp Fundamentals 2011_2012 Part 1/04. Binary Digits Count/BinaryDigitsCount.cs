using System;

class BinaryDigitsCount
{
    static void Main()
    {
        byte b = byte.Parse(Console.ReadLine());
        int n = Int32.Parse(Console.ReadLine());
        int firstBit = 0;
        for (int j = 0; j < n; j++)
        {
            uint number = uint.Parse(Console.ReadLine());
            
            for (int i = 31; i >= 0; i--)
            {
                if (((number >> i) & 1) == 1)
                {
                    firstBit = i;
                    break;
                }

            }
            
            uint countOfOnes = 0;
            for (int i = firstBit; i >=0; i--)
            {
                if (((number >> i) & 1) == 1)
                {
                    countOfOnes = countOfOnes + 1;
                }
            }
            if (b == 1)
            {
                Console.WriteLine(countOfOnes);
            }
            else
            {
                Console.WriteLine(firstBit - countOfOnes + 1);
            }
        }
        
    }
}
