using System;

class TryParse_Int_Single_String
{
    static void Main()
    {
        int int_number;
        double double_number;
        string some_string;
        Console.WriteLine("for integer press \"1\"");
        Console.WriteLine("for double press \"2\"");
        Console.WriteLine("for string press \"3\"");
        byte pressed_number = byte.Parse(Console.ReadLine());
        switch (pressed_number)
        {
            case 1: 
                {
                    Console.WriteLine("please enter integer");
                    int_number = int.Parse(Console.ReadLine());
                    Console.WriteLine(int_number + 1);
                    break;
                }
            case 2:
                {
                    Console.WriteLine("please enter double");
                    double_number = double.Parse(Console.ReadLine());
                    Console.WriteLine(double_number + 1);
                    break;
                }
            case 3:
                {
                    Console.WriteLine("please enter string");
                    some_string = Console.ReadLine();
                    Console.WriteLine(some_string + '*');
                    break;
                }
            default : 
                Console.WriteLine("you have pressed incorrect key");
                break;
        }
    }
}
