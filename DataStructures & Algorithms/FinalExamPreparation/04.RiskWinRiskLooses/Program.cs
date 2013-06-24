using System;
using System.Collections.Generic;

class Program
{
    static int res = -1;
    static int bigCounter = 0;

    static void Main()
    {
        string initialCombination = Console.ReadLine();
        int[] initial = new int[initialCombination.Length];
        for (int i = 0; i < initialCombination.Length; i++)
        {
            initial[i] = initialCombination[i] - 48;
        }

        string targetCombination = Console.ReadLine();
        int[] target = new int[targetCombination.Length];
        for (int i = 0; i < targetCombination.Length; i++)
        {
            target[i] = targetCombination[i] - 48;
        }

        int forbidenCombinations = int.Parse(Console.ReadLine());
        HashSet<string> forbiden = new HashSet<string>();
        for (int i = 0; i < forbidenCombinations; i++)
        {
            forbiden.Add(Console.ReadLine());
        }

        bool reversed = false;
        int count = 0;

        for (int i = 0; i < 5; i++)
        {
            if (initial[i] == target[i])
            {   
                continue;
            }

            if (initial[i] < target[i] && Math.Abs(initial[i] - target[i]) <= 5)
	        {
                reversed = false;
                while (initial[i] != target[i])
                {
                    if (!reversed)
	                {
		                initial[i]++;
                        if (initial[i] == -1 || initial[i] == 10)
                        {
                            initial[i] = CheckAndCorrectWheelDigit(initial[i]);
                        }
                        count++;
	                }
                    else
	                {
                        initial[i]--;
                        if (initial[i] == -1 || initial[i] == 10)
                        {
                            initial[i] = CheckAndCorrectWheelDigit(initial[i]);
                        }
                        count++;
	                }
                    
                    if (CheckIfForbiden(initial, forbiden))
                    {
                        if (reversed)
	                    {
		                    Console.WriteLine(res);
                            return;
	                    }
                        else
                        {
                            initial[i] = initial[i] - count;
                            count = 0;
                        }
                    } 
                }

                bigCounter += count;
                count = 0;
	        }

            else if (initial[i] < target[i] && Math.Abs(initial[i] - target[i]) > 5)
	        {
                reversed = true;
                while (initial[i] != target[i])
                {
                    if (!reversed)
	                {
		                initial[i]++;
                        if (initial[i] == -1 || initial[i] == 10)
                        {
                            initial[i] = CheckAndCorrectWheelDigit(initial[i]);
                        }
                        count++;
	                }
                    else
	                {
                        initial[i]--;
                        if (initial[i] == -1 || initial[i] == 10)
                        {
                            initial[i] = CheckAndCorrectWheelDigit(initial[i]);
                        }
                        count++;
	                }
                    
                    if (CheckIfForbiden(initial, forbiden))
                    {
                        if (!reversed)
	                    {
		                    Console.WriteLine(res);
                            return;
	                    }
                        else
                        {
                            initial[i] = initial[i] - count;
                            count = 0;
                        }
                    } 
                }

                bigCounter += count;
                count = 0;
	        }

            else if (initial[i] > target[i] && Math.Abs(initial[i] - target[i]) <= 5)
	        {
                reversed = true;
                while (initial[i] != target[i])
                {
                    if (!reversed)
	                {
		                initial[i]++;
                        if (initial[i] == -1 || initial[i] == 10)
                        {
                            initial[i] = CheckAndCorrectWheelDigit(initial[i]);
                        }
                        count++;
	                }
                    else
	                {
                        initial[i]--;
                        if (initial[i] == -1 || initial[i] == 10)
                        {
                            initial[i] = CheckAndCorrectWheelDigit(initial[i]);
                        }
                        count++;
	                }
                    
                    if (CheckIfForbiden(initial, forbiden))
                    {
                        if (reversed)
	                    {
		                    Console.WriteLine(res);
                            return;
	                    }
                        else
                        {
                            initial[i] = initial[i] - count;
                            count = 0;
                        }
                    } 
                }

                bigCounter += count;
                count = 0;
	        }

            else if (initial[i] > target[i] && Math.Abs(initial[i] - target[i]) > 5)
	        {
                reversed = false;
                while (initial[i] != target[i])
                {
                    if (!reversed)
	                {
		                initial[i]++;
                        if (initial[i] == -1 || initial[i] == 10)
                        {
                            initial[i] = CheckAndCorrectWheelDigit(initial[i]);
                        }
                        count++;
	                }
                    else
	                {
                        initial[i]--;
                        if (initial[i] == -1 || initial[i] == 10)
                        {
                            initial[i] = CheckAndCorrectWheelDigit(initial[i]);
                        }
                        count++;
	                }
                    
                    if (CheckIfForbiden(initial, forbiden))
                    {
                        if (!reversed)
	                    {
		                    Console.WriteLine(res);
                            return;
	                    }
                        else
                        {
                            initial[i] = initial[i] - count;
                            count = 0;
                        }
                    } 
                }

                bigCounter += count;
                count = 0;
	        }
        }

        Console.WriteLine(bigCounter);
    }

    private static bool CheckIfForbiden(int[] initial, HashSet<string> forbiden)
    {
        foreach (var item in forbiden)
        {
            if (item.CompareTo(string.Join(string.Empty, initial)) == 0)
            {
                return true;
            }
        }

        return false;
    }

    private static int CheckAndCorrectWheelDigit(int digit)
    {
        if (digit == -1)
        {
            digit = 9;
        }
        else if (digit == 10)
        {
            digit = 0;
        }

        return digit;
    }
}
