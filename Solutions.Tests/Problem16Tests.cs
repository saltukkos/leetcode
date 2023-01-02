using System.Linq;
using NUnit.Framework;

namespace Solutions.Tests
{
    [TestFixture]
    public class Problem16Tests
    {
        [TestCase(3)]
        [TestCase(4)]
        [TestCase(5)]
        public void FindThreeSumClosest_AllZeroesButSearchForOne_ResultIsZero(int length)
        {
            var input = Enumerable.Repeat(0, length).ToArray();
            var result = Problem16.FindThreeSumClosest(input, 1);
            
            Assert.That(result, Is.EqualTo(0));
        }

        [Test]
        public void FindThreeSumClosest_ExactMatch_ReturnsIt()
        {
            var input = new[] {-3, 5, 4, 0, 3, -10, 100};
            var result = Problem16.FindThreeSumClosest(input, 4);

            Assert.That(result, Is.EqualTo(4));
        }

        [Test]
        public void FindThreeSumClosest_ClosestIsBiggerThatTarget_ReturnsClosest()
        {
            var input = new[] {-3, 5, 4, 20, 1, -10, 100};
            var result = Problem16.FindThreeSumClosest(input, 5);

            Assert.That(result, Is.EqualTo(6));
        }

        [Test]
        public void FindThreeSumClosest_ClosestIsSmallerThatTarget_ReturnsClosest()
        {
            var input = new[] {-3, 6, 4, 20, 1, -10, 100};
            var result = Problem16.FindThreeSumClosest(input, 5);

            Assert.That(result, Is.EqualTo(4));
        }
    }
}