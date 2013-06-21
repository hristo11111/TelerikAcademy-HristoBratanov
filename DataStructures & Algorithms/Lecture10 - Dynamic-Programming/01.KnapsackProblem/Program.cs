using System;
using System.Collections.Generic;
using Wintellect.PowerCollections;

class Program
{
    static Product[] products = new Product[] { 
                                            new Product("beer", 3, 2), 
                                            new Product("vodka", 8, 12),
                                            new Product("cheese", 4, 5),
                                            new Product("nuts", 1, 4),
                                            new Product("nam", 2, 3), 
                                            new Product("whiskey", 8, 13)
                                            };

    static List<Product> bestProducts = new List<Product>();

    static void Main()
    {
        
        
        int capacity = 10;
        int[,] bestSums = new int[products.Length + 1, capacity];
        int[,] keep = new int[products.Length + 1, capacity];

        FindPossibleSums(products, bestSums, keep);

        int i = bestSums.GetLength(0) - 1;
        int j = bestSums.GetLength(1) - 1;
        ChooseBest(keep, i, j);

        int finalWeight = 0;
        int finalCost = 0;
        Console.WriteLine("Optimal solution: ");
        for (int k = 0; k < bestProducts.Count; k++)
        {
            finalWeight += bestProducts[k].Weight; 
            finalCost += bestProducts[k].Cost;
            Console.Write(bestProducts[k].Name);
            if (k != (bestProducts.Count - 1))
            {
                Console.Write(" + ");
            }
        }

        Console.WriteLine();
        Console.WriteLine("weight = {0}", finalWeight);
        Console.WriteLine("cost = {0}", finalCost);
    }

    private static void ChooseBest(int[,] keep, int i, int j)
    {
        if (i <= 0 || j < 0)
        {
            return;
        }

        if (keep[i,j] == 1)
        {
            bestProducts.Add(products[i - 1]);
            j = j - products[i - 1].Weight;
            i--;
        }
        else
        {
            i--;
        }

        ChooseBest(keep, i, j);
    }

    private static void FindPossibleSums(Product[] products, int[,] bestSums, int[,] keep)
    {
        for (int i = 1; i <= products.Length; i++)
        {
            for (int j = 1; j <= bestSums.GetLength(1); j++)
            {
                if (products[i - 1].Weight > j)
                {
                    bestSums[i, j - 1] = bestSums[i - 1, j - 1];
                    continue;
                }
                if (products[i - 1].Weight == j)
                {
                    if (products[i - 1].Cost >= bestSums[i - 1, j - 1])
                    {
                        bestSums[i, j - 1] = products[i - 1].Cost;
                        keep[i, j - 1] = 1;
                    }
                    else
                    {
                        bestSums[i, j - 1] = bestSums[i - 1, j - 1];
                    }
                }

                else if (products[i - 1].Weight < j)
                {
                    if (products[i - 1].Cost + bestSums[i - 1, j - products[i - 1].Weight - 1] > bestSums[i - 1, j - 1])
                    {
                        bestSums[i, j - 1] = products[i - 1].Cost + bestSums[i - 1, j - products[i - 1].Weight - 1];
                        keep[i, j - 1] = 1;
                    }
                    else
                    {
                        bestSums[i, j - 1] = bestSums[i - 1, j - 1];
                    }
                }
            }
        }
    }
}