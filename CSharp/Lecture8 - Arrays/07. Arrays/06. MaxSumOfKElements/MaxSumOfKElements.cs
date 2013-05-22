using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class MaxSumOfKElements
{
    static void Main()
    {
        Console.Write("n = ");
        int n = int.Parse(Console.ReadLine());
        int[] array = new int[n];
        int sum = 0;
        Console.WriteLine("enter {0} elements of the array: ", n);
        for (int i = 0; i < array.Length; i++)
        {
            array[i] = int.Parse(Console.ReadLine());
        }
        Console.Write("k = ");
        int k = int.Parse(Console.ReadLine());
        Array.Sort(array);
        for (int i = array.Length-1; i >= array.Length - k; i--)
        {
            sum = sum + array[i];
        }
        Console.WriteLine(sum);
    }
}
