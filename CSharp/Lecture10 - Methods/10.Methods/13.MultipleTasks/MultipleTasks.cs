using System;
using System.Collections.Generic;

class MultipleTasks
{
    static void Main()
    {
        Console.WriteLine("please enter the serial number of the task you want to perform (1-3): ");
        Console.WriteLine("1: Reverse digits of a number");
        Console.WriteLine("2: Calculate the average of sequence of integers");
        Console.WriteLine("3: Solve the equation a*x + b = 0");
        Console.Write("your choice (1-3): ");
        int input = Int32.Parse(Console.ReadLine());
        if (input <= 3 && input >= 1)
        {
            switch (input)
            {
                case 1:
                    {
                        Console.Write("Please enter non-negative number: ");
                        ReverseDecimal(decimal.Parse(Console.ReadLine()));
                    }; break;
                case 2:
                    {
                        Console.Write("How many alements will the sequence have: ");
                        int elements = Int32.Parse(Console.ReadLine());
                        CalculateAvarage(elements);
                    }; break;
                case 3:
                    {
                        Console.Write("a (a - different than 0) = ");
                        decimal a = decimal.Parse(Console.ReadLine());
                        Console.Write("b = ");
                        decimal b = decimal.Parse(Console.ReadLine());
                        SolveEquation(a, b);
                    }; break;
            }
        }
        else
        {
            Console.WriteLine("Wrong number! Please enter a number from 1 to 3");
        }
    }

    static void ReverseDecimal(decimal number)
    {
        if (number > 0)
        {
            string numberString = number.ToString();        //convert the input in string
            char[] numberChar = numberString.ToCharArray(); // then convert the string to array of chars
            char[] reversedNumberChar = new char[numberChar.Length];
            for (int i = 0; i < numberChar.Length; i++)             // reverse the array of chars
            {
                reversedNumberChar[numberChar.Length - i - 1] = numberChar[i];
            }
            for (int i = 0; i < reversedNumberChar.Length; i++)  // print the final array of chars. 45 is the ascii code of "-"
            {
                if (reversedNumberChar[i] == 45)
                {
                    break;                     //if decimal is < 0 print the reversed number without "-" behind it
                }
                Console.Write(reversedNumberChar[i]);
            }
            Console.WriteLine();
        }
        else
        {
            Console.WriteLine("Wrong number! Please enter non-negative number.");
        }
    }

    static void CalculateAvarage(int numberOfElements)
    {
        if (numberOfElements > 0)
        {
            List<int> sequence = new List<int>();
            double sum = 0;
            for (int i = 1; i <= numberOfElements; i++)
            {
                Console.Write("element {0} = ", i);
                sequence.Add(Int32.Parse(Console.ReadLine()));
            }
            for (int i = 0; i < numberOfElements; i++)
            {
                sum = sum + sequence[i];
            }
            Console.WriteLine("The average is: {0}", (double)sum / numberOfElements);
        }
        else
        {
            Console.WriteLine("Wrong number! Please enter number bigger than 0.");
        }
    }

    static void SolveEquation(decimal a, decimal b)
    {
        decimal x = 0m;
        if (a != 0)
        {
            x = - (b / a);
        }
        Console.WriteLine("x = {0}", x);
    }
}
