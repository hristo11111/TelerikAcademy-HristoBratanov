using System;

class BinaryToHexadecimal
{
    static void Main()
    {
        string binary = Console.ReadLine();
        ConvertBinarToHex(binary);
        Console.WriteLine();
    }

    static void ConvertBinarToHex(string input)
    {
        int len = input.Length;
        int steps = 0;
        int reminder = len % 4;
        int inputBinaryLength = len + (4 - reminder);
        if (reminder != 0)
	    {
	        steps = len/4 + 1;
	    }
        else
	    {
            steps = len/4;
	    }
        int sum = 0;
        int startSearch = 0;
        int endSearch = 0;
        int rank = 0;
        for (int i = 0; i < steps; i++)
		{
            if (i == 0)
	        {
		        startSearch = 0;
                endSearch = reminder;
	        }
            else if (i == 1)
            {
                startSearch = reminder;
                endSearch = reminder + 4;
            }
            else
            {
                startSearch = endSearch;
                endSearch = startSearch + 4;
                
            }
            rank = endSearch - startSearch - 1;
            for (int j = startSearch; j < endSearch; j++, rank--)
			{
                sum = sum + (int)((input[j]-48)*(Math.Pow(2, rank))); 
			}
            switch (sum)
            {
                case 10: Console.Write("A"); break;
                case 11: Console.Write("B"); break;
                case 12: Console.Write("C"); break;
                case 13: Console.Write("D"); break;
                case 14: Console.Write("E"); break;
                case 15: Console.Write("F"); break;
                default: Console.Write(sum); break; 
            }
            rank = 0;
            sum = 0;
		}
    }
}

