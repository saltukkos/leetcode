using System;

namespace Solutions
{
    /// <summary>
    /// 3Sum Closest
    /// https://leetcode.com/problems/3sum-closest/description/
    /// Solve with O(n^2) time complexity and with no memory allactions
    /// </summary>
    public static class Problem16
    {
        public static int FindThreeSumClosest(int[] numbers, int target)
        {
            Array.Sort(numbers);

            var closestSumToTarget = int.MaxValue;
            var smallestDiff = int.MaxValue;
            for (var firstNumberIndex = 0; firstNumberIndex < numbers.Length - 2;)
            {
                var firstNumber = numbers[firstNumberIndex];
                var leftIndex = firstNumberIndex + 1;
                var rightIndex = numbers.Length - 1;

                var targetTwoSum = target - firstNumber;
                var twoSum = FindClosestPair(numbers, targetTwoSum, leftIndex, rightIndex);
                if (twoSum == targetTwoSum)
                {
                    return target;
                }

                var diff = Math.Abs(twoSum - targetTwoSum);
                if (diff < smallestDiff)
                {
                    smallestDiff = diff;
                    closestSumToTarget = firstNumber + twoSum;
                }

                firstNumberIndex = MoveIndexRightWhileDataTheSame(numbers, firstNumberIndex, targetTwoSum);
            }

            return closestSumToTarget;
        }

        private static int FindClosestPair(int[] numbers, int targetSum, int leftIndex, int rightIndex)
        {
            var closestPairSum = int.MaxValue;
            var smallestDiff = int.MaxValue;
            while (leftIndex < rightIndex)
            {
                var leftNumber = numbers[leftIndex];
                var rightNumber = numbers[rightIndex];
                var sum = leftNumber + rightNumber;

                var diff = sum - targetSum;
                if (diff < 0)
                {
                    leftIndex = MoveIndexRightWhileDataTheSame(numbers, leftIndex, leftNumber);
                    if (-diff < smallestDiff)
                    {
                        smallestDiff = -diff;
                        closestPairSum = sum;
                    }
                }
                else if (diff > 0)
                {
                    rightIndex = MoveIndexLeftWhileDataTheSame(numbers, rightIndex, rightNumber);
                    if (diff < smallestDiff)
                    {
                        smallestDiff = diff;
                        closestPairSum = sum;
                    }
                }
                else
                {
                    return sum;
                }
            }

            return closestPairSum;
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