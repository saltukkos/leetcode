using System;
using System.Collections.Generic;

namespace Solutions
{
    /// <summary>
    /// 3Sum
    /// https://leetcode.com/problems/3sum/description/
    /// Solve with O(n^2) time complexity and with no additional memory allactions except for the answer
    /// </summary>
    public static class Problem15
    {
        public static IList<IList<int>> FindThreeSum(int[] numbers)
        {
            Array.Sort(numbers);

            var result = new List<IList<int>>();
            for (var firstNumberIndex = 0; firstNumberIndex < numbers.Length - 2;)
            {
                var firstNumber = numbers[firstNumberIndex];
                var leftIndex = firstNumberIndex + 1;
                var rightIndex = numbers.Length - 1;

                FindCorrespondingPair(numbers, firstNumber, leftIndex, rightIndex, result);
                firstNumberIndex = MoveIndexRightWhileDataTheSame(numbers, firstNumberIndex, firstNumber);
            }

            return result;
        }

        private static void FindCorrespondingPair(
            int[] numbers, int firstNumber, int leftIndex, int rightIndex, List<IList<int>> result)
        {
            var targetSum = -firstNumber;

            while (leftIndex < rightIndex)
            {
                var leftNumber = numbers[leftIndex];
                var rightNumber = numbers[rightIndex];
                var sum = leftNumber + rightNumber;

                if (sum < targetSum)
                {
                    leftIndex = MoveIndexRightWhileDataTheSame(numbers, leftIndex, leftNumber);
                }
                else if (sum > targetSum)
                {
                    rightIndex = MoveIndexLeftWhileDataTheSame(numbers, rightIndex, rightNumber);
                }
                else
                {
                    result.Add(new[] {firstNumber, leftNumber, rightNumber});
                    leftIndex = MoveIndexRightWhileDataTheSame(numbers, leftIndex, leftNumber);
                    rightIndex = MoveIndexLeftWhileDataTheSame(numbers, rightIndex, rightNumber);
                }
            }
        }

        private static int MoveIndexLeftWhileDataTheSame(int[] numbers, int index, int data)
        {
            do
            {
                index--;
            } while (index >= 0 && numbers[index] == data);

            return index;
        }

        private static int MoveIndexRightWhileDataTheSame(int[] numbers, int index, int data)
        {
            do
            {
                index++;
            } while (index < numbers.Length && numbers[index] == data);

            return index;
        }
    }
}