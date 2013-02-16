using System;

class ForestRoad
{
    static void Main()
    {
        int number = Int32.Parse(Console.ReadLine());
        for (int i = 0; i < number; i++)
        {
            Console.Write(new string('.', i));
            Console.Write(new string('*', 1));
            Console.Write(new string('.', (number - i - 1)));
            Console.WriteLine();
        }
        for (int i = number-2; i >= 0; i--)
        {
            Console.Write(new string('.', i));
            Console.Write(new string('*', 1));
            Console.Write(new string('.', (number - i - 1)));
            Console.WriteLine();
        }
    }
}
