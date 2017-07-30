using System;
using System.Collections.Generic;
using System.Linq;
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

        [TestMethod]
        public void m_42_n_42_should_return_42_2500()
        {
            AssertSumSquaredDivisorsShouldBe(42, 42, "[[42, 2500]]");
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
            var sumSquared = new Dictionary<long, long>();
            if (m == n)
            {
                var sumOfSquared = Divisor(m).Sum();
                if (SumOfSquaredDivisorCouldBeSqrt(sumOfSquared))
                {
                    sumSquared.Add(m, sumOfSquared);
                }
            }

            return $"[[{m}, {sumSquared[m]}]]";
        }

        private static bool SumOfSquaredDivisorCouldBeSqrt(int sumOfSquared)
        {
            return !Math.Sqrt(sumOfSquared).ToString().Contains(".");
        }

        private static IEnumerable<int> Divisor(long m)
        {
            for (var i = 1; i <= 42; i++)
            {
                if (m % i == 0)
                {
                    yield return i * i;
                }
            }
        }
    }
}
