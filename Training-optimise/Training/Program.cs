using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using Microsoft.EntityFrameworkCore;

namespace Training.Benchmarks
{
    [ShortRunJob]
    [MemoryDiagnoser]
    public class AsyncVsSyncBenchmark
    {
        private SalesDbContext _context;

        [GlobalSetup]
        public void Setup()
        {
            _context = new SalesDbContext();
        }


        [Benchmark]
        public void FetchDataSync()
        {
            var sales = _context.SalesRecords
                                .Sum(sr => sr.TotalProfit);
        }

        [Benchmark]
        public void FetchDataAsync()
        {
            var sales = _context.SalesRecords
                                .SumAsync(sr => sr.TotalProfit);
        }

        [GlobalCleanup]
        public void Cleanup()
        {
            _context.Dispose();
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            BenchmarkRunner.Run<AsyncVsSyncBenchmark>();
        }
    }
}
