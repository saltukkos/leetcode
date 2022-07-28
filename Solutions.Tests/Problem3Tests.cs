using NUnit.Framework;

namespace Solutions.Tests
{
    [TestFixture]
    public class Problem3Tests
    {
        [TestCase("abcabcbb", 3)]
        [TestCase("bbbbb", 1)]
        [TestCase("pwwkew", 3)]
        public void LengthOfLongestSubstring_InputsFromLeetCode_OutputMatchesLeetCode(string input, int expectedOutput)
        {
            var result = Problem3.LengthOfLongestSubstring(input);
            Assert.That(result, Is.EqualTo(expectedOutput));
        }
    }
}