using System;

class DancingBits
{
    static void Main()
    {
        int k = int.Parse(Console.ReadLine());
        int n = int.Parse(Console.ReadLine());
        //firstBit;
        int sumOfDancingBits = 0;
        int len = 0;
        int lastBit = -1;
        
        for (int i = 1; i <= n; i++)
        {
            int startBit = 0;
            int num = int.Parse(Console.ReadLine());
            for (int j = 31; j >= 0; j--)
            {
                if (((num >> j) & 1) == 1)
                {
                    startBit = j;    
                    break;
                }
                
                
            }
            
            for (int j = startBit; j >= 0; j--)
            {
                int firstBit = (num >> j) & 1; 
                if (firstBit == lastBit)
                {
                    len++;
                }
                else
                {
                    if (len == k)
                    {
                        sumOfDancingBits++;
                    }
                    len = 1;
                }
                lastBit = firstBit;
            }
        }
        if (len == k)
        {
            sumOfDancingBits++;
        }
        Console.WriteLine(sumOfDancingBits);
    }
}
