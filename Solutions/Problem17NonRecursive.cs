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
        public static IList<string> GetLetterCombinationsNonRecursive(string digits)
        {
            var result = new List<string>();

            var buttonLetters = SelectLettersForButtons(digits);
            Span<int> currentPosition = stackalloc int[digits.Length];
            do
            {
                result.Add(GetLettersAccordingToPositions(buttonLetters, currentPosition));
            } while (TryIncrementCurrentPosition(buttonLetters, currentPosition));

            return result;
        }

        private static Span<string> SelectLettersForButtons(string digits)
        {
            var result = new string[digits.Length];
            for (var index = 0; index < digits.Length; index++)
            {
                var buttonNumber = digits[index];
                var letters = LettersOnDigit[buttonNumber - '2'];
                result[index] = letters;
            }

            return result;
        }

        private static string GetLettersAccordingToPositions(
            ReadOnlySpan<string> buttonLetters,
            ReadOnlySpan<int> currentPosition)
        {
            var stringBuilder = new StringBuilder(currentPosition.Length);
            for (var i = 0; i < currentPosition.Length; ++i)
            {
                var letterInGroupNumber = currentPosition[i];
                stringBuilder.Append(buttonLetters[i][letterInGroupNumber]);
            }

            return stringBuilder.ToString();
        }

        private static bool TryIncrementCurrentPosition(ReadOnlySpan<string> buttonLetters, Span<int> currentPosition)
        {
            for (var i = currentPosition.Length - 1; i >= 0; --i)
            {
                var lettersLength = buttonLetters[i];
                ref var position = ref currentPosition[i];
                if (position < lettersLength.Length - 1)
                {
                    position++;
                    return true;
                }

                position = 0;
            }

            return false;
        }
    }
}