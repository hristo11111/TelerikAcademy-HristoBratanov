using System;

class MathExpression
{
    static void Main()
    {
        double N = double.Parse(Console.ReadLine());
        double M = double.Parse(Console.ReadLine());
        double P = double.Parse(Console.ReadLine());
        double sum = ((double)(N * N) + 1d / (double)(M * P) + 1337d) / (N - (double)(128.523123123d * P)) + (Math.Sin((int)M % 180));
        Console.WriteLine("{0:F6}",sum);
    }
}