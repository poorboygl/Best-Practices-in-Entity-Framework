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
        public void LoadSalesRecordsNPlusOne()
        {
            using var context = new SalesDbContext();

            var countries = context.Countries.ToList();

            foreach (var country in countries)
            {
                var saleRecords = context.SalesRecords
                                          .Where(sr => sr.CountryID == country.ID)
                                          .ToList();
                country.SalesRecords = saleRecords;
            }
      
        }

        [Benchmark]
        public void LoadSalesRecordsWithInClude()
        {
            using var context = new SalesDbContext();
            var CountryWithSaleRecords = context.Countries
                                         .Include(c => c.SalesRecords)
                                         .ToList();
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
