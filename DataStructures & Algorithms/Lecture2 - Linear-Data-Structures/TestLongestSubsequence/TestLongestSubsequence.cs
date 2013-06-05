using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace TestLongestSubsequence
{
    [TestClass]
    public class TestLongestSubsequence
    {
        [TestMethod]
        public void TestIfLongestAtTheMiddle()
        {
            List<int> sequence = new List<int>() {
                1, 1, 2, 2, 5, 5, 5, 5, 5, 6, 7, 8, 1, 2, 4, 4 };
            SequenceOperationsEngine engine = new SequenceOperationsEngine();

            List<int> subsequence = engine.FindSubsequence(sequence);
            List<int> expected = new List<int>() { 5, 5, 5, 5, 5 };

            CollectionAssert.AreEqual(expected, subsequence);
        }

        [TestMethod]
        public void TestIfLongestAtTheBeginning()
        {
            List<int> sequence = new List<int>() {
                5, 5, 5, 5, 5, 1, 1, 2, 2, 6, 7, 8, 1, 2, 4, 4 };
            SequenceOperationsEngine engine = new SequenceOperationsEngine();

            List<int> subsequence = engine.FindSubsequence(sequence);
            List<int> expected = new List<int>() { 5, 5, 5, 5, 5 };

            CollectionAssert.AreEqual(expected, subsequence);
        }

        [TestMethod]
        public void TestIfLongestAtTheEnd()
        {
            List<int> sequence = new List<int>() {
                1, 1, 2, 2, 6, 7, 8, 1, 2, 4, 4, 5, 5, 5, 5, 5 };
            SequenceOperationsEngine engine = new SequenceOperationsEngine();

            List<int> subsequence = engine.FindSubsequence(sequence);
            List<int> expected = new List<int>() { 5, 5, 5, 5, 5 };

            CollectionAssert.AreEqual(expected, subsequence);
        }

        [TestMethod]
        public void TestWhenNoRepeatableNumbers()
        {
            List<int> sequence = new List<int>() {
                1, 2, 6, 7, 8, 1, 2, 4, 5 };
            SequenceOperationsEngine engine = new SequenceOperationsEngine();

            List<int> subsequence = engine.FindSubsequence(sequence);
            List<int> expected = new List<int>() { };

            CollectionAssert.AreEqual(expected, subsequence);
        }
    }
}
