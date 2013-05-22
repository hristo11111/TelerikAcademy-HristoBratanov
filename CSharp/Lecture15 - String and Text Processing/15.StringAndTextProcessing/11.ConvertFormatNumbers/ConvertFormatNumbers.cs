using System;
using System.Text;

class ConvertFormatNumbers
{
    static void Main()
    {
        string num = "-2";
        Console.WriteLine("{0,15}", Int32.Parse(num));
        Console.WriteLine("{0,15:X}", Int32.Parse(num));
        Console.WriteLine("{0,15:P}", Int32.Parse(num));
        Console.WriteLine("{0,15:E}", Int32.Parse(num));
    }

}
