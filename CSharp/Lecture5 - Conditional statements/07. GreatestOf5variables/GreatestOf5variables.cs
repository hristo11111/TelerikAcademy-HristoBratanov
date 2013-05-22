using System;

class GreatestOf5variables
{
    static void Main()
    {
        Console.WriteLine("enter first variable: ");
        double num1 = Single.Parse(Console.ReadLine());
        Console.WriteLine("enter second variable: ");
        double num2 = Single.Parse(Console.ReadLine());
        Console.WriteLine("enter third variable: ");
        double num3 = Single.Parse(Console.ReadLine());
        Console.WriteLine("enter fourth variable: ");
        double num4 = Single.Parse(Console.ReadLine());
        Console.WriteLine("enter fifth variable: ");
        double num5 = Single.Parse(Console.ReadLine());
        double greatestOf1_2 = Math.Max(num1, num2);
        double greatestOf3_4 = Math.Max(num3, num4);
        if (greatestOf1_2 >= greatestOf3_4)
        {
            if (greatestOf1_2 == greatestOf3_4)
            {
                if (greatestOf1_2 >= num5)
                {
                    if (greatestOf1_2 == num5)
                    {
                        Console.WriteLine("variables greatest number is {0}", num5);
                    }
                    else
                    {
                        Console.WriteLine("the greatest variable of {1}, {2}, {3}, {4} and {5} is: {0}", greatestOf1_2, num1, num2, num3, num4, num5);
                    }
                }
                else
                {
                    Console.WriteLine("the greatest variable of {0}, {1}, {2}, {3} and {4} is: {4}", num1, num2, num3, num4, num5);
                }
            }
            else
            {
                if (greatestOf1_2 >= num5)
                {
                    if (greatestOf1_2 == num5)
                    {
                        Console.WriteLine("the greatest variable of {1}, {2}, {3}, {4} and {5} is: {0}", greatestOf1_2, num1, num2, num3, num4, num5);
                    }
                    else
                    {
                        Console.WriteLine("the greatest variable of {1}, {2}, {3}, {4} and {5} is: {0}", greatestOf1_2, num1, num2, num3, num4, num5);
                    }
                }
                else
                {
                    Console.WriteLine("the greatest variable of {0}, {1}, {2}, {3} and {4} is: {4}", num1, num2, num3, num4, num5);
                }
            }
        }
        else if (greatestOf1_2 < greatestOf3_4)
        {
            if (greatestOf3_4 >= num5)
            {
                if (greatestOf3_4 == num5)
                {
                    Console.WriteLine("the greatest variable of {0}, {1}, {2}, {3} and {4} is: {5}", num1, num2, num3, num4, num5, greatestOf3_4);
                }
                else
                {
                    Console.WriteLine("the greatest variable of {0}, {1}, {2}, {3} and {4} is: {5}", num1, num2, num3, num4, num5, greatestOf3_4);
                }
            }
            else
            {
                Console.WriteLine("the greatest variable of {0}, {1}, {2}, {3} and {4} is: {4}", num1, num2, num3, num4, num5);
            }
        }

    }
}