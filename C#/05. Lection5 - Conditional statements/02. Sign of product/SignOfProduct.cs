using System;

class SignOfProduct
{
    static void Main()
    {
        Console.WriteLine("enter first number: ");
        double first_number = Single.Parse(Console.ReadLine());
        Console.WriteLine("enter second number: ");
        double second_number = Single.Parse(Console.ReadLine());
        Console.WriteLine("enter third number: ");
        double third_number = Single.Parse(Console.ReadLine());
        if ((first_number < 0) && (second_number < 0) && (third_number < 0))
            Console.WriteLine("the product of {0}, {1} and {2} is negative", first_number, second_number, third_number);
        if ((first_number < 0) && (second_number < 0) && (third_number > 0))
            Console.WriteLine("the product of {0}, {1} and {2} is positive", first_number, second_number, third_number);
        if ((first_number < 0) && (second_number > 0) && (third_number < 0))
            Console.WriteLine("the product of {0}, {1} and {2} is positive", first_number, second_number, third_number);
        if ((first_number < 0) && (second_number > 0) && (third_number > 0))
            Console.WriteLine("the product of {0}, {1} and {2} is negative", first_number, second_number, third_number);
        if ((first_number > 0) && (second_number > 0) && (third_number > 0))
            Console.WriteLine("the product of {0}, {1} and {2} is positive", first_number, second_number, third_number);
        if ((first_number > 0) && (second_number > 0) && (third_number < 0))
            Console.WriteLine("the product of {0}, {1} and {2} is negative", first_number, second_number, third_number);
        if ((first_number > 0) && (second_number < 0) && (third_number > 0))
            Console.WriteLine("the product of {0}, {1} and {2} is negative", first_number, second_number, third_number);
        if ((first_number > 0) && (second_number < 0) && (third_number < 0))
            Console.WriteLine("the product of {0}, {1} and {2} is positive", first_number, second_number, third_number);
    }
}
