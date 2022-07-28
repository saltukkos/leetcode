using System;

namespace Solutions
{
    /// <summary>
    /// Longest Substring Without Repeating Characters
    /// https://leetcode.com/problems/longest-substring-without-repeating-characters/
    /// Solve with O(n) time complexety and with O(1) memory usage with no heap allocations.
    /// </summary>
    public static class Problem3
    {
        public static int LengthOfLongestSubstring(string targetString)
        {
            Span<bool> usedCharacters = stackalloc bool[128]; // we know that characters are from ASCII-table
            var firstLetterIndex = 0;
            var lastLetterIndex = 0;
            var maxLength = 0;
            
            while (lastLetterIndex < targetString.Length)
            {
                var currentChar = targetString[lastLetterIndex];
                if (usedCharacters[currentChar])
                {
                    char removedChar;
                    do
                    {
                        removedChar = targetString[firstLetterIndex];
                        usedCharacters[removedChar] = false;
                        firstLetterIndex++;
                    } while (removedChar != currentChar);
                }
                
                usedCharacters[currentChar] = true;
                
                lastLetterIndex++;
                maxLength = Math.Max(maxLength, lastLetterIndex - firstLetterIndex);
            }

            return maxLength;
        }
    }
}