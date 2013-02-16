using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class FebunachiSequence
{
    static void Main()
    {
        int x = -1;
        int y = 1;
        int result;
        for (int i = 0; i < 100; i++)
        {
            result = x + y;
            x = y;
            y = result;
            Console.Write("{0}, ", result);
        }
    }
}
