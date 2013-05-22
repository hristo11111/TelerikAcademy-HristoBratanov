using System;

class BiggestOfThreeIntegers
{
    static void Main()
    {
        Console.WriteLine("enter first integer: ");
        int first_number = int.Parse(Console.ReadLine());
        Console.WriteLine("enter second integer: ");
        int second_number = int.Parse(Console.ReadLine());
        Console.WriteLine("enter third integer: ");
        int third_number = int.Parse(Console.ReadLine());
        if (first_number >= second_number)
        {
            if (first_number == second_number)
            {
                if (first_number >= third_number)
                {
                    if (first_number == third_number)
                    {
                        Console.WriteLine("integers {0}, {1} and {2} are equal", first_number, second_number, third_number);
                    }
                    else
                    {
                        Console.WriteLine("the biggest integer of {0}, {1} and {2} is: {0}", first_number, second_number, third_number);
                    }
                }
                else
                {
                    Console.WriteLine("the biggest integer of {0}, {1} and {2} is: {2}", first_number, second_number, third_number);
                }
            }
            else
            {
                if (first_number >= third_number)
                {
                    if (first_number == third_number)
                    {
                        Console.WriteLine("the biggest integer of {0}, {1} and {2} is: {0}", first_number, second_number, third_number);
                    }
                    else
                    {
                        Console.WriteLine("the biggest integer of {0}, {1} and {2} is: {0}", first_number, second_number, third_number);
                    }
                }
                else
                {
                    Console.WriteLine("the biggest integer of {0}, {1} and {2} is: {2}", first_number, second_number, third_number);
                }
            } 
        }
        else if (first_number < second_number)
        {
            if (second_number >= third_number)
            {
                if (second_number == third_number)
                {
                    Console.WriteLine("the biggest integer of {0}, {1} and {2} is: {1}", first_number, second_number, third_number);
                }
                else
                {
                    Console.WriteLine("the biggest integer of {0}, {1} and {2} is: {1}", first_number, second_number, third_number);
                }
            }
            else
            {
                Console.WriteLine("the biggest integer of {0}, {1} and {2} is: {2}", first_number, second_number, third_number);
            }
        }
    }
}
