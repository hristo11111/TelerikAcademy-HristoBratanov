using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            int[] array = { 2, 5, 8, 5, 2, 1, 4 };
           
            MethodAndTest.number = 5;
            MethodAndTest.CountTheElements(array);
            Assert.AreEqual(2, MethodAndTest.result);

            MethodAndTest.result = 0;
        }

        [TestMethod]
        public void TestMethod2()
        {
            int[] array = { 2, 2, 1, 1, 2, 1, 4 };
            MethodAndTest.number = 2;
            MethodAndTest.CountTheElements(array);
            Assert.AreEqual(3, MethodAndTest.result);

            MethodAndTest.result = 0;
        }

        
    }
}
