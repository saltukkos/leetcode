using BenchmarkDotNet.Attributes;
using JetBrains.Annotations;

namespace Solutions.Benchmarks
{
    [UsedImplicitly]
    [MemoryDiagnoser]
    public class Problem17Benchmarks
    {
        [Benchmark]
        public object GetLetterCombinationsRecursiveTwoDigits() =>
            Problem17.GetLetterCombinationsRecursive("23");

        [Benchmark]
        public object GetLetterCombinationsRecursiveFourDigits() => 
            Problem17.GetLetterCombinationsRecursive("2345");

        [Benchmark]
        public object GetLetterCombinationsNonRecursiveTwoDigits() => 
            Problem17.GetLetterCombinationsNonRecursive("23");

        [Benchmark]
        public object GetLetterCombinationsNonRecursiveFourDigits() =>
            Problem17.GetLetterCombinationsNonRecursive("2345");
    }
}

// |                                      Method |       Mean |    Error |   StdDev |  Gen 0 | Allocated |
// |-------------------------------------------- |-----------:|---------:|---------:|-------:|----------:|
// |     GetLetterCombinationsRecursiveTwoDigits |   492.3 ns |  0.93 ns |  0.87 ns | 0.4320 |     904 B |
// |    GetLetterCombinationsRecursiveFourDigits | 4,260.0 ns | 15.20 ns | 14.22 ns | 4.2114 |   8,816 B |
// |  GetLetterCombinationsNonRecursiveTwoDigits |   671.8 ns |  1.24 ns |  1.16 ns | 0.6580 |   1,376 B |
// | GetLetterCombinationsNonRecursiveFourDigits | 5,395.5 ns |  9.33 ns |  8.27 ns | 5.4092 |  11,320 B |
