using System;
using System.Diagnostics;

namespace Solutions
{
    /// <summary>
    /// Median of Two Sorted Arrays
    /// https://leetcode.com/problems/median-of-two-sorted-arrays/
    /// Solve with O(log(min(m, n))) time complexety
    /// </summary>
    public static class Problem4
    {
        public static double FindMedianOfSortedArrays(int[] nums1, int[] nums2)
        {
            int[] shortArray;
            int[] longArray;

            if (nums1.Length < nums2.Length)
            {
                shortArray = nums1;
                longArray = nums2;
            }
            else
            {
                shortArray = nums2;
                longArray = nums1;
            }

            if (shortArray.Length == 0)
            {
                return (longArray[longArray.Length / 2] + longArray[(longArray.Length - 1) / 2]) / 2.0;
            }

            return FindMedian(shortArray, longArray);
        }

        private static double FindMedian(int[] shortArray, int[] longArray)
        {
            var targetSegmentLength = shortArray.Length + longArray.Length;
            var shortArraySegmentStart = 0;
            var shortArraySegmentEnd = shortArray.Length * 2;
            
            while (shortArraySegmentStart <= shortArraySegmentEnd)
            {
                var shortArrayBorderCandidate = shortArraySegmentStart + (shortArraySegmentEnd - shortArraySegmentStart) / 2;
                var longArrayBorderCandidate = targetSegmentLength - shortArrayBorderCandidate;

                var (shortArrayItemBeforeBorder, shortArrayItemAfterBorder) =
                    SafeGetBorderValues(shortArray, shortArrayBorderCandidate);
                var (longArrayItemBeforeBorder, longArrayItemAfterBorder) =
                    SafeGetBorderValues(longArray, longArrayBorderCandidate);

                if (shortArrayItemBeforeBorder > longArrayItemAfterBorder)
                {
                    shortArraySegmentEnd = shortArrayBorderCandidate - 1;
                }
                else if (longArrayItemBeforeBorder > shortArrayItemAfterBorder)
                {
                    shortArraySegmentStart = shortArrayBorderCandidate + 1;
                }
                else
                {
                    var leftBorder = Math.Max(shortArrayItemBeforeBorder, longArrayItemBeforeBorder);
                    var rightBorder = Math.Min(shortArrayItemAfterBorder, longArrayItemAfterBorder);
                    return (leftBorder + rightBorder) / 2.0;
                }
            }

            Debug.Fail("Bound was not found! Are arrays not sorted?");
            return 0;
        }

        private static (int BeforeBorder, int AfterBorder) SafeGetBorderValues(int[] array, int index)
        {
            if (index == 0)
            {
                return (int.MinValue, array[0]);
            }

            if (index == array.Length * 2)
            {
                return (array[^1], int.MaxValue);
            }

            return (array[(index - 1) / 2], array[index / 2]);
        }
    }
}