using System;
class myAge_after10years
{
    static void Main()
    {
        byte ten=10;
        string agenow;
        int agethen;
        Console.WriteLine("your age now is:");
        agenow = Console.ReadLine();
        byte agenow_int = Convert.ToByte(agenow);
        agethen = agenow_int + ten;
        Console.WriteLine("after 10 years you will be {0} years old", agethen);
    }
}

