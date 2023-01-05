using System;
using System.Collections.Generic;
using System.Text;

namespace Solutions
{
    /// <summary>
    /// Letter Combinations of a Phone Number
    /// https://leetcode.com/problems/letter-combinations-of-a-phone-number/description/
    /// </summary>
    public static partial class Problem17
    {
        public static IList<string> GetLetterCombinationsRecursive(string digits)
        {
            var result = new List<string>();
            FillSubCombinations(digits.AsSpan(), string.Empty, result);
            return result;
        }

        private static void FillSubCombinations(
            ReadOnlySpan<char> digitsToHandle,
            string currentState,
            List<string> result)
        {
            if (digitsToHandle.IsEmpty)
            {
                result.Add(currentState);
                return;
            }

            var digitNumber = digitsToHandle[0] - '2';
            var lettersForCurrentDigit = LettersOnDigit[digitNumber];
            var subDigits = digitsToHandle.Slice(1);
            foreach (var letter in lettersForCurrentDigit)
            {
                FillSubCombinations(subDigits, currentState + letter, result);
            }
        }
    }
}