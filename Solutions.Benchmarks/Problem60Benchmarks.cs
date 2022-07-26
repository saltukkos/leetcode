using BenchmarkDotNet.Attributes;
using JetBrains.Annotations;

namespace Solutions.Benchmarks
{
    [UsedImplicitly]
    [MemoryDiagnoser]
    public class Problem60Benchmarks
    {
        [Benchmark]
        public string GetPermutationBenchmark() => Problem60.GetPermutation(9, 500);
    }
}

// |                  Method |     Mean |    Error |   StdDev |  Gen 0 | Allocated |
// |------------------------ |---------:|---------:|---------:|-------:|----------:|
// | GetPermutationBenchmark | 65.16 ns | 0.244 ns | 0.228 ns | 0.0191 |      40 B |

//The only allocation (40 B) is for return string, which is forced by the leetCode API