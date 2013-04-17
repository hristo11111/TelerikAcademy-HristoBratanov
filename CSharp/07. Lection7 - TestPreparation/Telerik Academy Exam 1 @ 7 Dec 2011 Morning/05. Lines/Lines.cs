using System;

class Lines
{
    static void Main()
    {
        // Read the input numbers

    int num0 = Int32.Parse(Console.ReadLine());
    int num1 = Int32.Parse(Console.ReadLine());
    int num2 = Int32.Parse(Console.ReadLine());
    int num3 = Int32.Parse(Console.ReadLine());
    int num4 = Int32.Parse(Console.ReadLine());
    int num5 = Int32.Parse(Console.ReadLine());
    int num6 = Int32.Parse(Console.ReadLine());
    int num7 = Int32.Parse(Console.ReadLine());
    int maxLen = 0;
    int maxCount = 0;
        // check horzontal lines

    for (int rows = 0; rows <= 7; rows++)
    {
        int number = 0;
        switch (rows)
        {
            case 0: number = num0; break;
            case 1: number = num1; break;
            case 2: number = num2; break;
            case 3: number = num3; break;
            case 4: number = num4; break;
            case 5: number = num5; break;
            case 6: number = num6; break;
            case 7: number = num7; break;
        }
        int len = 0;
        for (int cols = 0; cols <= 7; cols++)
        {
            int cell = (number >> cols) & 1;
            if (cell == 1)
            {
                len++;
                if (len > maxLen)
                {
                    maxLen = len;
                    maxCount = 0;
                }
                if (len == maxLen)
                {
                    maxCount++;
                }
            }
            else
            {
                len = 0;
            }
        }
    }
        //check vertical lines
    for (int cols = 0; cols <= 7; cols++)
    {
        int len = 0;
        int number = 0;
        for (int rows = 0; rows <= 7; rows++)
        {
            switch (rows)
            {
                case 0: number = num0; break;
                case 1: number = num1; break;
                case 2: number = num2; break;
                case 3: number = num3; break;
                case 4: number = num4; break;
                case 5: number = num5; break;
                case 6: number = num6; break;
                case 7: number = num7; break;
            }
            int cell = (number >> cols) & 1;
            if (cell == 1)
            {
                len++;
                if (len > maxLen)
                {
                    maxLen = len;
                    maxCount = 0;
                }
                if (len == maxLen)
                {
                    maxCount++;
                }
            }
            else
            {
                len = 0;
            }
        }
    }
    if (maxLen == 1)
    {
        maxCount = maxCount / 2;
    }
    Console.WriteLine(maxLen);
    Console.WriteLine(maxCount);
    
     
    }
}
