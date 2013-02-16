using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Two_integers_value_Change
{
    static void Main()
    {
        int var1, var2, buffer;
        var1 = 5;
        var2 = 10;
        buffer = var1;
        var1 = var2;
        var2 = buffer;
        Console.WriteLine("var1 = {0} \nvar2 = {1}", var1, var2);
    }
}
