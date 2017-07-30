using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Kata20170730_SumSquaredDivisors
{
    [TestClass]
    public class SumSquaredDivisorsTests
    {
        [TestMethod]
        public void m_1_n_1_should_return_1_1()
        {
            AssertSumSquaredDivisorsShouldBe(1, 1, "[[1, 1]]");
        }

        private static void AssertSumSquaredDivisorsShouldBe(long m, long n, string expected)
        {
            var sumSquaredDivisors = new SumSquaredDivisors();
            var actual = sumSquaredDivisors.listSquared(m, n);
            Assert.AreEqual(expected, actual);
        }
    }

    public class SumSquaredDivisors
    {
        public string listSquared(long m, long n)
        {
            return $"[[{m}, {n}]]";
        }
    }
}
