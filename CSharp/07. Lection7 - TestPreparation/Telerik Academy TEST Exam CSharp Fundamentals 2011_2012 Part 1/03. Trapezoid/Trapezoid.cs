using System;

class Trapezoid
{
    static void Main()
    {
        byte n = byte.Parse(Console.ReadLine());
        Console.Write(new string('.', n));
        Console.WriteLine(new string('*', n));
        for (int i = 1; i <= n-1; i++)
        {
            Console.Write(new string('.', n-i));
            Console.Write(new string('*', 1));
            Console.Write(new string('.', i + n -2));
            Console.WriteLine(new string('*', 1));
        }
        Console.WriteLine(new string('*', 2*n));
    }
}
