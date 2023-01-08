using System;
using System.Linq;
using BenchmarkDotNet.Attributes;
using JetBrains.Annotations;

namespace Solutions.Benchmarks
{
    [UsedImplicitly]
    [MemoryDiagnoser]
    public class Problem23Benchmarks
    {
        private Problem23.ListNode?[] _data = Array.Empty<Problem23.ListNode>();
        
        [Params(10000, 1000000)]
        [UsedImplicitly] //TODO don't know why it doesn't have [MeansImplicitUse], make pull request?
        public int ElementsCount;
        
        [Params(true, false)]
        [UsedImplicitly]
        public bool SpreadToSquare;
        
        [IterationSetup]
        public void FillDataToMerge()
        {
            int listsLength;
            if (SpreadToSquare)
            {
                var sqrt = (int) Math.Sqrt(ElementsCount);
                _data = new Problem23.ListNode?[sqrt];
                listsLength = sqrt;
            }
            else
            {
                _data = new Problem23.ListNode?[2];
                listsLength = ElementsCount / 2;
            }
            
            for (var i = 0; i < _data.Length; ++i)
            {
                _data[i] = Problem23.ListNode.From(Enumerable.Range(i * listsLength, listsLength).ToArray());
            }
        }
        
        [Benchmark]
        public Problem23.ListNode? CascadeMergeBenchmark()
        {
            return Problem23.MergeListsCascade(_data);
        }

        [Benchmark]
        public Problem23.ListNode? LinearMergeBenchmark()
        {
            return Problem23.MergeListsLinear(_data);
        }
    }
}

// |                Method | ElementsCount | SpreadToSquare |          Mean |      Error |     StdDev | Allocated |
// |---------------------- |-------------- |--------------- |--------------:|-----------:|-----------:|----------:|
// | CascadeMergeBenchmark |         10000 |          False |      21.75 us |   0.117 us |   0.091 us |     672 B |
// |  LinearMergeBenchmark |         10000 |          False |      79.30 us |   0.193 us |   0.151 us |     672 B |
// | CascadeMergeBenchmark |         10000 |           True |     146.30 us |   2.799 us |   2.618 us |     672 B |
// |  LinearMergeBenchmark |         10000 |           True |     794.46 us |   9.525 us |   7.954 us |     672 B |
// | CascadeMergeBenchmark |       1000000 |          False |   2,111.44 us |  39.936 us |  35.402 us |     672 B |
// |  LinearMergeBenchmark |       1000000 |          False |   7,824.08 us |  38.066 us |  33.744 us |     672 B |
// | CascadeMergeBenchmark |       1000000 |           True |  22,025.55 us | 220.083 us | 195.098 us |     672 B |
// |  LinearMergeBenchmark |       1000000 |           True | 673,502.64 us | 730.434 us | 647.511 us |     672 B |
