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
        public void FetchAllFields()
        {
            var record = _context.SalesRecords                         
                             .ToList();
        }


        [Benchmark]
        public void FetchProjectedFields()
        {
         var record = _context.SalesRecords
                          .Select(sr => new
                          {
                              sr.Id,
                              sr.SalesChannel,
                              sr.OrderDate,
                              sr.TotalProfit
                          })
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
