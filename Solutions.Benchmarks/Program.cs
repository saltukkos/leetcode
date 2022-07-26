using BenchmarkDotNet.Running;

namespace Solutions.Benchmarks
{
    public static class Program
    {
        public static void Main()
        {
            BenchmarkRunner.Run<Problem60Benchmarks>();
        }
    }
}