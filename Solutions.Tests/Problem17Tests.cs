using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Solutions.Tests
{
    [TestFixtureSource(nameof(FixtureArgs))]
    public sealed class Problem17Tests
    {
        private readonly Func<string, IList<string>> _testImplementation;

        public Problem17Tests(Func<string, IList<string>> testImplementation)
        {
            _testImplementation = testImplementation;
        }

        public static object[] FixtureArgs =
        {
            Problem17.GetLetterCombinationsRecursive,
            Problem17.GetLetterCombinationsNonRecursive
        };

        [TestCase("2", new[] {"a", "b", "c"})]
        [TestCase("3", new[] {"d", "e", "f"})]
        [TestCase("4", new[] {"g", "h", "i"})]
        [TestCase("5", new[] {"j", "k", "l"})]
        [TestCase("6", new[] {"m", "n", "o"})]
        [TestCase("7", new[] {"p", "q", "r", "s"})]
        [TestCase("8", new[] {"t", "u", "v"})]
        [TestCase("9", new[] {"w", "x", "y", "z"})]
        public void GetLetterCombinations_OneButton_AllCharsFromThatButtonAreReturned(
            string digits,
            string[] expectedResult)
        {
            var result = _testImplementation.Invoke(digits);
            Assert.That(result, Is.EquivalentTo(expectedResult));
        }

        [Test]
        public void GetLetterCombinations_ThreeButtons_AllCombinationsAreReturned()
        {
            var result = _testImplementation.Invoke("283");
            Assert.That(result, Is.EquivalentTo(new[]
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
            var result = _testImplementation.Invoke("22");
            Assert.That(result, Is.EquivalentTo(new[]
            {
                "aa", "ab", "ac",
                "ba", "bb", "bc",
                "ca", "cb", "cc",
            }));
        }
    }
}