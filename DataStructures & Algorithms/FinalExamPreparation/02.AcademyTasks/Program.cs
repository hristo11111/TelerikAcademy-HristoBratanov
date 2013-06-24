using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        string[] inputs = Console.ReadLine().Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);

        int[] pleasentness = new int[inputs.Length];
        for (int i = 0; i < inputs.Length; i++)
        {
            pleasentness[i] = int.Parse(inputs[i]);
        }
        
        int variety = int.Parse(Console.ReadLine());

        int res = pleasentness.Length;
        for (int i = 0; i < pleasentness.Length; i++)
        {
            for (int j = i + 1; j < pleasentness.Length; j++)
            {
                if (Math.Abs(pleasentness[i] - pleasentness[j]) < variety)
                {
                    continue;
                }

                int newRes = j / 2 + j % 2 + 1;
                res = Math.Min(res, newRes);
            }
        }

        Console.WriteLine(res);
    }
}
