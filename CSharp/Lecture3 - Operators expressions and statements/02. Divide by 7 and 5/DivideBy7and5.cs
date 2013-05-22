using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class DivideBy7and5
{
    static void Main()
    {
        bool divide;
        Console.WriteLine("enter a number: ");
        int input = int.Parse(Console.ReadLine());
        if (input % 35 == 0)
        {
            divide = true;
            Console.WriteLine("{0} is dividible by 5 and 7 at the same time without remainder: {1}", input, divide);
        }
        else
        {
            divide = false;
            Console.WriteLine("{0} is dividible by 5 and 7 at the same time without remainder: {1}", input, divide);
        }
    }
}
