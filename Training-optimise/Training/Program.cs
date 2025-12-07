using Training.Entities;

class Program
{
    static void Main(string[] args)
    {
       SalesDbContext _context = new SalesDbContext();
        var saleRecord = GenerateSaleRecords(1500);

        //not good
        //foreach (var record in saleRecord) 
        //{
        //    _context.SalesRecords.Add(record);
        //}
        _context.SalesRecords.AddRange(saleRecord);
        _context.SaveChanges();
    }

    static List<SalesRecord> GenerateSaleRecords(int count)
    {
        int idCount = 1166361;
        var saleRecords = new List<SalesRecord>();
        for (int i = 0; i < count; i++)
        {
            saleRecords.Add(new SalesRecord
            {
                Id = idCount + 1,
                OrderDate = DateTime.UtcNow.AddDays(-1),
                TotalProfit = i * 10,
                CountryID = 1
            });
        }
        return saleRecords;
    }
}


