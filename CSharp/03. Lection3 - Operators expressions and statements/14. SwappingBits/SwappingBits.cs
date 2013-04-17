using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class SwappingBits
{
    static void Main()
    {
        Console.Write("the unsigned 32bit integer number is = ");
        uint number = uint.Parse(Console.ReadLine());
        Console.WriteLine("the binary of " + number + "is = " + Convert.ToString(number, 2).PadLeft(32, '0'));
        Console.Write("enter p = ");
        byte p = byte.Parse(Console.ReadLine());
        Console.Write("enter q, (q>p; q+n <= 32) = ");
        byte q = byte.Parse(Console.ReadLine());
        Console.Write("number of bits to swap, n = ");
        byte n = byte.Parse(Console.ReadLine());
        uint mask = (((number >> p) ^ (number >> q)) & ((1U << n) - 1));
        uint result = number ^ ((mask << p) | (mask << q));
        Console.WriteLine("the number after swapping is = {0}", result);
        Console.WriteLine("the binary of " + number + "is = " + Convert.ToString(result, 2).PadLeft(32, '0'));
    }
}
