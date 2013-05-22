using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

class ExchangingBits
{
    static void Main()
    {
        int bit3, bit4, bit5, bit24, bit25, bit26;
        Console.Write("the number is: ");
        int number = int.Parse(Console.ReadLine());
        string numberString = Convert.ToString(number, 2).PadLeft(32, '0');
        BigInteger numberFormated = BigInteger.Parse(numberString);
        Console.WriteLine(number + " in binary = " + "{0:0000 0000 0000 0000 0000 0000 0000 0000}", numberFormated);
        int checkBit3 = number & (1 << 3);                                  // check 3rd bit
        if (checkBit3 == 0)
        {
            bit3 = 0;
            Console.WriteLine("3rd bit is = {0}", bit3);
        }
        else
        {
            bit3 = 1;
            Console.WriteLine("3rd bit is = {0}", bit3);
        }
        int checkBit4 = number & (1 << 4);                                  // check 4th bit
        if (checkBit4 == 0)
        {
            bit4 = 0;
            Console.WriteLine("4th bit is = {0}", bit4);
        }
        else
        {
            bit4 = 1;
            Console.WriteLine("4th bit is = {0}", bit4);
        }
        int checkBit5 = number & (1 << 5);                                  // check 5th bit
        if (checkBit5 == 0)
        {
            bit5 = 0;
            Console.WriteLine("5th bit is = {0}", bit5);
        }
        else
        {
            bit5 = 1;
            Console.WriteLine("5th bit is = {0}", bit5);
        }
        int checkBit24 = number & (1 << 24);                                  // check 24th bit
        if (checkBit24 == 0)
        {
            bit24 = 0;
            Console.WriteLine("24th bit is = {0}", bit24);
        }
        else
        {
            bit24 = 1;
            Console.WriteLine("24rd bit is = {0}", bit24);
        }
        int checkBit25 = number & (1 << 25);                                  // check 25th bit
        if (checkBit25 == 0)
        {
            bit25 = 0;
            Console.WriteLine("25th bit is = {0}", bit25);
        }
        else
        {
            bit25 = 1;
            Console.WriteLine("25th bit is = {0}", bit25);
        }
        int checkBit26 = number & (1 << 26);                                  // check 26th bit
        if (checkBit26 == 0)
        {
            bit26 = 0;
            Console.WriteLine("26th bit is = {0}", bit26);
        }
        else
        {
            bit26 = 1;
            Console.WriteLine("26th bit is = {0}", bit26);
        }
        if ((bit3 != bit24) & (bit3 == 0))                                    // exchange bit3 and bit 24
        {
            number = number | (1 << 3);
            number = ~(~number | (1 << 24));
        }
        else if ((bit3 != bit24) & (bit3 == 1))
        {
            number = number | (1 << 24);
            number = ~(~number | (1 << 3));
        }
        if ((bit4 != bit25) & (bit4 == 0))                                    // exchange bit4 and bit 25
        {
            number = number | (1 << 4);
            number = ~(~number | (1 << 25));
        }
        else if ((bit4 != bit25) & (bit4 == 1))
        {
            number = number | (1 << 25);
            number = ~(~number | (1 << 4));
        }
        if ((bit5 != bit26) & (bit5 == 0))                                    // exchange bit3 and bit 26
        {
            number = number | (1 << 5);
            number = ~(~number | (1 << 26));
        }
        else if ((bit5 != bit26) & (bit5 == 1))
        {
            number = number | (1 << 26);
            number = ~(~number | (1 << 5));
        }
        Console.WriteLine("after exchanging, new number = " + number);
        string resultString = Convert.ToString(number, 2).PadLeft(32, '0');
        BigInteger resultFormated = BigInteger.Parse(resultString);
        Console.WriteLine("and its binary is = " + "{0:0000 0000 0000 0000 0000 0000 0000 0000}", resultFormated);
        
    }
}