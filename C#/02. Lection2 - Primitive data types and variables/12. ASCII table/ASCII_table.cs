using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class ASCII_table
{
    static void Main()
    {
        for (int i = 0; i <= 255; i++)
        {
            Console.Write("{0}: ", i);
            Console.WriteLine((char)i);
        }
    }
}
