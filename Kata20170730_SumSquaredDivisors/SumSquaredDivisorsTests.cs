﻿using System;
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

        [TestMethod]
        public void m_1_n_42_should_return_1_1_and_42_2500()
        {
            AssertSumSquaredDivisorsShouldBe(1, 42, "[[1, 1], [42, 2500]]");
        }

        [TestMethod]
        public void m_1_n_250_should_return_1_1_and_42_2500_and_246_84100()
        {
            AssertSumSquaredDivisorsShouldBe(1, 250, "[[1, 1], [42, 2500], [246, 84100]]");
        }

        [TestMethod]
        public void m_42_n_250_should_return_42_2500_and_246_84100()
        {
            AssertSumSquaredDivisorsShouldBe(42, 250, "[[42, 2500], [246, 84100]]");
        }

        [TestMethod]
        public void m_250_n_500_should_return_287_84100()
        {
            AssertSumSquaredDivisorsShouldBe(250, 500, "[[287, 84100]]");
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
            return $"[{string.Join(", ", SumOfSquaredDivisor(m, n))}]";
        }

        private static IEnumerable<string> SumOfSquaredDivisor(long m, long n)
        {
            for (; m <= n; m++)
            {
                var sumOfSquaredDivisor = SquaredOfDivisor(m).Sum();
                if (SumOfSquaredDivisorCouldBeSqrt(sumOfSquaredDivisor))
                {
                    yield return $"[{m}, {sumOfSquaredDivisor}]";
                }
            }
        }

        private static IEnumerable<int> SquaredOfDivisor(long m)
        {
            for (var i = 1; i <= m; i++)
            {
                if (m % i == 0)
                {
                    yield return i * i;
                }
            }
        }

        private static bool SumOfSquaredDivisorCouldBeSqrt(int sumOfSquared)
        {
            return Math.Sqrt(sumOfSquared) % 1 == 0;
        }
    }
}
