using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Solutions.Tests
{
    [TestFixture]
    public class Problem4Tests
    {
        [TestCaseSource(typeof(TestCaseDataProvider), nameof(TestCaseDataProvider.ProvideArraysWithMedian))]
        public void FindMedian_TwoSameArrays_MedianOfSingleReturned(int[] array, double expectedResult)
        {
            var result = Problem4.FindMedianOfSortedArrays(array, array);
            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [TestCase(true)]
        [TestCase(false)]
        public void FindMedian_OneArrayIsEmpty_MedianOfOtherReturned(bool invertOrder)
        {
            var firstArray = new[] {1, 2, 3};
            var secondArray = Array.Empty<int>();
            if (invertOrder)
            {
                (firstArray, secondArray) = (secondArray, firstArray);
            }

            var result = Problem4.FindMedianOfSortedArrays(firstArray, secondArray);
            Assert.That(result, Is.EqualTo(2));
        }

        [Test]
        public void FindMedian_OneSortedArrayInsideAnother_MedianReturned()
        {
            var firstArray = new[] {1, 2, 5};
            var secondArray = new[] {3, 4};

            var result = Problem4.FindMedianOfSortedArrays(firstArray, secondArray);
            Assert.That(result, Is.EqualTo(3));
        }

        [Test]
        public void FindMedian_OneSortedArrayAfterAnother_MedianReturned()
        {
            var firstArray = new[] {1, 2};
            var secondArray = new[] {3, 4};

            var result = Problem4.FindMedianOfSortedArrays(firstArray, secondArray);
            Assert.That(result, Is.EqualTo(3));
        }
        
        private static class TestCaseDataProvider
        {
            public static IEnumerable<TestCaseData> ProvideArraysWithMedian()
            {
                yield return new TestCaseData(new[] {1}, 1);
                yield return new TestCaseData(new[] {2}, 2);
                yield return new TestCaseData(new[] {1, 2}, 1.5);
                yield return new TestCaseData(new[] {2, 3}, 2.5);
                yield return new TestCaseData(new[] {1, 2, 3}, 2);
                yield return new TestCaseData(new[] {2, 3, 4}, 3);
            }
        }
    }
}