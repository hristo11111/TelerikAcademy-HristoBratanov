using System;

class ExhangeValues_simple
{
    static void Main()
    {
        Console.Write("enter first number: ");
        int first_number = int.Parse(Console.ReadLine());
        Console.Write("enter second number: ");
        int second_number = int.Parse(Console.ReadLine());
        if (first_number > second_number)
        {
            int buffer_number = second_number;
            second_number = first_number;
            first_number = buffer_number;
            Console.WriteLine("the numbers exchange their places as follow: first number is {1}, second number is {0}", second_number, first_number);
        }
        else
        {
            Console.WriteLine("the first number is < than the second");
        }
    }
}
