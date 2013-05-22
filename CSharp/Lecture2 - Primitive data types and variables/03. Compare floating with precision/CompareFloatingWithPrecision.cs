using System;
using System.Text;

class CompareFloatingWithPrecision
{
    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;
        Console.Write("floating number1= ");
        float fl_number1 = float.Parse(Console.ReadLine());
        Console.Write("floating number2= ");
        float fl_number2 = float.Parse(Console.ReadLine());
        if (Math.Abs(fl_number1 - fl_number2) < 0.000001)
        {
            Console.WriteLine("{0} = {1}", fl_number1, fl_number2);
        }
        else
        {
            Console.WriteLine("{0} \u2260 {1}", fl_number1, fl_number2);
        }
    }
}
