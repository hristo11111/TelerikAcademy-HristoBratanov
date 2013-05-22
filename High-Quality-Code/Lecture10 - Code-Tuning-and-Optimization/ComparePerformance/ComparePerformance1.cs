using System;
using System.Diagnostics;
using System.Linq;

class ComparePerformance1
{
    static void Main()
    {
        //performance of add
        Console.WriteLine("Performance of add:");
        //int
        int intNum = 1;
        Stopwatch sw = new Stopwatch();
        sw.Start();

        intNum = intNum + 2;

        sw.Stop();
        Console.WriteLine(sw.Elapsed + "(int)");

        //long
        long longNum = 1;
        sw.Start();

        longNum = longNum + 2;

        sw.Stop();
        Console.WriteLine(sw.Elapsed + "(long)");

        //float
        float floatNum = 1f;
        sw.Start();

        floatNum = floatNum + 2;

        sw.Stop();
        Console.WriteLine(sw.Elapsed + "(float)");

        //double
        double doubleNum = 1;
        sw.Start();

        doubleNum = doubleNum + 2;

        sw.Stop();
        Console.WriteLine(sw.Elapsed + "(double)");

        //decimal
        decimal decimalNum = 1m;
        sw.Start();

        decimalNum = decimalNum + 2;

        sw.Stop();
        Console.WriteLine(sw.Elapsed + "(decimal)");
        Console.WriteLine();

        //performance of substract
        Console.WriteLine("Performance of substract:");
        //int
        intNum = 1;
        sw.Start();

        intNum = intNum - 2;

        sw.Stop();
        Console.WriteLine(sw.Elapsed + "(int)");

        //long
        longNum = 1;
        sw.Start();

        longNum = longNum - 2;

        sw.Stop();
        Console.WriteLine(sw.Elapsed + "(long)");

        //float
        floatNum = 1;
        sw.Start();

        floatNum = floatNum - 2;

        sw.Stop();
        Console.WriteLine(sw.Elapsed + "(float)");

        //double
        doubleNum = 1;
        sw.Start();

        doubleNum = doubleNum - 2;

        sw.Stop();
        Console.WriteLine(sw.Elapsed + "(double)");

        //decimal
        decimalNum = 1m;
        sw.Start();

        decimalNum = decimalNum - 2;

        sw.Stop();
        Console.WriteLine(sw.Elapsed + "(decimal)");
        Console.WriteLine();

        //performance of increment
        Console.WriteLine("Performance of increment:");
        //int
        intNum = 1;
        sw.Start();

        intNum++;

        sw.Stop();
        Console.WriteLine(sw.Elapsed + "(int)");

        //long
        longNum = 1;
        sw.Start();

        longNum++;

        sw.Stop();
        Console.WriteLine(sw.Elapsed + "(long)");

        //float
        floatNum = 1;
        sw.Start();

        floatNum++;

        sw.Stop();
        Console.WriteLine(sw.Elapsed + "(float)");

        //double
        doubleNum = 1;
        sw.Start();

        doubleNum++;

        sw.Stop();
        Console.WriteLine(sw.Elapsed + "(double)");

        //decimal
        decimalNum = 1m;
        sw.Start();

        decimalNum++;

        sw.Stop();
        Console.WriteLine(sw.Elapsed + "(decimal)");
        Console.WriteLine();

        //performance of multiply
        Console.WriteLine("Performance of multiply:");
        //int
        intNum = 1;
        sw.Start();

        intNum = intNum * intNum;

        sw.Stop();
        Console.WriteLine(sw.Elapsed + "(int)");

        //long
        longNum = 1;
        sw.Start();

        longNum = longNum * longNum;

        sw.Stop();
        Console.WriteLine(sw.Elapsed + "(long)");

        //float
        floatNum = 1;
        sw.Start();

        floatNum = floatNum * floatNum;

        sw.Stop();
        Console.WriteLine(sw.Elapsed + "(float)");

        //double
        doubleNum = 1;
        sw.Start();

        doubleNum = doubleNum * doubleNum;

        sw.Stop();
        Console.WriteLine(sw.Elapsed + "(double)");

        //decimal
        decimalNum = 1m;
        sw.Start();

        decimalNum = decimalNum * decimalNum;

        sw.Stop();
        Console.WriteLine(sw.Elapsed + "(decimal)");
        Console.WriteLine();

        //performance of divide
        Console.WriteLine("Performance of divide:");
        //int
        intNum = 1;
        sw.Start();

        intNum = intNum / intNum;

        sw.Stop();
        Console.WriteLine(sw.Elapsed + "(int)");

        //long
        longNum = 1;
        sw.Start();

        longNum = longNum / longNum;

        sw.Stop();
        Console.WriteLine(sw.Elapsed + "(long)");

        //float
        floatNum = 1;
        sw.Start();

        floatNum = floatNum / floatNum;

        sw.Stop();
        Console.WriteLine(sw.Elapsed + "(float)");

        //double
        doubleNum = 1;
        sw.Start();

        doubleNum = doubleNum / doubleNum; ;

        sw.Stop();
        Console.WriteLine(sw.Elapsed + "(double)");

        //decimal
        decimalNum = 1m;
        sw.Start();

        decimalNum = decimalNum / decimalNum;

        sw.Stop();
        Console.WriteLine(sw.Elapsed + "(decimal)");

    }
}
