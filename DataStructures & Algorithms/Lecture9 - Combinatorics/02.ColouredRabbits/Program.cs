using System;
using System.Linq;

class Program
{
    // 100/100 in bgcoder if system is not overloaded 
    // http://bgcoder.com/Contest/Practice/59

    static void Main()
    {
        int rabbitCount = int.Parse(Console.ReadLine());

        int[] rabbits = new int[10000001];
        for (int i = 1; i <= rabbitCount; i++)
        {
            int answer = int.Parse(Console.ReadLine());
            rabbits[answer]++; 
        }


        double sum = 0;
        for (int i = 0; i < rabbits.Length; i++)
        {
            double ceil = (double)Math.Ceiling((double)rabbits[i] / (i + 1));
            sum = sum + (i + 1) * ceil;
        }

        Console.WriteLine(sum);
    }
}
