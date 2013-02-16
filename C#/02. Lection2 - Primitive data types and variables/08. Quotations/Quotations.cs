using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Quotations
{
    static void Main()
    {
        string quotations1 = "The \"use\" of quotations causes difficulties";
        string quotations2 = "The " + '"' + "use" + '"' + " of quotations causes difficulties";
        Console.WriteLine(quotations1);
        Console.WriteLine(quotations2);
    }
}
