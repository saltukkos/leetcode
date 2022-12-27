using System;

namespace Solutions
{
    /// <summary>
    /// Longest Palindromic Substring
    /// https://leetcode.com/problems/longest-palindromic-substring/description/
    /// Solve with O(n^2) time complexity and with no heap allocations
    /// </summary>
    public static class Problem5
    {
        public static ReadOnlySpan<char> FindLongestPalindrome(ReadOnlySpan<char> text)
        {
            var longestPalindromeStart = 0;
            var longestPalindromeLength = 1;
            var centerPositionsCount = (text.Length - 2) * 2 + 1;
            for (var currentPosition = 1; currentPosition <= centerPositionsCount; ++currentPosition)
            {
                var leftPartStartingIndex = (currentPosition - 1) / 2;
                var rightPartStartingIndex = currentPosition / 2 + 1;
                var maxPalindromeDepth = Math.Min(leftPartStartingIndex + 1, text.Length - rightPartStartingIndex);
                for (var depth = 0; depth < maxPalindromeDepth; ++depth)
                {
                    var leftIndex = leftPartStartingIndex - depth;
                    var rightIndex = rightPartStartingIndex + depth;
                    if (text[leftIndex] != text[rightIndex])
                    {
                        break;
                    }

                    var currentLength = rightIndex - leftIndex + 1;
                    if (currentLength > longestPalindromeLength)
                    {
                        longestPalindromeLength = currentLength;
                        longestPalindromeStart = leftIndex;
                    }
                }
                
            }
            
            //We know that the length is at least 1, in other case we will throw
            return text.Slice(longestPalindromeStart, longestPalindromeLength);
        }
    }
}