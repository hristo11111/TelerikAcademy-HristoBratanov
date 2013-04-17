using System;

class SandGlass
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        //Console.WriteLine(new string('*', n));
        for (int i = 0; i < (n + 1)/2; i++)
        {
            for (int j = 1; j < i  + 1; j++)
            {
                Console.Write('.');
            }
            for (int j = n - 2*i; j > 0; j--)
            {
                Console.Write('*');
            }
            for (int j = i +1; j > 1; j--)
            {
                Console.Write('.');
            }
            Console.WriteLine();
        }
        for (int i = (n+1)/2 - 1; i > 0; i--)
        {
            for (int j = 2; j < i + 1; j++)
            {
                Console.Write('.');
            }
            for (int j = n - 2 * i +2; j > 0; j--)
            {
                Console.Write('*');
            }
            for (int j = i; j > 1; j--)
            {
                Console.Write('.');
            }
            
            Console.WriteLine();
        }

    }
}
