using System;
using System.Collections.Generic;

class DigitAsWord
{
    static void Main()
    {
        Console.Write("enter a number: ");
        int number = Int32.Parse(Console.ReadLine());
        Console.Write("the last digit of number {0} is: ", number);
        ShowLastDigitAsWord(number);
    }
    static void ShowLastDigitAsWord(int number)
    {
        int digit = number % 10;
        switch (digit)
        {
            case 0: Console.WriteLine("null"); ; break;
            case 1: Console.WriteLine("one"); ; break;
            case 2: Console.WriteLine("two"); ; break;
            case 3: Console.WriteLine("three"); ; break;
            case 4: Console.WriteLine("four"); ; break;
            case 5: Console.WriteLine("five"); ; break;
            case 6: Console.WriteLine("six"); ; break;
            case 7: Console.WriteLine("seven"); ; break;
            case 8: Console.WriteLine("eight"); ; break;
            case 9: Console.WriteLine("nine"); ; break;

        }
    }
}
