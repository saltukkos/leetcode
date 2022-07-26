using NUnit.Framework;

namespace Solutions.Tests
{
    [TestFixture]
    public class Problem60Tests
    {
        [TestCase(3, 3, "213")]
        [TestCase(4, 9, "2314")]
        [TestCase(3, 1, "123")]
        public void GetPermutation_InputsFromLeetCode_OutputMatchesLeetCode(int n, int k, string expectedResult)
        {
            var result = Problem60.GetPermutation(n, k);
            Assert.That(result, Is.EqualTo(expectedResult));
        }
    }
}