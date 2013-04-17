using System;

class SumOfSubset
{
    static void Main()
    {
        int num1 = 7;
        int num2 = -2;
        int num3 = 2;
        int num4 = 1;
        int num5 = -7;
        int count = -1;
        if ((num1 + num2) == 0)
        {
            Console.WriteLine("{0} + {1} = 0", num1, num2);
        }
        if ((num1 + num3) == 0)
        {
            Console.WriteLine("{0} + {1} = 0", num1, num3);
        }
        if ((num1 + num4) == 0)
        {
            Console.WriteLine("{0} + {1} = 0", num1, num4);
        }
        if ((num1 + num5) == 0)
        {
            Console.WriteLine("{0} + {1} = 0", num1, num5);
        }
        if ((num1 + num2 + num3) == 0)
        {
            Console.WriteLine("{0} + {1} + {2} = 0", num1, num2, num3);
        }
        if ((num1 + num2 + num4) == 0)
        {
            Console.WriteLine("{0} + {1} + {2} = 0", num1, num2, num4);
        }
        if ((num1 + num2 + num5) == 0)
        {
            Console.WriteLine("{0} + {1} + {2} = 0", num1, num2, num5);
        }
        if ((num1 + num3 + num4) == 0)
        {
            Console.WriteLine("{0} + {1} + {2} = 0", num1, num3, num4);
        }
        if ((num1 + num3 + num5) == 0)
        {
            Console.WriteLine("{0} + {1} + {2} = 0", num1, num3, num5);
        }
        if ((num1 + num4 + num5) == 0)
        {
            Console.WriteLine("{0} + {1} + {2} = 0", num1, num4, num5);
        }
        if ((num1 + num2 + num3 + num4) == 0)
        {
            Console.WriteLine("{0} + {1} + {2} + {3} = 0", num1, num2, num3, num4);
        }
        if ((num1 + num2 + num3 + num5) == 0)
        {
            Console.WriteLine("{0} + {1} + {2} + {3} = 0", num1, num2, num3, num5);
        }
        if ((num1 + num2 + num3 + num4 + num5) == 0)
        {
            Console.WriteLine("{0} + {1} + {2} + {3} + {4} = 0", num1, num2, num3, num4, num5);
        }
        if ((num2 + num3) == 0)
        {
            Console.WriteLine("{0} + {1} = 0", num2, num3);
        }
        if ((num2 + num4) == 0)
        {
            Console.WriteLine("{0} + {1} = 0", num2, num4);
        }
        if ((num2 + num5) == 0)
        {
            Console.WriteLine("{0} + {1} = 0", num2, num5);
        }
        if ((num2 + num3 + num4) == 0)
        {
            Console.WriteLine("{0} + {1} + {2} = 0", num2, num3, num4);
        }
        if ((num2 + num3 + num5) == 0)
        {
            Console.WriteLine("{0} + {1} + {2} = 0", num2, num3, num5);
        }
        if ((num2 + num3 + num4 + num5) == 0)
        {
            Console.WriteLine("{0} + {1} + {2} + {3} = 0", num2, num3, num4, num5);
        }
        if ((num3 + num4) == 0)
        {
            Console.WriteLine("{0} + {1} = 0", num3, num4);
        }
        if ((num3 + num5) == 0)
        {
            Console.WriteLine("{0} + {1} = 0", num3, num5);
        }
        if ((num3 + num4 + num5) == 0)
        {
            Console.WriteLine("{0} + {1} + {2} = 0", num3, num4, num5);
        }
        if ((num4 + num5) == 0)
        {
            Console.WriteLine("{0} + {1} = 0", num4, num5);
        }

    }
}
