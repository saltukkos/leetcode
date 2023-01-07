using NUnit.Framework;

namespace Solutions.Tests
{
    [TestFixture]
    public class Problem11Tests
    {
        [Test]
        public void FindMaxArea_DataFromLeetCodeCase1_ResultIsSame()
        {
            var input = new[] {1, 8, 6, 2, 5, 4, 8, 3, 7};
            var result = Problem11.FindMaxArea(input);
            Assert.That(result, Is.EqualTo(49));
        }
        
        [Test]
        public void FindMaxArea_DataFromLeetCodeCase2_ResultIsSame()
        {
            var input = new[] {1, 1};
            var result = Problem11.FindMaxArea(input);
            Assert.That(result, Is.EqualTo(1));
        }
    }
}