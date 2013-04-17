using System;
using System.Collections.Generic;

class CheckBrackets
{
    static void Main()
    {
        string input = Console.ReadLine();
        bool isCorrect = true;
        int countOpenBracket = 0;
        int countCloseBracket = 0;
        for (int i = 0; i < input.Length; i++)
        {
            if (input[i] == ('('))
            {
                countOpenBracket++;
            }

            else if (input[i] == (')'))
            {
                countCloseBracket++;
            }

            if (countCloseBracket > countOpenBracket)
            {
                isCorrect = false;
                break;
            }

        }

        if (countCloseBracket != countOpenBracket)
        {
            isCorrect = false;
        }

        if (isCorrect == false)
        {
            Console.WriteLine("incorect brackets input");
        }

        else
        {
            Console.WriteLine("correct brackets input");
        }

    }
}
