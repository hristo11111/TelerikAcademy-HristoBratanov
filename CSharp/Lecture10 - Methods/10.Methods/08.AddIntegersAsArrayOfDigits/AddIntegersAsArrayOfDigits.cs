using System;
using System.Collections.Generic;

class AddIntegersAsArrayOfDigits
{
    static void Main()
    {
        List<int> number1 = new List<int>{ 1,3,0,6,9,4,8,9,2,4,5 };     //reversed {5,4,2,9,8,4,9,6,0,3,1}
        List<int> number2 = new List<int>{ 9,8,9,4,1,0,7};              //reversed {7,0,1,4,9,8,9}
        List<int> result = IntegersAsArraysOfDigits(number1, number2);  //result {1,2,4,4,4,8,3,8,6,0,3,1}
        PrintArray(result);
    }

    static List<int> IntegersAsArraysOfDigits(List<int> arr1, List<int> arr2)
    {
        bool additionalDigit = false;
        List<int> reversedArr1 = new List<int>();
        List<int> reversedArr2 = new List<int>();
        List<int> concArray = new List<int>();
        int additionalValue = 0;
        reversedArr1 = ReverseArray(arr1);
        reversedArr2 = ReverseArray(arr2);
        int countArr1 = reversedArr1.Count;
        int countArr2 = reversedArr2.Count;
        if (countArr1 > countArr2)
        {
            for (int i = countArr1-countArr2-1; i < countArr1; i++)
            {
                reversedArr2.Add(0);
            }
        }
        else
        {
            for (int i = countArr2 - countArr1 - 1; i < countArr2; i++)
            {
                reversedArr1.Add(0);
            }
        }
        for (int i = 0; i < countArr1; i++)
        {
            concArray.Add(0);
        }
        for (int i = countArr1-1; i >= 0; i--)
        {
            if (i == 0)
            {
                concArray[0] = additionalValue + (reversedArr1[i] + reversedArr2[i]) % 10;
                if ((reversedArr1[i] + reversedArr2[i]) >= 10)
                {
                    additionalDigit = true;
                }
            }
            else
            {
                int sum = 0;
                int addedValue = 0;
                if (reversedArr1[i] + reversedArr2[i] >= 10)
                {
                    sum = (reversedArr1[i] + reversedArr2[i]) % 10;
                    addedValue = 1;
                }
                else
                {
                    sum = reversedArr1[i] + reversedArr2[i];
                }
                concArray[i] = concArray[i] + sum;
                if (concArray[i] == 10)
                {
                    concArray[i] = 0;
                    addedValue = 1;
                }
                concArray[i - 1] = concArray[i - 1] + addedValue;
            }
        }
        if (additionalDigit == true)
        {
            concArray.Add(0);
            for (int i = concArray.Count-2; i >=0 ; i--)
            {
                concArray[i+1] = concArray[i];
            }
            concArray[0] = 1;
        }
        return concArray;
    }

    static List<int> ReverseArray(List<int> arr)
    {
        List<int> reversed = new List<int>();
        for (int i = 0; i < arr.Count; i++)
        {
            reversed.Add(arr[arr.Count - 1 - i]);
        }
        return reversed;
    }

    static int ReturnMinLengthOfTwoArrays(int[] arr1, int[] arr2)
    {
        if (arr1.Length < arr2.Length)
        {
            return arr1.Length;
        }
        else
        {
            return arr2.Length;
        }
    }

    static void PrintArray(List<int> arr)
    {
        for (int i = 0; i < arr.Count; i++)
		{
            Console.Write(arr[i]); 
		}
        Console.WriteLine();
    }
}
