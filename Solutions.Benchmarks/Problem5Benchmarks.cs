using System;
using System.Linq;
using BenchmarkDotNet.Attributes;
using JetBrains.Annotations;

namespace Solutions.Benchmarks
{
    [UsedImplicitly]
    [MemoryDiagnoser]
    public class Problem5Benchmarks
    {
        private readonly string _tenLettersOptimalString = string.Join(null, Enumerable.Repeat("abcde", 2));
        private readonly string _fiftyLettersOptimalString = string.Join(null, Enumerable.Repeat("abcde", 10));
        private readonly string _tenLettersWorstString = string.Join(null, Enumerable.Repeat("aaaaa", 2));
        private readonly string _fiftyLettersWorstString = string.Join(null, Enumerable.Repeat("aaaaa", 10));

        [Benchmark]
        public ReadOnlySpan<char> TenLettersOptimalBenchmark() => 
            Problem5.FindLongestPalindrome(_tenLettersOptimalString.AsSpan());
        
        [Benchmark]
        public ReadOnlySpan<char> FiftyLettersOptimalBenchmark() =>
            Problem5.FindLongestPalindrome(_fiftyLettersOptimalString.AsSpan());
        
        [Benchmark]
        public ReadOnlySpan<char> TenLettersWorstBenchmark() => 
            Problem5.FindLongestPalindrome(_tenLettersWorstString.AsSpan());
        
        [Benchmark]
        public ReadOnlySpan<char> FiftyLettersWorstBenchmark() =>
            Problem5.FindLongestPalindrome(_fiftyLettersWorstString.AsSpan());
    }
}

// |                       Method |        Mean |    Error |   StdDev | Allocated |
// |----------------------------- |------------:|---------:|---------:|----------:|
// |   TenLettersOptimalBenchmark |    34.02 ns | 0.089 ns | 0.079 ns |         - |
// | FiftyLettersOptimalBenchmark |   172.28 ns | 0.358 ns | 0.334 ns |         - |
// |     TenLettersWorstBenchmark |    62.42 ns | 0.132 ns | 0.123 ns |         - |
// |   FiftyLettersWorstBenchmark | 1,350.14 ns | 2.277 ns | 2.019 ns |         - |


