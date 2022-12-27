using System;
using System.Text;
using NUnit.Framework;
// ReSharper disable StringLiteralTypo

namespace Solutions.Tests
{
    [TestFixture]
    public class Problem5Tests
    {
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(4)]
        public void FindLongestPalindrome_StringWithoutRepeats_ReturnOneSymbol(int length)
        {
            var targetChar = 'a';
            var stringBuilder = new StringBuilder();
            for (var i = 0; i < length; ++i)
            {
                stringBuilder.Append(targetChar++);
            }

            var input = stringBuilder.ToString();
            var result = Problem5.FindLongestPalindrome(input.AsSpan());
            
            Assert.That(result.Length, Is.EqualTo(1));
            Assert.That(input, Contains.Item(result[0]));
        }

        [Test]
        public void FindLongestPalindrome_WholeStringIsPalindromeOfEventLength_ReturnsWhole()
        {
            var input = "abccba";
            var result = Problem5.FindLongestPalindrome(input.AsSpan());
            
            Assert.That(result.ToString(), Is.EqualTo(input));
        }

        [Test]
        public void FindLongestPalindrome_WholeStringIsPalindromeOfOddLength_ReturnsWhole()
        {
            var input = "abcba";
            var result = Problem5.FindLongestPalindrome(input.AsSpan());
            
            Assert.That(result.ToString(), Is.EqualTo(input));
        }

        [TestCase(0, 1)]
        [TestCase(0, 2)]
        [TestCase(1, 0)]
        [TestCase(2, 0)]
        [TestCase(1, 1)]
        [TestCase(1, 2)]
        [TestCase(2, 1)]
        [TestCase(2, 2)]
        public void FindLongestPalindrome_PalindromeOfOddLengthInTheMiddle_ReturnsPalindrome(
            int leftAppendixLength,
            int rightAppendixLength)
        {
            var targetChar = 'd';
            var input = new StringBuilder();
            for (var i = 0; i < leftAppendixLength; ++i)
            {
                input.Append(targetChar++);
            }
            
            var palindrome = "abcba";
            input.Append(palindrome);
            
            for (var i = 0; i < rightAppendixLength; ++i)
            {
                input.Append(targetChar++);
            }
            
            var result = Problem5.FindLongestPalindrome(input.ToString().AsSpan());
            
            Assert.That(result.ToString(), Is.EqualTo(palindrome));
        }

        [TestCase(0, 1)]
        [TestCase(0, 2)]
        [TestCase(1, 0)]
        [TestCase(2, 0)]
        [TestCase(1, 1)]
        [TestCase(1, 2)]
        [TestCase(2, 1)]
        [TestCase(2, 2)]
        public void FindLongestPalindrome_PalindromeOfEvenLengthInTheMiddle_ReturnsPalindrome(
            int leftAppendixLength,
            int rightAppendixLength)
        {
            var targetChar = 'd';
            var input = new StringBuilder();
            for (var i = 0; i < leftAppendixLength; ++i)
            {
                input.Append(targetChar++);
            }
            
            var palindrome = "abccba";
            input.Append(palindrome);
            
            for (var i = 0; i < rightAppendixLength; ++i)
            {
                input.Append(targetChar++);
            }
            
            var result = Problem5.FindLongestPalindrome(input.ToString().AsSpan());
            
            Assert.That(result.ToString(), Is.EqualTo(palindrome));
        }
    }
}