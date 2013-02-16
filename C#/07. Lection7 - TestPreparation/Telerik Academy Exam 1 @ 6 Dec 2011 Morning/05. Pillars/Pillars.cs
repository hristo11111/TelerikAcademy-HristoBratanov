using System;

class Pillars
{
    static void Main()
    {
        //int num0 = 0;
        //int num1 = 64;
        //int num2 = 0;
        //int num3 = 8;
        //int num4 = 0;
        //int num5 = 12;
        //int num6 = 224;
        //int num7 = 0;
        int coll0Sum = 0;
        int coll1Sum = 0;
        int coll2Sum = 0;
        int coll3Sum = 0;
        int coll4Sum = 0;
        int coll5Sum = 0;
        int coll6Sum = 0;
        int coll7Sum = 0;
        for (int i = 0; i < 8; i++)
        {
            int number = int.Parse(Console.ReadLine());
            for (int coll = 0; coll < 8; coll++)
            {
                
                int cell = (number >> coll) & 1;
                switch (coll)
                {
                    case 0: coll0Sum = coll0Sum + cell; break;
                    case 1: coll1Sum = coll1Sum + cell; break;
                    case 2: coll2Sum = coll2Sum + cell; break;
                    case 3: coll3Sum = coll3Sum + cell; break;
                    case 4: coll4Sum = coll4Sum + cell; break;
                    case 5: coll5Sum = coll5Sum + cell; break;
                    case 6: coll6Sum = coll6Sum + cell; break;
                    case 7: coll7Sum = coll7Sum + cell; break;
                }
            }
        }
        int copyOfSum0 = coll0Sum;
        int copyOfSum1 = coll1Sum;
        int copyOfSum2 = coll2Sum;
        int copyOfSum3 = coll3Sum;
        int copyOfSum4 = coll4Sum;
        int copyOfSum5 = coll5Sum;
        int copyOfSum6 = coll6Sum;
        int copyOfSum7 = coll7Sum;
        coll7Sum = 0;
        if ((coll0Sum + coll1Sum + coll2Sum + coll3Sum + coll4Sum + coll5Sum + coll6Sum) == 0)
        {
            Console.WriteLine("7");
            Console.WriteLine("0");
        }
        else
        {
            coll7Sum = copyOfSum7;
            coll6Sum = 0;
            if (coll7Sum == (coll0Sum + coll1Sum + coll2Sum + coll3Sum + coll4Sum + coll5Sum))
            {
                Console.WriteLine("6");
                Console.WriteLine(coll7Sum);
                coll6Sum = copyOfSum6;
            }
            else
            {
                coll6Sum = copyOfSum6;
                coll5Sum = 0;
                if ((coll7Sum + coll6Sum) == (coll0Sum + coll1Sum + coll2Sum + coll3Sum + coll4Sum))
                {
                    Console.WriteLine("5");
                    Console.WriteLine(coll7Sum + coll6Sum);
                    coll5Sum = copyOfSum5;
                }
                else
                {
                    coll5Sum = copyOfSum5;
                    coll4Sum = 0;
                    if ((coll7Sum + coll6Sum + coll5Sum) == (coll3Sum + coll2Sum + coll1Sum + coll0Sum))
                    {
                        Console.WriteLine("4");
                        Console.WriteLine(coll7Sum + coll6Sum + coll5Sum);
                        coll4Sum = copyOfSum4;
                    }
                    else
                    {
                        coll4Sum = copyOfSum4;
                        coll3Sum = 0;
                        if ((coll7Sum + coll6Sum + coll5Sum + coll4Sum) == (coll2Sum + coll1Sum + coll0Sum))
                        {
                            Console.WriteLine("3");
                            Console.WriteLine(coll7Sum + coll6Sum + coll5Sum + coll4Sum);
                        }
                        else
                        {
                            coll3Sum = copyOfSum3;
                            coll2Sum = 0;
                            if ((coll7Sum + coll6Sum + coll5Sum + coll4Sum + coll3Sum) == (coll1Sum + coll0Sum))
                            {
                                Console.WriteLine("2");
                                Console.WriteLine(coll1Sum + coll0Sum);
                            }
                            else
                            {
                                coll2Sum = copyOfSum2;
                                coll1Sum = 0;
                                if ((coll7Sum + coll6Sum + coll5Sum + coll4Sum + coll3Sum + coll2Sum) == coll0Sum)
                                {
                                    Console.WriteLine("1");
                                    Console.WriteLine(coll0Sum);
                                }
                                else
                                {
                                    coll1Sum = copyOfSum1;
                                    coll0Sum = 0;
                                    if ((coll1Sum + coll2Sum + coll3Sum + coll4Sum + coll5Sum + coll6Sum + coll7Sum) == 0)
                                    {
                                        Console.WriteLine("0");
                                        Console.WriteLine("0");
                                    }
                                    else
                                    {
                                        Console.WriteLine("No");
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        
    }
}
