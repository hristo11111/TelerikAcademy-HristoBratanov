﻿using System;

class CartesianCoordSystem
{
    static void Main()
    {
        decimal X = decimal.Parse(Console.ReadLine());
        decimal Y = decimal.Parse(Console.ReadLine());
        if (X == 0 && Y == 0)
        {
            Console.WriteLine("0");
        }
        else if (X == 0 && Y != 0)
        {
            Console.WriteLine("5");
        }
        else if (X != 0 && Y == 0)
        {
            Console.WriteLine("6");
        }
        else if (X > 0 && Y > 0)
        {
            Console.WriteLine("1");
        }
        else if (X > 0 && Y < 0)
        {
            Console.WriteLine("4");
        }
        else if (X < 0 && Y > 0)
        {
            Console.WriteLine("2");
        }
        else
        {
            Console.WriteLine("3");
        }
    }
}