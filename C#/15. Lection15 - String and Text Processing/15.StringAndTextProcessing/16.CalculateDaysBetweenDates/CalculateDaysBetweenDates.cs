using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Console.Write("Enter first date (day.month.year): ");
        string date1 = Console.ReadLine();
        Console.Write("Enter second date (day.month.year): ");
        string date2 = Console.ReadLine();
        int result = 0;
        bool date1IsBigger = false;
        string[] date1Arr = date1.Split('.');
        string[] date2Arr = date2.Split('.');
        Array.Reverse(date1Arr);        
        Array.Reverse(date2Arr);
        int[] date1Int = ConvertStringArrToIntArr(date1Arr);
        int[] date2Int = ConvertStringArrToIntArr(date2Arr);
        if (date1Int[0] == date2Int[0] && date1Int[1] == date2Int[1] && date1Int[1] == date2Int[2])
        {
            result = 0;
        }

        else
        {
            for (int i = 0; i < date2Int.Length; i++)
            {
                if (date1Int[i] > date2Int[i])
                {
                    date1IsBigger = true;
                    break;
                }

                else if (date1Int[i] < date2Int[i])
                {
                    date1IsBigger = false;
                    break;
                }

            }

            if (date1IsBigger == false)
            {
                result = CalculateDatesBetween(date1Int, date2Int);
            }

            else
            {
                result = CalculateDatesBetween(date2Int, date1Int);
            }

        }

        Console.WriteLine(result);
        
    }

    static int[] ConvertStringArrToIntArr(string[] arr)
    {
        int[] nums = new int[arr.Length];
        for (int i = 0; i < arr.Length; i++)
        {
            nums[i] = Int32.Parse(arr[i]);
        }

        return nums;
    }

    static int CalculateDatesBetween(int[] arr1, int[] arr2)
    {
        DateTime date2 = new DateTime(arr2[0], arr2[1], arr2[2]);
        DateTime date1 = new DateTime(arr1[0], arr1[1], arr1[2]);
        TimeSpan days = date2 - date1;
        return days.Days;
    }

}
        