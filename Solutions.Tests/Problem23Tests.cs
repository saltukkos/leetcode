using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Solutions.Tests
{
    [TestFixtureSource(nameof(FixtureArgs))]
    public sealed class Problem23Tests
    {
        private readonly Func<Problem23.ListNode?[], Problem23.ListNode?> _testImplementation;

        public Problem23Tests(Func<Problem23.ListNode?[], Problem23.ListNode?> testImplementation)
        {
            _testImplementation = testImplementation;
        }

        public static object[] FixtureArgs =
        {
            Problem23.MergeListsCascade,
            Problem23.MergeListsLinear,
        };

        [Test]
        public void Merge_EmptyArray_ReturnsNullNode()
        {
            var input = Array.Empty<Problem23.ListNode>();
            var result = _testImplementation.Invoke(input);
            Assert.That(result, Is.Null);
        }

        [Test]
        public void Merge_ArrayWithNulls_ReturnsNullNode()
        {
            var input = new Problem23.ListNode?[] {null, null, null};
            var result = _testImplementation.Invoke(input);
            Assert.That(result, Is.Null);
        }

        [Test]
        public void Merge_TwoSortedLists_ReturnsSortedList()
        {
            var input = new[]
            {
                Problem23.ListNode.From(new[] {1, 5, 9}),
                Problem23.ListNode.From(new[] {2, 6, 8}),
            };

            var result = _testImplementation.Invoke(input);

            Assert.That(ToList(result), Is.EqualTo(new[] {1, 2, 5, 6, 8, 9}));
        }

        [Test]
        public void Merge_FiveListsWithNullsAndRepeats_ReturnsSortedList()
        {
            var input = new[]
            {
                Problem23.ListNode.From(new[] {1, 5, 9, 11}),
                Problem23.ListNode.From(new[] {2, 2, 6, 8}),
                null,
                null,
                Problem23.ListNode.From(new[] {4, 11, 15}),
                null,
                null,
                null,
                Problem23.ListNode.From(new[] {23, 23, 25}),
                null,
                Problem23.ListNode.From(new[] {1, 2, 3, 4, 5, 8, 8, 11, 11, 15}),
            };

            var result = _testImplementation.Invoke(input);

            Assert.That(ToList(result), Is.EqualTo(new[]
            {
                1, 1, 2, 2, 2, 3, 4, 4, 5, 5, 6, 8, 8, 8, 9, 11, 11, 11, 11, 15, 15, 23, 23, 25
            }));
        }

        private static IReadOnlyList<int> ToList(Problem23.ListNode? node)
        {
            var result = new List<int>();
            while (node != null)
            {
                result.Add(node.val);
                node = node.next;
            }

            return result;
        }
    }
}