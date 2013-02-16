using System;

class OddNumber
{
    static void Main()
    {
        int n = Int32.Parse(Console.ReadLine());
        long oddNumber = 0L;
        for (int i = 0; i < n; i++)
        {
            long number = Int64.Parse(Console.ReadLine());
            oddNumber = oddNumber ^ number; 
        }
        Console.WriteLine(oddNumber);
    }
}
