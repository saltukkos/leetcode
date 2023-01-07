using NUnit.Framework;

namespace Solutions.Tests
{
    [TestFixture]
    public class Problem22Tests
    {
        [Test]
        public void Generate_NIsOne_OnePair()
        {
            var result = Problem22.GenerateParenthesis(1);
            Assert.That(result, Is.EquivalentTo(new[] {"()"}));
        }

        [Test]
        public void Generate_NIsTwo_TwoPairs()
        {
            var result = Problem22.GenerateParenthesis(2);
            Assert.That(result, Is.EquivalentTo(new[] {"()()", "(())"}));
        }

        [Test]
        public void Generate_NIsThree_FivePairs()
        {
            var result = Problem22.GenerateParenthesis(3);
            Assert.That(result, Is.EquivalentTo(new[] {"()()()", "()(())", "(())()", "(()())", "((()))"}));
        }
    }
}