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
        public void FetchDataWithIndex()
        {
         var recentSales = _context.SalesRecords
                          .Where(sr => sr.OrderDate < DateTime.UtcNow.AddYears(-3))
                          .ToList();
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
