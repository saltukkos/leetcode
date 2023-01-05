using NUnit.Framework;

namespace Solutions.Tests
{
    [TestFixture]
    public class Problem17Tests
    {

        [TestCase("2", new [] {"a", "b", "c"})]
        [TestCase("3", new [] {"d", "e", "f"})]
        [TestCase("4", new [] {"g", "h", "i"})]
        [TestCase("5", new [] {"j", "k", "l"})]
        [TestCase("6", new [] {"m", "n", "o"})]
        [TestCase("7", new [] {"p", "q", "r", "s"})]
        [TestCase("8", new [] {"t", "u", "v"})]
        [TestCase("9", new [] {"w", "x", "y", "z"})]
        public void GetLetterCombinations_OneButton_AllCharsFromThatButtonAreReturned(
            string digits,
            string[] expectedResult)
        {
            var result = Problem17.GetLetterCombinations(digits);
            Assert.That(result, Is.EquivalentTo(expectedResult));
        }

        [Test]
        public void GetLetterCombinations_ThreeButtons_AllCombinationsAreReturned()
        {
            var result = Problem17.GetLetterCombinations("283");
            Assert.That(result, Is.EquivalentTo(new []
            {
                "atd", "ate", "atf",
                "aud", "aue", "auf",
                "avd", "ave", "avf",
                "btd", "bte", "btf",
                "bud", "bue", "buf",
                "bvd", "bve", "bvf",
                "ctd", "cte", "ctf",
                "cud", "cue", "cuf",
                "cvd", "cve", "cvf",
            }));
        }

        [Test]
        public void GetLetterCombinations_DuplicatedButton_AllCombinationsAreReturned()
        {
            var result = Problem17.GetLetterCombinations("22");
            Assert.That(result, Is.EquivalentTo(new []
            {
                "aa", "ab", "ac",
                "ba", "bb", "bc",
                "ca", "cb", "cc",
            }));
        }
    }
}