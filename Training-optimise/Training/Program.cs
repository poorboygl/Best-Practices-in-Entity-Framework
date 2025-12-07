using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using Training.Entities;

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
        public void FetchAllAndFilterInMemory()
        {
            var allRecords = _context.SalesRecords.ToList();
            var filteredRecord = allRecords.FirstOrDefault(sr => sr.Id == 1466028);
        }

        [Benchmark]
        public void FilterAtDatabaseLevel()
        {
            var filteredRecord = _context.SalesRecords.FirstOrDefault(sr => sr.Id == 1466028);
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
