using System;

class DesceningOrderOfThreeValues
{
    static void Main()
    {
        Console.WriteLine("please enter first number: ");
        double first_number = Single.Parse(Console.ReadLine());
        Console.WriteLine("please enter second number: ");
        double second_number = Single.Parse(Console.ReadLine());
        Console.WriteLine("please enter third number: ");
        double third_number = Single.Parse(Console.ReadLine());
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
                        Console.WriteLine("the descending orders is: {0}, {1}, {2}", first_number, second_number, third_number);
                    }
                }
                else
                {
                    Console.WriteLine("the descending orders is: {2}, {0}, {1}", first_number, second_number, third_number);
                }
            }
            else
            {
                if (first_number >= third_number)
                {
                    if (first_number == third_number)
                    {
                        Console.WriteLine("the descending orders is: {0}, {2}, {1}", first_number, second_number, third_number);
                    }
                    else
                    {
                        if (third_number >= second_number)
                        {
                            Console.WriteLine("the descending orders is: {0}, {2}, {1}", first_number, second_number, third_number);
                        }
                        else
                        {
                            Console.WriteLine("the descending orders is: {0}, {1}, {2}", first_number, second_number, third_number);
                        }
                    }
                }
                else
                {
                    Console.WriteLine("the descending orders is: {2}, {0}, {1}", first_number, second_number, third_number);
                }
            }
        }
        else if (first_number < second_number)
        {
            if (second_number >= third_number)
            {
                if (second_number == third_number)
                {
                    Console.WriteLine("the descending orders is: {1}, {2}, {0}", first_number, second_number, third_number);
                }
                else
                {
                    if (third_number >= first_number)
                    {
                        Console.WriteLine("the descending orders is: {1}, {2}, {0}", first_number, second_number, third_number);
                    }
                    else
                    {
                        Console.WriteLine("the descending orders is: {1}, {0}, {2}", first_number, second_number, third_number);
                    }
                }
            }
            else
            {
                Console.WriteLine("the descending orders is: {2}, {1}, {0}", first_number, second_number, third_number);
            }
        } 
    }
}
