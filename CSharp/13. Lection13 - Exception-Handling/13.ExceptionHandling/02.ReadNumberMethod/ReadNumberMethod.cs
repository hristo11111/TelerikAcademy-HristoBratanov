using System;

class ReadNumberMethod
{
    static void Main()
    {
        try
        {
            int begin = 0;
            begin = ReadRangeStart(begin);
            int finish = 0;
            finish = ReadRangeEnd(begin);
            Console.WriteLine("enter 10 numbers in range [{0}, {1}]",begin, finish);
            for (int i = 0; i < 10; i++)
            {
                begin = ReadNumber(begin, finish);
            }
            
        }

        catch (System.ArgumentOutOfRangeException)
        {

            Console.WriteLine("Invalid number! Enter number in given range.");
        }

        catch (System.OverflowException)
        {
            Console.WriteLine("Invalid number! Overflow Exception.");
        }

        catch (FormatException)
        {
            Console.WriteLine("Invalid number! Enter int.");
        }

    }

    static int ReadNumber(int start, int end)
    {
        Console.WriteLine("Enter number between {0} and {1}", start, end);
        int num = Int32.Parse(Console.ReadLine());
        if (num <= start || num >= end)
        {
            throw new System.ArgumentOutOfRangeException();
        }

        return num;
    }

    static int ReadRangeStart(int start)
    {
        Console.Write("enter number for start of the range (0 <= start < 91) = ");
        start = Int32.Parse(Console.ReadLine());
        if (start <=1 || start >= 91)
        {
            throw new System.ArgumentOutOfRangeException();
        }
        return start;
        
    }

    static int ReadRangeEnd(int start)
    {
        Console.Write("enter number for start of the range (start + 10< end < 100) = ");
        int end = Int32.Parse(Console.ReadLine());
        if (end >= 100 || end <= (start + 10))
        {
            throw new System.ArgumentOutOfRangeException();
        }

        return end;
    }

}
