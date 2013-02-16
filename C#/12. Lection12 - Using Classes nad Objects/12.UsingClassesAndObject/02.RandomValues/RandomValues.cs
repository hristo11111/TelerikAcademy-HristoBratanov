using System;

class RandomValues
{
    static void Main()
    {
        Random randomNumber = new Random();
        for (int i = 0; i < 10; i++)
        {
            int number = randomNumber.Next(0,101);
            Console.WriteLine(number + 100);
        }
    }
}
