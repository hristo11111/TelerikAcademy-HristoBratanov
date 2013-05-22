using System;

class WeAllLoveBits
{
    static void Main()
    {
        string output = "";
        int numbers = Int32.Parse(Console.ReadLine());
        for (int j = 0; j < numbers; j++)
        {
            int n = Int32.Parse(Console.ReadLine());
            int reverseN = n;
            int firstDigit = 0;
            for (int i = 31; i >= 0; i--)
            {
                firstDigit = (reverseN >> i) & 1;
                if (firstDigit == 1)
                {
                    firstDigit = i;
                    break;
                }
            }
            for (int i = 0; i < (firstDigit + 1) / 2; i++)
            {
                int backDigit = reverseN & (1 << i);
                int frontDigit = reverseN & (1 << firstDigit - i);
                if (backDigit != 0)
                {
                    if (frontDigit == 0)
                    {
                        reverseN = reverseN | (1 << (firstDigit - i));
                        reverseN = ~(~reverseN | (1 << i));
                    }
                }
                else if (backDigit == 0)
                {
                    if (frontDigit != 0)
                    {
                        reverseN = ~(~reverseN | (1 << (firstDigit - i)));
                        reverseN = reverseN | (1 << i);
                    }
                }
            }
            int pNew = (n ^ (~n)) & reverseN;
            Console.WriteLine(pNew);
 
        }
        
            
    }
}
