using System;
using System.Diagnostics;
using System.Linq;

class ComparePerformance2
{
    static void Main()
    {
        double result;
        //performance of square root
        Console.WriteLine("Performance of square root:");
        //float
        float floatNum = 1f;
        
        Stopwatch sw = new Stopwatch();
        sw.Start();

        result = Math.Sqrt(floatNum);

        sw.Stop();
        Console.WriteLine(sw.Elapsed + "(float)");

        //double
        double doubleNum = 1;
        sw.Start();

        result = Math.Sqrt(doubleNum);

        sw.Stop();
        Console.WriteLine(sw.Elapsed + "(double)");

        //decimal
        decimal decimalNum = 1m;
        sw.Start();

        result = Math.Sqrt((double)decimalNum);

        sw.Stop();
        Console.WriteLine(sw.Elapsed + "(decimal)");
        Console.WriteLine();

        //performance of square root
        Console.WriteLine("Performance of natural logarithm:");
        //float
        floatNum = 1f;

        sw.Start();

        result = Math.Log(floatNum);

        sw.Stop();
        Console.WriteLine(sw.Elapsed + "(float)");

        //double
        doubleNum = 1;
        sw.Start();

        result = Math.Log(doubleNum);

        sw.Stop();
        Console.WriteLine(sw.Elapsed + "(double)");

        //decimal
        decimalNum = 1m;
        sw.Start();

        result = Math.Log((double)decimalNum);

        sw.Stop();
        Console.WriteLine(sw.Elapsed + "(decimal)");
        Console.WriteLine();

        //performance of sin
        Console.WriteLine("Performance of square root:");
        //float
        floatNum = 1f;

        sw.Start();

        result = Math.Sin(floatNum);

        sw.Stop();
        Console.WriteLine(sw.Elapsed + "(float)");

        //double
        doubleNum = 1;
        sw.Start();

        result = Math.Sin(doubleNum);

        sw.Stop();
        Console.WriteLine(sw.Elapsed + "(double)");

        //decimal
        decimalNum = 1m;
        sw.Start();

        result = Math.Sin((double)decimalNum);

        sw.Stop();
        Console.WriteLine(sw.Elapsed + "(decimal)");
    }
}
