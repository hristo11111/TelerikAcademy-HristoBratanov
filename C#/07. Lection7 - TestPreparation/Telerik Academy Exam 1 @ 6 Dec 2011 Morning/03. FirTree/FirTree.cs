using System;

class FirTree
{
    static void Main()
    {
        int n = Int32.Parse(Console.ReadLine());
            for (int i = 0; i < n-1; i++)
            {
                Console.Write(new string('.', (n - 2 - i)));
                Console.Write(new string('*', (2 * i + 1)));
                Console.WriteLine(new string('.', (n - 2 - i)));
            }
            Console.Write(new string('.', (n - 2)));
            Console.Write(new string('*', 1));
            Console.WriteLine(new string('.', (n - 2)));
	   }
}
