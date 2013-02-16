using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Null_type
{
    static void Main()
    {
        double? null_double = null;
        Console.WriteLine(null_double);
        null_double = 5.22;
        Console.WriteLine(null_double);
        int? null_int = null;
        Console.WriteLine(null_int);
        null_int = 556;
        Console.WriteLine(null_int);
    }
}
