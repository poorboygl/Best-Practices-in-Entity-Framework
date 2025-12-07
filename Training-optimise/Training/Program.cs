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


        [Benchmark]
        public void QueryWithTracking()
        {
            using var context = new SalesDbContext();
            var records = context.SalesRecords.ToList();
        }

        [Benchmark]
        public void QueryWithoutTracking()
        {
            using var context = new SalesDbContext();
            var records = context.SalesRecords.AsNoTracking().ToList();
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
