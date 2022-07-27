using System;

namespace Solutions
{
    /// <summary>
    /// Permutation Sequence
    /// https://leetcode.com/problems/permutation-sequence/
    /// Solve it with O(n^2) complexity, which is almost constant in this case.
    /// </summary>
    public static class Problem60
    {
        public static string GetPermutation(int length, int index)
        {
            Span<char> result = stackalloc char[length];
            Span<bool> usedDigits = stackalloc bool[length];

            index -= 1;
            var currentDigitPermutationsSpan = Factorial(length);
            for (var digitPosition = 0; digitPosition < length; digitPosition++)
            {
                currentDigitPermutationsSpan /= length - digitPosition;
                var digitSequenceNumber = index / currentDigitPermutationsSpan;
                index %= currentDigitPermutationsSpan;

                var digit = GetNonUsedDigitBySequenceNumber(usedDigits, digitSequenceNumber);
                result[digitPosition] = (char) ('1' + digit);
            }

            return new string(result);
        }

        private static int GetNonUsedDigitBySequenceNumber(Span<bool> usedDigits, int digitSequenceNumber)
        {
            for (var i = 0; i < usedDigits.Length; i++)
            {
                if (usedDigits[i])
                {
                    continue;
                }

                if (digitSequenceNumber == 0)
                {
                    usedDigits[i] = true;
                    return i;
                }

                digitSequenceNumber--;
            }

            return -1;
        }

        private static int Factorial(int n)
        {
            var result = n;
            for (var i = n - 1; i > 1; --i)
            {
                result *= i;
            }

            return result;
        }
    }
}