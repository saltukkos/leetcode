using System.Linq;
using NUnit.Framework;

namespace Solutions.Tests
{
    [TestFixture]
    public class Problem15Tests
    {
        [TestCase(3)]
        [TestCase(4)]
        [TestCase(5)]
        public void FindThreeSum_AllZeroes_OneZeroResult(int length)
        {
            var input = Enumerable.Repeat(0, length).ToArray();
            var result = Problem15.FindThreeSum(input);
            
            Assert.That(result.Count, Is.EqualTo(1));
            Assert.That(result[0], Is.EquivalentTo(new[] {0, 0, 0}));
        }

        [TestCase(0)]
        [TestCase(1)]
        [TestCase(2)]
        public void FindThreeSum_NotEnoughElements_ReturnEmptyList(int length)
        {
            var input = Enumerable.Repeat(0, length).ToArray();
            var result = Problem15.FindThreeSum(input);
            
            Assert.That(result, Is.Empty);
        }

        [Test]
        public void FindThreeSum_ContainsSymmetricalPair_ReturnsTriplet()
        {
            var input = new[] {-3, 5, 4, 0, 3, -10, 100};
            var result = Problem15.FindThreeSum(input);

            Assert.That(result.Count, Is.EqualTo(1));
            Assert.That(result[0], Is.EquivalentTo(new [] {-3, 0, 3}));
        }

        [Test]
        public void FindThreeSum_ContainsAsymmetricalPair_ReturnsTriplet()
        {
            var input = new[] {-3, 5, 4, 0, 2, 1, -10, 100};
            var result = Problem15.FindThreeSum(input);

            Assert.That(result.Count, Is.EqualTo(1));
            Assert.That(result[0], Is.EquivalentTo(new [] {-3, 2, 1}));
        }

        [Test]
        public void FindThreeSum_ContainsTwoPairs_ReturnsTriplet()
        {
            var input = new[] {-3, 5, 4, 0, 2, 1, 3, -10, 100};
            var result = Problem15.FindThreeSum(input);

            Assert.That(result.Count, Is.EqualTo(2));
            Assert.That(result, Has.One.EquivalentTo(new [] {-3, 0, 3}));
            Assert.That(result, Has.One.EquivalentTo(new [] {-3, 2, 1}));
        }
    }
}