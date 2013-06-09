//Write a method that finds the longest subsequence of equal numbers in 
//given List<int> and returns the result as new List<int>. Write a program 
//to test whether the method works correctly.

using System;
using System.Collections.Generic;
using System.Linq;

//see the test in TestLongestSubsequence project
class LongestSubsequence
{
    static void Main()
    {
        SequenceOperationsEngine engine = new SequenceOperationsEngine();
        List<int> sequence = new List<int>() { 4, 5, 1, 2, 2, 2, 1, 3, 5, 1, 5 };

        List<int> subsequence = engine.FindSubsequence(sequence);

        if (subsequence.Count > 0)
        {
            Console.WriteLine(engine.SequenceToString(subsequence));
        }
        else
        {
            Console.WriteLine("There is no such subsequence bigger than 1 element.");
        }
    }
}
