using System.Linq;
using BenchmarkDotNet.Attributes;
using JetBrains.Annotations;

namespace Solutions.Benchmarks
{
    [UsedImplicitly]
    [MemoryDiagnoser]
    public class Problem3Benchmarks
    {
        private readonly string _tenLettersString = string.Join(null, Enumerable.Repeat("abcde", 2));
        private readonly string _fiftyLettersString = string.Join(null, Enumerable.Repeat("abcde", 10));

        [Benchmark]
        public int TenLettersBenchmark() => Problem3.LengthOfLongestSubstring(_tenLettersString);
        
        [Benchmark]
        public int FiftyLettersBenchmark() => Problem3.LengthOfLongestSubstring(_fiftyLettersString);
    }
}

// |                Method |      Mean |    Error |   StdDev | Allocated |
// |---------------------- |----------:|---------:|---------:|----------:|
// |   TenLettersBenchmark |  26.41 ns | 0.052 ns | 0.046 ns |         - |
// | FiftyLettersBenchmark | 116.69 ns | 0.086 ns | 0.081 ns |         - |
