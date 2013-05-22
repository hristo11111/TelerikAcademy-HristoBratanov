using System;

class SplitString
{
    static void Main()
    {
        string sequence = "43 68 9 23 318";
        string[] arr = sequence.Split(' ');
        int[] numbers = new int[arr.Length];
        int sum = 0;
        for (int i = 0; i < arr.Length; i++)
        {
            numbers[i] = int.Parse(arr[i]);
            sum = sum + numbers[i];
        }

        Console.WriteLine(sum);
    }
}
