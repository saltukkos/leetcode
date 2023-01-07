using System;

namespace Solutions
{
    /// <summary>
    /// Container With Most Water
    /// https://leetcode.com/problems/container-with-most-water/description/
    /// Solve with O(N) complexity without additional memory usage
    /// </summary>
    public static class Problem11
    {
        public static int FindMaxArea(int[] height)
        {
            var leftIndex = 0;
            var rightIndex = height.Length - 1;
            var maxArea = 0;
            while (leftIndex < rightIndex)
            {
                var leftHeight = height[leftIndex];
                var rightHeight = height[rightIndex];
                var area = (rightIndex - leftIndex) * Math.Min(leftHeight, rightHeight);
                maxArea = Math.Max(maxArea, area);

                if (leftHeight < rightHeight)
                {
                    ++leftIndex;
                }
                else
                {
                    --rightIndex;
                }
            }

            return maxArea;
        }
    }
}