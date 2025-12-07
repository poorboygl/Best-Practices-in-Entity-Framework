using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

public class Program
{
    public static async Task Main(string[] args)
    {
        using var context = new SalesDbContext();

        try 
        {
            var insertCommand = @"select pg_sleep(10); Insert INTO public. ""Regions"" (""id"", ""Name"") Values (65, 'New Region')";
            await context.Database.ExecuteSqlRawAsync(insertCommand);
        }
        catch(Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
