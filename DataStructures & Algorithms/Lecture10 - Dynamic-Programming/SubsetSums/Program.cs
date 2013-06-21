using System;

// This is not part of the homework.

class Program
{
    const int OFFSET = 20;

    static int[] possible = new int[OFFSET + OFFSET];

    static void Main()
    {
        int[] nums = new int[] { 2, 7, -3 };
        int maxPos = nums[0];
        int minPos = nums[0];

        for (int i = 0; i < nums.Length; i++)
        {
            int[] newPossible = new int[OFFSET + OFFSET];
            int newMaxPos = maxPos;
            int newMinPos = minPos;

            for (int j = maxPos; j >= minPos; j--)
            {
                if (possible[j + OFFSET] == 1)
                {
                    newPossible[j + nums[i] + OFFSET] = 1;
                }

                if (nums[i] + j > newMaxPos)
                {
                    newMaxPos = nums[i] + j;
                }

                if (nums[i] - j < newMinPos)
                {
                    newMinPos = nums[i] + j;
                }
            }

            maxPos = newMaxPos;
            minPos = newMinPos;

            for (int j = maxPos; j >= minPos; j--)
            {
                if (newPossible[j + OFFSET] == 1)
                {
                    possible[j + OFFSET] = 1;
                }
            }

            if (nums[i] > maxPos)
            {
                maxPos = nums[i];
            }

            if (nums[i] < minPos)
            {
                minPos = nums[i];
            }

            possible[nums[i] + OFFSET] = 1;
        }
    }
}