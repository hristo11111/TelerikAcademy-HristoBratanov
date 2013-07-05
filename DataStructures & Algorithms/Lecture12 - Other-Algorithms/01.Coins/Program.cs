using System;
using System.Collections.Generic;

class Coins
{
    static int[] coinsTypes = new int[] { 1, 2, 5 };

    static void Main()
    {
        Console.Write("Enter sum: ");
        long sumOfCoins = long.Parse(Console.ReadLine());
        List<int> coins = GetCoinsWithSum(sumOfCoins);
        if (coins.Count > 0)
        {
            Console.WriteLine("Coins: {0}", string.Join(" + ", coins));
        }
        else
        {
            Console.WriteLine("No such sum");
        }
    }

    static List<int> GetCoinsWithSum(long sumOfCoins)
    {
        List<int> coins = new List<int>();
        long currentSumOfCoins = 0;
        long newSum = 0;
        do
        {
            for (int i = coinsTypes.Length - 1; i >= 0; i--)
            {
                newSum = currentSumOfCoins + coinsTypes[i];
                if (newSum < sumOfCoins)
                {
                    coins.Add(coinsTypes[i]);
                    currentSumOfCoins = newSum;
                    break;
                }
                else if (newSum == sumOfCoins)
                {
                    coins.Add(coinsTypes[i]);
                    return coins;
                }
            }
        }
        while (currentSumOfCoins == newSum);

        coins.Clear();
        return coins;
    }
}