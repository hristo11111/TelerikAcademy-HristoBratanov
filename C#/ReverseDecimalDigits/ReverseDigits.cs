using System;

class ReverseDigits
{
    static void Main()
    {
        ReverseDecimal(decimal.Parse(Console.ReadLine()));
    }
    static void ReverseDecimal(decimal number)
    {
        string numberString = number.ToString();        //convert the input in string
        char[] numberChar = numberString.ToCharArray(); // then convert the string to array of chars
        char[] reversedNumberChar = new char[numberChar.Length];
        for (int i = 0; i < numberChar.Length; i++)             // reverse the array of chars
        {
            reversedNumberChar[numberChar.Length - i -1] = numberChar[i];
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
}
